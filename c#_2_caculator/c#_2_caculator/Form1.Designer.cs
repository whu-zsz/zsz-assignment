namespace c__2_caculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Caculate = new Button();
            NumA = new TextBox();
            NumB = new TextBox();
            Result = new TextBox();
            Symbol = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // Caculate
            // 
            Caculate.Location = new Point(326, 295);
            Caculate.Name = "Caculate";
            Caculate.Size = new Size(112, 34);
            Caculate.TabIndex = 0;
            Caculate.Text = "计算";
            Caculate.UseVisualStyleBackColor = true;
            Caculate.Click += button1_Click;
            // 
            // NumA
            // 
            NumA.Location = new Point(33, 120);
            NumA.Name = "NumA";
            NumA.Size = new Size(150, 30);
            NumA.TabIndex = 1;
            NumA.TextChanged += NumA_TextChanged;
            // 
            // NumB
            // 
            NumB.Location = new Point(496, 120);
            NumB.Name = "NumB";
            NumB.Size = new Size(150, 30);
            NumB.TabIndex = 2;
            NumB.TextChanged += NumB_TextChanged;
            // 
            // Result
            // 
            Result.Location = new Point(697, 120);
            Result.Name = "Result";
            Result.ReadOnly = true;
            Result.Size = new Size(150, 30);
            Result.TabIndex = 3;
            // 
            // Symbol
            // 
            Symbol.FormattingEnabled = true;
            Symbol.Items.AddRange(new object[] { "+", "-", "*", "/" });
            Symbol.Location = new Point(256, 120);
            Symbol.Name = "Symbol";
            Symbol.Size = new Size(182, 32);
            Symbol.TabIndex = 4;
            Symbol.SelectedIndexChanged += Symbol_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 74);
            label1.Name = "label1";
            label1.Size = new Size(57, 24);
            label1.TabIndex = 5;
            label1.Text = "数据1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(309, 74);
            label2.Name = "label2";
            label2.Size = new Size(82, 24);
            label2.TabIndex = 6;
            label2.Text = "计算符号";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(535, 74);
            label3.Name = "label3";
            label3.Size = new Size(57, 24);
            label3.TabIndex = 7;
            label3.Text = "数据2";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(739, 74);
            label4.Name = "label4";
            label4.Size = new Size(82, 24);
            label4.TabIndex = 8;
            label4.Text = "计算结果";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Symbol);
            Controls.Add(Result);
            Controls.Add(NumB);
            Controls.Add(NumA);
            Controls.Add(Caculate);
            Name = "Form1";
            Text = "caculator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Caculate;
        private TextBox NumA;
        private TextBox NumB;
        private TextBox Result;
        private ComboBox Symbol;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
