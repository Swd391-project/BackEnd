using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Services.BusinessModels;

namespace SWD.BBMS.Services.Interfaces
{
    public interface IUserService
    {
        void CreateUser(User user);

        Task<UserModel>? GetUserById(string id);

        Task<List<UserModel>> GetUsers();

        void UpdateUser(User user);

        User GetUserByUsername(string username);   
    }
}
