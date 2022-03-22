using System;

namespace Inheritance
{
    class Program
    {
        static void Main()
        {
            Base myBase = new Base();
            myBase.Speak();

            Derived myDerived = new Derived();

            Console.WriteLine("myBase.baseString = " + myBase.baseString);

            Console.WriteLine("myDerived.derivedString = " + myDerived.derivedString);
            Console.WriteLine("myDerived.baseString = " + myDerived.baseString);
            myDerived.Speak();
            myDerived.Speak("new string");

        }
    }
}