using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoDabiServiceAPI.DTOs;
using AutoDabiServiceAPI.DTOs.UserDtos;
using AutoDabiServiceAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AutoDabiServiceAPI.Repositories
{
    public class UserRepository  : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public UserRepository(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<ResultInfo> Login(UserLoginDto model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                return new ResultInfo(StatusType.Failed, "Nie znaleziono użytkownika.");
            }

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddHours(24),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return new ResultInfo(StatusType.Success, token);
            }
            else
            {
                return new ResultInfo(StatusType.Failed, "Niepoprawny login lub hasło.");
            }

        }

        public async Task<ResultInfo> Register(UserRegisterDto model)
        {
            var userExists = await _userManager.FindByNameAsync(model.UserName);
            if (userExists != null)
            {
                return new ResultInfo(StatusType.Failed, "User already exists!");
            }

            var user = new ApplicationUser()
            {
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                var errors = "";
                foreach (var identityError in result.Errors)
                {
                    errors += identityError.Description + " ";
                }
                return new ResultInfo(StatusType.Failed, errors);
            }

            return new ResultInfo(StatusType.Success, "User created successfully!");
        }

        public async Task<ResultInfo> ChangePassword(UserChangePasswordDto model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return new ResultInfo(StatusType.Failed, "User do not exist!");
            }

            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                var errors = "";
                foreach (var identityError in result.Errors)
                {
                    errors += identityError.Description + " ";
                }
                return new ResultInfo(StatusType.Failed, errors);
            }

            return new ResultInfo(StatusType.Success, "Password changed");
        }

        public async Task<ResultInfo> ResetPassword(UserResetPasswordDto model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return new ResultInfo(StatusType.Failed, "User do not exist!");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, model.Password);
            if (!result.Succeeded)
            {
                var errors = "";
                foreach (var identityError in result.Errors)
                {
                    errors += identityError.Description + " ";
                }
                return new ResultInfo(StatusType.Failed, errors);
            }

            return new ResultInfo(StatusType.Success, "Password changed");
        }

        public async Task<ResultInfo> DeleteUser(UserDeleteDto model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return new ResultInfo(StatusType.Failed, "User do not exist!");
            }

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                var errors = "";
                foreach (var identityError in result.Errors)
                {
                    errors += identityError.Description + " ";
                }
                return new ResultInfo(StatusType.Failed, errors);
            }

            return new ResultInfo(StatusType.Success, "User deleted");
        }

        public async Task<ResultInfo> UpdateUser(UserUpdateDto model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return new ResultInfo(StatusType.Failed, "User do not exist!");
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                var errors = "";
                foreach (var identityError in result.Errors)
                {
                    errors += identityError.Description + " ";
                }
                return new ResultInfo(StatusType.Failed, errors);
            }

            return new ResultInfo(StatusType.Success, "User updated");
        }
    }
}