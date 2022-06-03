namespace Task_11._05
{
    public class Product
    {
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public int ExpirationDate { get; set; }
        public int Price { get; set; }

        public Product(string name, DateTime dateStart, int expirationDate, int price)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            DateStart = dateStart;
            ExpirationDate = expirationDate;
            Price = price;
        }

        public DateTime FindEndDate()
        {
            return DateStart.AddDays(ExpirationDate);
        }

        public override string ToString()
        {
            return $" {Name,-15} | {DateStart.ToString("d"),-17} | {ExpirationDate,-17} | {Price,5}$ | {FindEndDate():d}";
        }
    }
}
