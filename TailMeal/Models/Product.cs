namespace TailMeal.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }         // Örn: "Tavuklu Kedi Maması"
    public string Category { get; set; }     // "Cat" veya "Dog"
    public string Flavor { get; set; }       // "Tavuk", "Hindi", "Balık"
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public int Quantity { get; set; }
    public bool? ShowOnHomePage { get; set; } = true;

}