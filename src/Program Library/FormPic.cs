using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Program_Library
{
    public partial class FormPic : Form
    {
        public System.Windows.Forms.Label lblLoad;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblL2;
    
        public FormPic()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPic));
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblL2 = new System.Windows.Forms.Label();
            this.lblLoad = new System.Windows.Forms.Label();
            this.processLoad = new System.Windows.Forms.ProgressBar();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.White;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblWelcome.ForeColor = System.Drawing.Color.Red;
            this.lblWelcome.Location = new System.Drawing.Point(-4, 3);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(379, 42);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome To Program";
            // 
            // lblL2
            // 
            this.lblL2.AutoSize = true;
            this.lblL2.BackColor = System.Drawing.Color.White;
            this.lblL2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblL2.ForeColor = System.Drawing.Color.Red;
            this.lblL2.Location = new System.Drawing.Point(118, 45);
            this.lblL2.Name = "lblL2";
            this.lblL2.Size = new System.Drawing.Size(132, 42);
            this.lblL2.TabIndex = 0;
            this.lblL2.Text = "Library";
            // 
            // lblLoad
            // 
            this.lblLoad.BackColor = System.Drawing.Color.White;
            this.lblLoad.Location = new System.Drawing.Point(0, 332);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(250, 13);
            this.lblLoad.TabIndex = 1;
            this.lblLoad.Text = "Please Wait to Loading Data . . . ";
            // 
            // processLoad
            // 
            this.processLoad.BackColor = System.Drawing.Color.Crimson;
            this.processLoad.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.processLoad.Location = new System.Drawing.Point(-8, 347);
            this.processLoad.MarqueeAnimationSpeed = 1000;
            this.processLoad.Maximum = 1000;
            this.processLoad.Name = "processLoad";
            this.processLoad.Size = new System.Drawing.Size(572, 10);
            this.processLoad.Step = 1;
            this.processLoad.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.processLoad.TabIndex = 0;
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // FormPic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(555, 354);
            this.ControlBox = false;
            this.Controls.Add(this.processLoad);
            this.Controls.Add(this.lblL2);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblLoad);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPic";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormPic_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Boolean ContinueTF = true;

        private void FormPic_Load(object sender, EventArgs e)
        {
            //' Run this procedure in an appropriate event.
            // Set to 1 second.
            Timer1.Interval = 100;
            // Enable timer.
            Timer1.Enabled = true;
        }
        public int TimerCount = 0;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (ContinueTF == false) return;
            // Set the caption to the current time.
            switch (TimerCount)
            {
                case 0:
                    {
                        TimerCount++;
                        Thread.Sleep(50);
                        lblLoad.Text = @"Please Wait to Loading Data";
                        for (int i = 0; i <= 50; i++)
                        {
                            processLoad.Value++;
                            Thread.Sleep(6);
                        }
                    }
                    break;
                case 1:
                    {
                        TimerCount++;
                        lblLoad.Text = @"Please Wait to Loading Data .";
                        for (int i = 51; i <= 100; i++)
                        {
                            processLoad.Value++;
                            Thread.Sleep(6);
                        }
                    }
                    break;
                case 2:
                    {
                        TimerCount++;
                        lblLoad.Text = @"Please Wait to Loading Data . .";
                        for (int i = 101; i <= 150; i++)
                        {
                            processLoad.Value++;
                            Thread.Sleep(6);
                        }
                    }
                    break;
                case 3:
                    {
                        TimerCount++;
                        lblLoad.Text = @"Please Wait to Loading Data . . .";
                        for (int i = 151; i <= 200; i++)
                        {
                            processLoad.Value++;
                            Thread.Sleep(6);
                        }
                    }
                    break;
                case 4:
                    {
                        TimerCount++;
                        lblLoad.Text = @"Please Wait to Loading Data . . . .";
                        for (int i = 201; i <= 250; i++)
                        {
                            processLoad.Value++;
                            Thread.Sleep(6);
                        }
                    }
                    break;
                case 5:
                    {
                        TimerCount++;
                        lblLoad.Text = @"Please Wait to Loading Data . . . . .";
                        for (int i = 251; i <= 300; i++)
                        {
                            processLoad.Value++;
                            Thread.Sleep(6);
                        }
                    }
                    break;
                case 6:
                    {
                        TimerCount++;
                        if (System.IO.File.Exists(@"Program Library DB\Behzad.dll") == true)
                        {
                            lblLoad.Text = @"Data Loading -> \\Program Library DB\Behzad.dll";
                            Thread.Sleep(20);
                            for (int i = 301; i <= 350; i++)
                            {
                                processLoad.Value++;
                                Thread.Sleep(6);
                            }
                        }
                        else
                        {
                            for (int i = 301; i <= 350; i++)
                            {
                                processLoad.Value++;
                                Thread.Sleep(6);
                            }
                            Thread.Sleep(20);
                            ContinueTF = false;
                            lblLoad.Text = @"Data Loading -> Program Library DB\Behzad.dll";
                            MessageBox.Show("File Behzad.dll Not Found in Patch: Program Library DB\\Behzad.dll" +
                                "\nPlease press Ok to Close Program Library", "Error File System Runing Not Found!",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            Application.Exit();
                            return;
                        };
                    }
                    break;
                case 7:
                    {
                        TimerCount++;
                        lblLoad.Text = @"Data Loading -> \\Program Library DB\Behzad.dll";
                        for (int i = 351; i <= 400; i++)
                        {
                            processLoad.Value++;
                            Thread.Sleep(6);
                        }
                    }
                    break;
                case 8:
                    {
                        TimerCount++;
                        lblLoad.Text = @"Data Loading -> \\Program Library DB\Behzad.dll";
                        for (int i = 401; i <= 450; i++)
                        {
                            processLoad.Value++;
                            Thread.Sleep(6);
                        }
                    }
                    break;
                case 9:
                    {
                        TimerCount++;
                        lblLoad.Text = @"Data Loading -> \\Program Library DB\Behzad.dll";
                        for (int i = 451; i <= 500; i++)
                        {
                            processLoad.Value++;
                            Thread.Sleep(6);
                        }
                    }
                    break;
                case 10:
                    {
                        TimerCount++;
                        lblLoad.Text = @"Data Loading -> \\Program Library DB\Behzad.dll";
                        for (int i = 501; i <= 550; i++)
                        {
                            processLoad.Value++;
                            Thread.Sleep(6);
                        }
                    }
                    break;
                case 11:
                    {
                        TimerCount++;
                        if (File.Exists(@"Program Library DB\PatchB.dll") == true)
                        {
                            lblLoad.Text = @"Data Loading -> \\Program Library DB\PatchB.dll";
                            Thread.Sleep(20);
                            for (int i = 551; i <= 600; i++)
                            {
                                processLoad.Value++;
                                Thread.Sleep(6);
                            }
                        }
                        else
                        {
                            for (int i = 551; i <= 600; i++)
                            {
                                processLoad.Value++;
                                Thread.Sleep(6);
                            }
                            Thread.Sleep(30);
                            ContinueTF = false;
                            lblLoad.Text = @"Data Loading -> \\Program Library DB\PatchB.dll";
                            MessageBox.Show("File PatchB.dll Not Found in Patch: Program Library DB\\PatchB.dll" +
                                "\nPlease press Ok to Close Program Library", "Error File System Runing Not Found!",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            Application.Exit();
                            return;
                        }
                    }
                    break;
                case 12:
                    {
                        TimerCount++;
                        lblLoad.Text = @"Data Loading -> \\Program Library DB\PatchB.dll";
                        for (int i = 601; i <= 650; i++)
                        {
                            processLoad.Value++;
                            Thread.Sleep(6);
                        }
                    }
                    break;
                case 13:
                    {
                        TimerCount++;
                        lblLoad.Text = @"Data Loading -> \\Program Library DB\PatchB.dll";
                        for (int i = 651; i <= 700; i++)
                        {
                            processLoad.Value++;
                            Thread.Sleep(6);
                        }
                    }
                    break;
                case 14:
                    {
                        TimerCount++;
                        lblLoad.Text = @"Data Loading -> \\Program Library DB\PatchB.dll";
                        for (int i = 701; i <= 750; i++)
                        {
                            processLoad.Value++;
                            Thread.Sleep(6);
                        }
                    }
                    break;
                case 15:
                    {
                        TimerCount++;
                        lblLoad.Text = @"Data Loading -> \\Program Library DB\PatchB.dll";
                        for (int i = 751; i <= 800; i++)
                        {
                            processLoad.Value++;
                            Thread.Sleep(6);
                        }
                    }
                    break;
                case 16:
                    {
                        TimerCount++;
                        if (File.Exists(@"Program Library DB\PatchC.dll") == true)
                        {
                            lblLoad.Text = @"Data Loading -> \\Program Library DB\PatchC.dll";
                            Thread.Sleep(40);
                            for (int i = 801; i <= 850; i++)
                            {
                                processLoad.Value++;
                                Thread.Sleep(6);
                            }
                        }
                        else
                        {
                            for (int i = 801; i <= 850; i++)
                            {
                                processLoad.Value++;
                                Thread.Sleep(6);
                            }
                            Thread.Sleep(20);
                            ContinueTF = false;
                            lblLoad.Text = @"Data Loading -> \\Program Library DB\PatchC.dll";
                            MessageBox.Show("File PatchC.dll Not Found in Patch: Program Library DB\\PatchC.dll" +
                                "\nPlease press Ok to Close Program Library", "Error File System Runing Not Found!",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            Application.Exit();
                            return;
                        }
                    }
                    break;
                case 17:
                    {
                        TimerCount++;
                        lblLoad.Text = @"Data Loading -> \\Program Library DB\PatchC.dll";
                        for (int i = 851; i <= 900; i++)
                        {
                            processLoad.Value++;
                            Thread.Sleep(6);
                        }
                    }
                    break;
                case 18:
                    {
                        TimerCount++;
                        lblLoad.Text = @"Data Loading -> \\Program Library DB\PatchC.dll";
                        for (int i = 901; i <= 950; i++)
                        {
                            processLoad.Value++;
                            Thread.Sleep(6);
                        }
                    }
                    break;
                case 19:
                    {
                        TimerCount++;
                        lblLoad.Text = @"Data Loading -> \\Program Library DB\PatchC.dll";
                        for (int i = 951; i < 1000; i++)
                        {
                            processLoad.Value++;
                            Thread.Sleep(6);
                        }
                    }
                    break;
                case 20:
                    {
                        TimerCount++;
                        lblLoad.Text = @"Data Loading -> \\Program Library DB\PatchC.dll";
                        ContinueTF = false;
                        Dispose();
                    }
                    break;
                default: TimerCount = 18;
                    break;
            }
        }
    }
}
