using SWD.BBMS.Repositories;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Services.BusinessModels;

namespace SWD.BBMS.Services.Interfaces
{
    public interface IUserService
    {
        void CreateUser(User user);

        Task<UserModel>? GetUserById(string id);

        Task<PagedList<UserModel>> GetUsers(int pageNumber, int pageSize);

        Task<bool> UpdateUser(string id, Dictionary<string, object> userModel);

        User GetUserByUsername(string username);   
    }
}
