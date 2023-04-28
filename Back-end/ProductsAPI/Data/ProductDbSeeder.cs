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

                    new Product
                      {
                          Title = "Antique Spoons",
                          Price = 2000.00M,
                          Description = "Antique Spoons, oil on canvas panel, 8 x 10 ins",
                          Category = "Still Life",
                          ImgUrl = "/images/antique-spoons.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Art Mask",
                          Price = 2500.00M,
                          Description = "Mask, oil on Canvas Panel, 25 x 20 cms",
                          Category = "Abstract",
                          ImgUrl = "/images/art-mask.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Happy Clown",
                          Price = 1500.00M,
                          Description = "Happy Clown - oil on canvas panel, 30 x 25 cms",
                          Category = "Abstract",
                          ImgUrl = "/images/happy-clown.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Lady after Picasso",
                          Price = 3000.00M,
                          Description = "A painting inspired by Picasso's style, oil, 23 x 28 cms",
                          Category = "Abstract",
                          ImgUrl = "/images/lady-after-picasso.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Maiya",
                          Price = 1200.00M,
                          Description = "A woman dressed in traditional attire - oil on canvas 14 x 18inches",
                          Category = "Portrait",
                          ImgUrl = "/images/maiya.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Marbles on Blue Plate",
                          Price = 1800.00M,
                          Description = "Still-life painting of marbles - oil on canvas panel 10 x 14inches",
                          Category = "Still Life",
                          ImgUrl = "/images/marbles-on-blue-plate.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Metal Mask",
                          Price = 2200.00M,
                          Description = "A metallic mask with intricate designs - oil on canvas - 30cm x 15cm",
                          Category = "Abstract",
                          ImgUrl = "/images/metal-mask.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Mystique",
                          Price = 2000.00M,
                          Description = "A mysterious mask - oil on canvas panel - 40cm x 25cm",
                          Category = "Abstract",
                          ImgUrl = "/images/mystique.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "New York",
                          Price = 2800.00M,
                          Description = "New York cityscape at night - oil on deep canvas - 35.5 x 25 inches",
                          Category = "CityScape",
                          ImgUrl = "/images/new-york.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Orchid",
                          Price = 1500.00M,
                          Description = "Orchid - oil on canvas - 14x18 inches",
                          Category = "Landscape",
                          ImgUrl = "/images/orchid.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Resonator Deconstructed",
                          Price = 2800.00M,
                          Description = "Resonator Guitar deconstructed - oil on Canvas Panel, 30 x 25 cms",
                          Category = "Music",
                          ImgUrl = "/images/resonator-deconstructed.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Spanish Doorway",
                          Price = 2000.00M,
                          Description = "A painting of an old Spanish doorway, with rustic charm - oil on Canvas Panel, 10 x 8 inches",
                          Category = "CityScape",
                          ImgUrl = "/images/spanish-doorway.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Summer Cocktails",
                          Price = 1200.00M,
                          Description = "A set of 4 cocktail glasses with summery designs - oil on Canvas Panel, 12 x 10 inches",
                          Category = "Still Life",
                          ImgUrl = "/images/summer-cocktails.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "The Aerialist",
                          Price = 2500.00M,
                          Description = "A painting of an aerialist performing acrobatic moves",
                          Category = "Portrait",
                          ImgUrl = "/images/the-aerialist.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Woman with fan (Picasso)",
                          Price = 1800.00M,
                          Description = "A painting of a woman holding a fan (after Picasso), Oil, 24 x 12 ins",
                          Category = "Abstract",
                          ImgUrl = "/images/woman-with-a-fan.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Yellow Buttons",
                          Price = 2000.00M,
                          Description = "A set of yellow buttons, made of natural materials - oil on canvas panel, 8 x 10 ins",
                          Category = "Still Life",
                          ImgUrl = "/images/yellow-buttons.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Art Marbles in Jar",
                          Price = 1500.00M,
                          Description = "A painting of marbles arranged in a glass jar, with vibrant colors - Oil, 400mm x 400mm",
                          Category = "Still Life",
                          ImgUrl = "/images/art-marbles-in-jar.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Doggie Daydreaming",
                          Price = 1200.00M,
                          Description = "A photograph of a dog sleeping, with a dreamy expression - oil on Canvas Panel, 14 x 10 inches",
                          Category = "Animals",
                          ImgUrl = "/images/doggie-daydreaming.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Lockdown Series 2",
                          Price = 3000.00M,
                          Description = "Lockdown - oil on canvas panel, 8 x 10 ins",
                          Category = "Still Life",
                          ImgUrl = "/images/lockdown-series-2.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Polly",
                          Price = 3000.00M,
                          Description = "Polly - oil, 12 x 10 ins",
                          Category = "Animals",
                          ImgUrl = "/images/polly.jpg",
                          InStock = true
                      },

                      new Product
                      {
                          Title = "Charlie",
                          Price = 3000.00M,
                          Description = "Charlie - oil, 12 x 10 ins",
                          Category = "Animals",
                          ImgUrl = "/images/charlie.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Reading (after Picasso)",
                          Price = 4000.00M,
                          Description = "A painting of a woman reading, inspired by Picasso's style",
                          Category = "Abstract",
                          ImgUrl = "/images/woman-reading-after-picasso.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Mr D'arcy",
                          Price = 3500.00M,
                          Description = "Mr D'arcy, sir - Oil on Deep Canvas, 12 x 10 inches",
                          Category = "Animals",
                          ImgUrl = "/images/mr-darcy.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Rose",
                          Price = 1500.00M,
                          Description = "A painting of a rose",
                          Category = "Landscape",
                          ImgUrl = "/images/rose.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Masquerade",
                          Price = 2500.00M,
                          Description = "A picture of a jester - oil on Canvas Panel, 14 x 10 inches",
                          Category = "Abstract",
                          ImgUrl = "/images/masquerade.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "White Rose",
                          Price = 1800.00M,
                          Description = "White rose -  oil on Canvas Panel, 30 x 25 cms",
                          Category = "Landscape",
                          ImgUrl = "/images/white-rose.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Face of climate change",
                          Price = 1400.00M,
                          Description = "Face of Climate Change, Watercolour on Fabriano Paper, 35.5 x 25 cms",
                          Category = "Abstract",
                          ImgUrl = "/images/face-of-climate-change.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Pigeon house sunset",
                          Price = 1800.00M,
                          Description = "Pigeon House Sunset (from original photo by Adam Gelston), Oil on Canvas Panel, 16 x 12 inches",
                          Category = "CityScape",
                          ImgUrl = "/images/pigeon-house-sunset.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Red Stables",
                          Price = 1200.00M,
                          Description = "Red Stables (detail) St Annes Park, Ink/Watercolour, 5 x 7 ins",
                          Category = "CityScape",
                          ImgUrl = "/images/red-stables-detail-st-annes-park.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Clowning Around",
                          Price = 1200.00M,
                          Description = "A painting of a clown with bright colors - oil, 25 x 35.5 cms",
                          Category = "Abstract",
                          ImgUrl = "/images/clowning-around.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Ciaran's guitar",
                          Price = 1450.00M,
                          Description = "A painting of a guitar in the style of Ciaran Crowley",
                          Category = "Music",
                          ImgUrl = "/images/ciarans-guitar.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Comedy / Tragedy",
                          Price = 1700.00M,
                          Description = "A painting of comedy and tragedy masks",
                          Category = "Abstract",
                          ImgUrl = "/images/comedy-tragedy.jpg",
                          InStock = true
                      },
                      new Product
                      {
                          Title = "Giant's Causeway",
                          Price = 1650.00M,
                          Description = "An original oil painting of Giant's Causeway, Northern Ireland",
                          Category = "LandScape",
                          ImgUrl = "/images/giants-causeway.jpg",
                          InStock = true
                      },

                      new Product
                        {
                            Title = "Gelato",
                            Price = 1500.00M,
                            Description = "Gelato - Original - oil 8 x 10 inches",
                            Category = "Still Life",
                            ImgUrl = "/images/gelato.jpg",
                            InStock = true
                        },

                      new Product
                        {
                            Title = "Summer Cocktails",
                            Price = 1400.00M,
                            Description = "Summer Cocktails - Original oil 8 x 10 inches",
                            Category = "Still Life",
                            ImgUrl = "/images/summer-cocktails.jpg",
                            InStock = true
                        },

                      new Product
                        {
                            Title = "Alexandria",
                            Price = 1600.00M,
                            Description = "Alexandria - oil on canvas, 14 X 18 ins",
                            Category = "Portrait",
                            ImgUrl = "/images/alexandria.jpg",
                            InStock = true
                        }
            };

            context.Products.AddRange(products);
            context.SaveChanges();

        }
    }
}