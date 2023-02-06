using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using AutoDabiServiceAPI.DTOs;
using AutoDabiServiceAPI.DTOs.UserDtos;

namespace AutoDabiServiceAPI.Repositories
{
    public interface IUserRepository
    {
        Task<ResultInfo> Login(UserLoginDto model);
        Task<ResultInfo> Register(UserRegisterDto model);
        Task<ResultInfo> ChangePassword(UserChangePasswordDto model);
        Task<ResultInfo> ResetPassword(UserResetPasswordDto model);
        Task<ResultInfo> DeleteUser(UserDeleteDto model);
        Task<ResultInfo> UpdateUser(UserUpdateDto model);
    }
}