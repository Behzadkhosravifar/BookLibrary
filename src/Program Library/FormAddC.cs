using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

namespace Program_Library
{
    public partial class FormAddC : Form
    {
        public static string[] strNumberCombo = { "1 - One", "2 - Two", "3 - Three", "4 - Four", "5 - Five", "6 - Six",
                 "7 - Seven", "8 - Eight", "9 - Nine", "10 - Ten", "11 - Eleven", "12 - Twelve", "13 - Thirteen",
                 "14 - Fourteen", "15 - Fifteen", "16 - Sixteen", "17 - Seventeen", "18 - Eighteen", "19 - Nineteen",
                 "20 - Twenty", "21 - Twenty One", "22 - Twenty Two", "23 - Twenty three", "24 - Twenty Four",
                 "25 - Twenty Five", "26 - Twenty Six", "27 - Twenty Seven", "28 - Twenty Eight", "29 - Twenty Nine",
                 "30 - Thirty", "31 - Thirty One", "32 - Thirty Two", "33 - Thirty Three", "34 - Thirty Four",
                 "35 - Thirty Five", "36 - Thirty Six", "37 - Thirty Seven", "38 - Thirty Eight", "39 - Thirty Nine",
                 "40 - Forty", "41 ~ 50 - Forty One ~ Fifty", "51 ~ 60 - Fifty One ~ Sixty", "61 ~ 70 - Sixty One ~ Seventy",
                 "71 ~ 80 - Seventy One ~ Eighty", "81 ~ 90 - Eighty One ~ Ninety", "91 ~ 100 - Ninety One ~ Hundred",
                 "101 ~ ... - Hundred One ~ Unbounded" };
        public static string[] strTypeCombo = { "Data - CD", "Data - DVD", "Driver CD - DVD", "Floppy Disk", "Floppy Zip Disk", 
                 "Multimedia - CD", "Multimedia - DVD", "Music - CD", "Music - DVD", "Other  CD-R", "Other  CD-RW", "Other  DVD",
                 "Other  DVD-RW", "Picture - CD", "Picture - DVD", "Video - CD", "Video - DVD", "Windows - CD or DVD" };
        public FormAddC()
        {
            InitializeComponent();
        }

        private void btnDriver_Click(object sender, EventArgs e)
        {
            rdbtnDriver.Checked = true;
            combType.ForeColor = Color.Black;
            StatusText = "Ready";
            combType.Text = "Driver CD - DVD";
        }

        private void btnWindows_Click(object sender, EventArgs e)
        {
            rdbtnWindows.Checked = true;
            combType.ForeColor = Color.Black;
            StatusText = "Ready";
            combType.Text = "Windows - CD or DVD";
        }

        private void btnZipFDD_Click(object sender, EventArgs e)
        {
            rdbtnZipFDD.Checked = true;
            combType.ForeColor = Color.Black;
            StatusText = "Ready";
            combType.Text = "Floppy Zip Disk";
        }

        private void txtCDName_MouseLeave(object sender, EventArgs e)
        {
            if (txtCDName.Text == "")
            {
                txtCDName.ForeColor = Color.DimGray;
                txtCDName.Text = "DVD یا CD نام";
            }
        }

        private void txtCDName_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
            if (txtCDName.Text == "")
            {
                txtCDName.ForeColor = Color.DimGray;
                txtCDName.Text = "DVD یا CD نام";
            }
        }

        private void txtCDName_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtCDName.Text == "DVD یا CD نام")
            {
                txtCDName.Text = string.Empty;
                txtCDName.ForeColor = Color.Black;
            }
        }

        private void txtCDName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtCDName.Text == "DVD یا CD نام")
            {
                txtCDName.Text = string.Empty;
                txtCDName.ForeColor = Color.Black;
            }
        }

        private void txtSpecifications_MouseLeave(object sender, EventArgs e)
        {
            if (txtSpecifications.Text == "")
            {
                txtSpecifications.ForeColor = Color.DimGray;
                txtSpecifications.Text = "CD - DVD مشخصات و خصوصیات";
            }
        }

        private void txtSpecifications_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
            if (txtSpecifications.Text == "")
            {
                txtSpecifications.ForeColor = Color.DimGray;
                txtSpecifications.Text = "CD - DVD مشخصات و خصوصیات";
            }
        }

        private void txtSpecifications_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSpecifications.Text == "CD - DVD مشخصات و خصوصیات")
            {
                txtSpecifications.Text = string.Empty;
                txtSpecifications.ForeColor = Color.Black;
            }
        }

        private void txtSpecifications_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtSpecifications.Text == "CD - DVD مشخصات و خصوصیات")
            {
                txtSpecifications.Text = string.Empty;
                txtSpecifications.ForeColor = Color.Black;
            }
        }

        private void btnFDD_Click(object sender, EventArgs e)
        {
            rdbtnFDD.Checked = true;
            combType.ForeColor = Color.Black;
            StatusText = "Ready";
            combType.Text = "Floppy Disk";
        }

        private void btnOtherDvdRw_Click(object sender, EventArgs e)
        {
            rdbtnOtherDvdRw.Checked = true;
            combType.ForeColor = Color.Black;
            StatusText = "Ready";
            combType.Text = "Other  DVD-RW";
        }

        private void btnOtherDvd_Click(object sender, EventArgs e)
        {
            rdbtnOtherDvd.Checked = true;
            combType.ForeColor = Color.Black;
            StatusText = "Ready";
            combType.Text = "Other  DVD";
        }

        private void btnMultimediaDvd_Click(object sender, EventArgs e)
        {
            rdbtnMultimediaDvd.Checked = true;
            combType.ForeColor = Color.Black;
            StatusText = "Ready";
            combType.Text = "Multimedia - DVD";
        }

        private void btnPictureDvd_Click(object sender, EventArgs e)
        {
            rdbtnPictureDvd.Checked = true;
            combType.ForeColor = Color.Black;
            StatusText = "Ready";
            combType.Text = "Picture - DVD";
        }

        private void btnVideoDvd_Click(object sender, EventArgs e)
        {
            rdbtnVideoDvd.Checked = true;
            combType.ForeColor = Color.Black;
            StatusText = "Ready";
            combType.Text = "Video - DVD";
        }

        private void btnDataDvd_Click(object sender, EventArgs e)
        {
            rdbtnDataDvd.Checked = true;
            combType.ForeColor = Color.Black;
            StatusText = "Ready";
            combType.Text = "Data - DVD";
        }

        private void btnAudioDvd_Click(object sender, EventArgs e)
        {
            rdbtnAudioDvd.Checked = true;
            combType.ForeColor = Color.Black;
            StatusText = "Ready";
            combType.Text = "Music - DVD";
        }

        private void btnOtherCdRw_Click(object sender, EventArgs e)
        {
            rdbtnOtherCdRw.Checked = true;
            combType.ForeColor = Color.Black;
            StatusText = "Ready";
            combType.Text = "Other  CD-RW";
        }

        private void btnOtherCd_Click(object sender, EventArgs e)
        {
            combType.ForeColor = Color.Black;
            StatusText = "Ready";
            rdbtnOtherCd.Checked = true;
            combType.Text = "Other  CD-R";
        }

        private void btnMultimediaCd_Click(object sender, EventArgs e)
        {
            rdbtnMultimediaCd.Checked = true;
            combType.ForeColor = Color.Black;
            StatusText = "Ready";
            combType.Text = "Multimedia - CD";
        }

        private void btnPictureCd_Click(object sender, EventArgs e)
        {
            rdbtnPictureCd.Checked = true;
            combType.ForeColor = Color.Black;
            StatusText = "Ready";
            combType.Text = "Picture - CD";
        }

        private void btnVideoCd_Click(object sender, EventArgs e)
        {
            rdbtnVideoCd.Checked = true;
            combType.ForeColor = Color.Black;
            StatusText = "Ready";
            combType.Text = "Video - CD";
        }

        private void btnDataCd_Click(object sender, EventArgs e)
        {
            rdbtnDataCd.Checked = true;
            combType.ForeColor = Color.Black;
            StatusText = "Ready";
            combType.Text = "Data - CD";
        }

        private void btnAudioCd_Click(object sender, EventArgs e)
        {
            rdbtnAudioCd.Checked = true;
            combType.ForeColor = Color.Black;
            StatusText = "Ready";
            combType.Text = "Music - CD";
        }

        private void combType_SelectedIndexChanged(object sender, EventArgs e)
        {
            combType.ForeColor = Color.Black;
            StatusText = "Ready";
            switch (combType.Text)
            {
                case "Windows - CD or DVD": rdbtnWindows.Checked = true; break;
                case "Music - DVD": rdbtnAudioDvd.Checked = true; break;
                case "Music - CD": rdbtnAudioCd.Checked = true; break;
                case "Video - CD": rdbtnVideoCd.Checked = true; break;
                case "Video - DVD": rdbtnVideoDvd.Checked = true; break;
                case "Picture - CD": rdbtnPictureCd.Checked = true; break;
                case "Picture - DVD": rdbtnPictureDvd.Checked = true; break;
                case "Multimedia - CD": rdbtnMultimediaCd.Checked = true; break;
                case "Multimedia - DVD": rdbtnMultimediaDvd.Checked = true; break;
                case "Floppy Disk": rdbtnFDD.Checked = true; break;
                case "Floppy Zip Disk": rdbtnZipFDD.Checked = true; break;
                case "Data - CD": rdbtnDataCd.Checked = true; break;
                case "Data - DVD": rdbtnDataDvd.Checked = true; break;
                case "Driver CD - DVD": rdbtnDriver.Checked = true; break;
                case "Other  CD-RW": rdbtnOtherCdRw.Checked = true; break;
                case "Other  DVD-RW": rdbtnOtherDvdRw.Checked = true; break;
                case "Other  CD-R": rdbtnOtherCd.Checked = true; break;
                case "Other  DVD": rdbtnOtherDvd.Checked = true; break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            Thread.Sleep(100);
            if (txtCDName.Text == "DVD یا CD نام" || txtSpecifications.Text == "CD - DVD مشخصات و خصوصیات" ||
                combNumber.Text == "CD - DVD تعداد" || combType.Text == "CD - DVD نوع")
            {
                progressBar1.Value = 100;
                MessageBox.Show("Please Fill the All Textbox", "TextBox Empty Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                StatusText = "TextBox Empty Error";
            }
            else
            {
                // Check comboBox combNumber.Text --=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=
                Boolean FindNumber = false;
                foreach (string readN in strNumberCombo)
                {
                    if (readN == combNumber.Text)
                    {
                        FindNumber = true;
                        break;
                    }
                }
                if (FindNumber == false)
                {
                    progressBar1.Value = 98;
                    MessageBox.Show("Please Enter or Seletct Correct Text of Combo Box!", "Error Not Found Correct Text");
                    StatusText = "Error Not Found Correct Text";
                    progressBar1.Visible = false;
                    combNumber.Focus();
                    combNumber.SelectAll();
                    return;
                }
                // --=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=
                //
                // Check combBox combType.Text --=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--
                Boolean FindType = false;
                foreach (string readT in strTypeCombo)
                {
                    if (readT == combType.Text)
                    {
                        FindType = true;
                        break;
                    }
                }
                if (FindType == false)
                {
                    progressBar1.Value = 98;
                    MessageBox.Show("Please Enter or Seletct Correct Text of Combo Box!", "Error Not Found Correct Text");
                    StatusText = "Error Not Found Correct Text";
                    progressBar1.Visible = false;
                    combType.Focus();
                    combType.SelectAll();
                    return;
                }
                // --=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=--=
                Thread.Sleep(80);
                progressBar1.Value = 1;
                CdInfo Fill = new CdInfo();
                Thread.Sleep(80);
                progressBar1.Value = 10;
                // Search Repeat CD Name ---------------------------------------
                string re = txtCDName.Text;
                if (Form1.arrCdInfo.Count != 0)
                {
                    while(true)
                    {
                        if (Form1.arrCdInfo.ContainsKey(re) == true) re += " ";
                        else break;
                    }
                }
                Fill.CdName = re;
                //----------------------------------------------------------------
                Thread.Sleep(80);
                progressBar1.Value = 20;
                Fill.Specifications = txtSpecifications.Text;
                //----------------------------------------------------------------
                Thread.Sleep(80);
                progressBar1.Value = 30;
                Fill.Type = combType.Text;
                progressBar1.Value = 40;
                Thread.Sleep(80);
                progressBar1.Value = 55;
                Fill.NumberOfCd = combNumber.Text;
                progressBar1.Value = 60;
                Thread.Sleep(80);
                Fill.DateOfCd = datePickerCdAdd.Value.ToLongDateString();
                progressBar1.Value = 70;
                Fill.Bailment = "false";
                Form1.SavedCdInfo = false;
                Thread.Sleep(80);
                progressBar1.Value = 80;
                Form1.arrCdInfo.Add(Fill.CdName, Fill);
                ClearText();
                Thread.Sleep(100);
                progressBar1.Value = 100;
                StatusText = ("The new " + Fill.Type + " added to Club");
            }
            Thread.Sleep(100);
            progressBar1.Visible = false;
        }
        public string StatusText
        {
            get
            {
                return sspStatus.Text;
            }
            set
            {
                sspStatus.Text = value;
            }
        }
        private void ClearText()
        {
            txtCDName.ForeColor = Color.DimGray;
            txtCDName.Text = "DVD یا CD نام";
            txtSpecifications.ForeColor = Color.DimGray;
            txtSpecifications.Text = "CD - DVD مشخصات و خصوصیات";
            combNumber.ForeColor = Color.DimGray;
            combNumber.Text = "CD - DVD تعداد";
            // Set Date to todey...................................
            DateTimePicker Todey = new DateTimePicker();
            datePickerCdAdd.Value = Todey.Value;
            //.....................................................
            combType.ForeColor = Color.DimGray;
            combType.Text = "CD - DVD نوع";
            rdbtnAudioCd.Checked = false;
            rdbtnAudioDvd.Checked = false;
            rdbtnDataCd.Checked = false;
            rdbtnDataDvd.Checked = false;
            rdbtnDriver.Checked = false;
            rdbtnFDD.Checked = false;
            rdbtnMultimediaCd.Checked = false;
            rdbtnMultimediaDvd.Checked = false;
            rdbtnOtherCd.Checked = false;
            rdbtnOtherCdRw.Checked = false;
            rdbtnOtherDvd.Checked = false;
            rdbtnOtherDvdRw.Checked = false;
            rdbtnPictureCd.Checked = false;
            rdbtnPictureDvd.Checked = false;
            rdbtnVideoCd.Checked = false;
            rdbtnVideoDvd.Checked = false;
            rdbtnWindows.Checked = false;
            rdbtnZipFDD.Checked = false;
            StatusText = "All Text box cleared!";
            txtCDName.Focus();
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
                    StatusText = "Save The CD - DVD Data in path: " + Form1.patchCD;
                }
            }
            else
            {
                Form1.SaveCdInfo();
                Form1.SaveCdBailment();
                Form1.SavedCdInfo = true;
                StatusText = "Save The CD - DVD Data in path: " + Form1.patchCD;
            }
        }
        private void SaveBStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCD();
        }

        private void AddDStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdd Add = new FormAdd();
            Add.ShowDialog();
        }

        private void BailmentBStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBailmentC BailmentC = new FormBailmentC();
            BailmentC.ShowDialog();
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

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Declare a TextBox object and
            // set it to the ActiveControl
            TextBox objTextBox = (TextBox)this.ActiveControl;
            // Undo the last operation
            objTextBox.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Declare a TextBox object and
            // set it to the ActiveControl
            TextBox objTextBox = (TextBox)this.ActiveControl;
            // Copy the text to the clipboard and clear the field
            objTextBox.Cut();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            // Declare a TextBox object and
            // set it to the ActiveControl
            TextBox objTextBox = (TextBox)this.ActiveControl;
            // Copy the text to the clipboard and clear the field
            objTextBox.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            // Declare a TextBox object and
            // set it to the ActiveControl
            TextBox objTextBox = (TextBox)this.ActiveControl;
            // Copy the text to the clipboard
            objTextBox.Copy();
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
            txtCDName.Text = txtCDName.Text.ToUpper();
            txtSpecifications.Text = txtSpecifications.Text.ToUpper();
            
            // Update the status bar text
            StatusText = "The text is all UpperCase";
        }
        private void tbrUpperCase_Click(object sender, EventArgs e)
        {
            UppercaseText();
        }

        public void LowercaseText()
        {
            // Make the text Uppercase
            if (txtCDName.Text != "DVD یا CD نام")
                txtCDName.Text = txtCDName.Text.ToLower();
            if (txtSpecifications.Text != "CD - DVD مشخصات و خصوصیات") 
                txtSpecifications.Text = txtSpecifications.Text.ToLower();
 
            // Update the status bar text
            StatusText = "The text is all LowerCase";
        }
        private void tbrLowerCase_Click(object sender, EventArgs e)
        {
            LowercaseText();
        }
        public void DisableButton()
        {
            copyToolStripButton.Enabled = false;
            copyToolStripMenuItem.Enabled = false;
            cutToolStripButton.Enabled = false;
            cutToolStripMenuItem.Enabled = false;
            pasteToolStripButton.Enabled = false;
            pasteToolStripMenuItem.Enabled = false;
            selectAllToolStripMenuItem.Enabled = false;
            undoToolStripMenuItem.Enabled = false;
        }
        private void ToggleMenus()
        {
            // Declare a TextBox object and
            // set it to the ActiveControl
            TextBox objTextBox = (TextBox)this.ActiveControl;
            // Toggle the Undo menu items
            undoToolStripMenuItem.Enabled = objTextBox.CanUndo;

            // Toggle the Cut toolbar button and menu items
            if (objTextBox.SelectionLength == 0)
            {
                cutToolStripMenuItem.Enabled = false;
                cutToolStripButton.Enabled = false;
            }
            else
            {
                cutToolStripMenuItem.Enabled = true;
                cutToolStripButton.Enabled = true;
            }
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

        private void btnDriver_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void rdbtnDriver_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnWindows_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void rdbtnWindows_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnZipFDD_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnFDD_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void rdbtnZipFDD_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void rdbtnFDD_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnOtherDvdRw_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void rdbtnOtherDvdRw_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnOtherDvd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void rdbtnOtherDvd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnMultimediaDvd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void rdbtnMultimediaDvd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnPictureDvd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void rdbtnPictureDvd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnVideoDvd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void rdbtnVideoDvd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnDataDvd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void rdbtnDataDvd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnAudioDvd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void rdbtnAudioDvd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnOtherCdRw_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void rdbtnOtherCdRw_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnOtherCd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void rdbtnOtherCd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnMultimediaCd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void rdbtnMultimediaCd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnPictureCd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void rdbtnPictureCd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnVideoCd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void rdbtnVideoCd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnDataCd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void rdbtnDataCd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnAudioCd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void rdbtnAudioCd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnCancel_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnAdd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void combNumber_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void datePickerCdAdd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void combType_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void txtCDName_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtSpecifications_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtSpecifications_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtSpecifications == ActiveControl) ToggleMenus();
        }

        private void txtCDName_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtCDName == ActiveControl) ToggleMenus();
        }

        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;
        // ...............................................................................
        private void combNumber_KeyDown(object sender, KeyEventArgs e)
        {
            // Initialize the flag to false.
            nonNumberEntered = false;

            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Space)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEntered = true;
                    }
                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                if (combNumber.Text == "CD - DVD تعداد")
                {
                    combNumber.Text = string.Empty;
                    combNumber.ForeColor = Color.Black;
                }
            }
        }

        private void combNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (combNumber.Text == "")
            {
                combNumber.ForeColor = Color.DimGray;
                combNumber.Text = "CD - DVD تعداد";
            }
        }

        private void combNumber_MouseClick(object sender, MouseEventArgs e)
        {
            if (combNumber.Text == "CD - DVD تعداد")
            {
                combNumber.Text = string.Empty;
                combNumber.ForeColor = Color.Black;
            }
        }

        private void combNumber_MouseLeave(object sender, EventArgs e)
        {
            if (combNumber.Text == "")
            {
                combNumber.ForeColor = Color.DimGray;
                combNumber.Text = "CD - DVD تعداد";
            }
        }

        private void combType_KeyDown(object sender, KeyEventArgs e)
        {
            if (combType.Text == "CD - DVD نوع")
            {
                combType.Text = string.Empty;
                combType.ForeColor = Color.Black;
            }
        }

        private void combType_MouseClick(object sender, MouseEventArgs e)
        {
            if (combType.Text == "CD - DVD نوع")
            {
                combType.Text = string.Empty;
                combType.ForeColor = Color.Black;
            }
        }

        private void combType_KeyUp(object sender, KeyEventArgs e)
        {
            if (combType.Text == "")
            {
                combType.ForeColor = Color.DimGray;
                combType.Text = "CD - DVD نوع";
            }
        }

        private void combType_MouseLeave(object sender, EventArgs e)
        {
            if (combType.Text == "")
            {
                combType.ForeColor = Color.DimGray;
                combType.Text = "CD - DVD نوع";
            }
        }

        private void txtCDName_TextChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void txtSpecifications_TextChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void datePickerCdAdd_ValueChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void combNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            combNumber.ForeColor = Color.Black;
            StatusText = "Ready";
        }

        private void combNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
            // clear TextBox Fill "شابک"
            if (nonNumberEntered == false)
            {
                if (combNumber.Text == "CD - DVD تعداد")
                {
                    combNumber.Text = string.Empty;
                    combNumber.ForeColor = Color.Black;
                }
            }
        }
    }
}
