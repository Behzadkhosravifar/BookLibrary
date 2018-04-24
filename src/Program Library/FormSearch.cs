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
    public partial class FormSearch : Form
    {
        public FormSearch()
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
        public void FindAllOfMyStringBN(string searchString)
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
                        if (lstBookName.Items.Count > x + 6)
                        {
                            lstBookName.SetSelected(x + 6, true);
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
            else if (txtBookName.Text != "") FindAllOfMyStringBN(txtBookName.Text);
        }

        private void txtBookName_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtBookName.Text == "نام کتاب")
            {
                txtBookName.Text = string.Empty;
                txtBookName.ForeColor = Color.Black;
            }
            if (e.KeyCode == Keys.Enter && lstBookName.SelectedIndex >= 0) btnSearchBN_Click(sender, e);
        }

        private void txtBookName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtBookName.Text == "نام کتاب")
            {
                txtBookName.Text = string.Empty;
                txtBookName.ForeColor = Color.Black;
            }
        }

        private void txtIsbn_MouseLeave(object sender, EventArgs e)
        {
            if (txtIsbn.Text == "")
            {
                txtIsbn.ForeColor = Color.DimGray;
                txtIsbn.Text = "شابک";
            }
        }
        public bool nonNumberEntered = false;
        public bool OemMinusOne = false;
        private void txtIsbn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift == true && txtIsbn.Text == "شابک")
            {
                txtIsbn.Text = string.Empty;
                txtIsbn.ForeColor = Color.Black;
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
                if (txtIsbn.Text == "شابک")
                {
                    txtIsbn.Text = string.Empty;
                    txtIsbn.ForeColor = Color.Black;
                }
            }
        }

        private void txtIsbn_KeyPress(object sender, KeyPressEventArgs e)
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
                if (txtIsbn.Text == "شابک")
                {
                    txtIsbn.Text = string.Empty;
                    txtIsbn.ForeColor = Color.Black;
                }
            }
        }
        public void FindAllOfMyStringIsbn(string searchString)
        {
            // Set the SelectionMode property of the ListBox to select multiple items.
            lstISBN.SelectionMode = SelectionMode.One;

            // Set our intial index variable to -1.
            int x = -1;
            // If the search string is empty exit.
            if (searchString.Length != 0)
            {
                // Loop through and find each item that matches the search string.
                do
                {
                    // Retrieve the item based on the previous index found. Starts with -1 which searches start.
                    x = lstISBN.FindString(searchString, x);
                    // If no item is found that matches exit.
                    if (x != -1)
                    {
                        // Since the FindString loops infinitely, determine if we found first item again and exit.
                        if (lstISBN.SelectedIndices.Count > 0)
                        {
                            if (x == lstISBN.SelectedIndices[0]) return;
                        }
                        // Select the item in the ListBox once it is found.
                        if (lstISBN.Items.Count > x + 6)
                        {
                            lstISBN.SetSelected(x + 6, true);
                            lstISBN.ClearSelected();
                        }
                        else
                        {
                            lstISBN.SetSelected(lstISBN.Items.Count - 1, true);
                            lstISBN.ClearSelected();
                        }
                        lstISBN.ClearSelected();
                        lstISBN.SetSelected(x, true);
                        break;
                    }
                    // If no item is found that matches Clear SelectedItem.
                    else lstISBN.ClearSelected();

                } while (x != -1);
            }
        }
        private void txtIsbn_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
            if (txtIsbn.Text == "")
            {
                txtIsbn.ForeColor = Color.DimGray;
                txtIsbn.Text = "شابک";
                lstISBN.ClearSelected();
                if (lstISBN.Items.Count != 0) lstISBN.SetSelected(0, true);
            }
            else if (txtIsbn.Text != "") FindAllOfMyStringIsbn(txtIsbn.Text);
        }

        private void txtIsbn_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtIsbn.Text == "شابک")
            {
                txtIsbn.Text = string.Empty;
                txtIsbn.ForeColor = Color.Black;
            }
        }

        private void txtWriterName_MouseLeave(object sender, EventArgs e)
        {
            if (txtWriterName.Text == "")
            {
                txtWriterName.ForeColor = Color.DimGray;
                txtWriterName.Text = "نام نویسنده";
            }
        }
        public void FindAllOfMyStringWN(string searchString)
        {
            // Set the SelectionMode property of the ListBox to select multiple items.
            lstWriterName.SelectionMode = SelectionMode.One;

            // Set our intial index variable to -1.
            int x = -1;
            // If the search string is empty exit.
            if (searchString.Length != 0)
            {
                // Loop through and find each item that matches the search string.
                do
                {
                    // Retrieve the item based on the previous index found. Starts with -1 which searches start.
                    x = lstWriterName.FindString(searchString, x);
                    // If no item is found that matches exit.
                    if (x != -1)
                    {
                        // Since the FindString loops infinitely, determine if we found first item again and exit.
                        if (lstWriterName.SelectedIndices.Count > 0)
                        {
                            if (x == lstWriterName.SelectedIndices[0]) return;
                        }
                        // Select the item in the ListBox once it is found.
                        if (lstWriterName.Items.Count > x + 6)
                        {
                            lstWriterName.SetSelected(x + 6, true);
                            lstWriterName.ClearSelected();
                        }
                        else
                        {
                            lstWriterName.SetSelected(lstWriterName.Items.Count - 1, true);
                            lstWriterName.ClearSelected();
                        }
                        lstWriterName.ClearSelected();
                        lstWriterName.SetSelected(x, true);
                        break;
                    }
                    // If no item is found that matches Clear SelectedItem.
                    else lstWriterName.ClearSelected();

                } while (x != -1);
            }
        }
        private void txtWriterName_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
            if (txtWriterName.Text == "")
            {
                txtWriterName.ForeColor = Color.DimGray;
                txtWriterName.Text = "نام نویسنده";
                lstWriterName.ClearSelected();
                if (lstWriterName.Items.Count != 0) lstWriterName.SetSelected(0, true);
            }
            else if (txtWriterName.Text != "") FindAllOfMyStringWN(txtWriterName.Text);
        }

        private void txtWriterName_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtWriterName.Text == "نام نویسنده")
            {
                txtWriterName.Text = string.Empty;
                txtWriterName.ForeColor = Color.Black;
            } 
            if (e.KeyCode == Keys.Enter && lstWriterName.SelectedIndex >= 0) btnSearchWN_Click(sender, e);
        }

        private void txtWriterName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtWriterName.Text == "نام نویسنده")
            {
                txtWriterName.Text = string.Empty;
                txtWriterName.ForeColor = Color.Black;
            }
        }

        public void btnSearchBN_Click(object sender, EventArgs e)
        {
            if (lstBookName.SelectedIndex >= 0)
            {
                string bufferName = lstBookName.SelectedItem.ToString();
                foreach (BookInfo Read in Form1.arrBookInfo.Values)
                {
                    if (bufferName == Read.BookName)
                    {
                        txtDBookName.ForeColor = Color.Black;
                        txtDBookName.Text = Read.BookName;
                        txtDWriterName.ForeColor = Color.Black;
                        txtDWriterName.Text = Read.WriterName;
                        txtDTranslator.ForeColor = Color.Black;
                        txtDTranslator.Text = Read.Translator;
                        txtDPropagator.ForeColor = Color.Black;
                        txtDPropagator.Text = Read.Propagator;
                        txtDIsbn.ForeColor = Color.Black;
                        txtDIsbn.Text = Read.Isbn;
                        txtDDateOfBook.ForeColor = Color.Black;
                        txtDDateOfBook.Text = Read.DateOfBook;
                        txtDPrice.ForeColor = Color.Black;
                        txtDPrice.Text = Read.Price;
                        txtDNumberPage.ForeColor = Color.Black;
                        txtDNumberPage.Text = Read.NumberPage;
                        txtDHaveCD.ForeColor = Color.Black;
                        txtDHaveCD.Text = Read.HaveCd;
                        txtDBailment.ForeColor = Color.Black;
                        if (string.Compare(Read.Bailment, "true", true) == 0)
                        {
                            BookBailment fillB = (BookBailment)Form1.arrBookBailment[Read.Isbn];
                            txtDBailment.Text = "Yes (By: " + fillB.BailmentName + ")";
                        }
                        else txtDBailment.Text = "No";
                        break;
                    }
                }
            }
        }

        private void btnSearchWN_Click(object sender, EventArgs e)
        {
            if (lstWriterName.SelectedIndex >= 0)
            {
                string bufferName = lstWriterName.SelectedItem.ToString();
                foreach (BookInfo Read in Form1.arrBookInfo.Values)
                {
                    if (bufferName == Read.WriterName)
                    {
                        txtDBookName.ForeColor = Color.Black;
                        txtDBookName.Text = Read.BookName;
                        txtDWriterName.ForeColor = Color.Black;
                        txtDWriterName.Text = Read.WriterName;
                        txtDTranslator.ForeColor = Color.Black;
                        txtDTranslator.Text = Read.Translator;
                        txtDPropagator.ForeColor = Color.Black;
                        txtDPropagator.Text = Read.Propagator;
                        txtDIsbn.ForeColor = Color.Black;
                        txtDIsbn.Text = Read.Isbn;
                        txtDDateOfBook.ForeColor = Color.Black;
                        txtDDateOfBook.Text = Read.DateOfBook;
                        txtDPrice.ForeColor = Color.Black;
                        txtDPrice.Text = Read.Price;
                        txtDNumberPage.ForeColor = Color.Black;
                        txtDNumberPage.Text = Read.NumberPage;
                        txtDHaveCD.ForeColor = Color.Black;
                        txtDHaveCD.Text = Read.HaveCd;
                        txtDBailment.ForeColor = Color.Black;
                        if (string.Compare(Read.Bailment, "true", true) == 0)
                        {
                            BookBailment fillB = (BookBailment)Form1.arrBookBailment[Read.Isbn];
                            txtDBailment.Text = "Yes (By: " + fillB.BailmentName + ")";
                        }
                        else txtDBailment.Text = "No";
                        break;
                    }
                }
            }
        }

        private void btnSearchISBN_Click(object sender, EventArgs e)
        {
            if (lstISBN.SelectedIndex >= 0)
            {
                if (Form1.arrBookInfo.Contains(lstISBN.SelectedItem.ToString()) == true)
                {
                    BookInfo Read = (BookInfo)Form1.arrBookInfo[lstISBN.SelectedItem.ToString()];
                    txtDBookName.ForeColor = Color.Black;
                    txtDBookName.Text = Read.BookName;
                    txtDWriterName.ForeColor = Color.Black;
                    txtDWriterName.Text = Read.WriterName;
                    txtDTranslator.ForeColor = Color.Black;
                    txtDTranslator.Text = Read.Translator;
                    txtDPropagator.ForeColor = Color.Black;
                    txtDPropagator.Text = Read.Propagator;
                    txtDIsbn.ForeColor = Color.Black;
                    txtDIsbn.Text = Read.Isbn;
                    txtDDateOfBook.ForeColor = Color.Black;
                    txtDDateOfBook.Text = Read.DateOfBook;
                    txtDPrice.ForeColor = Color.Black;
                    txtDPrice.Text = Read.Price;
                    txtDNumberPage.ForeColor = Color.Black;
                    txtDNumberPage.Text = Read.NumberPage;
                    txtDHaveCD.ForeColor = Color.Black;
                    txtDHaveCD.Text = Read.HaveCd;
                    txtDBailment.ForeColor = Color.Black;
                    if (string.Compare(Read.Bailment, "true", true) == 0)
                    {
                        BookBailment fillB = (BookBailment)Form1.arrBookBailment[Read.Isbn];
                        txtDBailment.Text = "Yes (By: " + fillB.BailmentName + ")";
                    }
                    else txtDBailment.Text = "No";
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void changePassStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormChangePass ChangePass = new FormChangePass();
            ChangePass.ShowDialog();
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

        private void AddStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdd Add = new FormAdd();
            Add.ShowDialog();
        }

        private void BailmentBStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBailment Bailment = new FormBailment();
            Bailment.ShowDialog();
        }

        private void DelStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDelete Delete = new FormDelete();
            Delete.ShowDialog();
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

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Declare a TextBox object and
            // set it to the ActiveControl
            TextBox objTextBox = (TextBox)this.ActiveControl;
            // Select all text
            objTextBox.SelectAll();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout About = new FormAbout();
            About.ShowDialog();
        }

        private void SearchDStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSearchC SearchC = new FormSearchC();
            SearchC.ShowDialog();
        }

        private void FormSearch_Load(object sender, EventArgs e)
        {
            if (Form1.arrBookInfo.Count > 0)
            {
                foreach (BookInfo buffer in Form1.arrBookInfo.Values)
                {
                    lstBookName.Items.Add(buffer.BookName);
                    txtBookName.AutoCompleteCustomSource.Add(buffer.BookName);
                    lstWriterName.Items.Add(buffer.WriterName);
                    txtWriterName.AutoCompleteCustomSource.Add(buffer.WriterName);
                    lstISBN.Items.Add(buffer.Isbn);
                    txtIsbn.AutoCompleteCustomSource.Add(buffer.Isbn);
                }
                txtBookName.Select();
            }
        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        public string UndoISBN = "شابک";
        private void txtIsbn_TextChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
            bool Corrent = true;
            if (txtIsbn.Text != "شابک" && txtIsbn.Text != "")
            {
                char[] Spil = txtIsbn.Text.ToCharArray();
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
                        txtIsbn.Text = UndoISBN;
                        break;
                    }
                }
            }
            if (Corrent == true) UndoISBN = txtIsbn.Text;
            else return;
        }

        private void txtWriterName_TextChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void lstBookName_SelectedIndexChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void lstISBN_SelectedIndexChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void lstWriterName_SelectedIndexChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }
        private void ClearText()
        {
            txtBookName.ForeColor = Color.DimGray;
            txtBookName.Text = "نام کتاب";
            txtWriterName.ForeColor = Color.DimGray;
            txtWriterName.Text = "نام نویسنده";
            txtIsbn.ForeColor = Color.DimGray;
            txtIsbn.Text = "شابک";
            txtDBookName.ForeColor = Color.DimGray;
            txtDBookName.Text = "نام کتاب";
            txtDWriterName.ForeColor = Color.DimGray;
            txtDWriterName.Text = "نام نویسنده";
            txtDPropagator.ForeColor = Color.DimGray;
            txtDPropagator.Text = "انتشارات";
            txtDTranslator.ForeColor = Color.DimGray;
            txtDTranslator.Text = "مترجم";
            txtDIsbn.ForeColor = Color.DimGray;
            txtDIsbn.Text = "شابک";
            txtDDateOfBook.ForeColor = Color.DimGray;
            txtDDateOfBook.Text = "تاریخ انتشار";
            txtDPrice.ForeColor = Color.DimGray;
            txtDPrice.Text = "قیمت کتاب";
            txtDNumberPage.ForeColor = Color.DimGray;
            txtDNumberPage.Text = "تعداد صفحات";
            txtDHaveCD.ForeColor = Color.DimGray;
            txtDHaveCD.Text = "CD به همراه";
            txtDBailment.ForeColor = Color.DimGray;
            txtDBailment.Text = "کتاب را چه کسی به امانت برده ؟";
            StatusText = "All Text box cleared!";
            txtBookName.Focus();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearText();
        }
        private void ToggleMenus()
        {
            // Declare a TextBox object and
            // set it to the ActiveControl
            TextBox objTextBox = (TextBox)this.ActiveControl;
            // Toggle the Copy toolbar button and menu items
            copyToolStripMenuItem.Enabled = Convert.ToBoolean(objTextBox.SelectionLength);
            // Toggle the Paste toolbar button and menu items
            pasteToolStripMenuItem.Enabled = Clipboard.ContainsText();
            // Toggle the Select All menu items
            selectAllToolStripMenuItem.Enabled = (objTextBox.SelectionLength < objTextBox.Text.Length);
        }
        public void DisableButton()
        {
            copyToolStripMenuItem.Enabled = false;
            pasteToolStripMenuItem.Enabled = false;
            selectAllToolStripMenuItem.Enabled = false;
        }

        private void lstBookName_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void lstISBN_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void lstWriterName_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnSearchBN_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnSearchISBN_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnSearchWN_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void txtBookName_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtIsbn_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtWriterName_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtDBookName_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtDBookName_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtDWriterName_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtDWriterName_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtDPropagator_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtDPropagator_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtDTranslator_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtDTranslator_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtDIsbn_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtDIsbn_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtDDateOfBook_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtDDateOfBook_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtDPrice_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtDPrice_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtDNumberPage_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtDNumberPage_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtDHaveCD_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtDHaveCD_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtDBailment_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtDBailment_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtWriterName_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtWriterName == ActiveControl) ToggleMenus();
        }

        private void txtBookName_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtBookName == ActiveControl) ToggleMenus();
        }

        private void txtIsbn_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtIsbn == ActiveControl) ToggleMenus();
        }

        private void txtDBookName_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtDBookName == ActiveControl) ToggleMenus();
        }

        private void txtDWriterName_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtDWriterName == ActiveControl) ToggleMenus();
        }

        private void txtDPropagator_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtDPropagator == ActiveControl) ToggleMenus();
        }

        private void txtDTranslator_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtDTranslator == ActiveControl) ToggleMenus();
        }

        private void txtDIsbn_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtDIsbn == ActiveControl) ToggleMenus();
        }

        private void txtDDateOfBook_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtDDateOfBook == ActiveControl) ToggleMenus();
        }

        private void txtDPrice_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtDPrice == ActiveControl) ToggleMenus();
        }

        private void txtDNumberPage_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtDNumberPage == ActiveControl) ToggleMenus();
        }

        private void txtDHaveCD_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtDHaveCD == ActiveControl) ToggleMenus();
        }

        private void txtDBailment_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtDBailment == ActiveControl) ToggleMenus();
        }

        private void lstBookName_KeyDown(object sender, KeyEventArgs e)
        {
            if (lstBookName.SelectedIndex >= 0 && e.KeyCode == Keys.Enter)
                btnSearchBN_Click(sender, e);
        }

        private void lstISBN_KeyDown(object sender, KeyEventArgs e)
        {
            if (lstISBN.SelectedIndex >= 0 && e.KeyCode == Keys.Enter)
                btnSearchISBN_Click(sender, e);
        }

        private void lstWriterName_KeyDown(object sender, KeyEventArgs e)
        {
            if (lstWriterName.SelectedIndex >= 0 && e.KeyCode == Keys.Enter)
                btnSearchWN_Click(sender, e);
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

        private void lstISBN_KeyUp(object sender, KeyEventArgs e)
        {
            if (lstISBN.SelectedIndex >= 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Down:
                        {
                            txtIsbn.Text = lstISBN.SelectedItem.ToString();
                            txtIsbn.ForeColor = Color.Black;
                        }
                        break;
                    case Keys.Up:
                        {
                            txtIsbn.Text = lstISBN.SelectedItem.ToString();
                            txtIsbn.ForeColor = Color.Black;
                        }
                        break;
                    case Keys.Left:
                        {
                            txtIsbn.Text = lstISBN.SelectedItem.ToString();
                            txtIsbn.ForeColor = Color.Black;
                        }
                        break;
                    case Keys.Right:
                        {
                            txtIsbn.Text = lstISBN.SelectedItem.ToString();
                            txtIsbn.ForeColor = Color.Black;
                        }
                        break;
                }
            }
        }

        private void lstWriterName_KeyUp(object sender, KeyEventArgs e)
        {
            if (lstWriterName.SelectedIndex >= 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Down:
                        {
                            txtWriterName.Text = lstWriterName.SelectedItem.ToString();
                            txtWriterName.ForeColor = Color.Black;
                        }
                        break;
                    case Keys.Up:
                        {
                            txtWriterName.Text = lstWriterName.SelectedItem.ToString();
                            txtWriterName.ForeColor = Color.Black;
                        }
                        break;
                    case Keys.Left:
                        {
                            txtWriterName.Text = lstWriterName.SelectedItem.ToString();
                            txtWriterName.ForeColor = Color.Black;
                        }
                        break;
                    case Keys.Right:
                        {
                            txtWriterName.Text = lstWriterName.SelectedItem.ToString();
                            txtWriterName.ForeColor = Color.Black;
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

        private void lstISBN_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstISBN.SelectedIndex >= 0)
            {
                txtIsbn.Text = lstISBN.SelectedItem.ToString();
                txtIsbn.ForeColor = Color.Black;
            }
        }

        private void lstWriterName_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstWriterName.SelectedIndex >= 0)
            {
                txtWriterName.Text = lstWriterName.SelectedItem.ToString();
                txtWriterName.ForeColor = Color.Black;
            }
        }
        public static String OldISBN;
        public String OldBookName;
        public String OldWriterName;
        private Boolean BtnEditClicked = false;
        private void EditBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BtnEditClicked == true)
            {
                BookInfo Change = (BookInfo)Form1.arrBookInfo[OldISBN];
                if (Change.Bailment == "true")
                {
                    BookBailment SaveBailment = (BookBailment)Form1.arrBookBailment[OldISBN];
                    Form1.arrBookBailment.Remove(OldISBN);
                    Change.BookName = txtDBookName.Text;
                    Change.WriterName = txtDWriterName.Text;
                    Change.Price = txtDPrice.Text;
                    Change.Propagator = txtDPropagator.Text;
                    Change.Translator = txtDTranslator.Text;
                    Change.DateOfBook = txtDDateOfBook.Text;
                    Change.Isbn = txtDIsbn.Text;
                    Change.NumberPage = txtDNumberPage.Text;
                    Change.HaveCd = txtDHaveCD.Text;
                    SaveBailment.BailmentBookIsbn = txtDIsbn.Text;
                    SaveBailment.BookName = txtDBookName.Text;
                    Form1.arrBookInfo.Remove(OldISBN);
                    Form1.arrBookInfo.Add(Change.Isbn, Change);
                    Form1.arrBookBailment.Add(Change.Isbn, SaveBailment);
                    OldISBN = Change.Isbn;
                    CancelToolStripMenuItem_Click(sender, e);
                    BtnEditClicked = false;
                    Form1.SavedBookInfo = false;
                    StatusText = "Edit Book Complete Successfuly ...";
                    //------------------------------ Refresh Data --------------------
                    lstBookName.Items.Remove(OldBookName);
                    lstBookName.Items.Add(Change.BookName);
                    txtBookName.AutoCompleteCustomSource.Remove(OldBookName);
                    txtBookName.AutoCompleteCustomSource.Add(Change.BookName);
                    lstWriterName.Items.Remove(OldWriterName);
                    lstWriterName.Items.Add(Change.WriterName);
                    txtWriterName.AutoCompleteCustomSource.Remove(OldWriterName);
                    txtWriterName.AutoCompleteCustomSource.Add(Change.WriterName);
                    lstISBN.Items.Remove(OldISBN);
                    lstISBN.Items.Add(Change.Isbn);
                    txtIsbn.AutoCompleteCustomSource.Remove(OldISBN);
                    txtIsbn.AutoCompleteCustomSource.Add(Change.Isbn);
                    //----------------------------------------------------------------
                    MessageBox.Show("Edit Complete ...", "Successful Changed Data!");
                }
                else
                {
                    Change.BookName = txtDBookName.Text;
                    Change.WriterName = txtDWriterName.Text;
                    Change.Price = txtDPrice.Text;
                    Change.Propagator = txtDPropagator.Text;
                    Change.Translator = txtDTranslator.Text;
                    Change.DateOfBook = txtDDateOfBook.Text;
                    Change.Isbn = txtDIsbn.Text;
                    Change.NumberPage = txtDNumberPage.Text;
                    Change.HaveCd = txtDHaveCD.Text;
                    Form1.arrBookInfo.Remove(OldISBN);
                    Form1.arrBookInfo.Add(Change.Isbn, Change);
                    OldISBN = Change.Isbn;
                    CancelToolStripMenuItem_Click(sender, e);
                    BtnEditClicked = false;
                    Form1.SavedBookInfo = false;
                    StatusText = "Edit Book Complete Successfuly ...";
                    //------------------------------ Refresh Data --------------------
                    lstBookName.Items.Remove(OldBookName);
                    lstBookName.Items.Add(Change.BookName);
                    txtBookName.AutoCompleteCustomSource.Remove(OldBookName);
                    txtBookName.AutoCompleteCustomSource.Add(Change.BookName);
                    lstWriterName.Items.Remove(OldWriterName);
                    lstWriterName.Items.Add(Change.WriterName);
                    txtWriterName.AutoCompleteCustomSource.Remove(OldWriterName);
                    txtWriterName.AutoCompleteCustomSource.Add(Change.WriterName);
                    lstISBN.Items.Remove(OldISBN);
                    lstISBN.Items.Add(Change.Isbn);
                    txtIsbn.AutoCompleteCustomSource.Remove(OldISBN);
                    txtIsbn.AutoCompleteCustomSource.Add(Change.Isbn);
                    //----------------------------------------------------------------
                    MessageBox.Show("Edit Complete ...", "Successful Changed Data!");
                }
            }
            else if (BtnEditClicked == false) 
            {
                if (txtDBookName.Text == "نام کتاب")
                {
                    MessageBox.Show("Please Search One Book Then Edit It", "Empty TextBox!", MessageBoxButtons.OK
                        , MessageBoxIcon.Information);
                    txtBookName.Focus();
                    txtBookName.SelectAll();
                }
                else
                {
                    BtnEditClicked = true;
                    CancelToolStripMenuItem.Visible = true;
                    EditBookToolStripMenuItem.Text = "&Save Change";
                    // Save Old Data -----------------
                    OldISBN = txtDIsbn.Text;
                    OldBookName = txtDBookName.Text;
                    OldWriterName = txtDWriterName.Text;
                    //--------------------------------
                    txtDBookName.ReadOnly = false;
                    txtDWriterName.ReadOnly = false;
                    txtDPrice.ReadOnly = false;
                    txtDPropagator.ReadOnly = false;
                    txtDTranslator.ReadOnly = false;
                    txtDDateOfBook.ReadOnly = false;
                    txtDIsbn.ReadOnly = false;
                    txtDNumberPage.ReadOnly = false;
                    txtDHaveCD.ReadOnly = false;
                }
            }
        }

        private void CancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtnEditClicked = false;
            txtDBookName.ReadOnly = true;
            txtDWriterName.ReadOnly = true;
            txtDPrice.ReadOnly = true;
            txtDPropagator.ReadOnly = true;
            txtDTranslator.ReadOnly = true;
            txtDDateOfBook.ReadOnly = true;
            txtDIsbn.ReadOnly = true;
            txtDNumberPage.ReadOnly = true;
            txtDHaveCD.ReadOnly = true;
            EditBookToolStripMenuItem.Text = "Edit &Book";
            CancelToolStripMenuItem.Visible = false;
            // Refresh Info ==============
            BookInfo Read = (BookInfo)Form1.arrBookInfo[OldISBN];
            txtDBookName.Text = Read.BookName;
            txtDWriterName.Text = Read.WriterName;
            txtDTranslator.Text = Read.Translator;
            txtDPropagator.Text = Read.Propagator;
            txtDIsbn.Text = Read.Isbn;
            txtDDateOfBook.Text = Read.DateOfBook;
            txtDPrice.Text = Read.Price;
            txtDNumberPage.Text = Read.NumberPage;
            txtDHaveCD.Text = Read.HaveCd;
            if (string.Compare(Read.Bailment, "true", true) == 0)
            {
                BookBailment fillB = (BookBailment)Form1.arrBookBailment[Read.Isbn];
                txtDBailment.Text = "Yes (By: " + fillB.BailmentName + ")";
            }
            else txtDBailment.Text = "No";
            //============================
        }

    }
}
