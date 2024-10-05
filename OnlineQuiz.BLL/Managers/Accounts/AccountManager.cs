using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineQuiz.BLL.Dtos.Accounts;
using OnlineQuiz.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.BLL.Managers.Accounts
{
    public class AccountManager : IAccountManager
    {
        private readonly UserManager<Users> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountManager(UserManager<Users> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }


        public async Task<GeneralRespnose> Register(RegisterDto registerDto)
        {
            var response = new GeneralRespnose();
            Users user = null;

            // Determine user type
            if (registerDto.UserType == UserTypeEnum.Student)
            {
                user = new Student();
            }
            else if (registerDto.UserType == UserTypeEnum.Instructor)
            {
                user = new Instructor();
            }
            else if (registerDto.UserType == UserTypeEnum.Admin)
            {
                //user = new Admin();
            }


            user.UserName = registerDto.UserName;
            user.Email = registerDto.Email;
            user.UserType = registerDto.UserType;
            user.Gender= registerDto.Gender;
            user.Adress = registerDto.Address;
            user.Age = registerDto.Age;
            
           

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
                // Assign the role 
                if (registerDto.UserType == UserTypeEnum.Admin)
                {
                    await _userManager.AddToRoleAsync(user, Roles.Admin);
                }
                else if (registerDto.UserType == UserTypeEnum.Instructor)
                {
                    await _userManager.AddToRoleAsync(user, Roles.Instructor);
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, Roles.Student);
                }

                response.successed = true;
                return response;
            }

            response.Errors = result.Errors.Select(d => d.Description).ToList();
            return response;
        }


        public async Task<GeneralRespnose> Login(LoginDto loginDto)
        {
            var response = new GeneralRespnose();
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                response.Errors.Add("Email not found. Please make sure the email is correct.");
                return response;
            }
            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (result)
            {
                #region Claims
                List<Claim> claims = new List<Claim>()
                {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()), // User ID as Subject
                new Claim(JwtRegisteredClaimNames.Email, user.Email), // User email
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())// Token identifie
                };
                var UserRoles = await _userManager.GetRolesAsync(user);
                foreach (var role in UserRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
                #endregion
                await _userManager.AddClaimsAsync(user, claims);
                response.Token = GenerateToken(claims);
                response.successed = true;
                return response;

            }
            response.Errors.Add("Wrong Password or Email");
            return response;
        }



        private string GenerateToken(IList<Claim> claims)
        {

            #region Token
            #region SecurityKey
            var SecretKeyString = _configuration.GetSection("SecretKey").Value;
            var SecretKeyByte = Encoding.ASCII.GetBytes(SecretKeyString);
            SecurityKey securityKey = new SymmetricSecurityKey(SecretKeyByte);
            #endregion

            //Combind SecretKey , HasingAlgorithm (SigningCredentials)
            SigningCredentials signingCredential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Token

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
            (
                claims: claims,
                signingCredentials: signingCredential,
                expires: DateTime.Now.AddDays(10)
            );
            //To convert Token To String
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            string token = handler.WriteToken(jwtSecurityToken);

            #endregion

            return token;
        }
    }
}
