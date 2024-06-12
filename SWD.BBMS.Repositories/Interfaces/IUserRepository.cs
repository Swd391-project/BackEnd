

using SWD.BBMS.Repositories.Entities;

namespace SWD.BBMS.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void CreateUser(User user);

        Task<PagedList<User>> GetUsers(int pageNumber, int pageSize);

        Task<User>? GetUserById(string id);

        Task<bool> UpdateUser(User user);

        User GetUserByUsername(string username);

        bool ExistsByEmail(string email);

        bool ExistsByPhoneNumber(string phoneNumber);

        Task<bool> ExistsByUserName(string userName);

        Task<bool> ExistsById(string id);
    }
}
