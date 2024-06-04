﻿using BadmintonRentalSWD.Entities;

namespace BadmintonRentalSWD.Services
{
    public interface IUserService
    {
        void CreateUser(User user);

        User? GetUserById(int id);

        List<User> GetUsers();

        void UpdateUser(User user);

        User GetUserByUsername(string username);   
    }
}