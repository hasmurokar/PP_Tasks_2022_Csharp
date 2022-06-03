using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_12_14._05
{
    public class Triangle : IShape
    {
        private double Side1 { get; }
        private double Side2 { get; }
        private double Side3 { get; }
        
        public Triangle(double side1, double side2, double side3)
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }
        public double Perimetr()
        {
            return Side1 + Side2 + Side3;
        }

        public double Area()
        {
            var P = Perimetr() / 2;
            return Math.Sqrt(P * (P - Side1) * (P - Side2) * (P - Side3));
        }

        public override string ToString()
        {
            return $"Треугольник - {Side1}  {Side2}  {Side3}";
        }
    }
}
