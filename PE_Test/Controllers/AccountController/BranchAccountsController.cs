using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using BusinessObject.Request;
using Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PE_Test.Controllers.AccountController
{
    [Route("api/accounts")]
    [ApiController]
    public class BranchAccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IConfiguration _configuration;


        public BranchAccountsController(IAccountRepository accountRepository, IConfiguration configuration)
        {
            _accountRepository = accountRepository;
            _configuration = configuration;
        }



        [HttpPost]
        [Route("login")]
        [AllowAnonymous]

        public ActionResult<string> CheckLogin([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest != null)
            {
                if (!String.IsNullOrEmpty(loginRequest.Email) && !String.IsNullOrEmpty(loginRequest.Password))
                {
                    try
                    {
                        var account = _accountRepository.CheckLogin(loginRequest.Email, loginRequest.Password);
                        if (account != null)
                        {
                            if (account.Role == 1)
                            {
                                Claim[]? claims = null;
                                claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]!),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim(ClaimTypes.Role, "Admin"),
                        new Claim("Email", loginRequest.Email),
                        new Claim("Role", "Admin")
                            };

                                //create claims details based on the user information

                                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
                                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                                var token = new JwtSecurityToken(
                                    _configuration["Jwt:Issuer"],
                                    _configuration["Jwt:Audience"],
                                    claims,
                                    expires: DateTime.UtcNow.AddMinutes(180),
                                    signingCredentials: signIn);

                                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                            }
                            else if (account.Role == 2)
                            {
                                Claim[]? claims = null;
                                claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]!),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim(ClaimTypes.Role, "Staff"),
                        new Claim("Email", loginRequest.Email),
                        new Claim("Role", "Staff")
                            };

                                //create claims details based on the user information

                                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
                                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                                var token = new JwtSecurityToken(
                                    _configuration["Jwt:Issuer"],
                                    _configuration["Jwt:Audience"],
                                    claims,
                                    expires: DateTime.UtcNow.AddMinutes(180),
                                    signingCredentials: signIn);

                                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                            }
                            else if (account.Role == 3)
                            {
                                Claim[]? claims = null;
                                claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]!),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim(ClaimTypes.Role, "Manager"),
                        new Claim("Email", loginRequest.Email),
                        new Claim("Role", "Manager")
                            };

                                //create claims details based on the user information

                                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
                                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                                var token = new JwtSecurityToken(
                                    _configuration["Jwt:Issuer"],
                                    _configuration["Jwt:Audience"],
                                    claims,
                                    expires: DateTime.UtcNow.AddMinutes(180),
                                    signingCredentials: signIn);

                                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                            }
                            else
                            {
                                Claim[]? claims = null;
                                claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]!),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim(ClaimTypes.Role, "Customer"),
                        new Claim("Email", loginRequest.Email),
                        new Claim("Role", "Customer")
                            };

                                //create claims details based on the user information

                                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
                                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                                var token = new JwtSecurityToken(
                                    _configuration["Jwt:Issuer"],
                                    _configuration["Jwt:Audience"],
                                    claims,
                                    expires: DateTime.UtcNow.AddMinutes(180),
                                    signingCredentials: signIn);

                                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        return BadRequest(e.Message);
                    }
                }
            }
            return BadRequest("The value input should not be empty!");
        }
    }
}

