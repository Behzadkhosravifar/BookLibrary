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
    public partial class FormSearchC : Form
    {
        public FormSearchC()
        {
            InitializeComponent();
        }

        private void txtSearchCd_MouseLeave(object sender, EventArgs e)
        {
            if (txtSearchCd.Text == "")
            {
                txtSearchCd.ForeColor = Color.DarkGray;
                txtSearchCd.Text = "CD - DVD نام";
            }
        }

        private void txtSearchCd_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
            if (txtSearchCd.Text == "")
            {
                txtSearchCd.ForeColor = Color.DarkGray;
                txtSearchCd.Text = "CD - DVD نام";
            }
            else if (txtSearchCd.Text != "") FindAllOfMyString(txtSearchCd.Text);
        }

        private void FindAllOfMyString(string searchString)
        {
            // Set the SelectionMode property of the ListBox to select multiple items.
            lstSearch.SelectionMode = SelectionMode.One;

            // Set our intial index variable to -1.
            int x = -1;
            // If the search string is empty exit.
            if (searchString.Length != 0)
            {
                // Loop through and find each item that matches the search string.
                do
                {
                    // Retrieve the item based on the previous index found. Starts with -1 which searches start.
                    x = lstSearch.FindString(searchString, x);
                    // If no item is found that matches exit.
                    if (x != -1)
                    {
                        // Since the FindString loops infinitely, determine if we found first item again and exit.
                        if (lstSearch.SelectedIndices.Count > 0)
                        {
                            if (x == lstSearch.SelectedIndices[0]) return;
                        }
                        // Select the item in the ListBox once it is found.
                        if (lstSearch.Items.Count > x + 7)
                        {
                            lstSearch.SetSelected(x + 7, true);
                            lstSearch.ClearSelected();
                        }
                        else
                        {
                            lstSearch.SetSelected(lstSearch.Items.Count - 1, true);
                            lstSearch.ClearSelected();
                        }
                        lstSearch.ClearSelected();
                        lstSearch.SetSelected(x, true);
                        break;
                    }
                    // If no item is found that matches Clear SelectedItem.
                    else lstSearch.ClearSelected();

                } while (x != -1);
            }
        }

        private void txtSearchCd_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSearchCd.Text == "CD - DVD نام")
            {
                txtSearchCd.Text = string.Empty;
                txtSearchCd.ForeColor = Color.Black;
            }
            if (e.KeyCode == Keys.Enter && lstSearch.SelectedIndex >= 0) btnSearch_Click(sender, e);
        }

        private void txtSearchCd_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtSearchCd.Text == "CD - DVD نام")
            {
                txtSearchCd.Text = string.Empty;
                txtSearchCd.ForeColor = Color.Black;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (lstSearch.SelectedIndex >= 0)
            {
                if(txtType.ForeColor != Color.Black)
                {
                    txtCDName.ForeColor = Color.Black;
                    txtDateOfWrite.ForeColor = Color.Black;
                    txtSpecifications.ForeColor = Color.Black;
                    txtType.ForeColor = Color.Black;
                    txtNumber.ForeColor = Color.Black;
                    txtBailment.ForeColor = Color.Black;
                    txtDateOfBailment.ForeColor = Color.Black;
                }
                // Clear All Pic --\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/
                picDataCd.Visible = false;
                picDataDvd.Visible = false;
                picDriver.Visible = false;
                picFloppyDisk.Visible = false;
                picFloppyZipDisk.Visible = false;
                picMultimediaCd.Visible = false;
                picMultimediaDvd.Visible = false;
                picMusicCd.Visible = false;
                picMusicDvd.Visible = false;
                picOtherCD.Visible = false;
                picOtherCdRw.Visible = false;
                picOtherDvd.Visible = false;
                picOtherDvdRw.Visible = false;
                picPictureCd.Visible = false;
                picPictureDvd.Visible = false;
                picVideoCd.Visible = false;
                picVideoDvd.Visible = false;
                picWindows.Visible = false;
                //--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/
                string bufferName = lstSearch.SelectedItem.ToString();
                CdInfo Read = (CdInfo)Form1.arrCdInfo[bufferName];
                SelectTypePic(Read.Type);
                txtCDName.Text = Read.CdName;
                txtDateOfWrite.Text = Read.DateOfCd;
                txtNumber.Text = Read.NumberOfCd;
                txtSpecifications.Text = Read.Specifications;
                txtType.Text = Read.Type;
                if (string.Compare(Read.Bailment, "true", true) == 0)
                {
                    CdBailment BRead = (CdBailment)Form1.arrCdBailment[bufferName];
                    txtBailment.Text = "Yes (By:  " + BRead.BailmentName + ")";
                    txtDateOfBailment.Text = BRead.DateOfBailment;
                }
                else
                {
                    txtBailment.Text = "No";
                    txtDateOfBailment.Text = "-- -- --";
                }
            }
            else return;
        }
        private void SelectTypePic(string p)
        {
            switch (p)
            {
                case "Data - CD":
                    {
                        picDataCd.Visible = true;
                    }
                    break;
                case "Data - DVD":
                    {
                        picDataDvd.Visible = true;
                    }
                    break;
                case "Driver CD - DVD":
                    {
                        picDriver.Visible = true;
                    }
                    break;
                case "Floppy Disk":
                    {
                        picFloppyDisk.Visible = true;
                    }
                    break;
                case "Floppy Zip Disk":
                    {
                        picFloppyZipDisk.Visible = true;
                    }
                    break;
                case "Multimedia - CD":
                    {
                        picMultimediaCd.Visible = true;
                    }
                    break;
                case "Multimedia - DVD":
                    {
                        picMultimediaDvd.Visible = true;
                    }
                    break;
                case "Music - CD":
                    {
                        picMusicCd.Visible = true;
                    }
                    break;
                case "Music - DVD":
                    {
                        picMusicDvd.Visible = true;
                    }
                    break;
                case "Other  CD-R":
                    {
                        picOtherCD.Visible = true;
                    }
                    break;
                case "Other  CD-RW":
                    {
                        picOtherCdRw.Visible = true;
                    }
                    break;
                case "Other  DVD":
                    {
                        picOtherDvd.Visible = true;
                    }
                    break;

                case "Other  DVD-RW":
                    {
                        picOtherDvdRw.Visible = true;
                    }
                    break;
                case "Picture - CD":
                    {
                        picPictureCd.Visible = true;
                    }
                    break;
                case "Picture - DVD":
                    {
                        picPictureDvd.Visible = true;
                    }
                    break;
                case "Video - CD":
                    {
                        picVideoCd.Visible = true;
                    }
                    break;
                case "Video - DVD":
                    {
                        picVideoDvd.Visible = true;
                    }
                    break;
                case "Windows - CD or DVD":
                    {
                        picWindows.Visible = true;
                    }
                    break;
                default:
                    {
                        MessageBox.Show("Can not Find any Type For Your CD - DVD Name!!!", "Error", MessageBoxButtons.OK
                            , MessageBoxIcon.Error);
                        return;
                    }
            }
        }

        private void FormSearchC_Load(object sender, EventArgs e)
        {
            foreach (CdInfo Refresh in Form1.arrCdInfo.Values)
            {
                txtSearchCd.AutoCompleteCustomSource.Add(Refresh.CdName);
                lstSearch.Items.Add(Refresh.CdName);
            }
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

        private void AddStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddC AddC = new FormAddC();
            AddC.ShowDialog();
        }

        private void BailmentBStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBailmentC BailmentC = new FormBailmentC();
            BailmentC.ShowDialog();
        }

        private void DelDStripMenuItem_Click(object sender, EventArgs e)
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
            // Declare a TextBox object and
            // set it to the ActiveControl
            TextBox objTextBox = (TextBox)this.ActiveControl;
            // Copy the text to the clipboard
            objTextBox.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Declare a TextBox object and
            // set it to the ActiveControl
            TextBox objTextBox = (TextBox)this.ActiveControl;
            // Select all text
            objTextBox.SelectAll();
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
            // Toggle the Paste toolbar button and menu items
            pasteToolStripMenuItem.Enabled = Clipboard.ContainsText();
            // Toggle the Select All menu items
            selectAllToolStripMenuItem.Enabled = (objTextBox.SelectionLength < objTextBox.Text.Length);
        }
        public void DisableButton()
        {
            copyToolStripMenuItem.Enabled = false;
            cutToolStripMenuItem.Enabled = false;
            pasteToolStripMenuItem.Enabled = false;
            selectAllToolStripMenuItem.Enabled = false;
            undoToolStripMenuItem.Enabled = false;
        }

        private void btnSearch_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void lstSearch_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void txtSearchCd_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtCDName_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtDateOfWrite_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtSpecifications_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtNumber_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtType_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtBailment_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtDateOfBailment_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtCDName_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtDateOfWrite_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtSpecifications_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtType_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtBailment_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtNumber_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtDateOfBailment_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtSearchCd_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtSearchCd == ActiveControl) ToggleMenus();
        }

        private void txtCDName_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtCDName == ActiveControl) ToggleMenus();
        }

        private void txtDateOfWrite_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtDateOfWrite == ActiveControl) ToggleMenus();
        }

        private void txtSpecifications_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtSpecifications == ActiveControl) ToggleMenus();
        }

        private void txtType_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtType == ActiveControl) ToggleMenus();
        }

        private void txtBailment_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtBailment == ActiveControl) ToggleMenus();
        }

        private void txtNumber_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtNumber == ActiveControl) ToggleMenus();
        }

        private void txtDateOfBailment_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtDateOfBailment == ActiveControl) ToggleMenus();
        }

        private void lstSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (lstSearch.SelectedIndex >= 0 && e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, e);
        }

        private void lstSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (lstSearch.SelectedIndex >= 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Down:
                        {
                            txtSearchCd.Text = lstSearch.SelectedItem.ToString();
                            txtSearchCd.ForeColor = Color.Black;
                        }
                        break;
                    case Keys.Up:
                        {
                            txtSearchCd.Text = lstSearch.SelectedItem.ToString();
                            txtSearchCd.ForeColor = Color.Black;
                        }
                        break;
                    case Keys.Left:
                        {
                            txtSearchCd.Text = lstSearch.SelectedItem.ToString();
                            txtSearchCd.ForeColor = Color.Black;
                        }
                        break;
                    case Keys.Right:
                        {
                            txtSearchCd.Text = lstSearch.SelectedItem.ToString();
                            txtSearchCd.ForeColor = Color.Black;
                        }
                        break;
                }
            }
        }

        private void lstSearch_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstSearch.SelectedIndex >= 0)
            {
                txtSearchCd.Text = lstSearch.SelectedItem.ToString();
                txtSearchCd.ForeColor = Color.Black;
            }
        }

        private void lstSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        private void txtSearchCd_TextChanged(object sender, EventArgs e)
        {
            btnSearch.Enabled = true;
        }

        private void SearchBStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSearch Search = new FormSearch();
            Search.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout About = new FormAbout();
            About.ShowDialog();
        }
    }
}
