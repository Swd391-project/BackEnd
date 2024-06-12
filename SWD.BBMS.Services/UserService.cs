using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SWD.BBMS.Repositories;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Repositories.Interfaces;
using SWD.BBMS.Services.BusinessModels;
using SWD.BBMS.Services.Interfaces;
using System.Text.Json;

namespace SWD.BBMS.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        private readonly IMapper mapper;

        private readonly UserManager<User> userManager;

        public UserService(IUserRepository userRepository, IMapper mapper, UserManager<User> userManager)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public void CreateUser(User user)
        {
            userRepository.CreateUser(user);
        }

        public async Task<UserModel>? GetUserById(string id)
        {
            try
            {
                var user = await userManager.FindByIdAsync(id);
                if (user == null)
                {
                    throw new Exception("There is no user with id: " + id);
                }
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

        public async Task<PagedList<UserModel>> GetUsers(int pageNumber, int pageSize)
        {
            try
            {
                var users = await userRepository.GetUsers(pageNumber, pageSize);
                var userModels = mapper.Map<PagedList<UserModel>>(users);
                userModels.TotalCount = users.TotalCount;
                userModels.TotalPages = users.TotalPages;
                userModels.CurrentPage = users.CurrentPage;
                userModels.PageSize = users.PageSize;

                return userModels;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateUser(string id, UserUpdateDictionary userModel)
        {
            try
            {
                var user = await userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return false;
                    throw new Exception("There is no user with id: " + id);
                }
                foreach (var dict in userModel)
                {
                    SetPropertyValueFromDictionary(user, dict);
                }
                var success = await userRepository.UpdateUser(user);
                return success;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }
        }
        private string KebabToPascalCase(string kebab)
        {
            var parts = kebab.Split('-');
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i] = char.ToUpper(parts[i][0]) + parts[i].Substring(1);
            }
            return string.Join(string.Empty, parts);
        }

        private void SetPropertyValueFromDictionary(User user, KeyValuePair<string, object> dict)
        {
            var property = user.GetType().GetProperty(KebabToPascalCase(dict.Key));
            if (property != null && property.CanWrite)
            {
                var propertyType = property.PropertyType;

                object value;

                if (dict.Value == null)
                {
                    value = null;
                }
                else if (propertyType.IsAssignableFrom(dict.Value.GetType()))
                {
                    value = dict.Value; // No conversion needed
                }
                else if (propertyType.IsEnum)
                {
                    // Handle enum conversion
                    value = Enum.Parse(propertyType, dict.Value.ToString());
                }
                else if (propertyType == typeof(Guid))
                {
                    // Handle Guid conversion
                    value = Guid.Parse(dict.Value.ToString());
                }
                else
                {
                    // Use JSON serialization/deserialization for complex types
                    var json = JsonSerializer.Serialize(dict.Value);
                    value = JsonSerializer.Deserialize(json, propertyType);
                }

                // Set the property value
                property.SetValue(user, value);
            }
        }
    }
}
