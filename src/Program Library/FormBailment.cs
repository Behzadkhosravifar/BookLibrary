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
    public partial class FormBailment : Form
    {
        public FormBailment()
        {
            InitializeComponent();
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtSearch.Text == "نام کتاب به امانت گرفته شده")
            {
                txtSearch.Text = string.Empty;
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_MouseLeave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.ForeColor = Color.DarkGray;
                txtSearch.Text = "نام کتاب به امانت گرفته شده";
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
            if (txtSearch.Text == "")
            {
                txtSearch.ForeColor = Color.DarkGray;
                txtSearch.Text = "نام کتاب به امانت گرفته شده";
                lstBailmentUser.ClearSelected();
                if(lstBailmentUser.Items.Count != 0) lstBailmentUser.SetSelected(0, true);
            }
            else if (txtSearch.Text != "") FindAllOfMyString1(txtSearch.Text);
        }

        private void FormBailment_Load(object sender, EventArgs e)
        {
            foreach (BookInfo buffer in Form1.arrBookInfo.Values)
            {
                txtBookNameAdd.AutoCompleteCustomSource.Add(buffer.BookName);
            }
            foreach (BookBailment buffer in Form1.arrBookBailment.Values)
            {
                lstBailmentUser.Items.Add(buffer.BookName);
                txtSearch.AutoCompleteCustomSource.Add(buffer.BookName);
                lstSearchDel.Items.Add(buffer.BookName);
                txtSearchDel.AutoCompleteCustomSource.Add(buffer.BookName);
            }
            txtSearch.Select();
        }

        private void txtUserNameAdd_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUserNameAdd.Text == "نام امانت گیرنده")
            {
                txtUserNameAdd.Text = string.Empty;
                txtUserNameAdd.ForeColor = Color.Black;
            }
        }

        private void txtUserNameAdd_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
            if (txtUserNameAdd.Text == "")
            {
                txtUserNameAdd.ForeColor = Color.DarkGray;
                txtUserNameAdd.Text = "نام امانت گیرنده";
            }
        }

        private void txtUserNameAdd_MouseLeave(object sender, EventArgs e)
        {
            if (txtUserNameAdd.Text == "")
            {
                txtUserNameAdd.ForeColor = Color.DarkGray;
                txtUserNameAdd.Text = "نام امانت گیرنده";
            }
        }

        private void txtUserNameAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtUserNameAdd.Text == "نام امانت گیرنده")
            {
                txtUserNameAdd.Text = string.Empty;
                txtUserNameAdd.ForeColor = Color.Black;
            }
            if (e.KeyCode == Keys.Enter) btnSearchAdd_Click(sender, e);
        }

        private void txtBookNameAdd_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtBookNameAdd.Text == "نام کتاب امانت گرفته شده")
            {
                txtBookNameAdd.Text = string.Empty;
                txtBookNameAdd.ForeColor = Color.Black;
            }
        }

        private void txtBookNameAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtBookNameAdd.Text == "نام کتاب امانت گرفته شده")
            {
                txtBookNameAdd.Text = string.Empty;
                txtBookNameAdd.ForeColor = Color.Black;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                foreach (BookInfo IsbnRead in Form1.arrBookInfo.Values)
                {
                    if (string.Compare(txtBookNameAdd.Text, IsbnRead.BookName, true) == 0)
                    {
                        txtIsbnAdd.ForeColor = Color.Black;
                        txtIsbnAdd.Text = IsbnRead.Isbn;
                        break;
                    }
                }
            }
        }

        private void txtBookNameAdd_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
            if (txtBookNameAdd.Text == "")
            {
                txtBookNameAdd.ForeColor = Color.DarkGray;
                txtBookNameAdd.Text = "نام کتاب امانت گرفته شده";
            }
        }

        private void txtBookNameAdd_MouseLeave(object sender, EventArgs e)
        {
            if (txtBookNameAdd.Text == "")
            {
                txtBookNameAdd.ForeColor = Color.DarkGray;
                txtBookNameAdd.Text = "نام کتاب امانت گرفته شده";
            }
        }

        public bool OemMinusOne = false;
        private void txtIsbnAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift == true && txtIsbnAdd.Text == "شابک کتاب امانت گرفته شده")
            {
                txtIsbnAdd.Text = string.Empty;
                txtIsbnAdd.ForeColor = Color.Black;
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
                if (txtIsbnAdd.Text == "شابک کتاب امانت گرفته شده")
                {
                    txtIsbnAdd.Text = string.Empty;
                    txtIsbnAdd.ForeColor = Color.Black;
                }
            }
        }

        private void txtIsbnAdd_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtIsbnAdd.Text == "شابک کتاب امانت گرفته شده")
            {
                txtIsbnAdd.Text = string.Empty;
                txtIsbnAdd.ForeColor = Color.Black;
            }
        }

        private void txtIsbnAdd_MouseLeave(object sender, EventArgs e)
        {
            if (txtIsbnAdd.Text == "")
            {
                txtIsbnAdd.ForeColor = Color.DarkGray;
                txtIsbnAdd.Text = "شابک کتاب امانت گرفته شده";
            }
        }

        private void txtIsbnAdd_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
            if (txtIsbnAdd.Text == "")
            {
                txtIsbnAdd.ForeColor = Color.DarkGray;
                txtIsbnAdd.Text = "شابک کتاب امانت گرفته شده";
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text == "نام کتاب به امانت گرفته شده")
            {
                txtSearch.Text = string.Empty;
                txtSearch.ForeColor = Color.Black;
            }
            if (e.KeyCode == Keys.Enter && lstBailmentUser.SelectedIndex >= 0) btnSearch_Click(sender, e);
        }

        private void txtSearchDel_MouseLeave(object sender, EventArgs e)
        {
            if (txtSearchDel.Text == "")
            {
                txtSearchDel.ForeColor = Color.DarkGray;
                txtSearchDel.Text = "نام کتاب به امانت گرفته شده";
            }
        }
        public void FindAllOfMyString3(string searchString)
        {
            // Set the SelectionMode property of the ListBox to select multiple items.
            lstSearchDel.SelectionMode = SelectionMode.One;

            // Set our intial index variable to -1.
            int x = -1;
            // If the search string is empty exit.
            if (searchString.Length != 0)
            {
                // Loop through and find each item that matches the search string.
                do
                {
                    // Retrieve the item based on the previous index found. Starts with -1 which searches start.
                    x = lstSearchDel.FindString(searchString, x);
                    // If no item is found that matches exit.
                    if (x != -1)
                    {
                        // Since the FindString loops infinitely, determine if we found first item again and exit.
                        if (lstSearchDel.SelectedIndices.Count > 0)
                        {
                            if (x == lstSearchDel.SelectedIndices[0]) return;
                        }
                        // Select the item in the ListBox once it is found.
                        if (lstSearchDel.Items.Count > x + 7)
                        {
                            lstSearchDel.SetSelected(x + 7, true);
                            lstSearchDel.ClearSelected();
                        }
                        else
                        {
                            lstSearchDel.SetSelected(lstSearchDel.Items.Count - 1, true);
                            lstSearchDel.ClearSelected();
                        }
                        lstSearchDel.ClearSelected();
                        lstSearchDel.SetSelected(x, true);
                        break;
                    }
                    // If no item is found that matches Clear SelectedItem.
                    else lstSearchDel.ClearSelected();

                } while (x != -1);
            }
        }
        private void txtSearchDel_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
            if (txtSearchDel.Text == "")
            {
                txtSearchDel.ForeColor = Color.DarkGray;
                txtSearchDel.Text = "نام کتاب به امانت گرفته شده";
                lstSearchDel.ClearSelected();
                if (lstSearchDel.Items.Count != 0) lstSearchDel.SetSelected(0, true);
            }
            else if (txtSearchDel.Text != "") FindAllOfMyString3(txtSearchDel.Text);
        }

        private void txtSearchDel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lstSearchDel.SelectedIndex >= 0) btnSearchDel_Click(sender, e);
            if (txtSearchDel.Text == "نام کتاب به امانت گرفته شده")
            {
                txtSearchDel.Text = String.Empty;
                txtSearchDel.ForeColor = Color.Black;
            }
        }

        private void txtSearchDel_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtSearchDel.Text == "نام کتاب به امانت گرفته شده")
            {
                txtSearchDel.Text = String.Empty;
                txtSearchDel.ForeColor = Color.Black;
            }
        }

        private void lstBailmentUser_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstBailmentUser.SelectedIndex >= 0)
            {
                txtSearch.Text = lstBailmentUser.SelectedItem.ToString();
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void lstBailmentUser_KeyUp(object sender, KeyEventArgs e)
        {
            if (lstBailmentUser.SelectedIndex >= 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Down:
                        {
                            txtSearch.Text = lstBailmentUser.SelectedItem.ToString();
                            txtSearch.ForeColor = Color.Black;
                        }
                        break;
                    case Keys.Up:
                        {
                            txtSearch.Text = lstBailmentUser.SelectedItem.ToString();
                            txtSearch.ForeColor = Color.Black;
                        }
                        break;
                    case Keys.Left:
                        {
                            txtSearch.Text = lstBailmentUser.SelectedItem.ToString();
                            txtSearch.ForeColor = Color.Black;
                        }
                        break;
                    case Keys.Right:
                        {
                            txtSearch.Text = lstBailmentUser.SelectedItem.ToString();
                            txtSearch.ForeColor = Color.Black;
                        }
                        break;
                }
            }
        }
        public void FindAllOfMyString1(string searchString)
        {
            // Set the SelectionMode property of the ListBox to select multiple items.
            lstBailmentUser.SelectionMode = SelectionMode.One;

            // Set our intial index variable to -1.
            int x = -1;
            // If the search string is empty exit.
            if (searchString.Length != 0)
            {
                // Loop through and find each item that matches the search string.
                do
                {
                    // Retrieve the item based on the previous index found. Starts with -1 which searches start.
                    x = lstBailmentUser.FindString(searchString, x);
                    // If no item is found that matches exit.
                    if (x != -1)
                    {
                        // Since the FindString loops infinitely, determine if we found first item again and exit.
                        if (lstBailmentUser.SelectedIndices.Count > 0)
                        {
                            if (x == lstBailmentUser.SelectedIndices[0]) return;
                        }
                        // Select the item in the ListBox once it is found.
                        if (lstBailmentUser.Items.Count > x + 7)
                        {
                            lstBailmentUser.SetSelected(x + 7, true);
                            lstBailmentUser.ClearSelected();
                        }
                        else
                        {
                            lstBailmentUser.SetSelected(lstBailmentUser.Items.Count - 1, true);
                            lstBailmentUser.ClearSelected();
                        }
                        lstBailmentUser.ClearSelected();
                        lstBailmentUser.SetSelected(x, true);
                        break;
                    }
                    // If no item is found that matches Clear SelectedItem.
                    else lstBailmentUser.ClearSelected();

                } while (x != -1);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (lstBailmentUser.SelectedIndex >= 0)
            {
                string bufferName = lstBailmentUser.SelectedItem.ToString();
                foreach (BookBailment Read in Form1.arrBookBailment.Values)
                {
                    if (string.Compare(bufferName, Read.BookName, true) == 0)
                    {
                        txtUserName.Text = Read.BailmentName;
                        txtBookName.Text = Read.BookName;
                        txtDateOfBailment.Text = Read.DateOfBailment;
                        txtIsbn.Text = Read.BailmentBookIsbn;
                        break;
                    }
                }
            }
        }

        private void btnSearchAdd_Click(object sender, EventArgs e)
        {
            chbBookName.Checked = false;
            chbUserName.Checked = false;
            chbIsbn.Checked = false;
            btnOK.Enabled = false;
            if (txtUserNameAdd.Text == "نام امانت گیرنده" || txtBookNameAdd.Text == "نام کتاب امانت گرفته شده"
                || txtIsbnAdd.Text == "شابک کتاب امانت گرفته شده")
            {
                MessageBox.Show("Please Fill the All Textbox", "TextBox Empty Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                StatusText = "TextBox Empty Error";
                txtUserNameAdd.Focus();
                return;
            }
            else
            {
                foreach (BookBailment user in Form1.arrBookBailment.Values)
                {
                    if (string.Compare(user.BailmentName, txtUserNameAdd.Text) == 0)
                    {
                        chbUserName.Checked = true;
                        break;
                    }
                }
                if (Form1.arrBookInfo.Contains(txtIsbnAdd.Text) == true)
                {
                    chbIsbn.Checked = true;
                    // copy arrBookInfo[txtIsbn.text(KeyObject)].Valus in other one Hashtable(read)
                    Hashtable read = new Hashtable();
                    read.Add(txtIsbnAdd.Text, Form1.arrBookInfo[txtIsbnAdd.Text]);
                    foreach (BookInfo readInfo in read.Values)
                    {
                        // Add Character Space to Book Name For Match Search
                        while (txtBookNameAdd.Text.Length < readInfo.BookName.Length)
                        {
                            txtBookNameAdd.Text += " ";
                        }
                        if (string.Compare(txtBookNameAdd.Text, readInfo.BookName, true) == 0)
                        {
                            if (readInfo.Bailment == "true")
                            {
                                MessageBox.Show("Sorry! This Book Already was in Bailment!", "Old Bailment"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                StatusText = "The Book was in Bailment List";
                                txtBookNameAdd.Focus();
                                return;
                            }
                            chbBookName.Checked = true;
                            btnOK.Enabled = true;
                            StatusText = "OK... All Filling is True Entered";
                            btnOK.Focus();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Book ISBN is not Match by your Book Name!", "No Matching Error"
                                , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtBookNameAdd.Focus();
                            StatusText = "No Matching Error";
                            return;
                        }
                    }
                }
                else if (Form1.arrBookInfo.Contains(txtIsbn.Text) == false)
                {
                    MessageBox.Show("The Book by this ISBN is not exist in Library", "Not Found Error");
                    txtUserNameAdd.Focus();
                    StatusText = "Not Found any Book for you in Library";
                    return;
                }
            }
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
        private void ClearText()
        {
            txtUserNameAdd.Text = "نام امانت گیرنده";
            txtUserNameAdd.ForeColor = Color.DarkGray;
            txtBookNameAdd.Text = "نام کتاب امانت گرفته شده";
            txtBookNameAdd.ForeColor = Color.DarkGray;
            txtIsbnAdd.Text = "شابک کتاب امانت گرفته شده";
            txtIsbnAdd.ForeColor = Color.DarkGray;
            // Set Date to todey...................................
            DateTimePicker Todey = new DateTimePicker();
            datePickerBBailment.Value = Todey.Value;
            //.....................................................
            txtSearch.Text = "نام کتاب به امانت گرفته شده";
            txtSearch.ForeColor = Color.DarkGray;
            txtUserName.Text = "نام امانت گیرنده";
            txtBookName.Text = "نام کتاب امانت گرفته شده";
            txtIsbn.Text = "شابک کتاب امانت گرفته شده";
            txtDateOfBailment.Text = "تاریخ امانت گیری";
            txtSearchDel.Text = "نام کتاب به امانت گرفته شده";
            txtSearchDel.ForeColor = Color.DarkGray;
            txtUserDel.Text = "نام امانت گیرنده";
            txtBookNameDel.Text = "نام کتاب امانت گرفته شده";
            txtIsbnDel.Text = "شابک کتاب امانت گرفته شده";
            txtDateOfBailmentDel.Text = "تاریخ امانت گیری";
            chbUserName.Checked = false;
            chbBookName.Checked = false;
            chbIsbn.Checked = false;
            btnDelete.Enabled = false;
            btnOK.Enabled = false;
            StatusText = "All Text box cleared!";
            txtUserNameAdd.Focus();
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

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void tbrClear_Click(object sender, EventArgs e)
        {
            ClearText();
        }
        public void UppercaseText()
        {
            // Make the text Uppercase
            string BookNameAddChangedISBN = txtIsbnAdd.Text;
            txtUserNameAdd.Text = txtUserNameAdd.Text.ToUpper();
            txtBookNameAdd.Text = txtBookNameAdd.Text.ToUpper();
            txtSearch.Text = txtSearch.Text.ToUpper();
            txtUserName.Text = txtUserName.Text.ToUpper();
            txtBookName.Text = txtBookName.Text.ToUpper();
            txtDateOfBailment.Text = txtDateOfBailment.Text.ToUpper();
            txtSearchDel.Text = txtSearchDel.Text.ToUpper();
            txtUserDel.Text = txtUserDel.Text.ToUpper();
            txtBookNameDel.Text = txtBookNameDel.Text.ToUpper();
            txtDateOfBailmentDel.Text = txtDateOfBailmentDel.Text.ToUpper();
            txtIsbnAdd.Text = BookNameAddChangedISBN;
            txtIsbnAdd.ForeColor = Color.Black;
            // Update the status bar text
            StatusText = "The text is all UpperCase";
        }
        public void LowercaseText()
        {
            // Make the text Lowercase
            string BookNameAddChangedISBN = txtIsbnAdd.Text;
            txtUserNameAdd.Text = txtUserNameAdd.Text.ToLower();
            txtBookNameAdd.Text = txtBookNameAdd.Text.ToLower();
            txtSearch.Text = txtSearch.Text.ToLower();
            txtUserName.Text = txtUserName.Text.ToLower();
            txtBookName.Text = txtBookName.Text.ToLower();
            txtDateOfBailment.Text = txtDateOfBailment.Text.ToLower();
            txtSearchDel.Text = txtSearchDel.Text.ToLower();
            txtUserDel.Text = txtUserDel.Text.ToLower();
            txtBookNameDel.Text = txtBookNameDel.Text.ToLower();
            txtDateOfBailmentDel.Text = txtDateOfBailmentDel.Text.ToLower();
            txtIsbnAdd.Text = BookNameAddChangedISBN;
            txtIsbnAdd.ForeColor = Color.Black;
            // Update the status bar text
            StatusText = "The text is all LowerCase";
        }

        private void tbrLowerCase_Click(object sender, EventArgs e)
        {
            LowercaseText();
        }

        private void tbrUpperCase_Click(object sender, EventArgs e)
        {
            UppercaseText();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void txtIsbn_TextChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void txtDateOfBailment_TextChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void txtUserNameAdd_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = false;
            StatusText = "Ready";
        }

        private void txtBookNameAdd_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = false;
            StatusText = "Ready";
            txtIsbnAdd.ForeColor = Color.DarkGray;
            txtIsbnAdd.Text = "شابک کتاب امانت گرفته شده";
        }

        public string UndoISBN = "شابک کتاب امانت گرفته شده";
        private void txtIsbnAdd_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = false;
            StatusText = "Ready";
            bool Corrent = true;
            if (txtIsbnAdd.Text != "شابک کتاب امانت گرفته شده" && txtIsbnAdd.Text != "")
            {
                char[] Spil = txtIsbnAdd.Text.ToCharArray();
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
                        txtIsbnAdd.Text = UndoISBN;
                        break;
                    }
                }
            }
            if (Corrent == true) UndoISBN = txtIsbnAdd.Text;
            else return;
        }

        private void datePickerBBailment_ValueChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void txtUserDel_TextChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void txtBookNameDel_TextChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void txtIsbnDel_TextChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void txtDateOfBailmentDel_TextChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void txtSearchDel_TextChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void tbrHelpAbout_Click(object sender, EventArgs e)
        {
            FormAbout About = new FormAbout();
            About.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout About = new FormAbout();
            About.ShowDialog();
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

        private void BailmentDStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBailmentC BailmentC = new FormBailmentC();
            BailmentC.ShowDialog();
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdd Add = new FormAdd();
            Add.ShowDialog();
        }

        private void DelBStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDelete Delete = new FormDelete();
            Delete.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnSaveDel_Click(object sender, EventArgs e)
        {
            SaveBook();
        }

        private void btnSaveAdd_Click(object sender, EventArgs e)
        {
            SaveBook();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveBook();
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
            if (objTextBox.Text == "نام امانت گیرنده" || objTextBox.Text == "نام کتاب امانت گرفته شده" ||
                objTextBox.Text == "شابک کتاب امانت گرفته شده")
            {
                objTextBox.Text = string.Empty;
                objTextBox.ForeColor = Color.Black;
            }
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

        private void btnSearch_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnSave_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnRefresh_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnBailmentCD_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void tabPageDisplay_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnSearchAdd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnOK_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnSaveAdd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnRefreshAdd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnBailmentCDAdd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void tabPageAdd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void chbUserName_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void chbBookName_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void chbIsbn_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void datePickerBBailment_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnBailmentCDDel_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnRefreshDel_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnSaveDel_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void btnSearchDel_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void txtSearchDel_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtSearchDel_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtSearchDel == ActiveControl) ToggleMenus();
        }
        private void lstSearchDel_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void lstBailmentUser_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }
        private void txtUserDel_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtUserDel == ActiveControl) ToggleMenus();
        }

        private void txtUserDel_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtBookNameDel_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtBookNameDel_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtBookNameDel == ActiveControl) ToggleMenus();
        }

        private void txtIsbnDel_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtIsbnDel_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtIsbnDel == ActiveControl) ToggleMenus();
        }

        private void txtDateOfBailmentDel_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtDateOfBailmentDel_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtDateOfBailmentDel == ActiveControl) ToggleMenus();
        }
        private void txtUserNameAdd_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtUserNameAdd_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtUserNameAdd == ActiveControl) ToggleMenus();
        }

        private void txtBookNameAdd_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }
        private void txtBookNameAdd_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtBookNameAdd == ActiveControl) ToggleMenus();
        }

        private void txtIsbnAdd_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtIsbnAdd_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtIsbnAdd == ActiveControl) ToggleMenus();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }
        private void txtSearch_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtSearch == ActiveControl) ToggleMenus();
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtUserName_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtUserName == ActiveControl) ToggleMenus();
        }

        private void txtBookName_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }
        private void txtBookName_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtBookName == ActiveControl) ToggleMenus();
        }

        private void txtIsbn_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtIsbn_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtIsbn == ActiveControl) ToggleMenus();
        }

        private void txtDateOfBailment_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtDateOfBailment_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtDateOfBailment == ActiveControl) ToggleMenus();
        }

        private void statusStrip1_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void txtUserName_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtBookName_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtIsbn_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtDateOfBailment_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtUserDel_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtBookNameDel_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtIsbnDel_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtDateOfBailmentDel_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lstBailmentUser.Items.Clear();
            lstSearchDel.Items.Clear();
            foreach (BookBailment user in Form1.arrBookBailment.Values)
            {
                lstBailmentUser.Items.Add(user.BookName);
                lstSearchDel.Items.Add(user.BookName);
            }
            StatusText = "Refresh Book Database";
        }

        private void btnRefreshDel_Click(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }

        private void btnRefreshAdd_Click(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }

        private void btnBailmentCD_Click(object sender, EventArgs e)
        {
            FormBailmentCDisplay CDisplay = new FormBailmentCDisplay();
            CDisplay.ShowDialog();
        }

        private void btnBailmentCDAdd_Click(object sender, EventArgs e)
        {
            FormBailmentCAdd CAdd = new FormBailmentCAdd();
            CAdd.ShowDialog();
        }

        private void btnBailmentCDDel_Click(object sender, EventArgs e)
        {
            FormBailmentCDelete CDelete = new FormBailmentCDelete();
            CDelete.ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            BookBailment write = new BookBailment();
            write.BailmentName = txtUserNameAdd.Text;
            write.BookName = txtBookNameAdd.Text;
            write.BailmentBookIsbn = txtIsbnAdd.Text;
            write.DateOfBailment = datePickerBBailment.Value.ToLongDateString();
            // Change BookInfo Bailment of "False" to "True" by copy **********************
            Hashtable read = new Hashtable();
            read.Add(txtIsbnAdd.Text, Form1.arrBookInfo[txtIsbnAdd.Text]);
            Form1.arrBookInfo.Remove(txtIsbnAdd.Text);
            BookInfo BailmentChange = new BookInfo();
            foreach (BookInfo rr in read.Values)
            {
                BailmentChange = rr;
            }
            BailmentChange.Bailment = "true";
            Form1.arrBookInfo.Add(txtIsbnAdd.Text, BailmentChange);
            // ****************************************************************************
            Form1.arrBookBailment.Add(write.BailmentBookIsbn, write);
            txtSearchDel.AutoCompleteCustomSource.Add(write.BookName);
            txtSearch.AutoCompleteCustomSource.Add(write.BookName);
            txtBookNameAdd.AutoCompleteCustomSource.Remove(txtBookNameAdd.Text);
            ClearText();
            txtUserNameAdd.Focus();
            StatusText = "New Bailment Book Added in List Bailment";
            chbUserName.Checked = false;
            chbBookName.Checked = false;
            chbIsbn.Checked = false;
            Form1.SavedBookInfo = false;
        }
        private bool nonNumberEntered = false;

        private void txtIsbnAdd_KeyPress(object sender, KeyPressEventArgs e)
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
                if (txtIsbnAdd.Text == "شابک کتاب امانت گرفته شده")
                {
                    txtIsbnAdd.Text = string.Empty;
                    txtIsbnAdd.ForeColor = Color.Black;
                }
            }
        }

        private void lstBailmentUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (lstBailmentUser.SelectedIndex >= 0 && e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, e);
        }

        private void lstSearchDel_KeyDown(object sender, KeyEventArgs e)
        {
            if (lstSearchDel.SelectedIndex >= 0 && e.KeyCode == Keys.Enter)
                btnSearchDel_Click(sender, e);
        }

        private void lstSearchDel_KeyUp(object sender, KeyEventArgs e)
        {
            if (lstSearchDel.SelectedIndex >= 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Down:
                        {
                            txtSearchDel.Text = lstSearchDel.SelectedItem.ToString();
                            txtSearchDel.ForeColor = Color.Black;
                        }
                        break;
                    case Keys.Up:
                        {
                            txtSearchDel.Text = lstSearchDel.SelectedItem.ToString();
                            txtSearchDel.ForeColor = Color.Black;
                        }
                        break;
                    case Keys.Left:
                        {
                            txtSearchDel.Text = lstSearchDel.SelectedItem.ToString();
                            txtSearchDel.ForeColor = Color.Black;
                        }
                        break;
                    case Keys.Right:
                        {
                            txtSearchDel.Text = lstSearchDel.SelectedItem.ToString();
                            txtSearchDel.ForeColor = Color.Black;
                        }
                        break;
                }
            }
        }

        private void lstSearchDel_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstSearchDel.SelectedIndex >= 0)
            {
                txtSearchDel.Text = lstSearchDel.SelectedItem.ToString();
                txtSearchDel.ForeColor = Color.Black;
            }
        }

        private void btnSearchDel_Click(object sender, EventArgs e)
        {
            if (lstSearchDel.SelectedIndex >= 0)
            {
                string bufferName = lstSearchDel.SelectedItem.ToString();
                foreach (BookBailment Read in Form1.arrBookBailment.Values)
                {
                    if (string.Compare(bufferName, Read.BookName, true) == 0)
                    {
                        txtUserDel.Text = Read.BailmentName;
                        txtBookNameDel.Text = Read.BookName;
                        txtIsbnDel.Text = Read.BailmentBookIsbn;
                        txtDateOfBailmentDel.Text = Read.DateOfBailment;
                        btnDelete.Enabled = true;
                        btnDelete.Focus();
                        break;
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Form1.SavedBookInfo = false;
            // ReWrite Bailment Book in arrBookInfo ......................................
            Hashtable ReWrite = new Hashtable();
            ReWrite.Add(txtIsbnDel, Form1.arrBookInfo[txtIsbnDel.Text]);
            Form1.arrBookInfo.Remove(txtIsbnDel.Text);
            BookInfo BailmentChange = new BookInfo();
            foreach (BookInfo Rew in ReWrite.Values)
            {
                BailmentChange = Rew;
            }
            BailmentChange.Bailment = "false";
            Form1.arrBookInfo.Add(txtIsbnDel.Text, BailmentChange);
            //............................................................................
            Form1.arrBookBailment.Remove(txtIsbnDel.Text);
            txtSearch.AutoCompleteCustomSource.Remove(BailmentChange.BookName);
            txtSearchDel.AutoCompleteCustomSource.Remove(BailmentChange.BookName);
            txtBookNameAdd.AutoCompleteCustomSource.Add(BailmentChange.BookName);
            ClearText();
            btnRefresh_Click(sender, e);
            StatusText = "The Bailment Book Successful Removed of Bailment List...";
            txtSearchDel.Focus();
        }

        private void datePickerBBailment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSearchAdd_Click(sender, e);
        }

    }
}
