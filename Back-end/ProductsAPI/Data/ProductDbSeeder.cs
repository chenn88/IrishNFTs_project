using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsAPI.Models;

namespace ProductsAPI.Data
{
    public static class ProductDbSeeder
    {

        public static void Seed(ProductDbContext context)
        {
            var products = new List<Product>
            {
                new Product { Title = "Antique Spoons", Price = 2000.00M, Description = "A set of 4 antique spoons made of silver", Category = "Antiques",     ImgUrl = "/images/antique-spoons.jpg", InStock = true },
                new Product { Title = "Art Mask", Price = 2500.00M, Description = "A handcrafted ceramic mask with intricate details", Category = "Art", ImgUrl = "/images/art-mask.jpg", InStock = true },
                new Product { Title = "Happy Clown", Price = 1500.00M, Description = "A colorful ceramic clown figurine with a big smile", Category = "Art", ImgUrl = "/images/happy-clown.jpg", InStock = true },
                new Product { Title = "Lady after Picasso", Price = 3000.00M, Description = "A painting inspired by Picasso's style, depicting a woman's face", Category = "Art", ImgUrl = "/images/lady-after-picasso.jpg", InStock = true },
                new Product { Title = "Maiya", Price = 1200.00M, Description = "A handmade doll dressed in traditional Indian attire", Category = "Toys", ImgUrl = "/images/maiya.jpg", InStock = true },
                new Product { Title = "Marbles on Blue Plate", Price = 1800.00M, Description = "A still-life painting of marbles arranged on a blue plate", Category = "Art", ImgUrl = "/images/marbles-on-blue-plate.jpg", InStock = true },
                new Product { Title = "Metal Mask", Price = 2200.00M, Description = "A metallic mask with intricate designs, perfect for display", Category = "Art", ImgUrl = "/images/metal-mask.jpg", InStock = true },
                new Product { Title = "Mystique", Price = 2000.00M, Description = "A painting with a mysterious landscape, invoking a sense of wonder", Category = "Art", ImgUrl = "/images/mystique.jpg", InStock = true },
                new Product { Title = "New York", Price = 2800.00M, Description = "A contemporary sculpture made of stainless steel", Category = "Art", ImgUrl = "/images/new-york.jpg", InStock = true },
                new Product { Title = "Orchid", Price = 1500.00M, Description = "A watercolor painting of a pink orchid flower", Category = "Art", ImgUrl = "/images/orchid.jpg", InStock = true },
                new Product { Title = "Resonator Deconstructed", Price = 2800.00M, Description = "A mixed media artwork featuring deconstructed resonator parts", Category = "Art", ImgUrl = "/images/resonator-deconstructed.jpg", InStock = true },
                new Product { Title = "Spanish Doorway", Price = 2000.00M, Description = "A photograph of an old Spanish doorway, with rustic charm", Category = "Photography", ImgUrl = "/images/spanish-doorway.jpg", InStock = true },
                new Product { Title = "Summer Cocktails", Price = 1200.00M, Description = "A set of 4 cocktail glasses with summery designs", Category = "Kitchenware", ImgUrl = "/images/summer-cocktails.jpg", InStock = true },
                new Product { Title = "The Aerialist", Price = 2500.00M, Description = "A photograph of an aerialist performing acrobatic moves", Category = "Photography", ImgUrl = "/images/the-aerialist.jpg", InStock = true },
                new Product { Title = "Woman with a Fan", Price = 1800.00M, Description = "A painting of a woman holding a fan, with intricate details", Category = "Art", ImgUrl = "/images/woman-with-a-fan.jpg", InStock = true },
                new Product { Title = "Yellow Buttons", Price = 2000.00M, Description = "A set of yellow buttons, made of natural materials", Category = "Crafts", ImgUrl = "/images/yellow-buttons.jpg", InStock = true },
                new Product { Title = "Art Marbles in Jar", Price = 1500.00M, Description = "A painting of marbles arranged in a glass jar, with vibrant colors", Category = "Art", ImgUrl = "/images/art-marbles-in-jar.jpg", InStock = true },
                new Product { Title = "Doggie Daydreaming", Price = 1200.00M, Description = "A photograph of a dog sleeping, with a dreamy expression", Category = "Photography", ImgUrl = "/images/doggie-daydreaming.jpg", InStock = true },
                new Product { Title = "Lockdown Series 2", Price = 3000.00M, Description = "A set of 3 paintings depicting life during lockdown, with emotional intensity", Category = "Art", ImgUrl = "/images/lockdown-series-2.jpg", InStock = true }

            };

            context.Products.AddRange(products);
            context.SaveChanges();

        }
    }
}