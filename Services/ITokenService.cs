using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersApi.Models;

namespace UsersApi.Services
{
    public interface ITokenService
    {
        public string CreateToken(UserDto userDto);
    }
}
