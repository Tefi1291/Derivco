using QuestionTwo;
using System;
using Xunit;

namespace UnitTests
{
    public class QuestionTwoUnitTest
    {
        [Fact]
        public void Number_of_decks_is_zero_then_exception_is_throw()
        {
            Assert.Throws<Exception>(() => new HighCard(0, 13));
        }

        [Fact]
        public void Play_with_suit_precendece_never_returns_a_tie()
        {
            var highCard = new HighCard();
            var result = highCard.Play(true);

            Assert.NotEqual(PlayResultEnum.Tie, result);
        }
    }
}
