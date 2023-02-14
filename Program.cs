using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace exp_imp
{
    abstract class Figure
    {
        public abstract void Draw();
    }
    abstract class Quadrangle : Figure { }
    class Rectangle : Quadrangle
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public static implicit operator Rectangle(Square s) // неявное преобразования квадрата в прямоугольник
        {
            return new Rectangle { Width = s.Length * 2, Height = s.Length };
        }
        public override void Draw()
        {
            for (int i = 0; i < Height; i++, WriteLine())
            {
                for (int j = 0; j < Width; j++)
                {
                    Write("*");
                }
            }
            WriteLine();
        }
        public override string ToString()
        {
            return $"Rectangle: Width = {Width}, Height = {Height}";
        }
    }
    class Square : Quadrangle
    {
        public int Length { get; set; }
        public static explicit operator
        Square(Rectangle rect)
        {
            return new Square { Length = rect.Height };
        }
        public static explicit operator int(Square s) // возможна потеря данных поэтому пишем explicit
        {
            return s.Length;
        }
        public static implicit operator Square(int number)
        {
            return new Square { Length = number };
        }
        public override void Draw()
        {
            for (int i = 0; i < Length; i++, WriteLine())
            {
                for (int j = 0; j < Length; j++)
                {
                    Write("*");
                }
            }
            WriteLine();
        }
        public override string ToString()
        {
            return $"Square: Length = {Length}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle
            {
                Width = 5,
                Height = 10
            };
            Square square = new Square { Length = 7 };
            Rectangle rectSquare = square;
            WriteLine($"Неявное преобразование квадрата ({square}) к прямоугольнику.\n{rectSquare}\n");

            //rectSquare.Draw();

            Square squareRect = (Square)rectangle; //явное преобразование из прямоугольнка в квадрат
            WriteLine($"Явное преобразование прямоугольника ({rectangle}) к квадрату.\n{squareRect}\n");

            //squareRect.Draw();

            WriteLine("Введите целое число.");
            int number = int.Parse(ReadLine());
            Square squareInt = number;
            WriteLine($"Неявное преобразование целого ({number}) к квадрату.\n{squareInt}\n");

            //squareInt.Draw();

            number = (int)square;
            WriteLine($"Явное преобразование квадрата ({square}) к целому.\n{number}");
        }
    }
}
