using System;
using System.Collections.Generic;
using System.Text;
using RijndaelCipher;
using System.Diagnostics;
using System.IO;
using SquareCipher;
using AnubisCipher;
using PresentCipher;
using CryptographyLibrary;
using System.Drawing;

namespace ConsoleApp1
{
    class Program
    {
        

        static void Main(string[] args)
        {
            List<byte[]> keys = new List<byte[]>();

            using (StreamReader f = new StreamReader("keys.txt"))
            {
                string[] item;

                for (int i = 0; i < 10; i++)
                {
                    item = f.ReadLine().Split(' ');
                    keys.Add(new byte[16]);

                    for (int j = 0; j < 16; j++)
                    {
                        keys[i][j] = byte.Parse(item[j]);
                    }
                }
            }
            string text;
            using (StreamReader f = new StreamReader("input.txt"))
            {
                text = f.ReadToEnd();
            }
            text = text.Substring(0, 2000000);
            string original = text;

                var ciphers = new List<ICipher>
            {
                new Anubis(keys[0]),
                new Square(keys[0]),
                new Rijndael(keys[0]),
                new Present(keys[0]),
            };


            foreach (var cipher in ciphers)
            {
                Console.WriteLine(cipher.GetType());
                byte[] encoded = Encoding.Unicode.GetBytes(text);
                Stopwatch t = new Stopwatch();
                t.Start();
                byte[] decoded = cipher.Encrypt(encoded);
                t.Stop();
                Console.WriteLine(t.ElapsedMilliseconds);
                t.Reset();
                t.Start();
                byte[] tt = cipher.Decrypt(decoded);
                t.Stop();
                Console.WriteLine(t.ElapsedMilliseconds);
                string text1 = Encoding.Unicode.GetString(tt);

                if (text1==original)
                    Console.WriteLine("расшифровано верно");
                else
                    Console.WriteLine("ошибка!");
            }

            

        }
    }
}
