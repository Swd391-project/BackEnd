using BadmintonRentalSWD.BusinessObjects;
using BadmintonRentalSWD.DAO;
using BadmintonRentalSWD.Data;

namespace BadmintonRentalSWD.Repositories
{
    public class UserRepository : IUserRepository
    {

        public void CreateUser(User user)
            => UserDAO.CreateUser(user);

        public User? GetUserById(int id)
            => UserDAO.GetUserById(id);

        public List<User> GetUsers()
            => UserDAO.GetUsers();

        public void UpdateUser(User user)
            => UserDAO.UpdateUser(user);
    }
}
