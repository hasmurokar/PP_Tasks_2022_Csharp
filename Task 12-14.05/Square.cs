namespace Task_12_14._05
{
    public class Square: IShape  
    {
        private double Side { get; }
        
        public Square(double side)
        {
            Side = side;
        }

        public double Perimetr()
        {
            return Side * 4;
        }

        public double Area()
        {
            return Side * Side;
        }

        public override string ToString()
        {
            return $"Квадрат - {Side}";
        }
    }
}
