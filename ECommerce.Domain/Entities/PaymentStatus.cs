namespace ECommerce.Domain.Entities
{
    public class PaymentStatus
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Payment> Payments { get; set; } = new List<Payment>();

        public static PaymentStatus Create(string name)
        {
            return new PaymentStatus
            {
                Name = name
            };
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
