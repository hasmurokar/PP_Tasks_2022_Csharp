namespace IndividualTask
{
    public class Labirint
    {
        private int[,] _Labirint;
        private Player Player;
        private int Size;
        private int FinishX;
        private int FinishY;
        private static Random rnd = new Random();
        public Labirint()
        {
            _Labirint = new int[,] { };
            Player = new Player();
            Size = 0;
            FinishX = 0;
            FinishY = 0;
        }
        
        public void SetSettings(int size)
        {
            Size = size;
            Player = new Player(size / 2, size / 2, '@');
            GenerateLabirint();
        }

        public void StartGame()
        {
            while (true)
            {
                DrawLabirint();
                ConsoleKeyInfo ki = Console.ReadKey();
                if (ki.Key == ConsoleKey.LeftArrow && _Labirint[Player.PositionY, Player.PositionX - 1] == 0) Player.PositionX--;
                if (ki.Key == ConsoleKey.RightArrow && _Labirint[Player.PositionY, Player.PositionX + 1] == 0) Player.PositionX++;
                if (ki.Key == ConsoleKey.UpArrow && _Labirint[Player.PositionY-1, Player.PositionX] == 0) Player.PositionY--;
                if (ki.Key == ConsoleKey.DownArrow && _Labirint[Player.PositionY+1, Player.PositionX] == 0) Player.PositionY++;
                if (Player.PositionX == FinishY && Player.PositionY == FinishX)
                {
                    Gameover();
                    break;
                }
            }
        }

        private void DrawLabirint()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            for (int i = 0; i < _Labirint.GetLength(0); i++)
            {
                for (int j = 0; j < _Labirint.GetLength(1); j++)
                {
                    if (i == FinishX && j == FinishY) { DrawFinish(); continue; }
                    if (_Labirint[i, j] == 0) DrawRoad();
                    if (_Labirint[i, j] == 1) DrawWall();
                    if (_Labirint[i, j] == 2) DrawBorder();
                }
                Console.WriteLine();
            }
            DrawPlayer();
        }

        private void DrawPlayer()
        {
            Console.CursorVisible = false;
            Console.CursorLeft = Player.PositionX * 2;
            Console.CursorTop = Player.PositionY;
            PaintColor(1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(Player.Cursor);
            Console.BackgroundColor = ConsoleColor.Black;
        }
        private void DrawBorder()
        {
            PaintColor(3);
            Console.Write("# ");
        }
        private void DrawFinish()
        {
            PaintColor(0);
            Console.Write("F ");
        }
        private void DrawRoad()
        {
            PaintColor(1);
            Console.Write(". ");
        }
        private void DrawWall()
        {
            PaintColor(2);
            Console.Write("# ");
        }
        private void GenerateNoise()
        {
            for (int i = 0; i < _Labirint.GetLength(0); i++)
            {
                for (int j = 0; j < _Labirint.GetLength(1); j++)
                {
                    _Labirint[i, j] = rnd.Next(0, 3) == 1 ? 0 : 1;
                }
            }
        }
        private void CreateBorders()
        {
            for (int i = 0; i < _Labirint.GetLength(0); i++)
            {
                _Labirint[i, 0] = 2;
                _Labirint[i, _Labirint.GetLength(1) - 1] = 2;
            }
            for (int i = 0; i < _Labirint.GetLength(1); i++)
            {
                _Labirint[0, i] = 2;
                _Labirint[_Labirint.GetLength(0) - 1, i] = 2;
            }
        }
        private void GenerateLabirint()
        {
            _Labirint = new int[Size + 2, Size + 2];
            GenerateNoise();
            _Labirint[Player.PositionX, Player.PositionY] = 0;
            GenerateRightWay();
            CreateBorders();
        }

        private void GenerateRightWay()
        {
            int y = Player.PositionY;
            int x = Player.PositionX;
            var directionX = rnd.Next(0, 2) == 1 ? 1 : -1;
            var directionY = rnd.Next(0, 2) == 1 ? 1 : -1;
            while (true)
            {
                if (x == Size || x < 2 || y == Size || y < 2) break;
                if (rnd.Next(0, 2) == 0)
                {
                    x += directionX;
                    _Labirint[x, y] = 0;
                }
                else
                {
                    y += directionY;
                    _Labirint[x, y] = 0;
                }
                SetupFinish(x, y);
            }
        }

        private void SetupFinish(int x, int y)
        {
            FinishX = x;
            FinishY = y;
        }
        private void Gameover()
        {
            Console.Clear();
            Console.WriteLine("ИГРА ОКОНЧЕНА! ВЫ ПРОШЛИ ЛАБИРИНТ!");
        }
        private void PaintColor(int idColor)
        {
            switch (idColor)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    break;
            }
        }
    }
}
