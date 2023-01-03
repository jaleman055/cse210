using System;
/*Add a loop that keeps looping as long as the guess does not match the magic number.
At this point, the user should be able to keep playing until they get the correct answer.
Instead of having the user supply the magic number, generate a random number from 1 to 100.

Stretch Challenge
Keep track of how many guesses the user has made and inform them of it at the end of the game.

After the game is over, ask the user if they want to play again. Then, loop back and play the whole game again and continue this loop as long as they keep saying "yes".
*/


class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int magicNumber = random.Next(1, 101);
        int guess = 0;
        int guessCount = 0;
        bool isCorrect = false;

        while (!isCorrect)
        {
            Console.WriteLine("Guess a number between 1 and 100");
            guess = int.Parse(Console.ReadLine());
            guessCount++;

            if (guess == magicNumber)
            {
                isCorrect = true;
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Too high");
            }
            else
            {
                Console.WriteLine("Too low");
            }
        }

        Console.WriteLine("You guessed it! It took you " + guessCount + " guesses.");
        
    }
}