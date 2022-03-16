namespace GuessingGame
{
	class Program
	{
		static void Main(string[] args)
		{
			//Guessing game - play a quick guessing game with the computer.
			Console.WriteLine("Welcome to the Guessing Game!");
			var rand = new Random();

			while ( true )
			{
				Console.WriteLine("Enter the number for the menu option of your choice: ");
				Console.WriteLine("[1] - Play the guessing game");
				Console.WriteLine("[2] - Math Challenge!");
				Console.WriteLine("[0] - Exit");

				int menu = int.Parse(Console.ReadLine());

				switch ( menu )
				{
					case 0:
						Console.WriteLine("Press Enter to continue.");
						Console.ReadLine();				
						Console.Clear();
						return;
				
					case 1:
						GuessingGame();
						break;
				
					case 2:
						AdditionChallenge();
						break;

					default:
						Console.WriteLine("Bad input: Input was not a valid option.");
						Console.WriteLine("Press Enter to continue.");
						Console.ReadLine();
						Console.Clear();
						break;
				}
			}
		}

		static void GuessingGame()
		{
			var rand = new Random(); //Creates the random number
			int secret = rand.Next(11); //Limit the random number from 0-10, then save as int to "secret"

			while ( true ) //Begin the loop!
			{
				Console.WriteLine("Guess a number between 0 and 10: "); //Prompt the user
				int input = int.Parse(Console.ReadLine()); //Read user input, parsing to an int, then save as int "input"
				Console.WriteLine("You guessed: " + input); //Confirming the input with the user

				if ( input == secret ) //If the user guessed the secret number (if input is equal to secret)
				{
					Console.WriteLine("Congratulations! You've correctly guessed the secret number!");
					Console.WriteLine("Press Enter to continue.");
					Console.ReadLine();
					Console.Clear();
					break; //break out of the while loop!
				}

				else if ( input > secret ) //If the user guessed too high (if input is greater than secret)
				{
					Console.WriteLine("Uh oh, you've guessed too high!");
					Console.WriteLine("Press Enter to continue.");
					Console.ReadLine();
					Console.Clear();
				}

				else //Else (the only possible option left is that the user entered a number smaller than secret)
				{
					Console.WriteLine("Mhh, looks like you've guessed too low.");
					Console.WriteLine("Press Enter to continue.");
					Console.ReadLine();
					Console.Clear();
				}
			}

			Console.WriteLine("Good game, thanks for playing!");
			Console.WriteLine("Press Enter to continue.");
			Console.ReadLine();
			Console.Clear();
		}

		static void AdditionChallenge()
		{
			var rand = new Random(); // Generating the random values for the problem
			int num1 = rand.Next(101);
			int num2 = rand.Next(101);

			int solution = num1 + num2; // Findng the correct solution

			Console.WriteLine("Welcome to the Addition Challenge!");
			
			while ( true )
			{
				Console.WriteLine("Your question is: ");
				Console.WriteLine( num1 + " + " + num2 + " = ?"); // "33 + 45"

				Console.WriteLine("Please enter your solution: ");
				int userGuess = int.Parse(Console.ReadLine()); // Accepting the users solution

				if ( solution == userGuess )
				{
					Console.WriteLine("You got it!");

					Console.WriteLine("Press Enter to continue.");
					Console.ReadLine();
					Console.Clear();

					break;
				}
				else
				{
					Console.WriteLine("Not quite, you were off by: " + Math.Abs( solution - userGuess ));
					Console.WriteLine("Press Enter to continue.");
					Console.ReadLine();
					Console.Clear();
				}
			}

		}
	}
}