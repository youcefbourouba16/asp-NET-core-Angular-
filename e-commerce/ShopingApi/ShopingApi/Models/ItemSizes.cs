using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace ShopingApi.Models
{
    [PrimaryKey(nameof(SizeID), nameof(ItemID))]
    public class ItemSizes
    {
        [Key]
        public string SizeID { get; set; }

        [Key]
        [ForeignKey("Item")]
        public int ItemID { get; set; }
    }
}
