using System;
using System.Text;

namespace CryptographyLibrary
{
    public static class RandomGenerator
    {
        private static Random random = new Random();

        public static byte[] GenerateKey(int count)
        {
            byte[] key = new byte[count];

            for (int i = 0; i < count; i++)
            {
                key[i] = (byte)random.Next(0, 255);
            }

            return key;
        }

        public static string GenerateText(int lenght)
        {
            StringBuilder str = new StringBuilder();
            string alf = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789!№;%:?*()_+=-/., ";

            for (int i = 0; i < lenght; i++)
            {
                str.Append(alf[ (byte)random.Next(0, alf.Length-1)]);
            }

            return str.ToString();
        }
    }
}
