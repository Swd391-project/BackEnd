using SWD.BBMS.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Repositories.Interfaces
{
    public interface IFeedbackRepository
    {
        Task<PagedList<Feedback>> GetFeedbacks(int id, int pageNumber, int pageSize);

        Task<Feedback?> GetFeedbackById(int id);

        Task<bool> SaveFeedback(Feedback feedback);

        Task<bool> UpdateFeedback(Feedback feedback);

        Task<bool> DeleteFeedback(int id);
    }
}
