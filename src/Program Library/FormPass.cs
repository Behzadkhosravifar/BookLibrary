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
    public partial class FormPass : Form
    {
        public FormPass()
        {
            InitializeComponent();
        }
 
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public int openbufer = 0; // close program if Invalid Password was more than 5
        public static bool Dis = false;
        private void FormPass_Load(object sender, EventArgs e)
        {
            FormPic Demo = new FormPic();
            Demo.ShowDialog();
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.Focus();
            timer1.Enabled = true;
        }
        
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnOk_Click(sender, e);
            else if (e.KeyCode == Keys.Escape) btnExit_Click(sender, e);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Load pass
            if (System.IO.File.Exists(Form1.patch) == true)
                Form1.password = System.IO.File.ReadAllText(Form1.patch);
            else Form1.password = "642262666192376815848799551463570896553700";

            // Encoder Entered Password To ...(Private Code) --\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--
            char[] spilPass = txtPassword.Text.ToCharArray();
            int[] PassEncoder = new int[spilPass.Length];
            int counter = 0;
            foreach (char readCh in spilPass)
            {
                PassEncoder[counter] = readCh.GetHashCode();
                counter++;
            }
            string bufferPass = string.Empty;
            foreach (int readInt in PassEncoder)
            {
                bufferPass += readInt.ToString();
            }
            //--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/----\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--

            if (bufferPass == Form1.password)
            {
                Form1.passOk = true;
                FormOK ok = new FormOK();
                ok.ShowDialog();
                if (Dis == true)
                    Dispose();
            }
            else
            {
                openbufer++;
                MessageBox.Show("Invalid The Password", "Error Password", MessageBoxButtons.OK
                    , MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                if (openbufer >= 5) Application.Exit();
                txtPassword.Text = String.Empty;
                txtPassword.Focus();
                txtPassword.SelectAll();
                return;
            }
        }

        public string Title = "                                              Please press ENTER key to accept your password!!";
        public static int countTitle = 43;
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            char[] charTitle = Title.ToCharArray();
            string ch = "";
            for (int i = countTitle; i <= 93; i++)
            {
                ch += charTitle[i];
            }
            countTitle++;
            if (countTitle >= 93) countTitle = 0;
            lblDynamicText.Text = ch;
        }
    }
}
