namespace FunctionTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program starting: ");

            NewFunction();

            Console.WriteLine("Currently running in Main()");

            PrintValue( 6 );

            string returned;
            returned = GetString();
            Console.WriteLine(returned);


            // for ( int i = 0; i < 3; i++ )
            // {
            //     for ( int j = 0; j < 2; j++ )
            //     {
            //        NewFunction(); 
            //     }
            // }

            // int i, j;

            // for ( i = 2; i < 100; i++ )
            // {
            //     for ( j = 2; j <= (i/j); j++ )
            //     {
            //         if ( (i%j) == 0 ) // if ( !(i%j) )
            //         {
            //             break; // if factor found, not prime
            //         }
            //     }
                
            //     if ( j > (i/j) )
            //     {
            //         Console.WriteLine( i + " is prime" );
            //     }                
            // }
   


            string newstring = "abcdefgab";
            for ( int s = 0; s < newstring.Length; s++ )
            {
                for ( int t = s+1; t < newstring.Length; t++ )
                {
                    if ( newstring[s] == newstring[t])
                    {
                        Console.WriteLine(newstring[s] + " is repeated in the alphabet.");
                    }
                }
            }



            
        }

        static string GetString()
        {
            string x = "Hi There!";
            return x;
        }

        static void NewFunction()
        {
            Console.WriteLine("Currently running NewFunction()");
        }

        static void PrintValue(int num)
        {
            Console.WriteLine("PrintValue was passed: " + num);
        }

    }
}