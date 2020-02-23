using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FrequencyAnalysis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            cbLanguage.SelectedItem = "RU";
        }

        private void buttonEncode_Click(object sender, EventArgs e)
        {
            var language = cbLanguage.SelectedItem.ToString();
            var key = tbKey.Text;
            var text = rtbInput.Text;
            var coder = new Coder(language);
            var encodedText = coder.EncodeByKey(text, key);

            rtbOutput.Text = encodedText;
        }

        private void buttonEncodeUsingRandom_Click(object sender, EventArgs e)
        {
            var language = cbLanguage.SelectedItem.ToString();
            var text = rtbInput.Text;
            var coder = new Coder(language);
            var encodedText = coder.EncodeByRandom(text);

            rtbOutput.Text = encodedText;
        }

        private void buttonDecode_Click(object sender, EventArgs e)
        {
            var language = cbLanguage.SelectedItem.ToString();
            var encodedText = rtbInput.Text;
            var analyzer = new Analyzer(language);
            var decodedText = analyzer.Decode(encodedText);

            rtbOutput.Text = decodedText;
        }

        private void buttonSwap_Click(object sender, EventArgs e)
        {
            rtbInput.Text = rtbOutput.Text;
            rtbOutput.Clear();
        }

        private void pbOpenFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var text = string.Empty;
                var fileName = ofd.FileName;

                using (var f = new StreamReader(fileName, Encoding.Default))
                {
                    text = f.ReadToEnd();
                }

                rtbInput.Text = text;
            }
        }
    }
}
