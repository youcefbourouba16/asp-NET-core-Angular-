using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopingApi.Models
{

    [PrimaryKey(nameof(ColorId), nameof(ItemID))]
    public class ItemColors
    {
        // Foreign key to Color based on Color.Name
        [ForeignKey("Color")]
        public string ColorId { get; set; }

        public Color Color { get; set; }

        // Foreign key to Item
        [ForeignKey("Item")]
        public int ItemID { get; set; }

        public Item Item { get; set; }
    }
}
