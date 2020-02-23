using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ChiffreDeVigenere
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            cbLanguage.SelectedItem = "RU";
        }

        private void buttonSwap_Click(object sender, EventArgs e)
        {
            rtbInput.Text = rtbOutput.Text;
            rtbOutput.Clear();
        }

        private void buttonEncode_Click(object sender, EventArgs e)
        {
            var key = tbKey.Text;
            var text = rtbInput.Text;
            var language = cbLanguage.SelectedItem.ToString();
            var coder = new Coder(language);
            var encodedText = coder.Encode(text, key);

            rtbOutput.Text = encodedText;
            tbKey.Clear();
        }

        private void buttonAnalysis_Click(object sender, EventArgs e)
        {
            cbPossibleKeyLengths.Items.Clear();
            rtbOutput.Clear();

            var text = rtbInput.Text;
            var language = cbLanguage.SelectedItem.ToString();
            var breaker = new VigenereBreaker(language);
            var possibleKeyLengths = breaker.GetPossibleKeyLengths(text);

            foreach (var item in possibleKeyLengths)
                cbPossibleKeyLengths.Items.Add(item);

            cbPossibleKeyLengths.SelectedItem = cbPossibleKeyLengths.Items[0];
        }

        private void buttonDecode_Click(object sender, EventArgs e)
        {
            var language = cbLanguage.SelectedItem.ToString();
            var coder = new Coder(language);
            var encodedText = rtbInput.Text;
            var key = cbPossibleKeys.SelectedItem.ToString();
            var decodedText = coder.Decode(encodedText, key);

            rtbOutput.Text = decodedText;
        }

        private void cbPossibleKeyLengths_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbPossibleKeys.Items.Clear();

            var text = rtbInput.Text;
            var keyLength = int.Parse(cbPossibleKeyLengths.SelectedItem.ToString());
            var language = cbLanguage.SelectedItem.ToString();
            var breaker = new VigenereBreaker(language);
            var possibleKeys = breaker.GetPossibleKeys(keyLength, text).ToArray();

            cbPossibleKeys.Items.AddRange(possibleKeys);
        }

        private void buttonDecodeAll_Click(object sender, EventArgs e)
        {
            var encodedText = rtbInput.Text;
            var language = cbLanguage.SelectedItem.ToString();
            var breaker = new VigenereBreaker(language);
            var coder = new Coder(language);
            var possibleKeyLengths = breaker.GetPossibleKeyLengths(encodedText);
            var possibleKeys = new List<string>();
            var sb = new StringBuilder();

            foreach (var item in possibleKeyLengths)
                possibleKeys.AddRange(breaker.GetPossibleKeys(item, encodedText));

            for (int i = 0; i < possibleKeys.Count; i++)
            {
                var key = possibleKeys[i];
                var decodedText = coder.Decode(encodedText, key);

                sb.Append($"{i + 1}. Ключ: {key}\n{decodedText}\n\n");
            }

            rtbOutput.Text = sb.ToString();
        }
    }
}
