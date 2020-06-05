using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductRepo
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductsBrandAsync();
        Task<IReadOnlyList<ProductType>> GetProductsTypeAsync();
        Task<IReadOnlyList<Genre>> GetGenresAsync();
        Task<IReadOnlyList<Rating>> GetRatingsAsync();
    }
}
