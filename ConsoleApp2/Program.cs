using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hangman();
        }

        static void NumberGuessing()
        {
            Random random = new Random();
            int numberToGuess = random.Next(1, 101); // Random number between 1 and 100
            int guess = 0;

            Console.WriteLine("Guess a number between 1 and 100:");

            while (guess != numberToGuess)
            {
                guess = int.Parse(Console.ReadLine());

                if (guess < numberToGuess)
                    Console.WriteLine("Too low! Try again.");
                else if (guess > numberToGuess)
                    Console.WriteLine("Too high! Try again.");
                else
                    Console.WriteLine("Congratulations! You guessed the number!");
            }
        }

        static void Hangman()
        {
            string[] words = { "apple", "banana", "orange" };
            Random random = new Random();
            string wordToGuess = words[random.Next(words.Length)];
            char[] guessedWord = new string('_', wordToGuess.Length).ToCharArray();
            int attempts = 6;

            while (attempts > 0 && new string(guessedWord) != wordToGuess)
            {
                Console.WriteLine($"Word: {new string(guessedWord)}");
                Console.WriteLine($"Attempts remaining: {attempts}");
                Console.Write("Guess a letter: ");
                char guess = Console.ReadLine()[0];

                bool correctGuess = false;
                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i] == guess)
                    {
                        guessedWord[i] = guess;
                        correctGuess = true;
                    }
                }

                if (!correctGuess)
                    attempts--;

                Console.Clear();
            }

            if (new string(guessedWord) == wordToGuess)
                Console.WriteLine($"Congratulations! You guessed the word: {wordToGuess}");
            else
                Console.WriteLine($"Game over! The word was: {wordToGuess}");
        }

        static void RockPaperScissors()
        {
            string[] choices = { "Rock", "Paper", "Scissors" };
            Random random = new Random();
            int playerScore = 0, computerScore = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Choose Rock, Paper, or Scissors:");
                string playerChoice = Console.ReadLine();
                string computerChoice = choices[random.Next(3)];

                Console.WriteLine($"Computer chose: {computerChoice}");

                if (playerChoice == computerChoice)
                    Console.WriteLine("It's a tie!");
                else if ((playerChoice == "Rock" && computerChoice == "Scissors") ||
                         (playerChoice == "Paper" && computerChoice == "Rock") ||
                         (playerChoice == "Scissors" && computerChoice == "Paper"))
                {
                    Console.WriteLine("You win this round!");
                    playerScore++;
                }
                else
                {
                    Console.WriteLine("Computer wins this round!");
                    computerScore++;
                }
            }

            Console.WriteLine($"Final Score - You: {playerScore}, Computer: {computerScore}");
            Console.WriteLine(playerScore > computerScore ? "You are the overall winner!" : "Computer is the overall winner!");
        }
    }
}
