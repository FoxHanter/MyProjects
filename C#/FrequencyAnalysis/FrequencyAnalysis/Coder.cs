using System;
using System.Collections.Generic;
using System.Text;

namespace FrequencyAnalysis
{
    public class Coder
    {
        private const string _alphabetEN = "abcdefghijklmnopqrstuvwxyz";
        private const string _alphabetRU = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private string _alphabet;

        public Coder(string language)
        {
            if (language == "RU")
                _alphabet = _alphabetRU;
            else
                _alphabet = _alphabetEN;
        }

        public string EncodeByKey(string text, string key)
        {
            var textMaker = new TextMaker();
            text = textMaker.ProcessText(text, _alphabet);

            for (int i = 0; i < _alphabet.Length; i++)
            {
                if (key.IndexOf(_alphabet[i]) < 0)
                    key = key + _alphabet[i];
            }

            var sb = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                sb.Append(_alphabet[key.IndexOf(text[i])]);
            }

            return sb.ToString();
        }

        public string EncodeByRandom(string text)
        {
            var textMaker = new TextMaker();
            var replaces = new List<char>();
            var indexes = new List<int>();
            var sb = new StringBuilder();

            text = textMaker.ProcessText(text, _alphabet);

            for (int i = 0; i < _alphabet.Length; i++)
            {
                indexes.Add(i);
            }
            
            while (indexes.Count > 0)
            {
                var rand = new Random();
                var index = rand.Next(0, indexes.Count);

                replaces.Add(_alphabet[indexes[index]]);
                indexes.RemoveAt(index);
            }

            for (int i = 0; i < text.Length; i++)
            {
                sb.Append(_alphabet[replaces.IndexOf(text[i])]);
            }

            return sb.ToString();
        }
    }
}
