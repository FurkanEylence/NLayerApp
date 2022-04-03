using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Concrete;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeed: IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            {
                Id = 1, 
                CategoryId = 1, 
                Name = "FaberCastell", 
                Price = 35, 
                Stock = 100,
                CreatedDate = DateTime.Now
            },
                new Product
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Stilo",
                    Price = 20,
                    Stock = 80,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 3,
                    CategoryId = 2,
                    Name = "Sınırsız",
                    Price = 30,
                    Stock = 20,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 4,
                    CategoryId = 2,
                    Name = "Purdikkat",
                    Price = 40,
                    Stock = 30,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 5,
                    CategoryId = 3,
                    Name = "Mopak",
                    Price = 20,
                    Stock = 200,
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}
