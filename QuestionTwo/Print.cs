using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestionTwo
{
    internal static class Print
    {
        internal static void PrintStartMenu(int numberOfDecks, int numberOfCardsPerSuit, bool suitPrecedenceOn)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to HighCard");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(Enumerable.Repeat('*', 50).ToArray());
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Your game configuration:");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Number of decks: {numberOfDecks}");
            Console.WriteLine($"Number of cards per suit: {numberOfCardsPerSuit}");
            Console.WriteLine($"Suit Precedence: {(suitPrecedenceOn ? "On" : "Off")}");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Press enter to start the game...");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        internal static void PrintPlayResult(PlayResultEnum playResult)
        {
            switch (playResult)
            {
                case (PlayResultEnum.Win):
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You Won! :D");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case (PlayResultEnum.Lose):
                    Console.WriteLine("You lose this time :(");
                    break;
                case (PlayResultEnum.Tie):
                    Console.WriteLine("Ouh! It is a tie, let's define it with another round...");
                    Console.WriteLine("Press Enter to play...");

                    Console.ReadLine();
                    break;
            }
        }

        internal static void PrintExitMenu() 
        {
            Console.WriteLine("Press any key to close...");
            Console.ReadLine();
        }
    }
}
