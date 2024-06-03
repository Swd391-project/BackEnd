using BadmintonRentalSWD.BusinessObjects;
using BadmintonRentalSWD.Repositories;

namespace BadmintonRentalSWD.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void CreateUser(User user)
        {
            userRepository.CreateUser(user);
        }

        public User? GetUserById(int id)
        {
            return userRepository.GetUserById(id);
        }

        public List<User> GetUsers()
        {
            return userRepository.GetUsers();
        }

        public void UpdateUser(User user)
        {
            userRepository.UpdateUser(user);
        }
    }
}
