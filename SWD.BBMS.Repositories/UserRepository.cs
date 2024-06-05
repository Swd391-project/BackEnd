

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

        public User? GetUserById(int id)
        {
            using var dbContext = new BBMSDbContext();
            return dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            using var dbContext = new BBMSDbContext();
            return dbContext.Users.FirstOrDefault(u => u.UserName.Equals(username));
        }

        public List<User> GetUsers()
        {
            var users = new List<User>();
            try
            {
                using var dbContext = new BBMSDbContext();
                users = dbContext.Users.ToList();
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
