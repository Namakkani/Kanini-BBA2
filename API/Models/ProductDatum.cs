using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RoleBasedAuthorization.Models
{
    public class ProductDatum
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string? ProductId { get; set; } 
        public string? ProductName { get; set; }

        public int? QuantityAvailable { get; set; }
        public decimal? Cost { get; set; }
    }
}
