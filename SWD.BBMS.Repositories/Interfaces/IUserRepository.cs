

using SWD.BBMS.Repositories.Entities;

namespace SWD.BBMS.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void CreateUser(User user);

        Task<List<User>> GetUsers();

        Task<User>? GetUserById(string id);

        void UpdateUser(User user);

        User GetUserByUsername(string username);

        bool ExistsByEmail(string email);

        bool ExistsByPhoneNumber(string phoneNumber);
    }
}
