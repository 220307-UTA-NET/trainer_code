//Guessing game - play a quick guessing game with the computer.
Console.WriteLine("Welcome to the Guessing Game!");

while ( true )
{
	Console.WriteLine("Enter the number for the menu option of your choice: ");
	Console.WriteLine("[1] - Play the guessing game");
	Console.WriteLine("[0] - Exit");

	int menu = int.Parse(Console.ReadLine());

	switch ( menu )
	{
		case 0:
			return;
	
		case 1:
			﻿var rand = new Random(); //Creates the random number
			int secret = rand.Next(11); //Limit the random number from 0-10, then save as int to "secret"
	
			while ( true ) //Begin the loop!
			{
				Console.WriteLine("Guess a number between 0 and 10: "); //Prompt the user
				int input = int.Parse(Console.ReadLine()); //Read user input, parsing to an int, then save as int "input"
				Console.WriteLine("You guessed: " + input); //Confirming the input with the user
	
				if ( input == secret ) //If the user guessed the secret number (if input is equal to secret)
				{
					Console.WriteLine("Congratulations! You've correctly guessed the secret number!");
					break; //break out of the while loop!
				}
	
				else if ( input > secret ) //If the user guessed too high (if input is greater than secret)
				{
					Console.WriteLine("Uh oh, you've guessed too high!");
				}
	
				else //Else (the only possible option left is that the user entered a number smaller than secret)
				{
					Console.WriteLine("Mhh, looks like you've guessed too low.");
				}
			}
	
			Console.WriteLine("Good game, thanks for playing!");
			break;
	
		default:
			Console.WriteLine("Bad input: Input was not a valid option.");
			break;
	}
}
