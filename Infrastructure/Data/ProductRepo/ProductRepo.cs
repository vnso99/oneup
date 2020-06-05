using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entites;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.ProductRepo
{
    public class ProductRepo : IProductRepo
    {
        private readonly StoreContext _context;

        public ProductRepo(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Genre>> GetGenresAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .Include(p => p.Genre)
                .Include(p => p.Rating)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .Include(p => p.Genre)
                .Include(p => p.Rating)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductsBrandAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductsTypeAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<IReadOnlyList<Rating>> GetRatingsAsync()
        {
            return await _context.Ratings.ToListAsync();
        }
    }
}
