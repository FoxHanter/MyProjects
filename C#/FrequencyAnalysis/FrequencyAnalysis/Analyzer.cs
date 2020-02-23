using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FrequencyAnalysis
{
    class Analyzer
    {
        private const string _alphabetEN = "abcdefghijklmnopqrstuvwxyz";
        private const string _alphabetRU = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private double[,] _trgetBigrams;
        private double[,] currentBigrams;
        private List<char> _lettersOrderByCount;
        private string _alphabet;

        public Analyzer(string language)
        {
            if (language == "RU")
            {
                _alphabet = _alphabetRU;
                InitData("dataRU.txt");
            }
            else
            {
                _alphabet = _alphabetEN;
                InitData("dataEN.txt");
            }
        }

        public string Decode(string encodedText)
        {
            var key = GetLettersCount(encodedText);
            currentBigrams = GetBigrams(DecodeByKey(encodedText, key));
            var function = ObjectiveFunction(currentBigrams);

            for (int k = 0; k < 5; k++)
                for (int j = 1; j < 4; j++)
                {
                    for (int i = _alphabet.Length - 1; i > j; i--)
                    {
                        var item = key[i];

                        key[i] = key[i - j];
                        key[i - j] = item;

                        var newResult = ObjectiveFunction(ChangeBigrams(_alphabet.IndexOf(_lettersOrderByCount[i]),_alphabet.IndexOf(_lettersOrderByCount[i - j])));

                        if (newResult <= function)
                            function = newResult;
                        else
                        {
                            item = key[i];
                            key[i] = key[i - j];
                            key[i - j] = item;
                            ChangeBigrams(_alphabet.IndexOf(_lettersOrderByCount[i]), _alphabet.IndexOf(_lettersOrderByCount[i - j]));
                        }
                    }
                }

            return DecodeByKey(encodedText, key);
        }

        private void InitData(string fileName)
        {
            var lettersCount = new Dictionary<char, double>();
            _trgetBigrams = new double[_alphabet.Length, _alphabet.Length];

            for (int i = 0; i < _alphabet.Length; i++)
                for (int j = 0; j < _alphabet.Length; j++)
                    _trgetBigrams[i, j] = 0;

            var text = ReadText(fileName);
            var textMaker = new TextMaker();

            text = textMaker.ProcessText(text, _alphabet);

            for (int i = 0; i < _alphabet.Length; i++)
            {
                lettersCount.Add(_alphabet[i], 0);
            }

            for (int i = 0; i < text.Length; i++)
            {
                lettersCount[text[i]]++;

                if (i != text.Length - 1)
                    _trgetBigrams[GetIndex(text[i]), GetIndex(text[i + 1])]++;
            }

            for (int i = 0; i < _alphabet.Length; i++)
                for (int j = 0; j < _alphabet.Length; j++)
                {
                    _trgetBigrams[i, j] /= text.Length - 1;
                }

            _lettersOrderByCount = lettersCount.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value).Keys.ToList();
        }

        private int GetIndex(char letter)
        {
            return _alphabet.IndexOf(letter);
        }

        private double ObjectiveFunction(double[,] bigrams)
        {
            double result = 0;

            for (int i = 0; i < _alphabet.Length; i++)
                for (int j = 0; j < _alphabet.Length; j++)
                    result += Math.Abs(bigrams[i, j] - _trgetBigrams[i, j]);

            return result;
        }

        private string DecodeByKey(string text, List<char> key)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                sb.Append(_lettersOrderByCount[key.IndexOf(text[i])]);
            }

            return sb.ToString();
        }

        private double[,] GetBigrams(string text)
        {
            double[,] bigrams = new double[_alphabet.Length, _alphabet.Length];

            for (int i = 0; i < text.Length - 1; i++)
            {
                bigrams[GetIndex(text[i]), GetIndex(text[i + 1])]++;
            }

            for (int i = 0; i < _alphabet.Length; i++)
                for (int j = 0; j < _alphabet.Length; j++)
                {
                    bigrams[i, j] /= text.Length - 1;
                }

            return bigrams;
        }

        private double[,] ChangeBigrams(int i,int j)
        {
            for (int k = 0; k < _alphabet.Length; k++)
            {
                var item = currentBigrams[i, k];
                currentBigrams[i, k] = currentBigrams[j, k];
                currentBigrams[j, k] = item;
            }

            for (int k = 0; k < _alphabet.Length; k++)
            {
                var item = currentBigrams[k, i];
                currentBigrams[k, i] = currentBigrams[k, j];
                currentBigrams[k, j] = item;
            }

            return currentBigrams;
        }
        private List<char> GetLettersCount(string text)
        {
            var lettersCount = new Dictionary<char, double>();

            foreach (var item in _lettersOrderByCount)
                lettersCount.Add(item, 0);

            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                lettersCount[text[i]]++;
            }

            return lettersCount.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value).Keys.ToList();
        }

        private string ReadText(string fileName)
        {
            using (StreamReader f = new StreamReader(fileName, Encoding.Default))
            {
                var text = f.ReadToEnd();
                return text;
            }
        }
    }
}
