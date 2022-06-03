using Task_11._05;

class Program
{
    private static Random rnd = new Random();
    private static List<Product> listProducts = new List<Product>();
    static void Main(string[] args)
    {
        GenerateListData();
        Console.WriteLine("Весь список продуктов:");
        OutputList(listProducts);
        var averagePrice = GetAveragePrice(listProducts);
        Console.WriteLine($"Список продуктов ниже средней цены({averagePrice}$):");
        OutputList(listProducts.FindAll(x => x.Price < averagePrice));
        Console.WriteLine("Список продуктов со сроком годности больше недели:");
        OutputList(listProducts.FindAll(x => x.DateStart.Subtract(DateTime.Now).Days > 7));
        Console.WriteLine("Самый дорогой продукт:");
        OutputList(listProducts.FindAll(x => x.Price == listProducts.Max(x => x.Price)));
    }
    private static double GetAveragePrice(List<Product> list)
    {
        return list.Sum(x => x.Price) / list.Count;
    }

    private static void GenerateListData()
    {
        for (int i = 1; i <= 10; i++)
        {
            var name = "Продукт " + i;
            var startDate = new DateTime(2022, 5, 1).AddDays(rnd.Next(10, 30));
            var expiration = rnd.Next(3, 30);
            var price = rnd.Next(2, 100);
            listProducts.Add(new Product(name, startDate, expiration, price));
        }
    }
    private static void OutputList(List<Product> list)
    {
        Console.WriteLine();
        if (list.Count > 0)
        {
            Console.WriteLine(" Наименование    | Дата производства | Срок годности(д.) | Цена   | Годен до");
            Console.WriteLine("______________________________________________________________________________");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("______________________________________________________________________________");
        }
        else
        {
            Console.WriteLine("Список пуст.");
        }
        Console.WriteLine();
    }
}
