namespace ECommerce.Domain.Entities;

public class PaymentMethod
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public static PaymentMethod Create(string name)
    {
        return new PaymentMethod
        {
            Name = name
        };
    }

    public void Update(string name)
    {
        Name = name;
    }
}
