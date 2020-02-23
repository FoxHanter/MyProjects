using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChiffreDeVigenere
{
    public class VigenereBreaker
    {
        private const string _alphabetEN = "abcdefghijklmnopqrstuvwxyz";
        private const string _alphabetRU = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private string _alphabet;

        public VigenereBreaker(string language)
        {
            if (language == "RU")
                _alphabet = _alphabetRU;
            else
                _alphabet = _alphabetEN;
        }

        public List<int> GetPossibleKeyLengths(string text)
        {
            var icOfKeys = new List<double>() { 0, 0 };
            var currentLength = 2;
            var possibleKeyLengths = new List<int>();

            while (currentLength < 30)
            {
                var sb = new StringBuilder();

                for (int i = 0; i < text.Length; i++)
                {
                    if (i % currentLength == 0)
                        sb.Append(text[i]);
                }

                var icIndex = GetIcIndex(sb.ToString());

                icOfKeys.Add(icIndex);
                currentLength++;
            }

            for (int i = 2; i < icOfKeys.Count; i++)
            {
                if (icOfKeys[i] - icOfKeys[i - 1] > 0.005)
                    possibleKeyLengths.Add(i);
            }

            return possibleKeyLengths;
        }

        public List<string> GetPossibleKeys(int keyLength, string text)
        {
            var shiftedTexts = new List<string>();
            var shifts = new List<int>();

            for (int i = 0; i < keyLength; i++)
            {
                var j = i;
                var sb = new StringBuilder();

                while (j < text.Length)
                {
                    sb.Append(text[j]);
                    j += keyLength;
                }

                shiftedTexts.Add(sb.ToString());
            }

            for (int i = 1; i < shiftedTexts.Count; i++)
            {
                var indexes = new List<double>();

                for (int j = 1; j <= _alphabet.Length; j++)
                {
                    var sb = new StringBuilder();

                    for (int k = 0; k < shiftedTexts[i].Length; k++)
                    {
                        var symbol = shiftedTexts[i][k];
                        var q = _alphabet.IndexOf(symbol);
                        var shift = (j + q) % _alphabet.Length;

                        sb.Append(_alphabet[shift]);
                    }

                    indexes.Add(GetMutualIcIndex(shiftedTexts[0], sb.ToString()));
                }

                shifts.Add(indexes.IndexOf(indexes.Max()));
            }

            var possibleKeys = new List<string>();

            for (int i = 0; i < _alphabet.Length; i++)
            {
                var sb = new StringBuilder();
                sb.Append(_alphabet[i]);

                for (int j = 0; j < shifts.Count; j++)
                {
                    var index = i - shifts[j] - 1;

                    if (index < 0)
                        index += _alphabet.Length;

                    sb.Append(_alphabet[(index) % _alphabet.Length]);
                }

                possibleKeys.Add(sb.ToString());
            }

            return possibleKeys;
        }

        private double GetIcIndex(string text)
        {
            var lettersCount = new Dictionary<char, double>();
            var lettersIC = new List<double>();

            for (int i = 0; i < text.Length; i++)
            {
                if (lettersCount.ContainsKey(text[i]))
                    lettersCount[text[i]]++;
                else
                    lettersCount.Add(text[i], 1);
            }

            double zn = (text.Length * (text.Length - 1));

            foreach (var kvp in lettersCount)
            {
                double ic = kvp.Value * (kvp.Value - 1);
                lettersIC.Add(ic);
            }

            var icIndex = lettersIC.Sum();
            icIndex = icIndex / zn;

            return icIndex;
        }

        private double GetMutualIcIndex(string s1, string s2)
        {
            var lettersCount1 = new Dictionary<char, double>();
            var lettersIC1 = new List<double>();
            var lettersCount2 = new Dictionary<char, double>();

            for (int i = 0; i < s1.Length; i++)
            {
                if (lettersCount1.ContainsKey(s1[i]))
                    lettersCount1[s1[i]]++;
                else
                    lettersCount1.Add(s1[i], 1);
            }

            for (int i = 0; i < s2.Length; i++)
            {
                if (lettersCount2.ContainsKey(s2[i]))
                    lettersCount2[s2[i]]++;
                else
                    lettersCount2.Add(s2[i], 1);
            }

            double zn = (s1.Length * s2.Length);

            foreach (var kvp in lettersCount1)
            {
                if (lettersCount2.ContainsKey(kvp.Key))
                {
                    double ic = kvp.Value * lettersCount2[kvp.Key];
                    lettersIC1.Add(ic);
                }
            }

            var icIndex = lettersIC1.Sum();
            icIndex = icIndex / zn;

            return icIndex;
        }
    }
}
