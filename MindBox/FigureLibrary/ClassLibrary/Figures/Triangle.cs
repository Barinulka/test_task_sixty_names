using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Figures
{
    public class Triangle : Lib
    {

        public double A {  get; set; }  
        public double B { get; set; }   
        public double C { get; set; }   

        public Triangle()
        {

            bool isWhile = true;


            while (isWhile)
            {
                Console.Write("Введите значение стороны A: ");
                double sideA = double.Parse(Console.ReadLine());
                Console.Write("Введите значение стороны B: ");
                double sideB = double.Parse(Console.ReadLine());
                Console.Write("Введите значение стороны C: ");
                double sideC = double.Parse(Console.ReadLine());

                if (isIsset(sideA, sideB, sideC))
                {
                    A = sideA; B = sideB; C = sideC;
                    isWhile = false;
                }
                else
                {
                    Console.WriteLine("\nТреугольник не может быть получен!");
                    Console.WriteLine($"Одна сторона больше суммы двух других сторон\nA = {sideA} B = {sideB} C = {sideC}\n");
                }
            }


            if (isRightTriangle())
            {
                Console.WriteLine($"\nТреугольник A = {A}, B = {B}, C = {C} прямоугольный");
            }
        }

        /*
            * Удобнее будет найти площаль треугольника по формуле Герона 
            * result = √(p * (p - a) * (p - b) * (p - c))
            * где p - полупериметр, a,b,c - стороны треугольника
        */
        public override double Area()
        {
            double p, result;
            
            p = (A + B + C) / 2;

            result = Math.Round(Math.Sqrt(p * (p - A) * (p - B) * (p - C)), 2);

            return result;
        }

        private bool isRightTriangle()
        {
            bool result = false;
            
            if ((A * A == B * B + C * C) || (B * B == A * A + C * C) || (C * C == A * A + B * B))
            {
                result = true;
            }

            return result;
        }

        private bool isIsset(double sideA, double sideB, double sideC)
        {
            bool result = false;

            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                return false;
            }

            if (((sideA + sideB) > sideC) && ((sideB + sideC) > sideA) && ((sideA + sideC) > sideB))
            {
                result = true;
            }

            return result;
        }
    }
}
