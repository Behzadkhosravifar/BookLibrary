using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Program_Library
{
    public partial class FormOK : Form
    {
        public FormOK()
        {
            InitializeComponent();
        }
        public int ten = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ten >= 15)
            {
                FormPass.Dis = true;
                Dispose();
            }
            else ten++;
        }
    }
}
