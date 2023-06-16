namespace Farmfresh.Models;

public class Product
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public IFormFile Photo { get; set; }
    public string PhotoUrl { get; set; }
    
    public Category Category { get; set; }
}