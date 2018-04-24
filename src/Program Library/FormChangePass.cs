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
    public partial class FormChangePass : Form
    {
        public FormChangePass()
        {
            InitializeComponent();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            // Encoder Entered Password To ...(Private Code) --\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--
            char[] spilPass = txtCurrentPass.Text.ToCharArray();
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
                if (string.Compare(txtNewPass.Text, txtConfirmNewPass.Text, false) == 0)
                {
                    // Encode New Password to Save ---------------------------------------------------------------
                    char[] arrChar = txtNewPass.Text.ToCharArray();
                    int[] arrCharToArrInt = new int[arrChar.Length];
                    int i = 0;
                    foreach (char ch in arrChar)
                    {
                        arrCharToArrInt[i] = ch.GetHashCode();
                        i++;
                    }
                    Form1.password = string.Empty;
                    foreach (int Encode in arrCharToArrInt)
                    {
                        Form1.password += Encode.ToString();
                    }
                    // -------------------------------------------------------------------------------------------
                    SavePass();
                    Dispose();
                }
                else
                {
                    MessageBox.Show("The passwords you typed do not match. Please retype the new password in both boxes.",
                        "Change Password Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNewPass.Text = string.Empty;
                    txtConfirmNewPass.Text = string.Empty;
                    TextBox txtEmpty = new TextBox();
                    txtNewPass.PasswordChar = txtEmpty.PasswordChar;
                    txtConfirmNewPass.PasswordChar = txtEmpty.PasswordChar;
                    txtConfirmNewPass.ForeColor = Color.DarkGray;
                    txtNewPass.ForeColor = Color.DarkGray;
                    txtNewPass.Text = "New Password";
                    txtConfirmNewPass.Text = "Confirm New Password";
                    txtNewPass.Focus();
                }
            else
            {
                MessageBox.Show("The password you typed is incorrect. Please retype your current password.",
                    "Change Password Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtCurrentPass.Text = string.Empty;
                txtNewPass.Text = string.Empty;
                txtConfirmNewPass.Text = string.Empty;
                TextBox txtEmpty = new TextBox();
                txtNewPass.PasswordChar = txtEmpty.PasswordChar;
                txtConfirmNewPass.PasswordChar = txtEmpty.PasswordChar;
                txtCurrentPass.PasswordChar = txtEmpty.PasswordChar;
                txtConfirmNewPass.ForeColor = Color.DarkGray;
                txtNewPass.ForeColor = Color.DarkGray;
                txtCurrentPass.ForeColor = Color.DarkGray;
                txtCurrentPass.Text = "Current Password";
                txtNewPass.Text = "New Password";
                txtConfirmNewPass.Text = "Confirm New Password";
                txtCurrentPass.Focus();
            }
        }

        private void SavePass()
        {
            System.IO.File.WriteAllText(Form1.patch, Form1.password);
            FormPassOK Okform = new FormPassOK();
            Okform.ShowDialog();
        }

        private void txtCurrentPass_MouseLeave(object sender, EventArgs e)
        {
            if (txtCurrentPass.Text == "" && RightClick == false)
            {
                TextBox txtEmpty = new TextBox();
                txtCurrentPass.PasswordChar = txtEmpty.PasswordChar;
                txtCurrentPass.ForeColor = Color.DarkGray;
                txtCurrentPass.Text = "Current Password";
            }
        }

        private void txtCurrentPass_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.Compare(txtCurrentPass.Text, "Current Password", false) == 0)
            {
                txtCurrentPass.Text = string.Empty;
                txtCurrentPass.ForeColor = Color.Black;
                if (!chkShow.Checked)
                    txtCurrentPass.PasswordChar = '*';
            }
            else if (e.Button == MouseButtons.Right && txtCurrentPass.Text == "Current Password")
            {
                txtCurrentPass.Text = string.Empty;
                txtCurrentPass.ForeColor = Color.Black;
                if (!chkShow.Checked)
                    txtCurrentPass.PasswordChar = '*';
                RightClick = true;
            }
        }

        private void FormChangePass_Load(object sender, EventArgs e)
        {
            txtConfirmNewPass.ForeColor = Color.DarkGray;
            txtNewPass.ForeColor = Color.DarkGray;
            txtCurrentPass.ForeColor = Color.DarkGray;
            txtCurrentPass.Text = "Current Password";
            txtNewPass.Text = "New Password";
            txtConfirmNewPass.Text = "Confirm New Password";
            txtCurrentPass.Focus();
        }

        private void txtNewPass_MouseLeave(object sender, EventArgs e)
        {
            if (txtNewPass.Text == "" && RightClick == false)
            {
                TextBox txtEmpty = new TextBox();
                txtNewPass.PasswordChar = txtEmpty.PasswordChar;
                txtNewPass.ForeColor = Color.DarkGray;
                txtNewPass.Text = "New Password";
            }
        }

        private void txtConfirmNewPass_MouseLeave(object sender, EventArgs e)
        {
            if (txtConfirmNewPass.Text == "" && RightClick == false)
            {
                TextBox txtEmpty = new TextBox();
                txtConfirmNewPass.PasswordChar = txtEmpty.PasswordChar;
                txtConfirmNewPass.ForeColor = Color.DarkGray;
                txtConfirmNewPass.Text = "Confirm New Password";
            }
        }

        private void txtConfirmNewPass_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.Compare(txtConfirmNewPass.Text, "Confirm New Password", false) == 0)
            {
                txtConfirmNewPass.Text = string.Empty;
                txtConfirmNewPass.ForeColor = Color.Black;
                if (!chkShow.Checked)
                    txtConfirmNewPass.PasswordChar = '*';
            }
            else if (e.Button == MouseButtons.Right && txtConfirmNewPass.Text == "Confirm New Password")
            {
                txtConfirmNewPass.Text = string.Empty;
                txtConfirmNewPass.ForeColor = Color.Black;
                if (!chkShow.Checked)
                    txtConfirmNewPass.PasswordChar = '*';
                RightClick = true;
            }
        }

        private void txtNewPass_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.Compare(txtNewPass.Text, "New Password", false) == 0)
            {
                txtNewPass.Text = string.Empty;
                txtNewPass.ForeColor = Color.Black;
                if (!chkShow.Checked)
                    txtNewPass.PasswordChar = '*';
            }
            else if (e.Button == MouseButtons.Right && txtNewPass.Text == "New Password")
            {
                txtNewPass.Text = string.Empty;
                txtNewPass.ForeColor = Color.Black;
                if (!chkShow.Checked)
                    txtNewPass.PasswordChar = '*';
                RightClick = true;
            }
        }
        
        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShow.Checked)
            {
                TextBox check = new TextBox();
                txtCurrentPass.PasswordChar = check.PasswordChar;
                txtNewPass.PasswordChar = check.PasswordChar;
                txtConfirmNewPass.PasswordChar = check.PasswordChar;
            }
            else
            {
                if (txtCurrentPass.Text != "Current Password")
                    txtCurrentPass.PasswordChar = '*';

                if (txtNewPass.Text != "New Password")
                    txtNewPass.PasswordChar = '*';

                if (txtConfirmNewPass.Text != "Confirm New Password")
                    txtConfirmNewPass.PasswordChar = '*';
            }
        }

        private void txtCurrentPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtCurrentPass.Text == "")
            {
                TextBox Clear = new TextBox();
                txtCurrentPass.PasswordChar = Clear.PasswordChar;
                txtCurrentPass.ForeColor = Color.DarkGray;
                txtCurrentPass.Text = "Current Password";
            }
        }

        private void txtNewPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtNewPass.Text == "")
            {
                TextBox Clear = new TextBox();
                txtNewPass.PasswordChar = Clear.PasswordChar;
                txtNewPass.ForeColor = Color.DarkGray;
                txtNewPass.Text = "New Password";
            }
        }

        private void txtConfirmNewPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtConfirmNewPass.Text == "")
            {
                TextBox Clear = new TextBox();
                txtConfirmNewPass.PasswordChar = Clear.PasswordChar;
                txtConfirmNewPass.ForeColor = Color.DarkGray;
                txtConfirmNewPass.Text = "Confirm New Password";
            }
        }

        private void txtCurrentPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnChangePass_Click(sender, e);
            if (string.Compare(txtCurrentPass.Text, "Current Password", false) == 0)
            {
                txtCurrentPass.Text = string.Empty;
                txtCurrentPass.ForeColor = Color.Black;
                if (!chkShow.Checked)
                    txtCurrentPass.PasswordChar = '*';
            }
        }

        private void txtNewPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnChangePass_Click(sender, e);
            if (string.Compare(txtNewPass.Text, "New Password", false) == 0)
            {
                txtNewPass.Text = string.Empty;
                txtNewPass.ForeColor = Color.Black;
                if (!chkShow.Checked)
                    txtNewPass.PasswordChar = '*';
            }
        }

        private void txtConfirmNewPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnChangePass_Click(sender, e);
            if (string.Compare(txtConfirmNewPass.Text, "Confirm New Password", false) == 0)
            {
                txtConfirmNewPass.Text = string.Empty;
                txtConfirmNewPass.ForeColor = Color.Black;
                if (!chkShow.Checked)
                    txtConfirmNewPass.PasswordChar = '*';
            }
        }
        public bool RightClick = false;
        private void txtCurrentPass_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && txtCurrentPass.Text == "Current Password")
            {
                txtCurrentPass.Text = string.Empty;
                txtCurrentPass.ForeColor = Color.Black;
                if (!chkShow.Checked)
                    txtCurrentPass.PasswordChar = '*';
                RightClick = true;
            }
        }

        private void FormChangePass_MouseClick(object sender, MouseEventArgs e)
        {
            // txtCurrentPass Right Click ...
            if (txtCurrentPass.Text == "" && RightClick == true)
            {
                RightClick = false;
                txtCurrentPass.ForeColor = Color.DarkGray;
                TextBox ClearPass = new TextBox();
                txtCurrentPass.PasswordChar = ClearPass.PasswordChar;
                txtCurrentPass.Text = "Current Password";
            }
            else if (txtCurrentPass.Text == "" && e.Button == MouseButtons.Right && RightClick == true)
            {
                RightClick = false;
                txtCurrentPass.ForeColor = Color.DarkGray;
                TextBox ClearPass = new TextBox();
                txtCurrentPass.PasswordChar = ClearPass.PasswordChar;
                txtCurrentPass.Text = "Current Password";
            }
            //
            // txtConfirmNewPass Right Click ... 
            if (txtConfirmNewPass.Text == "" && RightClick == true)
            {
                RightClick = false;
                txtConfirmNewPass.ForeColor = Color.DarkGray;
                TextBox ClearPass = new TextBox();
                txtConfirmNewPass.PasswordChar = ClearPass.PasswordChar;
                txtConfirmNewPass.Text = "Confirm New Password";
            }
            else if (txtConfirmNewPass.Text == "" && e.Button == MouseButtons.Right && RightClick == true)
            {
                RightClick = false;
                txtConfirmNewPass.ForeColor = Color.DarkGray;
                TextBox ClearPass = new TextBox();
                txtConfirmNewPass.PasswordChar = ClearPass.PasswordChar;
                txtConfirmNewPass.Text = "Confirm New Password";
            }
            //
            // txtNewPass Right Click ... 
            if (txtNewPass.Text == "" && RightClick == true)
            {
                RightClick = false;
                txtNewPass.ForeColor = Color.DarkGray;
                TextBox ClearPass = new TextBox();
                txtNewPass.PasswordChar = ClearPass.PasswordChar;
                txtNewPass.Text = "New Password";
            }
            else if (txtNewPass.Text == "" && e.Button == MouseButtons.Right && RightClick == true)
            {
                RightClick = false;
                txtNewPass.ForeColor = Color.DarkGray;
                TextBox ClearPass = new TextBox();
                txtNewPass.PasswordChar = ClearPass.PasswordChar;
                txtNewPass.Text = "New Password";
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            // txtCurrentPass Right Click ...
            if (txtCurrentPass.Text == "" && RightClick == true)
            {
                RightClick = false;
                txtCurrentPass.ForeColor = Color.DarkGray;
                TextBox ClearPass = new TextBox();
                txtCurrentPass.PasswordChar = ClearPass.PasswordChar;
                txtCurrentPass.Text = "Current Password";
            }
            else if (txtCurrentPass.Text == "" && e.Button == MouseButtons.Right && RightClick == true)
            {
                RightClick = false;
                txtCurrentPass.ForeColor = Color.DarkGray;
                TextBox ClearPass = new TextBox();
                txtCurrentPass.PasswordChar = ClearPass.PasswordChar;
                txtCurrentPass.Text = "Current Password";
            }
            //
            // txtConfirmNewPass Right Click ... 
            if (txtConfirmNewPass.Text == "" && RightClick == true)
            {
                RightClick = false;
                txtConfirmNewPass.ForeColor = Color.DarkGray;
                TextBox ClearPass = new TextBox();
                txtConfirmNewPass.PasswordChar = ClearPass.PasswordChar;
                txtConfirmNewPass.Text = "Confirm New Password";
            }
            else if (txtConfirmNewPass.Text == "" && e.Button == MouseButtons.Right && RightClick == true)
            {
                RightClick = false;
                txtConfirmNewPass.ForeColor = Color.DarkGray;
                TextBox ClearPass = new TextBox();
                txtConfirmNewPass.PasswordChar = ClearPass.PasswordChar;
                txtConfirmNewPass.Text = "Confirm New Password";
            }
            //
            // txtNewPass Right Click ... 
            if (txtNewPass.Text == "" && RightClick == true)
            {
                RightClick = false;
                txtNewPass.ForeColor = Color.DarkGray;
                TextBox ClearPass = new TextBox();
                txtNewPass.PasswordChar = ClearPass.PasswordChar;
                txtNewPass.Text = "New Password";
            }
            else if (txtNewPass.Text == "" && e.Button == MouseButtons.Right && RightClick == true)
            {
                RightClick = false;
                txtNewPass.ForeColor = Color.DarkGray;
                TextBox ClearPass = new TextBox();
                txtNewPass.PasswordChar = ClearPass.PasswordChar;
                txtNewPass.Text = "New Password";
            }
        }

        private void txtNewPass_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && txtNewPass.Text == "New Password")
            {
                txtNewPass.Text = string.Empty;
                txtNewPass.ForeColor = Color.Black;
                if (!chkShow.Checked)
                    txtNewPass.PasswordChar = '*';
                RightClick = true;
            }
        }

        private void txtConfirmNewPass_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && txtConfirmNewPass.Text == "Confirm New Password")
            {
                txtConfirmNewPass.Text = string.Empty;
                txtConfirmNewPass.ForeColor = Color.Black;
                if (!chkShow.Checked)
                    txtConfirmNewPass.PasswordChar = '*';
                RightClick = true;
            }
        }

        private void txtCurrentPass_Leave(object sender, EventArgs e)
        {
            if (RightClick == true && txtCurrentPass.Text == "")
            {
                txtCurrentPass.ForeColor = Color.DarkGray;
                TextBox ClearPass = new TextBox();
                txtCurrentPass.PasswordChar = ClearPass.PasswordChar;
                txtCurrentPass.Text = "Current Password";
                RightClick = false;
            }
        }

        private void txtNewPass_Leave(object sender, EventArgs e)
        {
            if (RightClick == true && txtNewPass.Text == "")
            {
                txtNewPass.ForeColor = Color.DarkGray;
                TextBox ClearPass = new TextBox();
                txtNewPass.PasswordChar = ClearPass.PasswordChar;
                txtNewPass.Text = "New Password";
                RightClick = false;
            }
        }

        private void txtConfirmNewPass_Leave(object sender, EventArgs e)
        {
            if (RightClick == true && txtConfirmNewPass.Text == "")
            {
                txtConfirmNewPass.ForeColor = Color.DarkGray;
                TextBox ClearPass = new TextBox();
                txtConfirmNewPass.PasswordChar = ClearPass.PasswordChar;
                txtConfirmNewPass.Text = "Confirm New Password";
                RightClick = false;
            }
        }
        
    }
}
