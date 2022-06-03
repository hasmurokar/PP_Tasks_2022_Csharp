using Task_10._05;

class Program
{
    private static Random rnd = new Random();
    private static List<HockeyPlayer> listHockeyPlayers = new List<HockeyPlayer>();
    static void Main(string[] args)
    {
        GenerateListData();

        Console.WriteLine("Весь список:");
        OutputList(listHockeyPlayers);

        var averageAge = listHockeyPlayers.Sum(p => p.Age) / listHockeyPlayers.Count;
        Console.WriteLine($"Средний возраст: {averageAge}");

        Console.WriteLine("Хоккеисты, возраст которых больше 18 лет.");
        OutputList(listHockeyPlayers.Where(p => p.Age > 18).ToList());
    }

    private static void GenerateListData()
    {
        for (int i = 1; i <= 15; i++)
        {
            var name = "Рита К." + i;
            var age = rnd.Next(16, 24);
            var countGame = rnd.Next(5, 30);
            var countGoal = rnd.Next(1, 50);
            listHockeyPlayers.Add(new HockeyPlayer(name, age, countGame, countGoal));
        }
    }

    private static void OutputList(List<HockeyPlayer> list)
    {
        Console.WriteLine();
        if (list.Count > 0)
        {
            Console.WriteLine(" Фамилия         | Возраст | Количество игр | Количество заброшенных шайб");
            Console.WriteLine("__________________________________________________________________________");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("__________________________________________________________________________");
        }
        else
        {
            Console.WriteLine("Список пуст.");
        }
        Console.WriteLine();
    }
}
