using System;

namespace QuestionOne
{
    public static class StringEncoder
    {
        private const char _terminateCharValue = '=';
        private const int _transcodeSize = 63;
        private static char[] _transcode;
        public static char[] Transcode => GetTranscode();

        public static string Decode(string input)
        {
            int inputLength = input.Length;
            var output = InitializeDecodeOutput(inputLength);

            int c = 0;
            int bits = 0;
            int reflex = 0;
            for (int j = 0; j < inputLength; j++)
            {
                if (input[j] == _terminateCharValue)
                    break;

                reflex <<= 6;
                bits += 6;
                reflex += IndexOf(input[j]);

                while (bits >= 8)
                {
                    int mask = 0x000000ff << (bits % 8);
                    output[c++] = (char)((reflex & mask) >> (bits % 8));

                    reflex &= ~mask;
                    bits -= 8;
                }
            }

            var endOfStringIndex = Array.FindIndex(output, c => c == char.MinValue);
            var lengthToCopy = endOfStringIndex == -1
                ? output.Length
                : endOfStringIndex;
            var result = new string(output, 0, lengthToCopy);

            Console.WriteLine("{0} --> {1}\n", input, result);
            return result;
        }

        public static string Encode(string input)
        {
            int inputLength = input.Length;
            var output = InitializeEncodeOutput(inputLength);

            int c = 0;
            int reflex = 0;
            for (int j = 0; j < inputLength; j++)
            {
                reflex <<= 8;
                reflex &= 0x00ffff00;
                reflex += input[j];

                int shifter = ((j % 3) + 1) * 2;
                int mask = _transcodeSize << shifter;
                while (mask >= _transcodeSize)
                {
                    int pivot = (reflex & mask) >> shifter;
                    output[c++] = Transcode[pivot];

                    reflex &= ~mask;
                    mask >>= 6;
                    shifter -= 6;
                }
            }

            switch (inputLength % 3)
            {
                case 1:
                    reflex <<= 4;
                    output[c++] = Transcode[reflex];
                    break;

                case 2:
                    reflex <<= 2;
                    output[c++] = Transcode[reflex];
                    break;
            }

            Console.WriteLine("{0} --> {1}\n", input, new string(output));
            return new string(output);
        }

        private static char[] GetTranscode()
        {
            if (_transcode is null)
            {
                _transcode = new char[64];
                for (int i = 0; i < 64; i++)
                {
                    _transcode[i] = (char)((int)'A' + i);
                    if (i > 25) _transcode[i] = (char)((int)_transcode[i] + 6);
                    if (i > 51) _transcode[i] = (char)((int)_transcode[i] - 0x4b);
                }
                _transcode[62] = '+';
                _transcode[63] = '/';
            }
            return _transcode;
        }

        private static int IndexOf(char ch)
        {
            int index;
            for (index = 0; index < Transcode.Length; index++)
                if (ch == Transcode[index])
                    break;
            return index;
        }

        private static char[] InitializeDecodeOutput(int inputLength)
        {
            var module = (Convert.ToBoolean(inputLength % 4))
                ? 1
                : 0;
            int outputLength = (inputLength / 4 + module) * 3;
            return new char[outputLength];
        }

        private static char[] InitializeEncodeOutput(int inputLength)
        {
            var lengthModule = Convert.ToBoolean(inputLength % 3)
                ? 1
                : 0;
            int outputLength = (inputLength / 3 + lengthModule) * 4;

            char[] output = new char[outputLength];
            for (int i = 0; i < outputLength; i++)
            {
                output[i] = _terminateCharValue;
            }
            return output;
        }
    }
}