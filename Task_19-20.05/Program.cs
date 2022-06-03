using Task_19_20._05;

class Program
{
    private static Random rnd = new Random();
    static void Main(string[] args)
    {
        GuideControl();
        RunGame();
    }

    private static void RunGame()
    {
        var kW = new KeyBoardMaster();
        kW.wKeyPressedEvent += ButtonW_Click;
        kW.sKeyPressedEvent += ButtonS_Click;
        kW.aKeyPressedEvent += ButtonA_Click;
        kW.dKeyPressedEvent += ButtonD_Click;
        kW.fKeyPressedEvent += ButtonF_Click;
        var switcher = true;
        while (switcher)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.W:
                    kW.WKeyPressedEvent();
                    break;
                case ConsoleKey.S:
                    kW.SKeyPressedEvent();
                    break;
                case ConsoleKey.A:
                    kW.AKeyPressedEvent();
                    break;
                case ConsoleKey.D:
                    kW.DKeyPressedEvent();
                    break;
                case ConsoleKey.F:
                    kW.FKeyPressedEvent();
                    break;
                case ConsoleKey.Escape:
                    switcher = false;
                    return;
                default:
                    break;
            }
        }
    }

    private static void GuideControl()
    {
        Console.WriteLine("Управление: ");
        Console.WriteLine("W - вверх");
        Console.WriteLine("S - вниз");
        Console.WriteLine("A - влево");
        Console.WriteLine("D - вправо");
        Console.WriteLine("F - вскопать землю");
        Console.WriteLine("Для выхода нажмите ESC");
    }

    private static void RandomMeetEnemy()
    {
        if(rnd.Next(0, 2) == 1)
        {
            Console.WriteLine("Вы встретили врага!");
            Shoot();
        }
    }
    private static void Shoot()
    {
        Console.Write("Выстрел!");
        if (rnd.Next(0, 2) == 1)
        {
            Console.WriteLine($"Вы попали! Враг повержен! Вы нашли {rnd.Next(10, 50)} монет");
        }
        else
        {
            Console.WriteLine("Промах! Враг убежал в страхе.");
        }
    }
    private static void ButtonF_Click()
    {
        if (rnd.Next(0, 2) == 1)
        {
            Console.WriteLine($"\nВы нашли сундук! В нем было {rnd.Next(1, 100)} золотых монет.");
        }
        else
        {
            Console.WriteLine("\nВы не нашли сундука.");
        }
    }
    private static void ButtonW_Click()
    {
        Console.WriteLine($"\nДвижение вверх на {rnd.Next(1, 10)} метров.");
        RandomMeetEnemy();
    }
    private static void ButtonS_Click()
    {
        Console.WriteLine($"\nДвижение вниз на {rnd.Next(1, 10)} метров.");
        RandomMeetEnemy();
    }
    private static void ButtonA_Click()
    {
        Console.WriteLine($"\nДвижение влево на {rnd.Next(1, 10)} метров.");
        RandomMeetEnemy();
    }
    private static void ButtonD_Click()
    {
        Console.WriteLine($"\nДвижение вправо на {rnd.Next(1, 10)} метров.");
        RandomMeetEnemy();
    }
}