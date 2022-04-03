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
    internal class ProductFeatureSeed: IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasData(
                new ProductFeature
                {
                    Id = 1,
                    ProductId = 1,
                    Color = "Yesil",
                    Height = 100,
                    Width = 50
                },
                new ProductFeature
                {
                    Id = 2,
                    ProductId = 2,
                    Color = "Kırmızı",
                    Height = 90,
                    Width = 40
                }
                
                );
        }
    }
}
