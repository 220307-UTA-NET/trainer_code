namespace ClassesOOP
{
    class Triangle
    {
        //Fields
        int numberOfSides;
        int sideA;
        int sideB;
        int sideC;
        int numberOfAngles;
        double angleX;
        double angleY;
        double angleZ;


        //Constructor
        public Triangle()
        {
            this.numberOfSides = 3;
            this.numberOfAngles = 3;
        }

        public Triangle(int A)
        {
            // Defined Equlateral triangle
            this.numberOfAngles = 3;
            this.numberOfSides = 3;
            this.sideA = A;
            this.sideB = A;
            this.sideC = A;
        }

        public Triangle(int A, int B)
        {
            // Defined Isosceles triangle
            this.numberOfAngles = 3;
            this.numberOfSides = 3;
            this.sideA = A;
            this.sideB = B;
            this.sideC = A;
        }

        public Triangle(int A, int B, int C)
        {
            this.numberOfAngles = 3;
            this.numberOfSides = 3;
            this.sideA = A;
            this.sideB = B;
            this.sideC = C;

            if ((this.sideA >= this.sideB) && (this.sideA >= this.sideC))
            {
                if (this.sideA > (this.sideB + this.sideC))
                {
                    throw new Exception();
                }
            }
            else if ((this.sideB >= this.sideA) && (this.sideB >= this.sideC))
            {
                if (this.sideB > (this.sideA + this.sideC))
                {
                    throw new Exception();
                }
            }
            else if ((this.sideC >= this.sideA) && (this.sideC >= this.sideB))
            {
                if (this.sideC > (this.sideA + this.sideB))
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new Exception();
                //not a triangle
                //none are true, no side is longer than the others.
            }



            // any side may not be equal to or greater than the sum of the other two sides
        }

        public Triangle(double A, double B, double C)
        {
            this.numberOfAngles = 3;
            this.numberOfSides = 3;
            this.sideA = (int)A;                // explicit casting
            this.sideB = Convert.ToInt32(B);    // explicit conversion
            this.sideC = Convert.ToInt32(C);

            // Floor and Cieling - Rounding loose a level of precision
            // if we round up to the next value, we are taking the cieling
            // if we round down, we are taking the floor

            // explicit casting takes the floor, while Convert.to*Whatever*() performs a more traditional rounding.

            int[] sides = {this.sideA, this.sideB, this.sideC};
            Array.Sort(sides);

            if (sides[2] !> (sides[1]+sides[0]))
            {
                throw new Exception();
            }
        }

        // Polymorphism - Overloading - overloading a method or constructor
        // create a new definition for a method, that is differentiated based on the parameters.

        //Methods
        public int Perimiter()
        {
            int perimiter = this.sideA + this.sideB + this.sideC;
            return perimiter;
        }
    }
}