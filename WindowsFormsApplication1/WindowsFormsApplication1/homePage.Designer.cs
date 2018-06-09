namespace WindowsFormsApplication1
{
    partial class homePage
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PartnerID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PartnerPsw = new System.Windows.Forms.TextBox();
            this.connectBtm = new System.Windows.Forms.Button();
            this.myID = new System.Windows.Forms.Label();
            this.myPsw = new System.Windows.Forms.Label();
            this.allowconnection = new System.Windows.Forms.Button();
            this.logout = new System.Windows.Forms.Button();
            this.IP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Your ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Allow Remote Control";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // PartnerID
            // 
            this.PartnerID.Location = new System.Drawing.Point(345, 112);
            this.PartnerID.Name = "PartnerID";
            this.PartnerID.Size = new System.Drawing.Size(100, 20);
            this.PartnerID.TabIndex = 5;
            this.PartnerID.TextChanged += new System.EventHandler(this.PartnerID_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Control Remote Control";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(238, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Partners ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(238, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Partners Password";
            // 
            // PartnerPsw
            // 
            this.PartnerPsw.Location = new System.Drawing.Point(345, 185);
            this.PartnerPsw.Name = "PartnerPsw";
            this.PartnerPsw.Size = new System.Drawing.Size(100, 20);
            this.PartnerPsw.TabIndex = 9;
            // 
            // connectBtm
            // 
            this.connectBtm.Location = new System.Drawing.Point(370, 230);
            this.connectBtm.Name = "connectBtm";
            this.connectBtm.Size = new System.Drawing.Size(75, 23);
            this.connectBtm.TabIndex = 12;
            this.connectBtm.Text = "Connect";
            this.connectBtm.UseVisualStyleBackColor = true;
            this.connectBtm.Click += new System.EventHandler(this.connectBtm_Click);
            // 
            // myID
            // 
            this.myID.AutoSize = true;
            this.myID.Location = new System.Drawing.Point(77, 110);
            this.myID.Name = "myID";
            this.myID.Size = new System.Drawing.Size(31, 13);
            this.myID.TabIndex = 14;
            this.myID.Text = "myID";
            // 
            // myPsw
            // 
            this.myPsw.AutoSize = true;
            this.myPsw.Location = new System.Drawing.Point(81, 185);
            this.myPsw.Name = "myPsw";
            this.myPsw.Size = new System.Drawing.Size(66, 13);
            this.myPsw.TabIndex = 15;
            this.myPsw.Text = "myPassword";
            // 
            // allowconnection
            // 
            this.allowconnection.Location = new System.Drawing.Point(345, 259);
            this.allowconnection.Name = "allowconnection";
            this.allowconnection.Size = new System.Drawing.Size(100, 23);
            this.allowconnection.TabIndex = 17;
            this.allowconnection.Text = "allow connection";
            this.allowconnection.UseVisualStyleBackColor = true;
            this.allowconnection.Click += new System.EventHandler(this.allowconnection_Click);
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(370, 335);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(75, 23);
            this.logout.TabIndex = 18;
            this.logout.Text = "log out";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // IP
            // 
            this.IP.Location = new System.Drawing.Point(120, 268);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(100, 20);
            this.IP.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 252);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(208, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Enter user\'s ip address to allow connection";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 345);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "your ip";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(81, 345);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "label9";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // homePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 379);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.IP);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.allowconnection);
            this.Controls.Add(this.myPsw);
            this.Controls.Add(this.myID);
            this.Controls.Add(this.connectBtm);
            this.Controls.Add(this.PartnerPsw);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PartnerID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "homePage";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PartnerID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PartnerPsw;
        private System.Windows.Forms.Button connectBtm;
        private System.Windows.Forms.Label myID;
        private System.Windows.Forms.Label myPsw;
        private System.Windows.Forms.Button allowconnection;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.TextBox IP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

