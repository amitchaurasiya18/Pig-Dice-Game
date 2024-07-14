using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigDiceGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Start();
        }
    }

    internal class Game
    {
        private int _totalScore;
        private int _turnCounter;
        private Dice _dice;

        public Game()
        {
            _totalScore = 0;
            _turnCounter = 1;
            _dice = new Dice();
        }

        public void Start()
        {
            Console.WriteLine("Welcome to the game of Pig!!");

            while (_totalScore < 20)
            {
                PlayTurn();
                _turnCounter++;
            }

            EndGame();
        }

        private void PlayTurn()
        {
            int turnScore = 0;

            Console.WriteLine($"\nTURN {_turnCounter}:\n");

            while (true)
            {
                Console.WriteLine("Enter 'r' to roll, 'h' to hold.");
                char userInput = char.Parse(Console.ReadLine());
                Console.WriteLine();

                if (userInput == 'r')
                {
                    int diceValue = _dice.Roll();
                    Console.WriteLine($"You rolled: {diceValue}");

                    if (diceValue == 1)
                    {
                        Console.WriteLine("You rolled a 1. Turn over, no score.");
                        return;
                    }

                    turnScore += diceValue;
                    DisplayScores(turnScore);
                }
                else if (userInput == 'h')
                {
                    _totalScore += turnScore;
                    DisplayTotalScore();
                    return;
                }
            }
        }

        private void DisplayScores(int turnScore)
        {
            Console.WriteLine($"Your turn score is: {turnScore} and your total score is: {_totalScore}");
            Console.WriteLine($"If you hold, you will have {_totalScore + turnScore} points.");
        }

        private void DisplayTotalScore()
        {
            Console.WriteLine($"Your total score is: {_totalScore}");
        }

        private void EndGame()
        {
            Console.WriteLine($"You Win !! You finished in {_turnCounter} turns.\n");
            Console.WriteLine("Game over !!!");
        }
    }

    internal class Dice
    {
        private Random _random;

        public Dice()
        {
            _random = new Random();
        }

        public int Roll()
        {
            return _random.Next(1, 7);
        }
    }
}
