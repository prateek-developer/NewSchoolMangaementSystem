using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using schoolManagementsystem.Models;
using schoolManagementsystem.ViewModel;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace schoolManagementsystem.Repository
{
    public class UserRepository : IUserRepository
    {


        private readonly SchoolManagementContext db;


        public UserRepository(SchoolManagementContext _dbContext)
        {
            db = _dbContext;


        }





        public async Task<LoginDetail> Login(LoginDetailViewModel User)
        {
            var user_obj = await db.LoginDetails.Where(x => x.Username == User.Username ).Select(x => new LoginDetail()
            {
                Username=x.Username,
                Password=x.Password,
                UserRole=x.UserRole,
            })
                .FirstOrDefaultAsync();
           
           
                return user_obj;
            
        }

     






    }
}
