using Microsoft.AspNetCore.Mvc;
using TailMeal.Data; // senin namespace'in farklıysa düzelt
using TailMeal.Models; // Blog modeli buradaysa

public class BlogController : Controller
{
    private readonly ApplicationDbContext _context;

    public BlogController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var blogs = _context.Blogs.OrderByDescending(b => b.CreatedAt).ToList();
        return View(blogs);
    }
}

