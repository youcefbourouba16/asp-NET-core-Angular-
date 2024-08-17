using System.ComponentModel.DataAnnotations;

namespace ShopingApi.Models
{
    public class Color
    {
        

        [Key]
        public string Name { get; set; }

        // Additional properties, such as RGB values or Hex codes, can be added here
        [MaxLength(50)]
        public string? HexValue { get; set; }
        public Color() { }
        public Color(string name)
        {
            Name = name;
        }

        public Color(string name, string? hexValue) : this(name)
        {
            HexValue = hexValue;
        }
    }
}
