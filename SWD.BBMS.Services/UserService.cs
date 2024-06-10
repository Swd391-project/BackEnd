using AutoMapper;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Repositories.Interfaces;
using SWD.BBMS.Services.BusinessModels;
using SWD.BBMS.Services.Interfaces;

namespace SWD.BBMS.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public void CreateUser(User user)
        {
            userRepository.CreateUser(user);
        }

        public async Task<UserModel>? GetUserById(string id)
        {
            try
            {
                var user = await userRepository.GetUserById(id);
                var userModel = mapper.Map<UserModel>(user);
                return userModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User GetUserByUsername(string username)
        {
            return userRepository.GetUserByUsername(username);
        }

        public async Task<List<UserModel>> GetUsers()
        {
            try
            {
                var users = await userRepository.GetUsers();
                var userModels = mapper.Map<List<UserModel>>(users);
                return userModels;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateUser(User user)
        {
            userRepository.UpdateUser(user);
        }
    }
}
