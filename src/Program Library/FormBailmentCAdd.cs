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
    public partial class FormBailmentCAdd : Form
    {
        public FormBailmentCAdd()
        {
            InitializeComponent();
        }

        private void txtFullUserName_MouseLeave(object sender, EventArgs e)
        {
            if (txtFullUserName.Text == "")
            {
                txtFullUserName.ForeColor = Color.DarkGray;
                txtFullUserName.Text = "نام کامل امانت گیرنده";
            }
        }

        private void txtFullUserName_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
            picError.Visible = false;
            AddOk.Visible = false;
            if (txtFullUserName.Text == "")
            {
                txtFullUserName.ForeColor = Color.DarkGray;
                txtFullUserName.Text = "نام کامل امانت گیرنده";
            }
        }

        private void txtFullUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtFullUserName.Text == "نام کامل امانت گیرنده")
            {
                txtFullUserName.Text = string.Empty;
                txtFullUserName.ForeColor = Color.Black;
            }
        }

        private void txtFullUserName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtFullUserName.Text == "نام کامل امانت گیرنده")
            {
                txtFullUserName.Text = string.Empty;
                txtFullUserName.ForeColor = Color.Black;
            }
        }
        public bool nonNumberEntered = false;
        private void txtNumberCd_KeyDown(object sender, KeyEventArgs e)
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
                    if (e.KeyCode != Keys.Back)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEntered = true;
                    }
                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                if (txtNumberCd.Text == "CD - DVD تعداد")
                {
                    txtNumberCd.Text = string.Empty;
                    txtNumberCd.ForeColor = Color.Black;
                }
            }
        }

        private void txtNumberCd_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
            // clear TextBox Fill "CD - DVD تعداد"
            if (txtNumberCd.Text == "CD - DVD تعداد")
            {
                txtNumberCd.Text = string.Empty;
                txtNumberCd.ForeColor = Color.Black;
            }
        }

        private void txtNumberCd_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
            if (txtNumberCd.Text == "")
            {
                txtNumberCd.ForeColor = Color.DarkGray;
                txtNumberCd.Text = "CD - DVD تعداد";
            }
        }

        private void txtNumberCd_MouseLeave(object sender, EventArgs e)
        {
            if (txtNumberCd.Text == "")
            {
                txtNumberCd.ForeColor = Color.DarkGray;
                txtNumberCd.Text = "CD - DVD تعداد";
            }
        }

        private void txtNumberCd_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtNumberCd.Text == "CD - DVD تعداد")
            {
                txtNumberCd.Text = string.Empty;
                txtNumberCd.ForeColor = Color.Black;
            }
        }
        private void ClearText(bool p)
        {
            txtFullUserName.ForeColor = Color.DimGray;
            txtFullUserName.Text = "نام کامل امانت گیرنده";
            txtNumberCd.ForeColor = Color.DimGray;
            txtNumberCd.Text = "CD - DVD تعداد";
            combCdName.ForeColor = Color.DimGray;
            combCdName.Text = "CD - DVD نام";
            // Set Date to todey...................................
            DateTimePicker Todey = new DateTimePicker();
            dateTimePicker1.Value = Todey.Value;
            //.....................................................
            txtTypeCd.Text = "CD - DVD نوع";
            if (p == true)
            {
                picError.Visible = false;
                AddOk.Visible = false;
            }
            combCdName.Items.Clear();
            foreach (CdInfo read in Form1.arrCdInfo.Values)
            {
                if (read.Bailment == "false")
                    combCdName.Items.Add(read.CdName);
            }
            txtFullUserName.Focus();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearText(true);
        }

        private void changePassStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormChangePass ChangePass = new FormChangePass();
            ChangePass.ShowDialog();
        }

        private void tbrClear_Click(object sender, EventArgs e)
        {
            ClearText(true);
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

        private void tbrUpperCase_Click(object sender, EventArgs e)
        {
            // Make the text Uppercase
            txtFullUserName.Text = txtFullUserName.Text.ToUpper();
        }

        private void tbrLowerCase_Click(object sender, EventArgs e)
        {
            // Make the text Lowercase
            txtFullUserName.Text = txtFullUserName.Text.ToLower();
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

        private void dateTimePicker1_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void combCdName_Enter(object sender, EventArgs e)
        {
            DisableButton();
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

        private void txtFullUserName_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtNumberCd_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtNumberCd_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtNumberCd == ActiveControl) ToggleMenus();
        }

        private void txtFullUserName_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtFullUserName == ActiveControl) ToggleMenus();
        }

     

        private void combCdName_KeyDown(object sender, KeyEventArgs e)
        {
            if (combCdName.Text == "CD - DVD نام")
            {
                combCdName.Text = string.Empty;
                combCdName.ForeColor = Color.Black;
                btnFill.Enabled = true;
            }
            else if (e.KeyCode == Keys.Enter) SearchTypeCD();
        }

        private void SearchTypeCD()
        {
            if (Form1.arrCdInfo.ContainsKey(combCdName.Text) == true)
            {
                Hashtable readOnly = new Hashtable();
                readOnly.Add(combCdName.Text, Form1.arrCdInfo[combCdName.Text]);
                foreach (CdInfo readInfo in readOnly.Values)
                {
                    txtTypeCd.Text = readInfo.Type;
                    return;
                }
            }
            else
            {
                txtTypeCd.Text = "CD - DVD نوع";
                MessageBox.Show("Not Found Any CD - DVD for your CD - DVD Name Please Change it.", "Error Not Found"
                    , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                combCdName.Focus();
                combCdName.SelectAll();
                return;
            }
        }

        private void combCdName_MouseClick(object sender, MouseEventArgs e)
        {
            if (combCdName.Text == "CD - DVD نام")
            {
                combCdName.Text = string.Empty;
                combCdName.ForeColor = Color.Black;
                btnFill.Enabled = true;
            }
        }

        private void combCdName_KeyUp(object sender, KeyEventArgs e)
        {
            if (combCdName.Text == "")
            {
                combCdName.ForeColor = Color.DimGray;
                combCdName.Text = "CD - DVD نام";
                btnFill.Enabled = false;
            }
        }

        private void combCdName_MouseLeave(object sender, EventArgs e)
        {
            if (combCdName.Text == "")
            {
                combCdName.ForeColor = Color.DimGray;
                combCdName.Text = "CD - DVD نام";
                btnFill.Enabled = false;
            }
        }

        private void FormBailmentCAdd_Load(object sender, EventArgs e)
        {
            foreach (CdInfo read in Form1.arrCdInfo.Values)
            {
                if (read.Bailment == "false")
                    combCdName.Items.Add(read.CdName);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFullUserName.Text == "" || txtFullUserName.Text == "نام کامل امانت گیرنده")
            {
                MessageBox.Show("Full Bailment User Name TextBox is Empty! \nPlease Fill it.",
                    "Error TextBox Empty");
                AddOk.Visible = false;
                picError.Visible = true;
                txtFullUserName.Focus();
                txtFullUserName.SelectAll();
                return;
            }
            else if (txtNumberCd.Text == "" || txtNumberCd.Text == "CD - DVD تعداد")
            {
                MessageBox.Show("Number CD - DVD TextBox is Empty! \nPlease Fill it.",
                    "Error TextBox Empty");
                AddOk.Visible = false;
                picError.Visible = true;
                txtNumberCd.Focus();
                txtNumberCd.SelectAll();
                return;
            }
            
            else if (combCdName.Text == "" || combCdName.Text == "CD - DVD نام")
            {
                MessageBox.Show("CD - DVD Name TextBox is Empty! \nPlease Fill it.",
                    "Error TextBox Empty");
                AddOk.Visible = false;
                picError.Visible = true;
                combCdName.Focus();
                combCdName.SelectAll();
                return;
            }
            
            else if (txtTypeCd.Text == "CD - DVD نوع")
            {
                DialogResult R = MessageBox.Show("Please Search CD - DVD Type by your CD - DVD Name, Fill Button!"
                    + "Press Rerty Button to Search it , Etc Click On Cancel", "Error TextBox Empty"
                    , MessageBoxButtons.RetryCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if(R == DialogResult.Retry) SearchTypeCD();
                else if(R == DialogResult.Cancel) 
                {
                    AddOk.Visible = false;
                    picError.Visible = true;
                    combCdName.Focus();
                    return;
                }
            }
            //-------------------------------------------------------------------------------------------------------------------------------------
            // No Error go Add ->
            else
            {
                //--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--
                // Find Correctly Number of CD - DVD in TextBox Number CD - DVD 
                Boolean FindNumber = false;
                foreach (string readN in FormAddC.strNumberCombo)
                {
                    if (readN == txtNumberCd.Text)
                    {
                        FindNumber = true;
                        break;
                    }
                }
                if (FindNumber != true)
                {
                    MessageBox.Show("The Number of CD - DVD is Not Correct! \n Please Change it.", "Warning Not Found Correctly Number Of CD - DVD"
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    AddOk.Visible = false;
                    picError.Visible = true;
                    txtNumberCd.Focus();
                    txtNumberCd.SelectAll();
                    return;
                }
                //--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--\|/--
                //
                //=================================================================================================
                //Search the correct CD - DVD Name of Form1.arrCdInfo
                if (Form1.arrCdInfo.ContainsKey(combCdName.Text) == true)
                {
                    Hashtable write = new Hashtable();
                    write.Add(combCdName.Text, Form1.arrCdInfo[combCdName.Text]);
                    CdInfo ChangeData = new CdInfo();
                    foreach (CdInfo reW in write.Values)
                    {
                        if (reW.Bailment == "false")
                        {
                            if (txtTypeCd.Text == reW.Type)
                            {
                                Form1.SavedCdInfo = false;
                                CdBailment AddC = new CdBailment();
                                AddC.NumberCd = txtNumberCd.Text;
                                AddC.BailmentName = txtFullUserName.Text;
                                AddC.DateOfBailment = dateTimePicker1.Value.ToLongDateString();
                                AddC.CdName = reW.CdName;
                                AddC.BailmentCdType = reW.Type;
                                ChangeData = reW;
                                ChangeData.Bailment = "true";
                                Form1.arrCdInfo.Remove(ChangeData.CdName);
                                Form1.arrCdInfo.Add(ChangeData.CdName, ChangeData);                   
                                Form1.arrCdBailment.Add(AddC.CdName, AddC);
                                picError.Visible = false;
                                AddOk.Visible = true;
                                ClearText(false);
                                return;
                            }
                            else
                            {
                                DialogResult S = MessageBox.Show("Your CD - DVD Name no Match by Type CD - DVD!" +
                                    "\nPlease Press Ok to Search Again Etc press Cancel", "Error No Matching Entered Data"
                                    ,MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                                if (S == DialogResult.OK) SearchTypeCD();
                                else
                                {
                                    combCdName.Focus();
                                    combCdName.SelectAll();
                                }
                                AddOk.Visible = false;
                                picError.Visible = true;
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Your CD - DVD Already is Exist in Bailment List", "Warning Already Exist"
                                , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            AddOk.Visible = false;
                            picError.Visible = true;
                            txtFullUserName.Focus();
                            txtFullUserName.SelectAll();
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Not Found Any CD - DVD for your CD - DVD Name Please Change it.", "Error Not Found"
                    , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    AddOk.Visible = false;
                    picError.Visible = true;
                    return;
                }

                //=================================================================================================
            }
        }

        private void txtTypeCd_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
            cutToolStripButton.Enabled = false;
            cutToolStripMenuItem.Enabled = false;
        }

        private void txtTypeCd_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
            cutToolStripButton.Enabled = false;
            cutToolStripMenuItem.Enabled = false;
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            SearchTypeCD();
        }

        private void combCdName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchTypeCD();
        }
    }
}
