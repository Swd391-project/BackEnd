using SWD.BBMS.Repositories;
using SWD.BBMS.Services.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.Interfaces
{
    public interface IFeedbackService
    {
        Task<PagedList<FeedbackModel>> GetFeedbacks(int id, int pageNumber, int pageSize);

        Task<FeedbackModel> GetFeedbackById(int id);

        Task<bool> SaveFeedback(FeedbackModel feedbackModel);

        Task<bool> UpdateFeedback(int id, Dictionary<string, object> serviceModel);

        Task<bool> DeleteFeedback(int id);
    }
}
