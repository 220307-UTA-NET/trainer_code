using System;
using System.Collections.Generic;
using System.IO;

namespace ClassesOOP
{
    class Program
    {
        static void Main()
        {
            // The program starts here...
            Square squareOne = new Square();

            Console.WriteLine(squareOne.numberOfSides);
            Console.WriteLine(squareOne.getPerimiter());
        }
    }
}