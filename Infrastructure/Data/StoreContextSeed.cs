﻿using Core.Entites;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandsdata = File
                        .ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsdata);

                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any())
                {
                    var typesdata = File
                        .ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesdata);

                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Genres.Any())
                {
                    var genresdata = File
                        .ReadAllText("../Infrastructure/Data/SeedData/genres.json");
                    var genres = JsonSerializer.Deserialize<List<Genre>>(genresdata);

                    foreach (var item in genres)
                    {
                        context.Genres.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Ratings.Any())
                {
                    var ratingsdata = File
                        .ReadAllText("../Infrastructure/Data/SeedData/ratings.json");
                    var ratings = JsonSerializer.Deserialize<List<Rating>>(ratingsdata);

                    foreach (var item in ratings)
                    {
                        context.Ratings.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    var productsdata = File
                        .ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsdata);

                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(e.Message);
            }
        }
       
    }
}
