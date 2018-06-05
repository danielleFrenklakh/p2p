namespace WindowsFormsApplication1
{
    partial class viewScreen
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.endCnnctBtn = new System.Windows.Forms.Button();
            this.viewCnnctDetailsBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(705, 395);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // endCnnctBtn
            // 
            this.endCnnctBtn.Location = new System.Drawing.Point(599, 13);
            this.endCnnctBtn.Name = "endCnnctBtn";
            this.endCnnctBtn.Size = new System.Drawing.Size(95, 23);
            this.endCnnctBtn.TabIndex = 1;
            this.endCnnctBtn.Text = "End Connection";
            this.endCnnctBtn.UseVisualStyleBackColor = true;
            this.endCnnctBtn.Click += new System.EventHandler(this.endCnnctBtn_Click);
            // 
            // viewCnnctDetailsBtn
            // 
            this.viewCnnctDetailsBtn.Location = new System.Drawing.Point(13, 13);
            this.viewCnnctDetailsBtn.Name = "viewCnnctDetailsBtn";
            this.viewCnnctDetailsBtn.Size = new System.Drawing.Size(137, 23);
            this.viewCnnctDetailsBtn.TabIndex = 2;
            this.viewCnnctDetailsBtn.Text = "View Connection Details";
            this.viewCnnctDetailsBtn.UseVisualStyleBackColor = true;
            this.viewCnnctDetailsBtn.Click += new System.EventHandler(this.viewCnnctDetailsBtn_Click);
            // 
            // viewScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 440);
            this.Controls.Add(this.viewCnnctDetailsBtn);
            this.Controls.Add(this.endCnnctBtn);
            this.Controls.Add(this.pictureBox1);
            this.Name = "viewScreen";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button endCnnctBtn;
        private System.Windows.Forms.Button viewCnnctDetailsBtn;
    }
}