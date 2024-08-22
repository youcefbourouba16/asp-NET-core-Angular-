using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ShopingApi.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using ShopingApi.Enum;

namespace ShopingApi.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<Db_Context>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                string[] roles = new string[] { "user", "admin" };

                foreach (string role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }

                var user = new AppUser
                {
                    Email = "xxxx@example.com",
                    NormalizedEmail = "XXXX@EXAMPLE.COM",
                    UserName = "Owner",
                    NormalizedUserName = "OWNER",
                    PhoneNumber = "+111111111111",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };

                if (userManager.Users.All(u => u.UserName != user.UserName))
                {
                    var password = new PasswordHasher<AppUser>();
                    var hashed = password.HashPassword(user, "secret");
                    user.PasswordHash = hashed;

                    var result = await userManager.CreateAsync(user);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRolesAsync(user, roles);
                    }
                }

                if (!context.Colors.Any())
                {
                    context.Colors.AddRange(
                        new Color
                        {
                            Name = "Red",
                            HexValue = "#FF0000"
                        },
                        new Color
                        {
                            Name = "Blue",
                            HexValue = "#0000FF"
                        }
                        );
                    await context.SaveChangesAsync();
                }
                if (!context.ProductTypes.Any())
                {
                    context.ProductTypes.AddRange(
                        new ProductType
                        {
                            typeName="Tshirt"
                        }
                        );
                    await context.SaveChangesAsync();
                }

                if (!context.Sizes.Any())
                {
                    context.Sizes.AddRange(
                        new Size
                        {
                            size = TshirtSize_enum.Large.ToString()
                        },
                        new Size
                        {
                            size = TshirtSize_enum.Medium.ToString()
                        },
                        new Size
                        {
                            size = TshirtSize_enum.Small.ToString()
                        },
                        new Size
                        {
                            size = TshirtSize_enum.ExtraLarge.ToString()
                        });


                    await context.SaveChangesAsync();
                }

                if (!context.Items.Any())
                {
                    var tshirtType = context.ProductTypes.FirstOrDefault(pt => pt.typeName == "Tshirt");

                    var redColor = context.Colors.FirstOrDefault(c => c.Name == "Red");
                    var blueColor = context.Colors.FirstOrDefault(c => c.Name == "Blue");

                    var smallSize = context.Sizes.FirstOrDefault(c => c.size == TshirtSize_enum.Small.ToString());
                    var largeSize = context.Sizes.FirstOrDefault(c => c.size == TshirtSize_enum.Large.ToString());

                    var redTshirt = new Item
                    {
                        Name = "Red T-Shirt",
                        Description = "A plain red t-shirt.",
                        Quantity = 100,
                        Price = 19.99m,
                        productTypeId = tshirtType?.typeName,
                        Category = Category_enum.Men.ToString(),
                        ImageURL = "https://assets.ajio.com/medias/sys_master/root/20240728/zX8C/66a561026f60443f31cb1911/-1117Wx1400H-462103471-red-MODEL.jpg"
                    };

                    var blueJeans = new Item
                    {
                        Name = "Blue Jeans",
                        Description = "Comfortable blue jeans.",
                        Quantity = 50,
                        Price = 49.99m,
                        productTypeId = tshirtType?.typeName,
                        
                        Category =Category_enum.Women.ToString(),
                        ImageURL = "https://cobbitaly.com/cdn/shop/products/NVFSRE4092NAVYBLUE_1.jpg?v=1665659100&width=2048"
                    };

                    context.Items.AddRange(redTshirt, blueJeans);
                    await context.SaveChangesAsync();  // Save changes to get generated itemID

                    // After saving, redTshirt.itemID and blueJeans.itemID are populated
                    context.ItemColors.AddRange(
                        new ItemColors { ItemID = redTshirt.Id, ColorId = redColor.Name },
                        new ItemColors { ItemID = redTshirt.Id, ColorId = blueColor.Name },
                        new ItemColors { ItemID = blueJeans.Id, ColorId = redColor.Name },
                        new ItemColors { ItemID = blueJeans.Id, ColorId = blueColor.Name }
                    );

                    context.ItemSizes.AddRange(
                        new ItemSizes { ItemID = redTshirt.Id, SizeID = smallSize.size },
                        new ItemSizes { ItemID = redTshirt.Id, SizeID = largeSize.size },
                        new ItemSizes { ItemID = blueJeans.Id, SizeID = smallSize.size },
                        new ItemSizes { ItemID = blueJeans.Id, SizeID = largeSize.size }
                    );

                    await context.SaveChangesAsync();
                }


            }
        }
    }
}
