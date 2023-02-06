using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AutoDabiServiceAPI.DTOs;
using AutoDabiServiceAPI.DTOs.UserDtos;
using AutoDabiServiceAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDabiServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto model)
        {
            var result = await _userRepository.Login(model);
            if (result.Status == StatusType.Failed)
            {
                return StatusCode(StatusCodes.Status400BadRequest, result);
            }

            var response = new JwtSecurityTokenHandler().WriteToken((Microsoft.IdentityModel.Tokens.SecurityToken)result.Message);

            return Ok(response);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto model)
        {
            var result = await _userRepository.Register(model);
            if (result.Status == StatusType.Failed)
            {
                return StatusCode(StatusCodes.Status400BadRequest, result);
            }

            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        [Route("changePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] UserChangePasswordDto model)
        {
            var result = await _userRepository.ChangePassword(model);
            if (result.Status == StatusType.Failed)
            {
                return StatusCode(StatusCodes.Status400BadRequest, result);
            }

            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        [Route("resetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] UserResetPasswordDto model)
        {
            var result = await _userRepository.ResetPassword(model);
            if (result.Status == StatusType.Failed)
            {
                return StatusCode(StatusCodes.Status400BadRequest, result);
            }

            return Ok(result);
        }

        [Authorize]
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteUser([FromBody] UserDeleteDto model)
        {
            var result = await _userRepository.DeleteUser(model);
            if (result.Status == StatusType.Failed)
            {
                return StatusCode(StatusCodes.Status400BadRequest, result);
            }

            return Ok(result);
        }

        [Authorize]
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateDto model)
        {
            var result = await _userRepository.UpdateUser(model);
            if (result.Status == StatusType.Failed)
            {
                return StatusCode(StatusCodes.Status400BadRequest, result);
            }

            return Ok(result);
        }
    }
}
