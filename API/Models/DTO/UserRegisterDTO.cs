using RoleBasedAuthorization.Models;

namespace JWTAuthenticationApp.Models.DTO
{
    public class UserRegisterDTO : User
    {
        
        public string? PasswordClear { get; set; }
    }
}
