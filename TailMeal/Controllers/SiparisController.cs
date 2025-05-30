using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TailMeal.Data;
using TailMeal.Models;

namespace TailMeal.Controllers;

public class SiparisController : Controller
{
    
    // GET
    public IActionResult Tamamla()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Tamamla(Models.Siparis model)
    {
        if (ModelState.IsValid)
        {
            // Ödeme türüne göre işlemler burada yapılır
            // Veritabanına sipariş ekleme vs.

            return RedirectToAction("Tesekkur");
        }

        return View(model);
    }

    [Authorize]
    public async Task<IActionResult> Tesekkur()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
            return RedirectToAction("Login", "Account");

        // Sepeti temizle
        var sepetUrunleri = _context.SepetItems.Where(s => s.UserId == user.Id);
        _context.SepetItems.RemoveRange(sepetUrunleri);
        await _context.SaveChangesAsync();

        return View();
    }
    
    
    
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
   
    public SiparisController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
}