using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entites
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public int ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }

        public int ProductBrandId { get; set; }

        public ProductBrand ProductBrand { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public int RatingId { get; set; }

        public Rating Rating { get; set; }

        public string NumberOfPlayers { get; set; }
    }
}
