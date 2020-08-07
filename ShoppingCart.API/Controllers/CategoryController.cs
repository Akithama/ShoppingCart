using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Bll.Service.Interface;
using ShoppingCart.Data.Infrastructure.Interfaces;
using ShoppingCart.Data.Models;

namespace ShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository repo)
        {
            categoryRepository = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            var categories= categoryRepository.GetAll().ToList();
            if (categories.Count != 0)
                return categories;

            return NotFound("Categories Not Found");
        }
    }
}
