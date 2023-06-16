namespace Farmfresh.Repositories.Entities;

public class Product
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public byte[] Photo { get; set; }
    
    public Category Category { get; set; }
}