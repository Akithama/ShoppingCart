using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Data.Infrastructure.Interfaces;
using ShoppingCart.Data.Models;

namespace ShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private IProductRepository productRepository;

        public ProductController(IProductRepository repo)
        {
            productRepository = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = productRepository.GetAll().ToList();
            if (products.Count != 0)
                return products;

            return NotFound("Products Not Found");
        }

        [HttpGet("category")]
        public ActionResult<IEnumerable<Product>> GetProductsByCategoryId(string categoryId)
        {
            int catId = Convert.ToInt32(categoryId);
            var products = productRepository.GetProductsByCategoryId(catId);
            if (products.Count != 0)
                return products;

            return NotFound("Products Not Found");
        }
    }
}
