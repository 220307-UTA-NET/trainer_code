using System;
using System.Collections.Generic;
using System.IO;

namespace ClassesOOP
{
    class Square
    {
        public int numberOfSides;
        private double perimiter;
        double sideLength; // { get; set; } "Shorthand" way to write simple getter and setter methods for a field.
        double area;

        public Square()
        {
            this.numberOfSides = 4;
            this.sideLength = 1.5;
            setCalcPerimiter(this.numberOfSides, this.sideLength);
            setCalcArea(this.sideLength);
        }

        void setCalcPerimiter(int NumberSides, double Length)
        {
            this.perimiter = ( NumberSides * Length );
        }

        void setCalcArea(double length)
        {
            this.area = ( length * length );
        }

        // Getter - is a method that returns the value of a private (or otherwise) member
        public double getPerimiter()
        {
            return this.perimiter;
        }
        
        // Setter - is a metod that sets the value of a private (or otherwise) member
        public void setPerimiter( double Perimiter)
        {
            this.perimiter = Perimiter;
        }

    }
}