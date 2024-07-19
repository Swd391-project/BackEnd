

using SWD.BBMS.Repositories.Entities;

namespace SWD.BBMS.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void CreateUser(User user);

        Task<PagedList<User>> GetUsers(int pageNumber, int pageSize);

        Task<int> GetUsersNoPaging();

        Task<int> GetStaffs();

        Task<User>? GetUserById(string id);

        Task<bool> UpdateUser(User user);

        Task<User?> GetUserByUsername(string username);

        Task<bool> ExistsByEmail(string email);

        Task<bool> ExistsByPhoneNumber(string phoneNumber);

        Task<bool> ExistsByUserName(string userName);

        Task<bool> ExistsById(string id);
    }
}
