namespace Program_Library
{
    partial class FormChangePass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChangePass));
            this.chkShow = new System.Windows.Forms.CheckBox();
            this.txtConfirmNewPass = new System.Windows.Forms.TextBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.txtCurrentPass = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkShow
            // 
            this.chkShow.AutoSize = true;
            this.chkShow.Location = new System.Drawing.Point(182, 131);
            this.chkShow.Name = "chkShow";
            this.chkShow.Size = new System.Drawing.Size(113, 17);
            this.chkShow.TabIndex = 11;
            this.chkShow.Text = "Show Characterse";
            this.chkShow.UseVisualStyleBackColor = true;
            this.chkShow.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // txtConfirmNewPass
            // 
            this.txtConfirmNewPass.BackColor = System.Drawing.Color.White;
            this.txtConfirmNewPass.Location = new System.Drawing.Point(101, 70);
            this.txtConfirmNewPass.MaxLength = 40;
            this.txtConfirmNewPass.Name = "txtConfirmNewPass";
            this.txtConfirmNewPass.Size = new System.Drawing.Size(194, 20);
            this.txtConfirmNewPass.TabIndex = 9;
            this.txtConfirmNewPass.MouseLeave += new System.EventHandler(this.txtConfirmNewPass_MouseLeave);
            this.txtConfirmNewPass.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtConfirmNewPass_MouseMove);
            this.txtConfirmNewPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConfirmNewPass_KeyDown);
            this.txtConfirmNewPass.Leave += new System.EventHandler(this.txtConfirmNewPass_Leave);
            this.txtConfirmNewPass.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtConfirmNewPass_KeyUp);
            this.txtConfirmNewPass.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtConfirmNewPass_MouseClick);
            // 
            // txtNewPass
            // 
            this.txtNewPass.BackColor = System.Drawing.Color.White;
            this.txtNewPass.Location = new System.Drawing.Point(101, 44);
            this.txtNewPass.MaxLength = 40;
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(194, 20);
            this.txtNewPass.TabIndex = 8;
            this.txtNewPass.MouseLeave += new System.EventHandler(this.txtNewPass_MouseLeave);
            this.txtNewPass.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtNewPass_MouseMove);
            this.txtNewPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewPass_KeyDown);
            this.txtNewPass.Leave += new System.EventHandler(this.txtNewPass_Leave);
            this.txtNewPass.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNewPass_KeyUp);
            this.txtNewPass.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtNewPass_MouseClick);
            // 
            // txtCurrentPass
            // 
            this.txtCurrentPass.BackColor = System.Drawing.Color.White;
            this.txtCurrentPass.Location = new System.Drawing.Point(101, 18);
            this.txtCurrentPass.MaxLength = 40;
            this.txtCurrentPass.Name = "txtCurrentPass";
            this.txtCurrentPass.Size = new System.Drawing.Size(194, 20);
            this.txtCurrentPass.TabIndex = 7;
            this.txtCurrentPass.MouseLeave += new System.EventHandler(this.txtCurrentPass_MouseLeave);
            this.txtCurrentPass.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtCurrentPass_MouseMove);
            this.txtCurrentPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCurrentPass_KeyDown);
            this.txtCurrentPass.Leave += new System.EventHandler(this.txtCurrentPass_Leave);
            this.txtCurrentPass.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCurrentPass_KeyUp);
            this.txtCurrentPass.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCurrentPass_MouseClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(231, 102);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnChangePass
            // 
            this.btnChangePass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePass.Location = new System.Drawing.Point(101, 102);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(111, 23);
            this.btnChangePass.TabIndex = 10;
            this.btnChangePass.Text = "Change &Password";
            this.btnChangePass.UseVisualStyleBackColor = true;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-16, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // FormChangePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(310, 160);
            this.Controls.Add(this.chkShow);
            this.Controls.Add(this.txtConfirmNewPass);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.txtCurrentPass);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChangePass);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormChangePass";
            this.ShowInTaskbar = false;
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.FormChangePass_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormChangePass_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkShow;
        private System.Windows.Forms.TextBox txtConfirmNewPass;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.TextBox txtCurrentPass;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnChangePass;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}