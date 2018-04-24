using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Program_Library
{
    public partial class FormBailmentCDelete : Form
    {
        public FormBailmentCDelete()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void txtSearchCdName_MouseLeave(object sender, EventArgs e)
        {
            if (txtSearchCdName.Text == "")
            {
                txtSearchCdName.ForeColor = Color.DarkGray;
                txtSearchCdName.Text = "CD یا DVD نام";
                btnSearch.Enabled = false;
            }
        }

        public void FindAllOfMyString(string searchString)
        {
            // Set the SelectionMode property of the ListBox to select multiple items.
            lstCdName.SelectionMode = SelectionMode.One;

            // Set our intial index variable to -1.
            int x = -1;
            // If the search string is empty exit.
            if (searchString.Length != 0)
            {
                // Loop through and find each item that matches the search string.
                do
                {
                    // Retrieve the item based on the previous index found. Starts with -1 which searches start.
                    x = lstCdName.FindString(searchString, x);
                    // If no item is found that matches exit.
                    if (x != -1)
                    {
                        // Since the FindString loops infinitely, determine if we found first item again and exit.
                        if (lstCdName.SelectedIndices.Count > 0)
                        {
                            if (x == lstCdName.SelectedIndices[0]) return;
                        }
                        // Select the item in the ListBox once it is found.
                        if (lstCdName.Items.Count > x + 6)
                        {
                            lstCdName.SetSelected(x + 6, true);
                            lstCdName.ClearSelected();
                        }
                        else
                        {
                            lstCdName.SetSelected(lstCdName.Items.Count - 1, true);
                            lstCdName.ClearSelected();
                        }
                        lstCdName.ClearSelected();
                        lstCdName.SetSelected(x, true);
                        break;
                    }
                    // If no item is found that matches Clear SelectedItem.
                    else lstCdName.ClearSelected();

                } while (x != -1);
            }
        }
        private void txtSearchCdName_KeyUp(object sender, KeyEventArgs e)
        {
            btnDelete.Enabled = false;
            ToggleMenus();
            if (txtSearchCdName.Text == "")
            {
                txtSearchCdName.ForeColor = Color.DarkGray;
                txtSearchCdName.Text = "CD یا DVD نام";
                btnSearch.Enabled = false;
                lstCdName.ClearSelected();
                if (lstCdName.Items.Count != 0) lstCdName.SetSelected(0, true);
            }
            else if (txtSearchCdName.Text != "") FindAllOfMyString(txtSearchCdName.Text);
        }

        private void txtSearchCdName_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSearchCdName.Text == "CD یا DVD نام")
            {
                txtSearchCdName.Text = string.Empty;
                txtSearchCdName.ForeColor = Color.Black;
                btnSearch.Enabled = true;
            }
            if (e.KeyCode == Keys.Enter && lstCdName.SelectedIndex >= 0) btnSearch_Click(sender, e);
        }

        private void txtSearchCdName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtSearchCdName.Text == "CD یا DVD نام")
            {
                txtSearchCdName.Text = string.Empty;
                txtSearchCdName.ForeColor = Color.Black;
                btnSearch.Enabled = true;
            }
        }

        private void FormBailmentCDelete_Load(object sender, EventArgs e)
        {
            foreach (CdBailment FirstLoad in Form1.arrCdBailment.Values)
            {
                lstCdName.Items.Add(FirstLoad.CdName);
                txtSearchCdName.AutoCompleteCustomSource.Add(FirstLoad.CdName);
            }
        }

        public void DisableButton()
        {
            copyToolStripButton.Enabled = false;
            copyToolStripMenuItem.Enabled = false;
            pasteToolStripButton.Enabled = false;
            pasteToolStripMenuItem.Enabled = false;
            selectAllToolStripMenuItem.Enabled = false;
        }
        private void ClearText()
        {
            txtSearchCdName.ForeColor = Color.DarkGray;
            txtSearchCdName.Text = "CD یا DVD نام";
            txtBailmentUser.ForeColor = Color.DarkGray;
            txtBailmentUser.Text = "نام امانت گیرنده";
            txtBailmentCdSpecification.ForeColor = Color.DarkGray;
            txtBailmentCdSpecification.Text = "امانتی CD - DVD مشخصات و خصوصیات";
            txtBailmentCdNumber.ForeColor = Color.DarkGray;
            txtBailmentCdNumber.Text = "امانتی CD - DVD تعداد";
            txtBailmentCdType.ForeColor = Color.DarkGray;
            txtBailmentCdType.Text = "امانتی CD - DVD نوع";
            txtDateOfBailmentCd.ForeColor = Color.DarkGray;
            txtDateOfBailmentCd.Text = "تاریخ امانت گیری";
            DisableButton();
            txtSearchCdName.Focus();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void tbrClear_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void changePassStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormChangePass ChangePass = new FormChangePass();
            ChangePass.ShowDialog();
        }

        public void SaveCD()
        {
            if (Form1.SavedNewC == false)
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                // Set the FolderBrowserDialog control properties
                folderBrowserDialog1.Description = "Select a folder for your CDs backups:";
                folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
                folderBrowserDialog1.ShowNewFolderButton = true;
                // Show the Browse For Folder dialog
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    Form1.patchCD = folderBrowserDialog1.SelectedPath;
                    Form1.SaveCdInfo();
                    Form1.SaveCdBailment();
                    Form1.SavedCdInfo = true;
                    Form1.SavedNewC = true;
                }
            }
            else
            {
                Form1.SaveCdInfo();
                Form1.SaveCdBailment();
                Form1.SavedCdInfo = true;
            }
        }
        private void SaveBStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCD();
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddC AddC = new FormAddC();
            AddC.ShowDialog();
        }

        private void BailmentDStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBailment Bailment = new FormBailment();
            Bailment.ShowDialog();
        }

        private void DelBStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDeleteC DeleteC = new FormDeleteC();
            DeleteC.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Declare a TextBox object and
            // set it to the ActiveControl
            TextBox objTextBox = (TextBox)this.ActiveControl;
            // Copy the text to the clipboard
            objTextBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // set it to the ActiveControl
            TextBox objTextBox = (TextBox)this.ActiveControl;
            // Copy the data from the clipboard to the textbox
            objTextBox.Paste();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            // set it to the ActiveControl
            TextBox objTextBox = (TextBox)this.ActiveControl;
            // Copy the data from the clipboard to the textbox
            objTextBox.Paste();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            // Declare a TextBox object and
            // set it to the ActiveControl
            TextBox objTextBox = (TextBox)this.ActiveControl;
            // Copy the text to the clipboard
            objTextBox.Copy();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Declare a TextBox object and
            // set it to the ActiveControl
            TextBox objTextBox = (TextBox)this.ActiveControl;
            // Select all text
            objTextBox.SelectAll();
        }

        private void mainStripMenuItem_Click(object sender, EventArgs e)
        {
            // Toggle the visibility of the Main toolbar
            // based on this menu item's Checked property
            if (mainStripMenuItem.Checked)
            {
                tspMain.Visible = true;
            }
            else
            {
                tspMain.Visible = false;
            }
        }

        private void SearchBStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSearch Search = new FormSearch();
            Search.ShowDialog();
        }

        private void SearchDStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSearchC SearchC = new FormSearchC();
            SearchC.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout About = new FormAbout();
            About.ShowDialog();
        }

        private void tbrHelpAbout_Click(object sender, EventArgs e)
        {
            FormAbout About = new FormAbout();
            About.ShowDialog();
        }

        public void UppercaseText()
        {
            // Make the text Uppercase
            if (txtSearchCdName.Text != "CD یا DVD نام")
                txtSearchCdName.Text = txtSearchCdName.Text.ToUpper();
            if (txtBailmentUser.Text != "نام امانت گیرنده")
                txtBailmentUser.Text = txtBailmentUser.Text.ToUpper();
            if (txtBailmentCdSpecification.Text != "امانتی CD - DVD مشخصات و خصوصیات")
                txtBailmentCdSpecification.Text = txtBailmentCdSpecification.Text.ToUpper();
            if (txtBailmentCdNumber.Text != "امانتی CD - DVD تعداد")
                txtBailmentCdNumber.Text = txtBailmentCdNumber.Text.ToUpper();
            if (txtBailmentCdType.Text != "امانتی CD - DVD نوع")
                txtBailmentCdType.Text = txtBailmentCdType.Text.ToUpper();
            if (txtDateOfBailmentCd.Text != "تاریخ امانت گیری")
                txtDateOfBailmentCd.Text = txtDateOfBailmentCd.Text.ToUpper();
        }
        private void tbrUpperCase_Click(object sender, EventArgs e)
        {
            UppercaseText();
        }

        public void LowercaseText()
        {
            // Make the text Lowercase
            if (txtSearchCdName.Text != "CD یا DVD نام")
                txtSearchCdName.Text = txtSearchCdName.Text.ToLower();
            if (txtBailmentUser.Text != "نام امانت گیرنده")
                txtBailmentUser.Text = txtBailmentUser.Text.ToLower();
            if (txtBailmentCdSpecification.Text != "امانتی CD - DVD مشخصات و خصوصیات")
                txtBailmentCdSpecification.Text = txtBailmentCdSpecification.Text.ToLower();
            if (txtBailmentCdNumber.Text != "امانتی CD - DVD تعداد")
                txtBailmentCdNumber.Text = txtBailmentCdNumber.Text.ToLower();
            if (txtBailmentCdType.Text != "امانتی CD - DVD نوع")
                txtBailmentCdType.Text = txtBailmentCdType.Text.ToLower();
            if (txtDateOfBailmentCd.Text != "تاریخ امانت گیری")
                txtDateOfBailmentCd.Text = txtDateOfBailmentCd.Text.ToLower();
        }
        private void tbrLowerCase_Click(object sender, EventArgs e)
        {
            LowercaseText();
        }

        private void ToggleMenus()
        {
            // Declare a TextBox object and
            // set it to the ActiveControl
            TextBox objTextBox = (TextBox)this.ActiveControl;

            // Toggle the Copy toolbar button and menu items
            // اگر چیزی انتخاب نشود طول مقدار انتخابی 0 خواهد بود
            // بر میگرداند True و دیگر اعداد را False به جای عدد 0 Convert.ToBoolean(0)دستور
            copyToolStripMenuItem.Enabled = Convert.ToBoolean(objTextBox.SelectionLength);
            copyToolStripButton.Enabled = Convert.ToBoolean(objTextBox.SelectionLength);
            // Toggle the Paste toolbar button and menu items
            pasteToolStripMenuItem.Enabled = Clipboard.ContainsText();
            pasteToolStripButton.Enabled = Clipboard.ContainsText();
            // Toggle the Select All menu items
            selectAllToolStripMenuItem.Enabled = (objTextBox.SelectionLength < objTextBox.Text.Length);
        }

        private void lstCdName_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnDelete_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void txtSearchCdName_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtBailmentUser_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtBailmentCdSpecification_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtBailmentCdNumber_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtBailmentCdType_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtDateOfBailmentCd_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtBailmentUser_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtBailmentCdSpecification_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtBailmentCdNumber_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtBailmentCdType_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtDateOfBailmentCd_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtSearchCdName_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtSearchCdName == ActiveControl) ToggleMenus();
        }

        private void txtBailmentUser_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtBailmentUser == ActiveControl) ToggleMenus();
        }

        private void txtBailmentCdSpecification_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtBailmentCdSpecification == ActiveControl) ToggleMenus();
        }

        private void txtBailmentCdNumber_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtBailmentCdNumber == ActiveControl) ToggleMenus();
        }

        private void txtBailmentCdType_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtBailmentCdType == ActiveControl) ToggleMenus();
        }

        private void txtDateOfBailmentCd_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtDateOfBailmentCd == ActiveControl) ToggleMenus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (lstCdName.SelectedIndex >= 0)
            {
                string bufferName = lstCdName.SelectedItem.ToString();
                Hashtable BailmentRead = new Hashtable();
                BailmentRead.Add(bufferName, Form1.arrCdBailment[bufferName]);
                Hashtable CdInfoRead = new Hashtable();
                CdInfoRead.Add(bufferName, Form1.arrCdInfo[bufferName]);
                foreach (CdBailment Read in BailmentRead.Values)
                {
                    txtBailmentUser.ForeColor = Color.Black;
                    txtBailmentUser.Text = Read.BailmentName;
                    txtBailmentCdNumber.ForeColor = Color.Black;
                    txtBailmentCdNumber.Text = Read.NumberCd;
                    txtBailmentCdType.ForeColor = Color.Black;
                    txtBailmentCdType.Text = Read.BailmentCdType;
                    txtDateOfBailmentCd.ForeColor = Color.Black;
                    txtDateOfBailmentCd.Text = Read.DateOfBailment;
                    btnDelete.Enabled = true;
                }
                foreach (CdInfo ReadC in CdInfoRead.Values)
                {
                    txtBailmentCdSpecification.ForeColor = Color.Black;
                    txtBailmentCdSpecification.Text = ReadC.Specifications;
                }
            }
        }

        private void lstCdName_KeyDown(object sender, KeyEventArgs e)
        {
            if (lstCdName.SelectedIndex >= 0 && e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, e);
        }

        private void lstCdName_KeyUp(object sender, KeyEventArgs e)
        {
            if (lstCdName.SelectedIndex >= 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Down:
                        {
                            txtSearchCdName.Text = lstCdName.SelectedItem.ToString();
                            txtSearchCdName.ForeColor = Color.Black;
                        }
                        break;
                    case Keys.Up:
                        {
                            txtSearchCdName.Text = lstCdName.SelectedItem.ToString();
                            txtSearchCdName.ForeColor = Color.Black;
                        }
                        break;
                    case Keys.Left:
                        {
                            txtSearchCdName.Text = lstCdName.SelectedItem.ToString();
                            txtSearchCdName.ForeColor = Color.Black;
                        }
                        break;
                    case Keys.Right:
                        {
                            txtSearchCdName.Text = lstCdName.SelectedItem.ToString();
                            txtSearchCdName.ForeColor = Color.Black;
                        }
                        break;
                }
            }
        }

        private void lstCdName_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstCdName.SelectedIndex >= 0)
            {
                txtSearchCdName.Text = lstCdName.SelectedItem.ToString();
                txtSearchCdName.ForeColor = Color.Black;
            }
        }

        private void lstCdName_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstCdName.SelectedIndex >= 0)
            {
                DialogResult Ask = MessageBox.Show("Are you sure to delete Cd Bailment (" + lstCdName.SelectedItem.ToString()
                    + ") of Bailment list?", "Program library", MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                if (Ask == DialogResult.No)
                {
                    txtSearchCdName.Focus();
                    txtSearchCdName.SelectAll();
                    return;
                }
                else if (Ask == DialogResult.Yes)
                {
                    Form1.arrCdBailment.Remove(lstCdName.SelectedItem.ToString());
                    Hashtable ReadC = new Hashtable();  // Read All Form1.arrCdInfo
                    ReadC.Add(lstCdName.SelectedItem.ToString(), Form1.arrCdInfo[lstCdName.SelectedItem.ToString()]);
                    CdInfo ReWriteC = new CdInfo();
                    Form1.SavedCdInfo = false;
                    foreach (CdInfo re in ReadC.Values)
                    {
                        ReWriteC = re;
                    }
                    ReWriteC.Bailment = "false";
                    Form1.arrCdInfo.Remove(lstCdName.SelectedItem.ToString());
                    Form1.arrCdInfo.Add(ReWriteC.CdName, ReWriteC);
                    txtSearchCdName.AutoCompleteCustomSource.Remove(lstCdName.SelectedItem.ToString());
                    lstCdName.Items.Remove(lstCdName.SelectedItem.ToString());
                    ClearText();
                    return;
                }
            }
        }

        private void btnSearch_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }
    }
}
