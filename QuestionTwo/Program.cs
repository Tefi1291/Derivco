using CommandLine;

namespace QuestionTwo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var numberOfDecks = Constants.DefaultNumberOfDecks;
            var numberOfCardsPerSuit = Constants.DefaultNumberOfCardsPerSuit;
            var suitPrecedenceOn = false;

            Parser.Default.ParseArguments<ArgsOptions>(args)
                .WithParsed(argsOptions =>
                {
                    numberOfDecks = argsOptions.NumberOfDecks;
                    numberOfCardsPerSuit = argsOptions.NumberOfCardsPerSuit;
                    suitPrecedenceOn = argsOptions.SuitPrecedenceOn;
                });

            Print.PrintStartMenu(numberOfDecks, numberOfCardsPerSuit, suitPrecedenceOn);

            var highCard = new HighCard(numberOfDecks, numberOfCardsPerSuit);
            var playResult = PlayResultEnum.Tie;

            while (playResult == PlayResultEnum.Tie)
            {
                playResult = highCard.Play(suitPrecedenceOn: suitPrecedenceOn);

                Print.PrintPlayResult(playResult);
            }

            Print.PrintExitMenu();
        }
    }
}