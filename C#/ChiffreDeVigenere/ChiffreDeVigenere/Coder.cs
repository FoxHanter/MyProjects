using System.Text;

namespace ChiffreDeVigenere
{
    public class Coder
    {
        private const string _alphabetEN = "abcdefghijklmnopqrstuvwxyz";
        private const string _alphabetRU = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private string _alphabet;
        private int _alphabetLength;
        private char[,] _table;

        public Coder(string language)
        {
            if (language == "RU")
                _alphabet = _alphabetRU;
            else
                _alphabet = _alphabetEN;

            BuildTable();
        }        

        public string Encode(string text, string key)
        {
            text = text.ToLower();
            text = ProcessText(text);
            key = key.ToLower();

            var keyText = GetKeyText(text, key);
            var encodedText = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                var j = _alphabet.IndexOf(keyText[i]);
                var k = _alphabet.IndexOf(text[i]);
                var symbol = _table[j, k];

                encodedText.Append(symbol);
            }

            return encodedText.ToString();
        }

        public string Decode(string encodedText, string key)
        {
            encodedText = encodedText.ToLower();
            key = key.ToLower();

            var keyText = GetKeyText(encodedText, key);
            var decodedText = new StringBuilder();

            for (int i = 0; i < encodedText.Length; i++)
            {
                var j = _alphabet.IndexOf(keyText[i]);

                for (int k = 0; k < _table.GetLength(0); k++)
                {
                    if (_table[j, k] == encodedText[i])
                    {
                        var symbol = _alphabet[k];
                        decodedText.Append(symbol);

                        break;
                    }
                }
            }

            return decodedText.ToString();
        }

        private string ProcessText(string text)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                    sb.Append(text[i]);
            }

            return sb.ToString();
        }

        private string GetKeyText(string text, string key)
        {
            var keyText = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                keyText.Append(key[i % key.Length]);
            }

            return keyText.ToString();
        }

        private void BuildTable()
        {
            _alphabetLength = _alphabet.Length;
            _table = new char[_alphabetLength, _alphabetLength];

            for (int i = 0; i < _table.GetLength(0); i++)
                for (int j = 0; j < _table.GetLength(1); j++)
                {
                    var index = (i + j) % _table.GetLength(0);
                    _table[i, j] = _alphabet[index];
                }
        }
    }
}
