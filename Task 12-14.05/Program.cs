using Task_12_14._05;

class Program
{
    private static List<IShape> shapes = new List<IShape>();
    static void Main(string[] args)
    {
        bool flag = true;
        Console.WriteLine("Интерфейс программы:");
        while (flag)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" 1 - Добавить треугольник.");
            Console.WriteLine(" 2 - Добавить квадрат.");
            Console.WriteLine(" 3 - Найти суммы периметров всех фигур.");
            Console.WriteLine(" 4 - Найти суммы площадей всех фигур.");
            Console.WriteLine(" 5 - Вывести все фигуры.");
            Console.WriteLine(" 6 - Сортировать фигуры по площади.");
            Console.WriteLine(" 7 - Cортировать фигуры по периметру.");
            Console.WriteLine(" C - Очистить консоль.");
            Console.WriteLine(" Q - Выход.");
            Console.ForegroundColor = ConsoleColor.Blue;
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    AddTriangle();
                    break;
                case ConsoleKey.D2:
                    AddSquare();
                    break;
                case ConsoleKey.D3:
                    FindPerimeters();
                    break;
                case ConsoleKey.D4:
                    FindAreas();
                    break;
                case ConsoleKey.D5:
                    Console.WriteLine("\nВсе фигуры:");
                    PrintShapes();
                    break;
                case ConsoleKey.D6:
                    Console.WriteLine("\nФигуры по площади:");
                    PrintShapes(SortByArea());
                    break;
                case ConsoleKey.D7:
                    Console.WriteLine("\nФигуры по периметру:");
                    PrintShapes(SortByPerimeter());
                    break;
                case ConsoleKey.C:
                    Console.Clear();
                    break;
                case ConsoleKey.Q:
                    flag = false;
                    break;
                default:
                    Console.WriteLine("\nНеверный ввод. Повторите попытку.");
                    break;
            }
        }
    }
    private static void AddTriangle()
    {
        Console.WriteLine("\nВведите длину стороны A треугольника:");
        var sideA = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите длину стороны B треугольника:");
        var sideB = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите длину стороны C треугольника:");
        var sideC = double.Parse(Console.ReadLine());
        shapes.Add(new Triangle(sideA, sideB, sideC));
        Console.WriteLine("Треугольник добавлен.");
    }
    private static void AddSquare()
    {
        Console.WriteLine("\nВведите длину сторонe квадрата:");
        var side = double.Parse(Console.ReadLine());
        shapes.Add(new Square(side));
        Console.WriteLine("Квадрат добавлен.");
    }
    private static void FindPerimeters()
    {
        var perimeters = shapes.Sum(shape => shape.Perimetr());
        Console.WriteLine($"\nСумма периметров всех фигур: {perimeters}");
    }
    private static void FindAreas()
    {
        var areas = shapes.Sum(shape => shape.Area());
        Console.WriteLine($"\nСумма площадей всех фигур: {areas}");
    }
    private static void PrintShapes()
    {
        foreach (var shape in shapes)
        {
            Console.WriteLine(shape);
        }
    }
    private static void PrintShapes(List<IShape> shapes)
    {
        foreach (var shape in shapes)
        {
            Console.WriteLine(shape);
        }
    }
    private static List<IShape> SortByArea()
    {
        return shapes.OrderBy(shape => shape.Area()).ToList();
    }
    private static List<IShape> SortByPerimeter()
    {
        return shapes.OrderBy(shape => shape.Perimetr()).ToList();
    }
}
