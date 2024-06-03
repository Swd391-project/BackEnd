using BadmintonRentalSWD.BusinessObjects;
using BadmintonRentalSWD.Data;

namespace BadmintonRentalSWD.DAO
{
    public class UserDAO
    {
        public static void CreateUser(User user)
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

        public static User? GetUserById (int id)
        {
            using var dbContext = new BBMSDbContext();
            return dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public static List<User> GetUsers()
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

        public static void UpdateUser(User user)
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
