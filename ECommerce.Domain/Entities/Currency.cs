namespace ECommerce.Domain.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal MainRate { get; set; }
        public bool IsMain { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();

        public static Currency Create(string name, decimal mainRate, bool isMain)
        {
            return new Currency
            {
                Name = name,
                MainRate = mainRate,
                IsMain = isMain
            };
        }

        public void Update(string name, decimal mainRate, bool isMain)
        {
            Name = name;
            MainRate = mainRate;
            IsMain = isMain;
        }
    }
}
