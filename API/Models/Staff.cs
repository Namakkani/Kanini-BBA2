using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RoleBasedAuthorization.Models
{
    public class Staff
    {
        /*[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]*/
        public string? Id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? Email { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Passwordclear { get; set; } = string.Empty;
        public string Qualification { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public string YearsOfExperience { get; set; } = string.Empty;
    }
}
