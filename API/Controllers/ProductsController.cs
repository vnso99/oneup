using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entites;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly IProductRepo _repo;

        public ProductsController(IProductRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repo.GetProductsAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _repo.GetProductByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task <ActionResult<IReadOnlyList<ProductBrand>>> GetProductsBrands()
        {
            var brands = await _repo.GetProductsBrandAsync();

            return Ok(brands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductsTypes()
        {
            var types = await _repo.GetProductsTypeAsync();

            return Ok(types);
        }

        [HttpGet("genres")]
        public async Task<ActionResult<IReadOnlyList<Genre>>> GetGenres()
        {
            var genres = await _repo.GetGenresAsync();

            return Ok(genres);
        }

        [HttpGet("ratings")]
        public async Task<ActionResult<IReadOnlyList<Rating>>> GetRatings()
        {
            var ratings = await _repo.GetRatingsAsync();

            return Ok(ratings);
        }
    }
}
