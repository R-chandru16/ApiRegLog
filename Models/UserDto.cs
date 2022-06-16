using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersApi.Models
{
    public class UserDto
    {
        public string ID { get; set; }
        public string Password { get; set; }
        public string JWTToken { get; set; }
    }
}
