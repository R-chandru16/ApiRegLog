using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Models;

namespace UsersApi.Services
{
    public class UserService
    {
        private readonly UserContext _userContext;
        private readonly ITokenService _tokenService;

        public UserService(UserContext userContext,ITokenService tokenService)
        {
            _userContext = userContext;
            _tokenService = tokenService;
        }
        public UserDto Register(UserDto userDto)
        {
            try
            {
                using var hmac = new HMACSHA512();
                var user = new Users()
                {
                    ID = userDto.ID,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password)),
                    PasswordSalt = hmac.Key
                };
                _userContext.Users.Add(user);
                _userContext.SaveChanges();
                var JWTToken = _tokenService.CreateToken(userDto);
                userDto.JWTToken = JWTToken;
                userDto.Password = "";
                return userDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public UserDto Login(UserDto userDto)
        {
            Users user = _userContext.Users.SingleOrDefault(e => e.ID == userDto.ID);
            if (user != null)
            {
                using var hmac = new HMACSHA512(user.PasswordSalt);
                var PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password));
                for (int i = 0; i < PasswordHash.Length; i++)
                {
                    if (user.PasswordHash[i] != PasswordHash[i])
                        return null;
                }
                var JWTToken = _tokenService.CreateToken(userDto);
                userDto.JWTToken = JWTToken;
                userDto.Password = "";
                return userDto;
            }
            return null;
        }
    }
}
