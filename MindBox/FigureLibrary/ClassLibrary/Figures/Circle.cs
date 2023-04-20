using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Figures
{
    public class Circle : Lib
    {

        public double r { get; set; }

        public Circle()
        {

            Console.WriteLine("Введите значение радиуса: ");
            double radius = double.Parse(Console.ReadLine());

            if (radius < 0)
            {
                radius = 0;
            }

            r = radius;
        }

       
        public override double Area()
        {
            double result;

            result = Math.Round(Math.PI * (r * r), 2);

            return result;
        }

    }
}
