using System.Text;

namespace FrequencyAnalysis
{
    public class TextMaker
    {
        public string ProcessText(string text, string alphabet)
        {
            var sb = new StringBuilder();

            text = text.ToLower();

            for (int i = 0; i < text.Length; i++)
            {
                if (alphabet.IndexOf(text[i]) >= 0)
                    sb.Append(text[i]);
            }

            return sb.ToString();
        }
    }
}
