using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopingApi.Models
{

    [PrimaryKey(nameof(ColorId), nameof(ItemID))]
    public class ItemColors
    {
        
        public string ColorId { get; set; }

        
        [ForeignKey("Item")]
        public int ItemID { get; set; }
    }
}
