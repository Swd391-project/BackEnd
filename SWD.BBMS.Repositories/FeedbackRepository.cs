using Microsoft.EntityFrameworkCore;
using SWD.BBMS.Repositories.Data;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        public Task<bool> DeleteFeedback(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Feedback?> GetFeedbackById(int id)
        {
            using var dbContext = new BBMSDbContext();
            return await dbContext.Feedbacks.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<PagedList<Feedback>> GetFeedbacks(int id, int pageNumber, int pageSize)
        {
            try
            {
                using var dbContext = new BBMSDbContext();
                var feedbacks = await PagedList<Feedback>
                    .ToPagedList(dbContext.Feedbacks.Where(s => s.CourtGroupId == id), pageNumber, pageSize);
                return feedbacks;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> SaveFeedback(Feedback feedback)
        {
            var result = false;
            try
            {
                using var dbContext = new BBMSDbContext();
                await dbContext.Feedbacks.AddAsync(feedback);
                await dbContext.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public async Task<bool> UpdateFeedback(Feedback feedback)
        {
            var result = false;
            try
            {
                using var dbContext = new BBMSDbContext();
                dbContext.Attach(feedback).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
