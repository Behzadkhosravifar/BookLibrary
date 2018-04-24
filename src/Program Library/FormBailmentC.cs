using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Program_Library
{
    public partial class FormBailmentC : Form
    {
        public FormBailmentC()
        {
            InitializeComponent();
        }

        private void btnAllBailment_Click(object sender, EventArgs e)
        {
            FormBailmentCDisplay CDisplay = new FormBailmentCDisplay();
            CDisplay.ShowDialog();
        }

        private void btnAddBailment_Click(object sender, EventArgs e)
        {
            FormBailmentCAdd CAdd = new FormBailmentCAdd();
            CAdd.ShowDialog();
        }

        private void FormBailmentC_Load(object sender, EventArgs e)
        {
            if (Form1.arrCdInfo.Count <= 0)
            {
                btnAddBailment.Enabled = false;
                btnAllBailment.Enabled = false;
                btnDeleteBailment.Enabled = false;
                this.Text = "Bailment CD - DVD    (Lucked)";
            }
        }

        private void btnDeleteBailment_Click(object sender, EventArgs e)
        {
            FormBailmentCDelete CDelete = new FormBailmentCDelete();
            CDelete.ShowDialog();
        }
    }
}
