using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whirlpool.Core;
namespace Whirlpool.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var testString = "Hello, world";
            var hash = GetHash(testString);

            TestsDemo(hash);
        }
        private static byte[] GetHash(string testString)
        {
            var blake = new Whirlpool_Algorithm();

            var hash = blake.Start(testString);
            var hashToDisplay = blake.display(hash);
            Console.WriteLine("Текст: {0}",testString);
            Console.WriteLine("Хэш\n{0}",hashToDisplay);
            Console.ReadLine();

            return hash;
        }
        private static void TestsDemo(byte[] hash)
        {
            var testsDemo = new StatisticalTestsDemo(hash);
            testsDemo.Run();
        }
    }
}
