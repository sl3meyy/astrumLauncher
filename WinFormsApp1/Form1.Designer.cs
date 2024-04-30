
namespace WinFormsApp1

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
            components = new System.ComponentModel.Container();
            label2 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            errorProvider1 = new ErrorProvider(components);
            errorProvider2 = new ErrorProvider(components);
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            label1 = new Label();
            button9 = new Button();
            checkBox1 = new CheckBox();
            textBox3 = new TextBox();
            label5 = new Label();
            label6 = new Label();
            button10 = new Button();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider2).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(504, 29);
            label2.Name = "label2";
            label2.Size = new Size(98, 15);
            label2.TabIndex = 1;
            label2.Text = "Astrum Launcher";
            label2.Click += label2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 404);
            button1.Name = "button1";
            button1.Size = new Size(0, 0);
            button1.TabIndex = 4;
            button1.Text = "Launch Astrum";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(469, 203);
            textBox1.Name = "textBox1";
            textBox1.PasswordChar = '*';
            textBox1.Size = new Size(189, 23);
            textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(469, 159);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(189, 23);
            textBox2.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(469, 141);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 8;
            label3.Text = "Username:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(469, 185);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 9;
            label4.Text = "Password:";
            // 
            // button2
            // 
            button2.Location = new Point(504, 246);
            button2.Name = "button2";
            button2.Size = new Size(111, 40);
            button2.TabIndex = 10;
            button2.Text = "Login";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(504, 292);
            button3.Name = "button3";
            button3.Size = new Size(111, 40);
            button3.TabIndex = 11;
            button3.Text = "Register";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.LightBlue;
            button4.ForeColor = SystemColors.Desktop;
            button4.Location = new Point(26, 232);
            button4.Name = "button4";
            button4.Size = new Size(160, 48);
            button4.TabIndex = 12;
            button4.Text = "Launch Astrum";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            errorProvider2.ContainerControl = this;
            // 
            // button5
            // 
            button5.Location = new Point(855, 480);
            button5.Name = "button5";
            button5.Size = new Size(101, 22);
            button5.TabIndex = 13;
            button5.Text = "logout";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(962, 480);
            button6.Name = "button6";
            button6.Size = new Size(101, 22);
            button6.TabIndex = 14;
            button6.Text = "quit";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(748, 480);
            button7.Name = "button7";
            button7.Size = new Size(101, 22);
            button7.TabIndex = 15;
            button7.Text = "verify";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(641, 480);
            button8.Name = "button8";
            button8.Size = new Size(101, 22);
            button8.TabIndex = 17;
            button8.Text = "update";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(907, 54);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 18;
            // 
            // button9
            // 
            button9.BackColor = Color.LightCyan;
            button9.ForeColor = SystemColors.Desktop;
            button9.Location = new Point(50, 238);
            button9.Name = "button9";
            button9.Size = new Size(112, 37);
            button9.TabIndex = 19;
            button9.Text = "Buy Astrum";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(950, 12);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(113, 19);
            checkBox1.TabIndex = 20;
            checkBox1.Text = "Developer Mode";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(890, 120);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(116, 23);
            textBox3.TabIndex = 24;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(842, 102);
            label5.Name = "label5";
            label5.Size = new Size(221, 15);
            label5.TabIndex = 25;
            label5.Text = "Enter the auth server ip you want to use: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(483, 9);
            label6.Name = "label6";
            label6.Size = new Size(147, 15);
            label6.TabIndex = 26;
            label6.Text = "DEVELOPER MODE ACTIVE";
            // 
            // button10
            // 
            button10.Location = new Point(907, 149);
            button10.Name = "button10";
            button10.Size = new Size(87, 33);
            button10.TabIndex = 27;
            button10.Text = "Apply";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(26, 182);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(174, 23);
            comboBox1.TabIndex = 28;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PowderBlue;
            ClientSize = new Size(1075, 514);
            Controls.Add(comboBox1);
            Controls.Add(button10);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(textBox3);
            Controls.Add(checkBox1);
            Controls.Add(button9);
            Controls.Add(label1);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(label2);
            Name = "Form1";
            Text = "Astrum Launcher";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label3;
        private Label label4;
        private Button button2;
        private Button button3;
        private Button button4;
        private ErrorProvider errorProvider1;
        private ErrorProvider errorProvider2;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Label label1;
        private Button button9;
        private CheckBox checkBox1;
        private Label label5;
        private TextBox textBox3;
        private Label label6;
        private Button button10;
        private ComboBox comboBox1;
    }
}
