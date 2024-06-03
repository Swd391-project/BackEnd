using BadmintonRentalSWD.BusinessObjects;

namespace BadmintonRentalSWD.Repositories
{
    public interface IUserRepository
    {
        void CreateUser(User user);

        List<User> GetUsers();

        User? GetUserById(int id);

        void UpdateUser(User user);
    }
}
