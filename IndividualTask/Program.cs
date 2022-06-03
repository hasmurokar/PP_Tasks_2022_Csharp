using IndividualTask;

class Program
{
    private static Labirint Labirint;
    private static int size;
    static void Main(string[] args)
    {
        RunGame();
    }
    private static void RunGame()
    {
        PrintDescription();
        Console.ReadKey();
        Console.Clear();
        SetupLabirint();
        Labirint.StartGame();
        SelectCommand();
    }

    private static void SelectCommand()
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1 - Повторить игру");
            Console.WriteLine("2 - Создать новый лабиринт");
            Console.WriteLine("3 - Выход");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    CreateLevel(size);
                    Labirint.StartGame();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    SetupLabirint();
                    Labirint.StartGame();
                    break;
                case ConsoleKey.D3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Неверная команда, повторите попытку");
                    break;
            }
        }
    }

    private static void PrintDescription()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("______________________________________");
        Console.WriteLine("Добро пожаловать в игру \"Лабиринт\"!");
        Console.WriteLine("Выход из лабиринта отмечен буквой F. Вы - это \'@\'");
        Console.WriteLine("Управление: ");
        Console.WriteLine("Вверх - стрелка вверх");
        Console.WriteLine("Вниз - стрелка вниз");
        Console.WriteLine("Влево - стрелка влево");
        Console.WriteLine("Вправо - стрелка вправо");
        Console.WriteLine("______________________________________");
        Console.WriteLine("Для начала игры нажмите любую клавишу...");
    }

    private static void SetupLabirint()
    {
        Console.WriteLine("Введите размер лабиринта(от 10 до 50):");
        while (true)
        {
            size = ParseInt();
            if (size < 10 || size > 50)
            {
                Console.WriteLine("Размер лабиринта некорректный, повторите попытку");
            }
            else break;
        }
        CreateLevel(size);
    }
    private static void CreateLevel(int size)
    {
        Labirint = new Labirint();
        Labirint.SetSettings(size);
    }
    public static int ParseInt()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int value)) { Console.ForegroundColor = ConsoleColor.Blue; return value; }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Некоррентный ввод. Повторите попытку...");
            Console.ForegroundColor = ConsoleColor.Blue;
        }
    }
}