using AutoMapper;
using SWD.BBMS.Repositories;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Repositories.Interfaces;
using SWD.BBMS.Services.BusinessModels;
using SWD.BBMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SWD.BBMS.Services
{
    public class FeedbackService : IFeedbackService
    {

        private readonly IFeedbackRepository feedbackRepository;

        private readonly IMapper mapper;

        public FeedbackService(IMapper mapper, IFeedbackRepository feedbackRepository)
        {
            this.mapper = mapper;
            this.feedbackRepository = feedbackRepository;
        }

        public async Task<bool> DeleteFeedback(int id)
        {
            var result = false;
            try
            {
                var feedback = await feedbackRepository.GetFeedbackById(id);
                feedback.IsDeleted = true;
                result = await feedbackRepository.UpdateFeedback(feedback);
            }
            catch
            {
                throw;
            }
            return result;
        }

        public async Task<FeedbackModel> GetFeedbackById(int id)
        {
            try
            {
                var feedback = await feedbackRepository.GetFeedbackById(id);
                var feedbackModel = mapper.Map<FeedbackModel>(feedback);
                return feedbackModel;
            }
            catch
            {
                throw;
            }
        }

        public async Task<PagedList<FeedbackModel>> GetFeedbacks(int id, int pageNumber, int pageSize)
        {
            try
            {
                var feedbacks = await feedbackRepository.GetFeedbacks(id, pageNumber, pageSize);
                var feedbackModels = mapper.Map<PagedList<FeedbackModel>>(feedbacks);
                return new PagedList<FeedbackModel>(feedbackModels, feedbacks.TotalCount, feedbacks.CurrentPage, feedbacks.PageSize);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> SaveFeedback(FeedbackModel feedbackModel)
        {
            var result = false;
            try
            {
                var feedback = mapper.Map<Feedback>(feedbackModel);
                feedback.IsDeleted = false;
                feedback.CreatedDate = DateTime.UtcNow;
                feedback.ModifiedDate = DateTime.UtcNow;
                result = await feedbackRepository.SaveFeedback(feedback);
            }
            catch
            {
                throw;
            }
            return result;
        }

        public async Task<bool> UpdateFeedback(int id, Dictionary<string, object> serviceModel)
        {
            var result = false;
            try
            {
                var feedback = await feedbackRepository.GetFeedbackById(id);
                if (feedback == null)
                {
                    throw new Exception("There is no feedback with id: " + id);
                }
                var model = mapper.Map<FeedbackModel>(feedback);
                foreach (var dict in serviceModel)
                {
                    SetPropertyValueFromDictionary(model, dict);
                }
                feedback = mapper.Map<Feedback>(model);
                result = await feedbackRepository.UpdateFeedback(feedback);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        private void SetPropertyValueFromDictionary(FeedbackModel user, KeyValuePair<string, object> dict)
        {
            var property = user.GetType().GetProperty(dict.Key);
            if (property != null && property.CanWrite)
            {
                var propertyType = property.PropertyType;

                object value;

                if (dict.Value == null || dict.Value.Equals(""))
                {
                    return;
                }
                else if (propertyType.IsAssignableFrom(dict.Value.GetType()))
                {
                    value = dict.Value; // No conversion needed
                }
                else if (propertyType.IsEnum)
                {
                    // Handle enum conversion
                    value = Enum.Parse(propertyType, dict.Value.ToString());
                }
                else if (propertyType == typeof(Guid))
                {
                    // Handle Guid conversion
                    value = Guid.Parse(dict.Value.ToString());
                }
                else
                {
                    // Use JSON serialization/deserialization for complex types
                    var json = JsonSerializer.Serialize(dict.Value);
                    value = JsonSerializer.Deserialize(json, propertyType);
                    if (value == null || value.Equals(""))
                    {
                        return;
                    }
                }

                // Set the property value
                property.SetValue(user, value);
            }
        }
    }
}
