namespace ORACLEspace
{
    partial class Form_new
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
            this.zname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.zport = new System.Windows.Forms.TextBox();
            this.zip = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.zpass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.zuser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.zsid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.zother = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // zname
            // 
            this.zname.Location = new System.Drawing.Point(98, 27);
            this.zname.Name = "zname";
            this.zname.Size = new System.Drawing.Size(122, 21);
            this.zname.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "Describe";
            // 
            // zport
            // 
            this.zport.Location = new System.Drawing.Point(98, 81);
            this.zport.Name = "zport";
            this.zport.Size = new System.Drawing.Size(54, 21);
            this.zport.TabIndex = 24;
            // 
            // zip
            // 
            this.zip.Location = new System.Drawing.Point(98, 54);
            this.zip.Name = "zip";
            this.zip.Size = new System.Drawing.Size(122, 21);
            this.zip.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "DB IP";
            // 
            // zpass
            // 
            this.zpass.Location = new System.Drawing.Point(98, 162);
            this.zpass.Name = "zpass";
            this.zpass.Size = new System.Drawing.Size(100, 21);
            this.zpass.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "SID";
            // 
            // zuser
            // 
            this.zuser.Location = new System.Drawing.Point(98, 135);
            this.zuser.Name = "zuser";
            this.zuser.Size = new System.Drawing.Size(100, 21);
            this.zuser.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "username";
            // 
            // zsid
            // 
            this.zsid.Location = new System.Drawing.Point(98, 108);
            this.zsid.Name = "zsid";
            this.zsid.Size = new System.Drawing.Size(54, 21);
            this.zsid.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "password";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(91, 299);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // zother
            // 
            this.zother.Location = new System.Drawing.Point(12, 189);
            this.zother.Multiline = true;
            this.zother.Name = "zother";
            this.zother.Size = new System.Drawing.Size(227, 104);
            this.zother.TabIndex = 28;
            // 
            // Form_new
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 334);
            this.Controls.Add(this.zother);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zname);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.zport);
            this.Controls.Add(this.zip);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zpass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.zuser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.zsid);
            this.Controls.Add(this.label4);
            this.Name = "Form_new";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox zname;
        public System.Windows.Forms.TextBox zport;
        public System.Windows.Forms.TextBox zip;
        public System.Windows.Forms.TextBox zpass;
        public System.Windows.Forms.TextBox zuser;
        public System.Windows.Forms.TextBox zsid;
        public System.Windows.Forms.TextBox zother;
    }
}