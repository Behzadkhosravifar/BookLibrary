using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

namespace Program_Library
{
    public partial class FormDelete : Form
    {
        public FormDelete()
        {
            InitializeComponent();
        }

        private void txtBookName_MouseLeave(object sender, EventArgs e)
        {
            if (txtBookName.Text == "")
            {
                txtBookName.ForeColor = Color.DimGray;
                txtBookName.Text = "نام کتاب";
            }
        }

        private void txtBookName_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
            if (txtBookName.Text == "")
            {
                txtBookName.ForeColor = Color.DimGray;
                txtBookName.Text = "نام کتاب";
                lstBookName.ClearSelected();
                if (lstBookName.Items.Count != 0) lstBookName.SetSelected(0, true);
            }
            else if (txtBookName.Text != "") FindAllOfMyString1(txtBookName.Text);
        }

        private void txtBookName_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtBookName.Text == "نام کتاب")
            {
                txtBookName.Text = string.Empty;
                txtBookName.ForeColor = Color.Black;
            }
            else if (e.KeyCode == Keys.Enter) btnSearch_Click(sender, e);
        }

        private void txtBookName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtBookName.Text == "نام کتاب")
            {
                txtBookName.Text = string.Empty;
                txtBookName.ForeColor = Color.Black;
            }
        }

        private void txtISBN_MouseLeave(object sender, EventArgs e)
        {
            if (txtISBN.Text == "")
            {
                txtISBN.ForeColor = Color.DimGray;
                txtISBN.Text = "شابک";
            }
        }

        private void txtISBN_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
            if (txtISBN.Text == "")
            {
                txtISBN.ForeColor = Color.DimGray;
                txtISBN.Text = "شابک";
                btnDelete.Enabled = false;
            }
        }
        public bool OemMinusOne = false;
        public bool nonNumberEntered = false;
        private void txtISBN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift == true && txtISBN.Text == "شابک")
            {
                txtISBN.Text = string.Empty;
                txtISBN.ForeColor = Color.Black;
            }
            // Initialize the flag to false.
            nonNumberEntered = false;
            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Subtract && e.KeyCode != Keys.OemMinus)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEntered = true;
                    }
                    else if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
                    {
                        if (OemMinusOne == false)
                        {
                            OemMinusOne = true;
                        }
                        else if (OemMinusOne == true)
                        {
                            nonNumberEntered = true;
                        }
                    }
                    else OemMinusOne = false;
                }
                else OemMinusOne = false;
            }
            else OemMinusOne = false;
            if (e.KeyCode == Keys.Delete)
            {
                if (txtISBN.Text == "شابک")
                {
                    txtISBN.Text = string.Empty;
                    txtISBN.ForeColor = Color.Black;
                }
            }
        }

        private void txtISBN_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtISBN.Text == "شابک")
            {
                txtISBN.Text = string.Empty;
                txtISBN.ForeColor = Color.Black;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Value = 10;
            Thread.Sleep(100);
            if (Form1.arrBookInfo.Contains(txtISBN.Text) == true)
            {
                progressBar1.Value = 20;
                Thread.Sleep(200);
                Hashtable Match = new Hashtable();
                Match.Add(txtISBN.Text, Form1.arrBookInfo[txtISBN.Text]);
                foreach (BookInfo read in Match.Values)
                {
                    progressBar1.Value = 40;
                    Thread.Sleep(100);
                    if (read.BookName == lstBookName.SelectedItem.ToString())
                    {
                        progressBar1.Value = 60;
                        Thread.Sleep(200);
                        DialogResult Delete = MessageBox.Show("Are You Sure To Delete Book (" + read.BookName + ")", "Warning to Delete Info"
                            , MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                        if (Delete == DialogResult.Yes)
                        {
                            progressBar1.Value = 70;
                            Thread.Sleep(150);
                            Form1.arrBookInfo.Remove(read.Isbn);
                            progressBar1.Value = 90;
                            Thread.Sleep(150);
                            Form1.SavedBookInfo = false;
                            lstBookName.Items.Clear();
                            foreach (BookInfo buffer in Form1.arrBookInfo.Values)
                            {
                                lstBookName.Items.Add(buffer.BookName);
                            }
                            Form1.arrBookBailment.Remove(read.Isbn);
                            progressBar1.Value = 100;
                            Thread.Sleep(150);
                            txtBookName.AutoCompleteCustomSource.Remove(read.BookName);
                            txtISBN.AutoCompleteCustomSource.Remove(read.Isbn);
                            ClearText();
                            StatusText = "Book (" + read.BookName + ") Removed ...";
                            progressBar1.Visible = false;
                            return;
                        }
                        else if (Delete == DialogResult.No)
                        {
                            DisableButton();
                            progressBar1.Visible = false;
                            return;
                        }
                    }
                    else
                    {
                        progressBar1.Value = 100;
                        MessageBox.Show("Your Book Name No Matching by Book ISBN", "Error No Matching", MessageBoxButtons.OK
                            , MessageBoxIcon.Error);
                        txtBookName.Focus();
                        txtBookName.SelectAll();
                        progressBar1.Visible = false;
                        return;
                    }
                }
            }
            else
            {
                progressBar1.Value = 100;
                MessageBox.Show("Not Found Any Book for your typed ISBN \nPlease Type ISBN Again", "Not Found Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                txtISBN.Focus();
                txtISBN.SelectAll();
            }
            progressBar1.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (lstBookName.SelectedIndex >= 0)
            {
                foreach (BookInfo Search in Form1.arrBookInfo.Values)
                {
                    if (lstBookName.SelectedItem.ToString() == Search.BookName)
                    {
                        txtISBN.ForeColor = Color.Black;
                        txtISBN.Text = Search.Isbn;
                        btnDelete.Enabled = true;
                        btnDelete.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select One Item of ListBox Book Name", "Not Found any Selected Item");
                btnDelete.Enabled = false;
                txtBookName.Focus();
                txtBookName.Select();
            }
        }

        private void txtISBN_KeyPress(object sender, KeyPressEventArgs e)
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
                if (txtISBN.Text == "شابک")
                {
                    txtISBN.Text = string.Empty;
                    txtISBN.ForeColor = Color.Black;
                }
            }
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
            
            txtBookName.ForeColor = Color.DimGray;
            txtBookName.Text = "نام کتاب";
            txtISBN.ForeColor = Color.DimGray;
            txtISBN.Text = "شابک";
            lstBookName.ClearSelected();
            StatusText = "All Text box cleared!";
            btnDelete.Enabled = false;
            txtBookName.Focus();
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

        public void SaveBook()
        {
            if (Form1.SavedNewB == false)
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                // Set the FolderBrowserDialog control properties
                folderBrowserDialog1.Description = "Select a folder for your Books backups:";
                folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
                folderBrowserDialog1.ShowNewFolderButton = true;
                // Show the Browse For Folder dialog
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    Form1.patchBook = folderBrowserDialog1.SelectedPath;
                    Form1.SaveBookInfo();
                    Form1.SaveBookBailment();
                    Form1.SavedBookInfo = true;
                    Form1.SavedNewB = true;
                    StatusText = "Save The Book Data in path: " + Form1.patchBook;
                }
            }
            else
            {
                Form1.SaveBookInfo();
                Form1.SaveBookBailment();
                Form1.SavedBookInfo = true;
                StatusText = "Save The Book Data in path: " + Form1.patchBook;
            }
        }
        private void SaveBStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveBook();
        }

        private void BailmentBStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBailment Bailment = new FormBailment();
            Bailment.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void AddStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdd Add = new FormAdd();
            Add.ShowDialog();
        }

        private void DelDStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDeleteC DeleteC = new FormDeleteC();
            DeleteC.ShowDialog();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Declare a TextBox object and
            // set it to the ActiveControl
            TextBox objTextBox = (TextBox)this.ActiveControl;
            // Undo the last operation
            objTextBox.Undo();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Declare a TextBox object and
            // set it to the ActiveControl
            TextBox objTextBox = (TextBox)this.ActiveControl;
            // Select all text
            objTextBox.SelectAll();
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

        private void tbrHelpAbout_Click(object sender, EventArgs e)
        {
            FormAbout About = new FormAbout();
            About.ShowDialog();
        }
        public void UppercaseText()
        {
            // Make the text Uppercase
            txtBookName.Text = txtBookName.Text.ToUpper();
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
            txtBookName.Text = txtBookName.Text.ToLower();
            // Update the status bar text
            StatusText = "The text is all LowerCase";
        }
        private void tbrLowerCase_Click(object sender, EventArgs e)
        {
            LowercaseText();
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

        private void FormDelete_Load(object sender, EventArgs e)
        {
            foreach (BookInfo buffer in Form1.arrBookInfo.Values)
            {
                lstBookName.Items.Add(buffer.BookName);
                txtBookName.AutoCompleteCustomSource.Add(buffer.BookName);
                txtISBN.AutoCompleteCustomSource.Add(buffer.Isbn);
            }
            txtBookName.Focus();
        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            txtISBN.Text = "شابک";
            txtISBN.ForeColor = Color.DimGray;
            StatusText = "Ready";
        }

        public string UndoISBN = "شابک";
        private void txtISBN_TextChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
            bool Corrent = true;
            if (txtISBN.Text != "شابک" && txtISBN.Text != "")
            {
                btnDelete.Enabled = true;
                char[] Spil = txtISBN.Text.ToCharArray();
                for (int i = 0; i < Spil.Length; i++)
                {
                    if (Spil[i] == '0' || Spil[i] == '1' || Spil[i] == '2' || Spil[i] == '3' || Spil[i] == '4' || Spil[i] == '5' ||
                        Spil[i] == '6' || Spil[i] == '7' || Spil[i] == '8' || Spil[i] == '9' || Spil[i] == '-' || Spil[i] == 'x' || Spil[i] == 'X')
                        continue;
                    else
                    {
                        MessageBox.Show("Please Enter Just Number or (-). This TextBox don't Accept Other Key!" +
                            "\nلطفاً فقط عدد و خط جداکننده وارد کنید. این فیلد کلید دیگری را قبول نمی کند ", "Enter InCorrect Key"
                            , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        Corrent = false;
                        txtISBN.Text = UndoISBN;
                        break;
                    }
                }
            }
            if (Corrent == true) UndoISBN = txtISBN.Text;
            else return;
        }

        private void lstBookName_SelectedIndexChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
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

        private void lstBookName_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnSearch_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void txtBookName_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtISBN_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtBookName_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtBookName == ActiveControl) ToggleMenus();
        }

        private void txtISBN_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtISBN == ActiveControl) ToggleMenus();
        }

        private void lstBookName_KeyDown(object sender, KeyEventArgs e)
        {
            if (lstBookName.SelectedIndex >= 0 && e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, e);
        }

        private void lstBookName_KeyUp(object sender, KeyEventArgs e)
        {
            if (lstBookName.SelectedIndex >= 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Down:
                        {
                            txtBookName.Text = lstBookName.SelectedItem.ToString();
                            txtBookName.ForeColor = Color.Black;
                        }
                        break;
                    case Keys.Up:
                        {
                            txtBookName.Text = lstBookName.SelectedItem.ToString();
                            txtBookName.ForeColor = Color.Black;
                        }
                        break;
                    case Keys.Left:
                        {
                            txtBookName.Text = lstBookName.SelectedItem.ToString();
                            txtBookName.ForeColor = Color.Black;
                        }
                        break;
                    case Keys.Right:
                        {
                            txtBookName.Text = lstBookName.SelectedItem.ToString();
                            txtBookName.ForeColor = Color.Black;
                        }
                        break;
                }
            }
        }

        private void lstBookName_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstBookName.SelectedIndex >= 0)
            {
                txtBookName.Text = lstBookName.SelectedItem.ToString();
                txtBookName.ForeColor = Color.Black;
            }
        }
        public void FindAllOfMyString1(string searchString)
        {
            // Set the SelectionMode property of the ListBox to select multiple items.
            lstBookName.SelectionMode = SelectionMode.One;

            // Set our intial index variable to -1.
            int x = -1;
            // If the search string is empty exit.
            if (searchString.Length != 0)
            {
                // Loop through and find each item that matches the search string.
                do
                {
                    // Retrieve the item based on the previous index found. Starts with -1 which searches start.
                    x = lstBookName.FindString(searchString, x);
                    // If no item is found that matches exit.
                    if (x != -1)
                    {
                        // Since the FindString loops infinitely, determine if we found first item again and exit.
                        if (lstBookName.SelectedIndices.Count > 0)
                        {
                            if (x == lstBookName.SelectedIndices[0]) return;
                        }
                        // Select the item in the ListBox once it is found.
                        if (lstBookName.Items.Count > x + 7)
                        {
                            lstBookName.SetSelected(x + 7, true);
                            lstBookName.ClearSelected();
                        }
                        else
                        {
                            lstBookName.SetSelected(lstBookName.Items.Count - 1, true);
                            lstBookName.ClearSelected();
                        }
                        lstBookName.ClearSelected();
                        lstBookName.SetSelected(x, true);
                        break;
                    }
                    // If no item is found that matches Clear SelectedItem.
                    else lstBookName.ClearSelected();

                } while (x != -1);
            }
        }

    }
}
