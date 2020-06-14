using System;
using System.Collections;

namespace CryptographyLibrary
{
    public static class Converter
    {
        public static string ToBinForm(int number)
        {
            int[] vs = new int[8];
            string binForm = "";

            for (int i = 0; i < 8; i++)
            {
                vs[7 - i] = number % 2;
                number /= 2;
                if (number == 0)
                    break;
            }

            foreach(var item in vs)
                binForm = binForm + item;

            return binForm;
        }

        public static string ToBinForm(int number,int size)
        {
            int[] vs = new int[size];
            string binForm = "";

            for (int i = 0; i < size; i++)
            {
                vs[(size-1) - i] = number % 2;
                number /= 2;
                if (number == 0)
                    break;
            }

            foreach (var item in vs)
                binForm = binForm + item;

            return binForm;
        }

        public static string ToHexForm(string number)
        {
            int num = 0;
            string hexForm = "";

            for (int i = 0; i < 2; i++)
            {
                num = 0;

                for (int j = 0; j < 4; j++)
                    num += (int)Math.Pow(2, j) * (number[4 * (i + 1) - j - 1] - '0');

                if (num < 10)
                    hexForm += num;
                else
                    hexForm += (char)('a' + num - 10);
            }

            return hexForm;
        }

        public static string ToHexForm(int number)
        {
            return ToHexForm(ToBinForm(number));
        }

        static byte ReverseBits(byte value)
        {
            byte reversed = 0x00;

            int i = 7, j = 0;

            while (i >= 0)
            {
                reversed |= (byte)(((value >> i) & 0x01) << j);
                i--;
                j++;
            }
            return reversed;
        }

        public static byte GetFirstByte(byte b)
        {
            return (byte)(b >> 4);
        }

        public static byte GetSecondByte(byte b)
        {
            return (byte)((b << 4) % 256 >> 4);
        }

        public static byte UnionByte(byte a,byte b)
        {
            return (byte)((a << 4) + b);
        }
        public static byte[] ToByteArray(BitArray rezult)
        {
            byte[] answer = new byte[rezult.Length / 16];

            for (int i = 0; i < rezult.Length/16; i++)
            {
                int x = 0;

                for (int j = 0; j < 8; j++)
                {
                    x += rezult[i * 8 + j]? (int)Math.Pow(2, 7 - j) : 0;
                }

                answer[i] = byte.Parse(x.ToString());
                answer[i] = ReverseBits(answer[i]);
            }

            return answer;
        }
    }
}
