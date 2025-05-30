namespace TailMeal.Models;

public class Blog
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Excerpt { get; set; } // kısa açıklama
    public string Content { get; set; }
    public string ImageUrl { get; set; }
    public string Category { get; set; }
    public DateTime CreatedAt { get; set; }
}
