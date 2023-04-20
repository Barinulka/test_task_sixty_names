using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Library
    {
        private Lib? _lib;

        public void setFigure(Lib figure)
        {
            _lib = figure;
        }

        public double Area()
        {
            return _lib.Area();
        }

    }
}
