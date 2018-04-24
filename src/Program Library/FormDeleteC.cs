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
    public partial class FormDeleteC : Form
    {
        public FormDeleteC()
        {
            InitializeComponent();
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.Visible = true;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.Visible = false;
        }

        private void txtCdName_MouseLeave(object sender, EventArgs e)
        {
            if (txtCdName.Text == "")
            {
                txtCdName.ForeColor = Color.DarkGray;
                txtCdName.Text = "CD - DVD نام";
            }
        }

        private void txtCdName_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
            if (txtCdName.Text == "")
            {
                txtCdName.ForeColor = Color.DarkGray;
                txtCdName.Text = "CD - DVD نام";
            }
        }

        private void txtCdName_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtCdName.Text == "CD - DVD نام")
            {
                txtCdName.Text = string.Empty;
                txtCdName.ForeColor = Color.Black;
            }
            else if (e.KeyCode == Keys.Enter) SearchTN();            
        }

        private void SearchTN()
        {
            if (Form1.arrCdInfo.ContainsKey(txtCdName.Text) == true)
            {
                CdInfo readInfo = (CdInfo)Form1.arrCdInfo[txtCdName.Text];
                combType.Text = readInfo.Type;
                combNumber.Text = readInfo.NumberOfCd;
                return;
            }
            else
            {
                combType.Text = "CD - DVD نوع";
                combNumber.Text = "CD - DVD تعداد";
                MessageBox.Show("Not found (" + txtCdName.Text + ")!", "Error Not Found");
                txtCdName.Focus();
                txtCdName.SelectAll();
                return;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtCdName.Text == "" || txtCdName.Text == "CD - DVD نام")
            {
                MessageBox.Show("CD - DVD Name TextBox is Empty!", "Error TextBox Empty", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                StatusText = "TextBox CD - DVD Name is Empty ...";
                txtCdName.Focus();
                txtCdName.SelectAll();
                return;
            }
            else if (combType.Text == "" || combType.Text == "CD - DVD نوع")
            {
                MessageBox.Show("ComboBox Type of CD - DVD is Empty \nPlease Fill it!", "Error ComboBox Empty"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                StatusText = "ComboBox Type of CD - DVD is Empty ...";
                combType.Focus();
                combType.SelectAll();
                return;
            }
            else if (combNumber.Text == "" || combNumber.Text == "CD - DVD تعداد")
            {
                MessageBox.Show("ComboBox Number of CD - DVD is Empty \nPlease Fill it!", "Error ComboBox Empty"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                StatusText = "ComboBox Number of CD - DVD is Empty ...";
                combNumber.Focus();
                combNumber.SelectAll();
                return;
            }
            else
            {
                if (Form1.arrCdInfo.ContainsKey(txtCdName.Text) != true)
                {
                    MessageBox.Show("Not found any CD or DVD for your CD - DVD Name!", "Error Not Found"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    StatusText = "TextBox CD - DVD Name is not Correct ...";
                    txtCdName.Focus();
                    txtCdName.SelectAll();
                    return;
                }
                else if (Form1.arrCdInfo.ContainsKey(txtCdName.Text) == true)
                {
                    CdInfo ReadOnly = (CdInfo)Form1.arrCdInfo[txtCdName.Text];
                    if (string.Compare(ReadOnly.Type, combType.Text, true) == 0)
                    {
                        if (string.Compare(ReadOnly.NumberOfCd, combNumber.Text, true) == 0)
                        {
                            StatusText = "Search Successfuly Find (" + ReadOnly.CdName + ") of CD - DVD Club ...";
                            picFind.Visible = true;
                            btnDelete.Visible = true;
                            btnDelete.Focus();
                            btnDelete.Select();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("CD - DVD Name No Matching by your Number of CD - DVD!", "Warning No Matching"
                            , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            StatusText = "No Matching CD - DVD Name by Number of CD - DVD ...";
                            combNumber.Focus();
                            combNumber.SelectAll();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("CD - DVD Name No Matching by your Type of CD - DVD!", "Warning No Matching"
                            , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        StatusText = "No Matching CD - DVD Name by Type of CD - DVD ...";
                        combType.Focus();
                        combType.SelectAll();
                        return;
                    }

                }
            }
        }

        private void txtCdName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtCdName.Text == "CD - DVD نام")
            {
                txtCdName.Text = string.Empty;
                txtCdName.ForeColor = Color.Black;
            }
        }

        private void FormDeleteC_Load(object sender, EventArgs e)
        {
            foreach (CdInfo FirstRead in Form1.arrCdInfo.Values)
            {
                txtCdName.AutoCompleteCustomSource.Add(FirstRead.CdName);
            }
        }

        public void DisableButton()
        {
            undoToolStripMenuItem.Enabled = false;
            cutToolStripButton.Enabled = false;
            cutToolStripMenuItem.Enabled = false;
            copyToolStripButton.Enabled = false;
            copyToolStripMenuItem.Enabled = false;
            pasteToolStripButton.Enabled = false;
            pasteToolStripMenuItem.Enabled = false;
            selectAllToolStripMenuItem.Enabled = false;
        }
        private void ClearText()
        {
            txtCdName.ForeColor = Color.DimGray;
            txtCdName.Text = "CD - DVD نام";
            combNumber.Text = "CD - DVD تعداد";
            combType.Text = "CD - DVD نوع";
            DisableButton();
            picFind.Visible = false;
            picNotFound.Visible = true;
            btnDelete.Visible = false;
            StatusText = "All Text box cleared!";
            txtCdName.Focus();
        }
        private void tbrClear_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void DelDStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDelete Delete = new FormDelete();
            Delete.ShowDialog();
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
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

        public void UppercaseText()
        {
            // Make the text Uppercase
            if (txtCdName.Text != "CD - DVD نام")
                txtCdName.Text = txtCdName.Text.ToUpper();
            // Update the status bar text
            StatusText = "The text is all UpperCase";
        }
        private void tbrUpperCase_Click(object sender, EventArgs e)
        {
            UppercaseText();
        }
        
        public void LowercaseText()
        {
            // Make the text Lowercase
            if (txtCdName.Text != "CD - DVD نام")
                txtCdName.Text = txtCdName.Text.ToLower();
            // Update the status bar text
            StatusText = "The text is all LowerCase";
        }

        private void tbrLowerCase_Click(object sender, EventArgs e)
        {
            LowercaseText();
        }

        private void txtCdName_TextChanged(object sender, EventArgs e)
        {
            btnDelete.Visible = false;
            picFind.Visible = false;
            picNotFound.Visible = true;
            StatusText = "Ready";
        }

        private void combType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDelete.Visible = false;
            picFind.Visible = false;
            picNotFound.Visible = true;
            StatusText = "Ready";
        }

        private void combNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDelete.Visible = false;
            picFind.Visible = false;
            picNotFound.Visible = true;
            StatusText = "Ready";
        }

        private void txtCdName_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtCdName_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtCdName == ActiveControl) ToggleMenus();
            else DisableButton();
        }

        private void btnSearch_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            StatusText = "Ready";
            CdInfo ReadOnly = (CdInfo)Form1.arrCdInfo[txtCdName.Text];
            DialogResult RemoveIt = MessageBox.Show("Are you sure to delete " + ReadOnly.Type + "  (" + ReadOnly.CdName
                    + ") of Club?", "Delete CD - DVD", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (RemoveIt == DialogResult.Yes)
            {
                Form1.SavedCdInfo = false;
                txtCdName.AutoCompleteCustomSource.Remove(ReadOnly.CdName);
                Form1.arrCdInfo.Remove(ReadOnly.CdName);
                ClearText();
                StatusText = "Removed (" + ReadOnly.CdName + ") of CD - DVD Club Successfuly ...";
                return;
            }
            else
                return;
        }

        private void btnDelete_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void combType_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void combNumber_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void combType_KeyDown(object sender, KeyEventArgs e)
        {
            if (combType.Text == "CD - DVD نوع")
            {
                combType.Text = string.Empty;
            }
        }

        private void combType_MouseClick(object sender, MouseEventArgs e)
        {
            if (combType.Text == "CD - DVD نوع")
            {
                combType.Text = string.Empty;
            }
        }

        private void combType_MouseLeave(object sender, EventArgs e)
        {
            if (combType.Text == "")
            {
                combType.Text = "CD - DVD نوع";
            }
        }

        private void combType_KeyUp(object sender, KeyEventArgs e)
        {
            if (combType.Text == "")
            {
                combType.Text = "CD - DVD نوع";
            }
        }
        bool nonNumberEntered = false;
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
                if (combNumber.Text == "CD - DVD تعداد")
                {
                    combNumber.Text = string.Empty;
                }
            }
        }

        private void combNumber_MouseClick(object sender, MouseEventArgs e)
        {
            if (combNumber.Text == "CD - DVD تعداد")
            {
                combNumber.Text = string.Empty;
            }
        }

        private void combNumber_MouseLeave(object sender, EventArgs e)
        {
            if (combNumber.Text == "")
            {
                combNumber.Text = "CD - DVD تعداد";
            }
        }

        private void combNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (combNumber.Text == "")
            {
                combNumber.Text = "CD - DVD تعداد";
            }
        }

        private void combNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
            if (nonNumberEntered == false)
            {
                if (combNumber.Text == "CD - DVD تعداد")
                {
                    combNumber.Text = string.Empty;
                }
            }
        }
    }
}
