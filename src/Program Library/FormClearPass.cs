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
    public partial class FormClearPass : Form
    {
        public FormClearPass()
        {
            InitializeComponent();
        }

        private void txtUserName_MouseLeave(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                txtUserName.ForeColor = Color.DimGray;
                txtUserName.Text = "User Name";
            }
        }

        private void txtUserName_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtUserName.Text == "")
            {
                txtUserName.ForeColor = Color.DimGray;
                txtUserName.Text = "User Name";
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtUserName.Text == "User Name")
            {
                txtUserName.Text = string.Empty;
                txtUserName.ForeColor = Color.Black;
            }
            else if (e.KeyCode == Keys.Escape) btnCancel_Click(sender, e);
        }

        private void txtUserName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUserName.Text == "User Name")
            {
                txtUserName.Text = string.Empty;
                txtUserName.ForeColor = Color.Black;
            }
        }
        private Boolean password = false;
        private void btnCheckPass_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "User Name")
            {
                MessageBox.Show("Textbox User Name is Empty!", "TextBox Empty Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);
                txtUserName.Select();
                return;
            }
            else if (txtPass.Text == "Password")
            {
                MessageBox.Show("Textbox Password is Empty!", "TextBox Empty Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);
                txtPass.Select();
                return;
            }
            else if (string.Compare("Admin", txtUserName.Text, true) == 0)
            {
                // Encoder Entered Password To ...(Private Code) --\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--
                char[] spilPass = txtPass.Text.ToCharArray();
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

                if (string.Compare(bufferPass, Form1.password, false) == 0)
                {
                    picUnlock.Visible = true;
                    lblLocked.Text = "UnLocked";
                    password = true;
                    btnClear.Enabled = true;
                    txtPass.Enabled = false;
                    txtUserName.Enabled = false;
                    btnCheckPass.Enabled = false;
                    btnClear.Focus();
                }
                else
                {
                    MessageBox.Show("Invalid The UserName or Password", "Error Password", MessageBoxButtons.OK
                        , MessageBoxIcon.Error);
                    txtPass.Text = String.Empty;
                    TextBox ch = new TextBox();
                    txtPass.PasswordChar = ch.PasswordChar;
                    txtPass.ForeColor = Color.DimGray;
                    txtPass.Text = "Password";
                    txtUserName.Text = string.Empty;
                    txtUserName.ForeColor = Color.DimGray;
                    txtUserName.Text = "User Name";
                    txtUserName.Focus();
                }
            }
            else
            {
                MessageBox.Show("Invalid The UserName or Password", "Error Password", MessageBoxButtons.OK
                        , MessageBoxIcon.Error);
                txtPass.Text = String.Empty;
                TextBox ch = new TextBox();
                txtPass.PasswordChar = ch.PasswordChar;
                txtPass.ForeColor = Color.DimGray;
                txtPass.Text = "Password";
                txtUserName.Text = string.Empty;
                txtUserName.ForeColor = Color.DimGray;
                txtUserName.Text = "User Name";
                txtUserName.Focus();
            }
        }

        private void txtPass_MouseLeave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                TextBox ch = new TextBox();
                txtPass.PasswordChar = ch.PasswordChar;
                txtPass.ForeColor = Color.DimGray;
                txtPass.Text = "Password";
            }
        }

        private void txtPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPass.Text == "")
            {
                TextBox ch = new TextBox();
                txtPass.PasswordChar = ch.PasswordChar;
                txtPass.ForeColor = Color.DimGray;
                txtPass.Text = "Password";
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtPass.Text == "Password")
            {
                txtPass.Text = string.Empty;
                txtPass.ForeColor = Color.Black;
                txtPass.PasswordChar = '*';
            }
            else if (e.KeyCode == Keys.Enter) btnCheckPass_Click(sender, e);
        }

        private void txtPass_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPass.Text == "Password")
            {
                txtPass.Text = string.Empty;
                txtPass.ForeColor = Color.Black;
                txtPass.PasswordChar = '*';
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Form1.ClearPass = false;
            Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (password == true)
            {
                Form1.ClearPass = true;
                MessageBox.Show("Clear Data Successful Complate!", "Clear Success");
                Dispose();
            }
            else if (password == false)
            {
                MessageBox.Show("First Check your User Name and Password for Clear Data \n"
                    + "Then if your UserName and Password was True and Unlocked Clear Data Click On Clear button"
                    , "Check Password Warning");
            }
        }
    }
}
