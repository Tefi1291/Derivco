using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestionOne
{
    class Program
    {
        static void Main(string[] args)
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