using System;
using System.Collections.Generic;
using System.IO;

namespace FileInteraction
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an array of strings to save.
            string[] text = {"Hey", "Hi there!", "What's up?"};

            // echo "text" >> ./filename.txt 
            // take this string "text", convert it to a stream of data
            // > or >> is a stream redirect, and we redirect to a target file

            // hold the file path in memory as a string
            string path = @".\TestFile.txt";
            
            // Test if the taget file exists yet
            if ( ! File.Exists(path) ) //if no
            {
                // Create and and write to the file
                File.WriteAllLines(path, text);
            }

            else //if yes
            {
                // Open and append to the file
                File.AppendAllLines(path, text);
            }

            // reading from target file to an array of strings called readText
            string[] readText = File.ReadAllLines(path);

            foreach (string s in readText)
            {
                Console.WriteLine(s);
            }

            Person SillyGuy = new Person("Zhixin", 65.4, 21);
            Console.WriteLine(SillyGuy.name);
            Console.WriteLine("SillyGuy is " + SillyGuy.age + " years old.");
            SillyGuy.GrowUp();
            Console.WriteLine("SillyGuy is " + SillyGuy.age + " years old.");

            Person Rich = new Person("Rich", 55.5);
            Console.WriteLine(Rich.name + " is " + Rich.age + " years old.");

            Console.WriteLine("Enter the name of the new person: ");
            Person newPerson = new Person();
            Console.WriteLine(newPerson.name);
            Console.WriteLine(newPerson.height);
            Console.WriteLine(newPerson.age);
            newPerson.GrowUp();
            Console.WriteLine(newPerson.age);
        }
    }
}