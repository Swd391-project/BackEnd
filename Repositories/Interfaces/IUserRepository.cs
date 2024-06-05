

using SWD.BBMS.Repositories.Entities;

namespace SWD.BBMS.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void CreateUser(User user);

        List<User> GetUsers();

        User? GetUserById(int id);

        void UpdateUser(User user);

        User GetUserByUsername(string username);
    }
}
