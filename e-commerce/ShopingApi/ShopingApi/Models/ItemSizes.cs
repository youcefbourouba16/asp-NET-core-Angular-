    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Drawing;

    namespace ShopingApi.Models
    {

    [PrimaryKey(nameof(SizeID), nameof(ItemID))]
    public class ItemSizes
         {
            public string SizeID { get; set; } 

            [ForeignKey("SizeID")]
            public Size Size { get; set; } 

            public int ItemID { get; set; } 

            [ForeignKey("ItemID")]
            public Item Item { get; set; } 

          }
    }
