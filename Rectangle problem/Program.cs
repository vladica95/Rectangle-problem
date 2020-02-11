using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangle_problem
{
    

    class Program
    {
        static void Main(string[] args)
        {
            String hello = "Go";
            while (hello == "Go")
            {
                RectangleBars RB = new RectangleBars();
                Console.WriteLine("Biggest area of rectangle is:");
                Console.WriteLine(RB.BiggestRectangle());
                Console.WriteLine("Enter '\\Go'\\ to enter new rectangle bars");
                hello =Console.ReadLine();
            }
        }
    }
}
