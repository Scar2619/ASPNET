using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Testing.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Testing.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repo;

        public ProductController(IProductRepository repo)
        {
            this.repo = repo;
        }

        //GET: /<controller>/
        public IActionResult Index()
        {
            var products = repo.GetAllProducts();
            return View(products);
        }

        //views one product from table based on ID, the product passed into view method will refer to the Model we work with inside viewproduct
        public IActionResult ViewProduct(int id)
        {
            var product = repo.GetProduct(id);
            return View(product);
        }
    }
}

