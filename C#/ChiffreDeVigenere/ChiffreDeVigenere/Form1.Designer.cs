namespace ChiffreDeVigenere
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.buttonSwap = new System.Windows.Forms.Button();
            this.rtbInput = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEncode = new System.Windows.Forms.Button();
            this.buttonAnalysis = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonDecodeAll = new System.Windows.Forms.Button();
            this.buttonDecode = new System.Windows.Forms.Button();
            this.cbPossibleKeys = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbPossibleKeyLengths = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbOutput);
            this.groupBox1.Controls.Add(this.buttonSwap);
            this.groupBox1.Controls.Add(this.rtbInput);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(777, 503);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rtbOutput
            // 
            this.rtbOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbOutput.Location = new System.Drawing.Point(6, 265);
            this.rtbOutput.Name = "rtbOutput";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbKey);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.buttonEncode);
            this.groupBox2.Location = new System.Drawing.Point(795, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 83);
            this.groupBox2.TabIndex = 1;
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
            // buttonAnalysis
            // 
            this.buttonAnalysis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAnalysis.Location = new System.Drawing.Point(9, 19);
            this.buttonAnalysis.Name = "buttonAnalysis";
            this.buttonAnalysis.Size = new System.Drawing.Size(219, 32);
            this.buttonAnalysis.TabIndex = 3;
            this.buttonAnalysis.Text = "Анализ";
            this.buttonAnalysis.UseVisualStyleBackColor = true;
            this.buttonAnalysis.Click += new System.EventHandler(this.buttonAnalysis_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonDecodeAll);
            this.groupBox3.Controls.Add(this.buttonDecode);
            this.groupBox3.Controls.Add(this.cbPossibleKeys);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cbPossibleKeyLengths);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.buttonAnalysis);
            this.groupBox3.Location = new System.Drawing.Point(795, 101);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(234, 391);
            this.groupBox3.TabIndex = 4;
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
            this.buttonDecodeAll.Click += new System.EventHandler(this.buttonDecodeAll_Click);
            // 
            // buttonDecode
            // 
            this.buttonDecode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDecode.Location = new System.Drawing.Point(9, 180);
            this.buttonDecode.Name = "buttonDecode";
            this.buttonDecode.Size = new System.Drawing.Size(219, 32);
            this.buttonDecode.TabIndex = 11;
            this.buttonDecode.Text = "Расшифровать";
            this.buttonDecode.UseVisualStyleBackColor = true;
            this.buttonDecode.Click += new System.EventHandler(this.buttonDecode_Click);
            // 
            // cbPossibleKeys
            // 
            this.cbPossibleKeys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPossibleKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbPossibleKeys.FormattingEnabled = true;
            this.cbPossibleKeys.Location = new System.Drawing.Point(9, 150);
            this.cbPossibleKeys.Name = "cbPossibleKeys";
            this.cbPossibleKeys.Size = new System.Drawing.Size(219, 24);
            this.cbPossibleKeys.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(6, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Возможный ключ";
            // 
            // cbPossibleKeyLengths
            // 
            this.cbPossibleKeyLengths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPossibleKeyLengths.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbPossibleKeyLengths.FormattingEnabled = true;
            this.cbPossibleKeyLengths.Location = new System.Drawing.Point(9, 104);
            this.cbPossibleKeyLengths.Name = "cbPossibleKeyLengths";
            this.cbPossibleKeyLengths.Size = new System.Drawing.Size(90, 24);
            this.cbPossibleKeyLengths.TabIndex = 8;
            this.cbPossibleKeyLengths.SelectedIndexChanged += new System.EventHandler(this.cbPossibleKeyLengths_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Длина ключа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(938, 499);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Язык";
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
            this.cbLanguage.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 527);
            this.Controls.Add(this.cbLanguage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "ChiffreDeVigenere";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Button buttonSwap;
        private System.Windows.Forms.RichTextBox rtbInput;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonEncode;
        private System.Windows.Forms.Button buttonAnalysis;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbLanguage;
        private System.Windows.Forms.Button buttonDecode;
        private System.Windows.Forms.ComboBox cbPossibleKeys;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbPossibleKeyLengths;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonDecodeAll;
    }
}

