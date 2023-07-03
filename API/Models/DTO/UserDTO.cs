namespace JWTAuthenticationApp.Models.DTO
{
    public class UserDTO
    {
        public string? Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
        public string? Role { get; set; }
        /*public byte[]? Password_encrypt { get; set; }
        public byte[]? HashKey { get; set; }*/
    }
}
