namespace WindowsFormsApplication1
{
    partial class register
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
            this.titleRegister = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.confirm_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.confirmpsw = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // titleRegister
            // 
            this.titleRegister.AutoSize = true;
            this.titleRegister.Location = new System.Drawing.Point(12, 10);
            this.titleRegister.Name = "titleRegister";
            this.titleRegister.Size = new System.Drawing.Size(46, 13);
            this.titleRegister.TabIndex = 0;
            this.titleRegister.Text = "Register";
            this.titleRegister.Click += new System.EventHandler(this.titleRegister_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id";
            // 
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(102, 42);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(170, 20);
            this.ID.TabIndex = 2;
            this.ID.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(102, 110);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(170, 20);
            this.Password.TabIndex = 3;
            this.Password.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // confirm_button
            // 
            this.confirm_button.Location = new System.Drawing.Point(197, 226);
            this.confirm_button.Name = "confirm_button";
            this.confirm_button.Size = new System.Drawing.Size(75, 23);
            this.confirm_button.TabIndex = 5;
            this.confirm_button.Text = "confirm";
            this.confirm_button.UseVisualStyleBackColor = true;
            this.confirm_button.Click += new System.EventHandler(this.confirm_button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "confirm password";
            // 
            // confirmpsw
            // 
            this.confirmpsw.Location = new System.Drawing.Point(102, 176);
            this.confirmpsw.Name = "confirmpsw";
            this.confirmpsw.PasswordChar = '*';
            this.confirmpsw.Size = new System.Drawing.Size(170, 20);
            this.confirmpsw.TabIndex = 9;
            // 
            // register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.confirmpsw);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.confirm_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleRegister);
            this.Name = "register";
            this.Text = "register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleRegister;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ID;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button confirm_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox confirmpsw;
    }
}