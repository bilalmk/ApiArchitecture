using APIArchitecture.Entities;
using APIArchitecture.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class _CategoryController : Controller
    {
        public ICategoryRepository categoryRepository;
        public _CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("getAll")]
        public List<Category> Get()
        {
            var Category = categoryRepository.GetAll();
            return Category.ToList();
        }
    }
}
