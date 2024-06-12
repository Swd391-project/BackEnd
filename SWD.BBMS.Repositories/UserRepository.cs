

using Microsoft.EntityFrameworkCore;
using SWD.BBMS.Repositories.Data;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Repositories.Interfaces;

namespace SWD.BBMS.Repositories
{
    public class UserRepository : IUserRepository
    {

        public void CreateUser(User user)
        {
            try
            {
                using var dbContext = new BBMSDbContext();
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ExistsByEmail(string email)
        {
            try
            {
                using var dbContext = new BBMSDbContext();
                var result = dbContext.Users.Any(u => u.Email.Equals(email));
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ExistsById(string id)
        {
            try
            {
                using var dbContext = new BBMSDbContext();
                var result = await dbContext.Users.AnyAsync(u => u.Id.Equals(id));
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ExistsByPhoneNumber(string phoneNumber)
        {
            try
            {
                using var dbContext = new BBMSDbContext();
                var result = dbContext.Users.Any(u => u.PhoneNumber.Equals(phoneNumber));
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ExistsByUserName(string userName)
        {
            try
            {
                using var dbContext = new BBMSDbContext();
                var result = await dbContext.Users.AnyAsync(u => u.UserName.Equals(userName));
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User>? GetUserById(string id)
        {
            try
            {
                using var dbContext = new BBMSDbContext();
                return await dbContext.Users.FirstOrDefaultAsync(u => u.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User GetUserByUsername(string username)
        {
            using var dbContext = new BBMSDbContext();
            return dbContext.Users.FirstOrDefault(u => u.UserName.Equals(username));
        }

        public async Task<PagedList<User>> GetUsers(int pageNumber, int pageSize)
        {
            var users = new PagedList<User>();
            try
            {
                using var dbContext = new BBMSDbContext();
                users = await PagedList<User>.ToPagedList(dbContext.Users.OrderBy(u => u.FullName), pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return users;
        }

        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                using var dbContext = new BBMSDbContext();
                //dbContext.Entry(user).State = EntityState.Detached;
                //dbContext.Entry<User>(user).State = EntityState.Modified;
                //dbContext.Users.Update(user);
                dbContext.Attach(user).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }
        }
    }
}
