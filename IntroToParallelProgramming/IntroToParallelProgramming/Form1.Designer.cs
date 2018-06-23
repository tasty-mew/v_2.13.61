namespace IntroToParallelProgramming
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnRunMethodsInParallel = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(32, 29);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(391, 223);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // btnRunMethodsInParallel
            // 
            this.btnRunMethodsInParallel.Location = new System.Drawing.Point(32, 296);
            this.btnRunMethodsInParallel.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnRunMethodsInParallel.Name = "btnRunMethodsInParallel";
            this.btnRunMethodsInParallel.Size = new System.Drawing.Size(829, 55);
            this.btnRunMethodsInParallel.TabIndex = 1;
            this.btnRunMethodsInParallel.Text = "Run Two Methods in Synchronously";
            this.btnRunMethodsInParallel.UseVisualStyleBackColor = true;
            this.btnRunMethodsInParallel.Click += new System.EventHandler(this.btnRunMethodsInParallel_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(32, 365);
            this.button2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(829, 100);
            this.button2.TabIndex = 2;
            this.button2.Text = "Run Two Methods Asynchronously (in Parallel) Using the Task Constructor";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(445, 29);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(409, 223);
            this.richTextBox2.TabIndex = 3;
            this.richTextBox2.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 479);
            this.button1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(829, 114);
            this.button1.TabIndex = 4;
            this.button1.Text = "Run Two Methods Asynchronously (in Parallel) Using the property Factory";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(886, 326);
            this.label1.MaximumSize = new System.Drawing.Size(150, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 150);
            this.label1.TabIndex = 10;
            this.label1.Text = "Do Not \r\nRun All\r\nAt Once";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 622);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnRunMethodsInParallel);
            this.Controls.Add(this.richTextBox1);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnRunMethodsInParallel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

