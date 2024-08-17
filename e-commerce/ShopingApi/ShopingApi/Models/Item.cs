using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ShopingApi.Enum;

namespace ShopingApi.Models
{
    public class Item
    {
        public Item()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [MaxLength(50)]
        public TshirtSize_enum? Size { get; set; }

        public List<Color>? Colors { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; } = 1;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public string? ImageURL { get; set; }

        [ForeignKey("ProductType")]
        public string productTypeId { get; set; }

        public Category_enum Category { get; set; }

        // Navigation property for ProductType
        public ProductType? ProductType { get; set; }
    }
}
