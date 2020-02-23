namespace FrequencyAnalysis
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonDecodeAll = new System.Windows.Forms.Button();
            this.buttonDecode = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEncode = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbOpenFile = new System.Windows.Forms.PictureBox();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.buttonSwap = new System.Windows.Forms.Button();
            this.rtbInput = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonEncodeUsingRandom = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOpenFile)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbLanguage
            // 
            this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Items.AddRange(new object[] {
            "RU",
            "EN"});
            this.cbLanguage.Location = new System.Drawing.Point(986, 498);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(43, 21);
            this.cbLanguage.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(938, 499);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Язык";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonDecodeAll);
            this.groupBox3.Controls.Add(this.buttonDecode);
            this.groupBox3.Location = new System.Drawing.Point(795, 193);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(234, 57);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // buttonDecodeAll
            // 
            this.buttonDecodeAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDecodeAll.Location = new System.Drawing.Point(9, 329);
            this.buttonDecodeAll.Name = "buttonDecodeAll";
            this.buttonDecodeAll.Size = new System.Drawing.Size(219, 56);
            this.buttonDecodeAll.TabIndex = 12;
            this.buttonDecodeAll.Text = "Расшифровать, используя все ключи";
            this.buttonDecodeAll.UseVisualStyleBackColor = true;
            // 
            // buttonDecode
            // 
            this.buttonDecode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDecode.Location = new System.Drawing.Point(9, 14);
            this.buttonDecode.Name = "buttonDecode";
            this.buttonDecode.Size = new System.Drawing.Size(219, 32);
            this.buttonDecode.TabIndex = 11;
            this.buttonDecode.Text = "Расшифровать";
            this.buttonDecode.UseVisualStyleBackColor = true;
            this.buttonDecode.Click += new System.EventHandler(this.buttonDecode_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbKey);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.buttonEncode);
            this.groupBox2.Location = new System.Drawing.Point(795, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 83);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // tbKey
            // 
            this.tbKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbKey.Location = new System.Drawing.Point(54, 13);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(174, 22);
            this.tbKey.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ключ";
            // 
            // buttonEncode
            // 
            this.buttonEncode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEncode.Location = new System.Drawing.Point(9, 39);
            this.buttonEncode.Name = "buttonEncode";
            this.buttonEncode.Size = new System.Drawing.Size(219, 32);
            this.buttonEncode.TabIndex = 2;
            this.buttonEncode.Text = "Зашифровать";
            this.buttonEncode.UseVisualStyleBackColor = true;
            this.buttonEncode.Click += new System.EventHandler(this.buttonEncode_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbOpenFile);
            this.groupBox1.Controls.Add(this.rtbOutput);
            this.groupBox1.Controls.Add(this.buttonSwap);
            this.groupBox1.Controls.Add(this.rtbInput);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(777, 503);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // pbOpenFile
            // 
            this.pbOpenFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbOpenFile.Image = global::FrequencyAnalysis.Properties.Resources.openFile;
            this.pbOpenFile.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbOpenFile.InitialImage")));
            this.pbOpenFile.Location = new System.Drawing.Point(744, 19);
            this.pbOpenFile.Name = "pbOpenFile";
            this.pbOpenFile.Size = new System.Drawing.Size(24, 24);
            this.pbOpenFile.TabIndex = 2;
            this.pbOpenFile.TabStop = false;
            this.pbOpenFile.Click += new System.EventHandler(this.pbOpenFile_Click);
            // 
            // rtbOutput
            // 
            this.rtbOutput.BackColor = System.Drawing.SystemColors.Window;
            this.rtbOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbOutput.Location = new System.Drawing.Point(6, 265);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.ReadOnly = true;
            this.rtbOutput.Size = new System.Drawing.Size(732, 232);
            this.rtbOutput.TabIndex = 1;
            this.rtbOutput.Text = "";
            // 
            // buttonSwap
            // 
            this.buttonSwap.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSwap.Location = new System.Drawing.Point(744, 238);
            this.buttonSwap.Name = "buttonSwap";
            this.buttonSwap.Size = new System.Drawing.Size(28, 49);
            this.buttonSwap.TabIndex = 0;
            this.buttonSwap.Text = "↕";
            this.buttonSwap.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSwap.UseVisualStyleBackColor = true;
            this.buttonSwap.Click += new System.EventHandler(this.buttonSwap_Click);
            // 
            // rtbInput
            // 
            this.rtbInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbInput.Location = new System.Drawing.Point(6, 19);
            this.rtbInput.Name = "rtbInput";
            this.rtbInput.Size = new System.Drawing.Size(732, 238);
            this.rtbInput.TabIndex = 0;
            this.rtbInput.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonEncodeUsingRandom);
            this.groupBox4.Location = new System.Drawing.Point(795, 101);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(234, 86);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            // 
            // buttonEncodeUsingRandom
            // 
            this.buttonEncodeUsingRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEncodeUsingRandom.Location = new System.Drawing.Point(9, 19);
            this.buttonEncodeUsingRandom.Name = "buttonEncodeUsingRandom";
            this.buttonEncodeUsingRandom.Size = new System.Drawing.Size(219, 54);
            this.buttonEncodeUsingRandom.TabIndex = 2;
            this.buttonEncodeUsingRandom.Text = "Зашифровать, не используя ключ";
            this.buttonEncodeUsingRandom.UseVisualStyleBackColor = true;
            this.buttonEncodeUsingRandom.Click += new System.EventHandler(this.buttonEncodeUsingRandom_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 527);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.cbLanguage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "FrequencyAnalysis";
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbOpenFile)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbLanguage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonDecodeAll;
        private System.Windows.Forms.Button buttonDecode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonEncode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Button buttonSwap;
        private System.Windows.Forms.RichTextBox rtbInput;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonEncodeUsingRandom;
        private System.Windows.Forms.PictureBox pbOpenFile;
    }
}

