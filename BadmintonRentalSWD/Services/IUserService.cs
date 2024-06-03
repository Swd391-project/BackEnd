using BadmintonRentalSWD.BusinessObjects;

namespace BadmintonRentalSWD.Services
{
    public interface IUserService
    {
        void CreateUser(User user);

        User? GetUserById(int id);

        List<User> GetUsers();

        void UpdateUser(User user);
    }
}
