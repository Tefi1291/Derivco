using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionOne
{
    public static class StringEncoder
    {
        private static char[] _transcode;
        public static char[] Transcode => GetTranscode();

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

        public static string Encode(string input)
        {
            int l = input.Length;
            var lengthModule = Convert.ToBoolean(l % 3)
                ? 1
                : 0;
            int cb = (l / 3 + lengthModule) * 4;

            char[] output = new char[cb];
            for (int i = 0; i < cb; i++)
            {
                output[i] = '=';
            }

            int c = 0;
            int reflex = 0;
            const int s = 0x3f;

            for (int j = 0; j < l; j++)
            {
                reflex <<= 8;
                reflex &= 0x00ffff00;
                reflex += input[j];

                int x = ((j % 3) + 1) * 2;
                int mask = s << x;
                while (mask >= s)
                {
                    int pivot = (reflex & mask) >> x;
                    output[c++] = Transcode[pivot];
                    int invert = ~mask;
                    reflex &= invert;
                    mask >>= 6;
                    x -= 6;
                }
            }

            switch (l % 3)
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

        public static string Decode(string input)
        {
            int l = input.Length;
            var module = (Convert.ToBoolean(l % 4))
                ? 1
                : 0;
            int cb = (l / 4 + module) * 3;
            char[] output = new char[cb];
            int c = 0;
            int bits = 0;
            int reflex = 0;
            for (int j = 0; j < l; j++)
            {
                reflex <<= 6;
                bits += 6;
                bool fTerminate = ('=' == input[j]);
                if (!fTerminate)
                    reflex += IndexOf(input[j]);

                if (fTerminate)
                    break;

                while (bits >= 8)
                {
                    int mask = 0x000000ff << (bits % 8);
                    output[c++] = (char)((reflex & mask) >> (bits % 8));
                    int invert = ~mask;
                    reflex &= invert;
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

        private static int IndexOf(char ch)
        {
            int index;
            for (index = 0; index < Transcode.Length; index++)
                if (ch == Transcode[index])
                    break;
            return index;
        }
    }
}
