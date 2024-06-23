using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository serviceRepository;

        private readonly IMapper mapper;

        public ServiceService(IServiceRepository serviceRepository, IMapper mapper)
        {
            this.serviceRepository = serviceRepository;
            this.mapper = mapper;
        }

        public async Task<bool> DeleteService(int id)
        {
            var result = false;
            try
            {
                var service = await serviceRepository.GetServiceById(id);
                service.IsDeleted = true;
                result = await serviceRepository.UpdateService(service);
            }
            catch
            {
                throw;
            }
            return result;
        }

        public async Task<ServiceModel> GetServiceById(int id)
        {
            try
            {
                var service = await serviceRepository.GetServiceById(id);
                var serviceModel = mapper.Map<ServiceModel>(service);
                return serviceModel;
            }
            catch
            {
                throw;
            }
        }

        public async Task<PagedList<ServiceModel>> GetServices(int id, int pageNumber, int pageSize)
        {
            try
            {
                var services = await serviceRepository.GetServices(id, pageNumber, pageSize);
                var serviceModels = mapper.Map<PagedList<ServiceModel>>(services);
                return new PagedList<ServiceModel>(serviceModels, services.TotalCount, services.CurrentPage, services.PageSize);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> SaveService(ServiceModel serviceModel)
        {
            var result = false;
            try
            {
                var service = mapper.Map<Service>(serviceModel);
                service.IsDeleted = false;
                service.CreatedDate = DateTime.UtcNow;
                service.ModifiedDate = DateTime.UtcNow;
                result = await serviceRepository.SaveService(service);
            }
            catch
            {
                throw;
            }
            return result;
        }

        public async Task<bool> UpdateService(int id, Dictionary<string, object> serviceModel)
        {
            var result = false;
            try
            {
                var user = await serviceRepository.GetServiceById(id);
                var model = mapper.Map<ServiceModel>(user);
                if (user == null)
                {
                    return false;
                    throw new Exception("There is no service with id: " + id);
                }
                foreach (var dict in serviceModel)
                {
                    SetPropertyValueFromDictionary(model, dict);
                }
                user = mapper.Map<Service>(model);
                result = await serviceRepository.UpdateService(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        private void SetPropertyValueFromDictionary(ServiceModel user, KeyValuePair<string, object> dict)
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
