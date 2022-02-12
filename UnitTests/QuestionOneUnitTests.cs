using QuestionOne;
using Xunit;

namespace UnitTests
{
    public class QuestionOneUnitTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("car")]
        [InlineData("four")]
        [InlineData("boots")]
        [InlineData("tables")]
        [InlineData("sweet as")]
        [InlineData("sweet as!")]
        [InlineData("This is a test string")]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipisci elit, sed eiusmod tempor incidunt ut labore et dolore magna aliqua")]
        public void StringEncoderTest(string value)
        {
            var result = StringEncoder.Decode(StringEncoder.Encode(value));
            Assert.Equal(value, result);
        }
    }
}