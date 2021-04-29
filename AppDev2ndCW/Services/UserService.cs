using AppDev2ndCW.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AppDev2ndCW.Services
{
    public class UserService
    {
        private readonly DataBaseContext _context;
        public UserService(DataBaseContext context)
        {
            _context = context;
        }

        internal Users GetUserById(int id)
        {
            var appUser = _context.Users.Find(id);
            return appUser;
        }

        internal bool TryValidateUser (string email, string contact, out List<Claim> claims)
        {
            claims = new List<Claim>();
            var appUser = _context.Users
                .Where(a => a.email == email)
                .Where(a => a.contacts == contact).FirstOrDefault();
            if (appUser is null)
            {
                return false;
            }
            else
            {
                claims.Add(new Claim("id", appUser.id.ToString()));
                claims.Add(new Claim("name", appUser.name));
                claims.Add(new Claim("email", email));
                claims.Add(new Claim("contact", appUser.contacts));
                claims.Add(new Claim("role", appUser.role));
                claims.Add(new Claim("password", appUser.password));
            }
            return true;
        }
    }
}
