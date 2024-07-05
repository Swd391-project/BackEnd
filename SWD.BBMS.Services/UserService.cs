using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
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

        private readonly SignInManager<User> signInManager;

        public UserService(IUserRepository userRepository, IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<dynamic> CreateUser(UserModel userModel, string password)
        {
            var result = false;
            try
            {
                if(userModel == null)
                    throw new NullReferenceException("User is null in create user service.");

                if(string.IsNullOrWhiteSpace(password) || string.IsNullOrEmpty(password))
                    throw new Exception("Password is empty or white space in create user service.");

                //Check username
                if (await userRepository.ExistsByUserName(userModel.UserName))
                    throw new Exception($"Email {userModel.Email} is existed.");

                //Check email
                if (await userRepository.ExistsByEmail(userModel.Email))
                    throw new Exception($"Email {userModel.Email} is existed.");

                //Check phone number
                if (await userRepository.ExistsByPhoneNumber(userModel.PhoneNumber))
                    throw new Exception($"Phone number {userModel.PhoneNumber} is existed.");

                var user = mapper.Map<User>(userModel);
                var createdUser = await userManager.CreateAsync(user, password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await userManager.AddToRoleAsync(user, userModel.Role);

                    if (roleResult.Succeeded)
                    {
                        result = true;
                    }
                    else
                    {
                        return roleResult.Errors;
                    }
                }
                else
                {
                    return createdUser.Errors;
                }
            }
            catch
            {
                throw;
            }
            return result;
        }

        public async Task<bool> DeleteUser(string id)
        {
            var result = false;
            try
            {
                var user = await userManager.FindByIdAsync(id);
                if (user == null)
                {
                    throw new Exception("There is no user with id: " + id);
                }
                var userModel = mapper.Map<UserModel>(user);
                userModel.Status = UserModelStatus.Deleted;
                user = mapper.Map<User>(userModel);
                result = await userRepository.UpdateUser(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
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

        public async Task<UserModel> GetUserByUsername(string username)
        {
            var user = await userRepository.GetUserByUsername(username);
            var userModel = mapper.Map<UserModel>(user);
            return userModel;
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

        public async Task<bool> LoginUser(UserModel userModel, string password)
        {
            var result = false;
            try
            {
                var user = mapper.Map<User>(userModel);
                var checkPassResult = await signInManager.CheckPasswordSignInAsync(user, password, false);
                if (checkPassResult.Succeeded)
                {
                    result = true;
                }
            }
            catch
            {
                throw;
            }
            return result;
        }

        public async Task<bool> UpdateUser(string id, Dictionary<string, object> userModel)
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
            var property = user.GetType().GetProperty(dict.Key);
            if (property != null && property.CanWrite)
            {
                var propertyType = property.PropertyType;

                object value;

                if (dict.Value == null || dict.Value.Equals(""))
                {
                    return;
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
                    if (value == null || value.Equals(""))
                    {
                        return;
                    }
                }

                // Set the property value
                property.SetValue(user, value);
            }
        }
    }
}
