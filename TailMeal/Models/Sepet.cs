using Microsoft.AspNetCore.Identity;

namespace TailMeal.Models;

public class Sepet
{
    public int Id { get; set; }

    public string UserId { get; set; } // Giriş yapan kullanıcıyla ilişki
    public IdentityUser User { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int Quantity { get; set; }
    public DateTime EklenmeTarihi { get; set; } 
    

}