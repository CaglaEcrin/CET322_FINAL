using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TailMeal.Data;
using TailMeal.Models;
using Microsoft.EntityFrameworkCore;

namespace TailMeal.Controllers;
[Authorize]
public class SepetController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public SepetController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> SepeteEkle(int productId, int quantity = 1)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
            return RedirectToAction("Login", "Account");

        var mevcutUrun = await _context.SepetItems
            .FirstOrDefaultAsync(s => s.ProductId == productId && s.UserId == user.Id);

        if (mevcutUrun != null)
        {
            // Aynı ürün sepette varsa adeti artır
            mevcutUrun.Quantity += quantity;
            _context.SepetItems.Update(mevcutUrun);
        }
        else
        {
            // Yeni ürün olarak ekle
            var sepet = new Sepet
            {
                ProductId = productId,
                UserId = user.Id,
                Quantity = quantity, // ✅ düzeltme burada!
                EklenmeTarihi = DateTime.Now
            };
            await _context.SepetItems.AddAsync(sepet);
        }

        await _context.SaveChangesAsync();
        TempData["SuccessMessage"] = $"{quantity} adet ürün sepetinize eklendi!";

        return RedirectToAction("Index", "Products");
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
            return RedirectToAction("Login", "Account");

        var sepet = _context.SepetItems
            .Include(s => s.Product)
            .Where(s => s.UserId == user.Id)
            .ToList();

        return View(sepet);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCartCount()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
            return Json(new { count = 0 });

        var count = await _context.SepetItems
            .Where(s => s.UserId == user.Id)
            .SumAsync(s => s.Quantity);

        return Json(new { count });
    }
    [HttpPost]
    public async Task<IActionResult> Sil(int id)
    {
        var sepetItem = await _context.SepetItems.FindAsync(id);
        if (sepetItem == null)
        {
            TempData["ErrorMessage"] = "Ürün bulunamadı veya zaten silinmiş.";
            return RedirectToAction("Index");
        }

        _context.SepetItems.Remove(sepetItem);
        await _context.SaveChangesAsync();
        
        TempData["ErrorMessage"] = "Ürün sepetinizden çıkarıldı!"; 


        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Odeme()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Odeme(Models.Siparis model)
    {
        if (!ModelState.IsValid)
            return View(model);

        // Ödeme işlemi / sipariş kaydı burada yapılabilir
        // Örneğin: modelden bilgileri al, veritabanına kaydet

        return RedirectToAction("Tesekkur");
    }

    public IActionResult Tesekkur()
    {
        return View();
    }

}