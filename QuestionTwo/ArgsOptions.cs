using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionTwo
{
    class ArgsOptions
    {
        [Option('d', "decks", Required = false, Default = Constants.DefaultNumberOfDecks, HelpText = "Define the number of decks used on the game")]
        public int NumberOfDecks { get; set; }

        [Option('p', "precedence", Required = false, Default = false, HelpText = "Turn On/Off the feature to resolve a tie based on suits precedence")]
        public bool SuitPrecedenceOn { get; set; }

        [Option('c', "cards", Required = false, Default = Constants.DefaultNumberOfCardsPerSuit, HelpText = "Define the number of cards per suit")]
        public int NumberOfCardsPerSuit { get; set; }
    }
}
