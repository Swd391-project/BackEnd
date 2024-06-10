

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

        public async Task<List<User>> GetUsers()
        {
            var users = new List<User>();
            try
            {
                using var dbContext = new BBMSDbContext();
                users = await dbContext.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return users;
        }

        public void UpdateUser(User user)
        {
            try
            {
                using var dbContext = new BBMSDbContext();
                dbContext.Entry<User>(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
