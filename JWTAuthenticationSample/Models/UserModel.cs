using System;

namespace JWTAuthenticationSample.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public DateTime Birthdate { get; set; }
    }
}