namespace Inheritance
{
    public class Derived : Base
    {
        // Fields
        public string derivedString;
        
        // Constructor
        public Derived()
        {
            this.derivedString = "Derived";
        }

        // Methods


        public override void Speak() // "override" is required to extend or modify the virtual method
        {
            Console.WriteLine("I am a Derived type object.");
        }

        // All override members...
        // - Provide a new implemetation of an inherited method
        // - must have the same signature as the inherited method 
        //      (signature is made of the return type, method name , and parameters)
        // - both methods must be virtual or override
        // - must NOT use static or virtual to override a method

        public override void Speak(string s)
        {
            Console.WriteLine("The Speak method was passed: " + s);
        }
    }
}