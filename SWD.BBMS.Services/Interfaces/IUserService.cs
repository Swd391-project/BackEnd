using SWD.BBMS.Repositories;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Services.BusinessModels;

namespace SWD.BBMS.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> LoginUser(UserModel user, string password);

        Task<dynamic> CreateUser(UserModel userModel, string password);

        Task<UserModel>? GetUserById(string id);

        Task<PagedList<UserModel>> GetUsers(int pageNumber, int pageSize);

        Task<int> GetUsersNoPaging();

        Task<int> GetStaffs();

        Task<bool> UpdateUser(string id, Dictionary<string, object> userModel);

        Task<UserModel> GetUserByUsername(string username);

        Task<bool> DeleteUser(string id);
    }
}
