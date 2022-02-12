using System;

namespace QuestionTwo
{
    public class HighCard : IHighCard
    {
        private const int _wildCardValue = 20;
        private const int _numberOfSuits = 4;

        private readonly int _numberOfDecks;
        private readonly int _numberOfCardsPerSuit;
        private readonly int _cardsTotalNumber;

        /// <summary>
        /// Init a high card with one deck and thirteen card per suit
        /// </summary>
        public HighCard()
            : this(1, 13)
        {
        }

        /// <summary>
        /// Init a high card
        /// </summary>
        /// <param name="numberOfDecks">Number of decks</param>
        /// <param name="numberOfCardsPerSuit">Number of cards per suit</param>
        public HighCard(int numberOfDecks, int numberOfCardsPerSuit)
        {
            if (numberOfDecks <= 0)
                throw new Exception("The number of decks must be greater than 0");

            _numberOfDecks = numberOfDecks;
            _numberOfCardsPerSuit = numberOfCardsPerSuit;
            _cardsTotalNumber = _numberOfSuits * _numberOfCardsPerSuit * _numberOfDecks;
        }

        /// <summary>
        /// Plays a round.
        /// If suitPrecedenceOn is true, suits precedence will be applied for ties
        /// </summary>
        /// <param name="suitPrecedenceOn">Suit precedence is on/off</param>
        /// <returns>Result of the round</returns>
        public PlayResultEnum Play(bool suitPrecedenceOn = false)
        {
            Random random = new Random();

            int cardOne = random.Next(1, _cardsTotalNumber + 1);
            int cardTwo = random.Next(1, _cardsTotalNumber + 1);

            var playResult = ParsePlayResult(cardOne, cardTwo);

            if (playResult == PlayResultEnum.Tie && suitPrecedenceOn)
            {
                var cardOnePrecendence = random.Next(1, _numberOfSuits);
                var cardTwoPrecedence = random.Next(1, _numberOfSuits);

                playResult = (cardOnePrecendence < cardTwoPrecedence)
                    ? PlayResultEnum.Win
                    : PlayResultEnum.Lose;
            }

            return playResult;
        }

        private PlayResultEnum ParsePlayResult(int cardOnevalue, int cardTwoValue)
        {
            PlayResultEnum result;

            if (cardOnevalue == _wildCardValue)
            {
                result = PlayResultEnum.Lose;
            }
            else if (cardTwoValue == _wildCardValue)
            {
                result = PlayResultEnum.Win;
            }
            else if (cardOnevalue == cardTwoValue)
            {
                result = PlayResultEnum.Tie;
            }
            else
                result = (cardOnevalue < cardTwoValue)
                    ? PlayResultEnum.Win
                    : PlayResultEnum.Lose;

            return result;
        }
    }
}