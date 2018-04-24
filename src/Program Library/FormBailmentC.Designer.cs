namespace Program_Library
{
    partial class FormBailmentC
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBailmentC));
            this.btnAllBailment = new System.Windows.Forms.Button();
            this.btnAddBailment = new System.Windows.Forms.Button();
            this.btnDeleteBailment = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnAllBailment
            // 
            this.btnAllBailment.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAllBailment.BackgroundImage")));
            this.btnAllBailment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAllBailment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAllBailment.Location = new System.Drawing.Point(224, 12);
            this.btnAllBailment.Name = "btnAllBailment";
            this.btnAllBailment.Size = new System.Drawing.Size(100, 91);
            this.btnAllBailment.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btnAllBailment, " های امانتیCD - DVD نمایش کل لیست");
            this.btnAllBailment.UseVisualStyleBackColor = true;
            this.btnAllBailment.Click += new System.EventHandler(this.btnAllBailment_Click);
            // 
            // btnAddBailment
            // 
            this.btnAddBailment.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddBailment.BackgroundImage")));
            this.btnAddBailment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddBailment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddBailment.Location = new System.Drawing.Point(118, 12);
            this.btnAddBailment.Name = "btnAddBailment";
            this.btnAddBailment.Size = new System.Drawing.Size(100, 91);
            this.btnAddBailment.TabIndex = 0;
            this.toolTip2.SetToolTip(this.btnAddBailment, " امانتی CD - DVD اضافه کردن ");
            this.btnAddBailment.UseVisualStyleBackColor = true;
            this.btnAddBailment.Click += new System.EventHandler(this.btnAddBailment_Click);
            // 
            // btnDeleteBailment
            // 
            this.btnDeleteBailment.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDeleteBailment.BackgroundImage")));
            this.btnDeleteBailment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteBailment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteBailment.Location = new System.Drawing.Point(12, 12);
            this.btnDeleteBailment.Name = "btnDeleteBailment";
            this.btnDeleteBailment.Size = new System.Drawing.Size(100, 91);
            this.btnDeleteBailment.TabIndex = 0;
            this.toolTip3.SetToolTip(this.btnDeleteBailment, "  امانتی CD - DVD حذف ");
            this.btnDeleteBailment.UseVisualStyleBackColor = true;
            this.btnDeleteBailment.Click += new System.EventHandler(this.btnDeleteBailment_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.OwnerDraw = true;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.StripAmpersands = true;
            this.toolTip1.ToolTipTitle = "Display All Bailment CD - DVD";
            // 
            // toolTip2
            // 
            this.toolTip2.AutoPopDelay = 10000;
            this.toolTip2.InitialDelay = 500;
            this.toolTip2.IsBalloon = true;
            this.toolTip2.OwnerDraw = true;
            this.toolTip2.ReshowDelay = 100;
            this.toolTip2.ShowAlways = true;
            this.toolTip2.StripAmpersands = true;
            this.toolTip2.ToolTipTitle = "Add Bailment CD - DVD";
            // 
            // toolTip3
            // 
            this.toolTip3.AutoPopDelay = 10000;
            this.toolTip3.InitialDelay = 500;
            this.toolTip3.IsBalloon = true;
            this.toolTip3.OwnerDraw = true;
            this.toolTip3.ReshowDelay = 100;
            this.toolTip3.ShowAlways = true;
            this.toolTip3.StripAmpersands = true;
            this.toolTip3.ToolTipTitle = "Delete Bailment CD - DVD";
            // 
            // FormBailmentC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 115);
            this.Controls.Add(this.btnDeleteBailment);
            this.Controls.Add(this.btnAddBailment);
            this.Controls.Add(this.btnAllBailment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBailmentC";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Bailment CD - DVD";
            this.Load += new System.EventHandler(this.FormBailmentC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAllBailment;
        private System.Windows.Forms.Button btnAddBailment;
        private System.Windows.Forms.Button btnDeleteBailment;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;


    }
}