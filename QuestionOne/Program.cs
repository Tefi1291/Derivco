using System;

namespace QuestionOne
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var testString = "This is a test string";

            var encodedValue = StringEncoder.Encode(testString);
            var decodedValue = StringEncoder.Decode(encodedValue);
            if (testString == decodedValue)
            {
                Console.WriteLine("Test succeeded");
            }
            else
            {
                Console.WriteLine("Test failed");
            }
        }
    }
}