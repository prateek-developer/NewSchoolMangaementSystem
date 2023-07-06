using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using schoolManagementsystem.Models;
using schoolManagementsystem.Repository;
using schoolManagementsystem.ViewModel;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Linq.Expressions;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using schoolManagementsystem.helpers;

namespace schoolManagementsystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }



        [HttpPost("authentication")]

        public async Task<IActionResult> LoginUSer([FromBody] LoginDetailViewModel user0bj)
        {


          

            if (user0bj == null)
            {
                return BadRequest();
            }

          
            var user = await _userRepository.Login(user0bj);
            if (user == null)
            {
                return NotFound("not found");
            }
            if (!PasswordHasher.VerifyPassword(user0bj.Password , user.Password))
            {
                return BadRequest(new
                {
                    message = "Password is incorrect"
                });
            }
       
            user.Token = CreateJwt(user);

            return Ok(new
            {
                Token = user.Token,
                Message = "Login successful"
            });
        }

        private static string CreateJwt(LoginDetail user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysecret......");
            var identity = new ClaimsIdentity(new Claim[]
            {

                 new Claim(ClaimTypes.Role , user.UserRole),
                new Claim(ClaimTypes.Name , user.Username),
               


            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(TokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }


  




    }
}
