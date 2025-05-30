using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TailMeal.Models;
using Microsoft.AspNetCore.Mvc;
using TailMeal.Data;


namespace TailMeal.Controllers
{
    public class ProductsController : Controller
    {
        // Fake veri listesi (ileride veritabanına bağlanacağız)
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Tavuklu Kedi Maması", Category = "kedi", Flavor = "Tavuk", Price = 99.99m, ImageUrl = "/images/mama6.png" },
            new Product { Id = 2, Name = "Hindili Kedi Maması", Category = "kedi", Flavor = "Hindi", Price = 109.99m, ImageUrl = "/images/mama2.jpg" },
            new Product { Id = 3, Name = "Balıklı Köpek Maması", Category = "köpek", Flavor = "Balık", Price = 119.99m, ImageUrl = "/images/mama3.jpg" },
            new Product { Id = 4, Name = "Tavuklu Köpek Maması", Category = "köpek", Flavor = "Tavuk", Price = 89.99m, ImageUrl = "/images/mama4.jpg" },
            new Product { Id = 1, Name = "Tavuklu Kedi Maması", Category = "kedi", Flavor = "Tavuk", Price = 99.99m, ImageUrl = "/images/mama5.jpg" },
            new Product { Id = 2, Name = "Hindili Kedi Maması", Category = "kedi", Flavor = "Hindi", Price = 109.99m, ImageUrl = "/images/mama.jpg" },
            new Product { Id = 3, Name = "Balıklı Köpek Maması", Category = "köpek", Flavor = "Balık", Price = 119.99m, ImageUrl = "/images/mama.jpg" },
            new Product { Id = 4, Name = "Tavuklu Köpek Maması", Category = "köpek", Flavor = "Tavuk", Price = 89.99m, ImageUrl = "/images/mama2.jpg" }
        };

        
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string category)
        {
            var filtered = string.IsNullOrEmpty(category)
                ? _context.Products.Where(p=>p.ShowOnHomePage==true).ToList()
                : _context.Products.Where(p => p.ShowOnHomePage==true && p.Category.ToLower() == category.ToLower()).ToList();

            return View(filtered);
        }
        
        public IActionResult DenemePaketi(int id)
        {
            return View();
        }
        
        
    }    
    
}