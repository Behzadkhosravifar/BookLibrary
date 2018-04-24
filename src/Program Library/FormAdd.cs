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
    public partial class FormAdd : Form
    {
        public FormAdd()
        {
            InitializeComponent();
            this.InputLanguageChanged += new InputLanguageChangedEventHandler(languageChange);
        }
        private void languageChange(Object sender, InputLanguageChangedEventArgs e)
        {
            // If the input language is Farsi.
            // set the initial IMEMode to Katakana.
            // Show MessageBox ....
            if (e.InputLanguage.Culture.TwoLetterISOLanguageName.Equals("fa"))
            {
                MessageBox.Show("Please Change Language to English for Better Performance!" +
                    "\nلطفاً برای کارایی بهتر برنامه زبان سیستم را به انگلیسی برگردانید", "Language Changed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void FormAdd_Load(object sender, EventArgs e)
        {
            picNO.Visible = false;
            picOK.Visible = false;
            txtBookName.Select();
            foreach (BookInfo Read in Form1.arrBookInfo.Values)
            {
                txtPropagator.AutoCompleteCustomSource.Add(Read.Propagator);
                txtWriterName.AutoCompleteCustomSource.Add(Read.WriterName);
                txtTranslator.AutoCompleteCustomSource.Add(Read.Translator);
            }
        }

        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;
        // Handle the KeyDown event to determine the type of character entered into the control.
        private void txtNumberPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift == true && txtNumberPage.Text == "تعداد صفحات")
            {
                txtNumberPage.Text = string.Empty;
                txtNumberPage.ForeColor = Color.Black;
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
                if (txtNumberPage.Text == "تعداد صفحات")
                {
                    txtNumberPage.Text = string.Empty;
                    txtNumberPage.ForeColor = Color.Black;
                }
            }
        }
        // This event occurs after the KeyDown event and can be used to prevent
        // characters from entering the control.
        private void txtNumberPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
            if (nonNumberEntered == false)
            {
                if (txtNumberPage.Text == "تعداد صفحات")
                {
                    txtNumberPage.Text = string.Empty;
                    txtNumberPage.ForeColor = Color.Black;
                }
            }
        }
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
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Subtract && e.KeyCode != Keys.OemMinus && e.KeyCode != Keys.X)
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
            }
        }

        private void txtBookName_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtBookName.Text == "نام کتاب")
            {
                txtBookName.Text = string.Empty;
                txtBookName.ForeColor = Color.Black;
            }
        }

        private void txtBookName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtBookName.Text == "نام کتاب")
            {
                txtBookName.Text = string.Empty;
                txtBookName.ForeColor = Color.Black;
            }
        }

        private void txtWriterName_MouseLeave(object sender, EventArgs e)
        {
            if (txtWriterName.Text == "")
            {
                txtWriterName.ForeColor = Color.DimGray;
                txtWriterName.Text = "نام نویسنده کتاب";
            }
        }

        private void txtWriterName_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
            if (txtWriterName.Text == "")
            {
                txtWriterName.ForeColor = Color.DimGray;
                txtWriterName.Text = "نام نویسنده کتاب";
            }
        }

        private void txtWriterName_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtWriterName.Text == "نام نویسنده کتاب")
            {
                txtWriterName.Text = string.Empty;
                txtWriterName.ForeColor = Color.Black;
            }
        }

        private void txtWriterName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtWriterName.Text == "نام نویسنده کتاب")
            {
                txtWriterName.Text = string.Empty;
                txtWriterName.ForeColor = Color.Black;
            }
        }

        private void txtTranslator_MouseLeave(object sender, EventArgs e)
        {
            if (txtTranslator.Text == "")
            {
                txtTranslator.ForeColor = Color.DimGray;
                txtTranslator.Text = "مترجم";
            }
        }

        private void txtTranslator_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
            if (txtTranslator.Text == "")
            {
                txtTranslator.ForeColor = Color.DimGray;
                txtTranslator.Text = "مترجم";
            }
        }

        private void txtTranslator_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtTranslator.Text == "مترجم")
            {
                txtTranslator.Text = string.Empty;
                txtTranslator.ForeColor = Color.Black;
            }
        }

        private void txtTranslator_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtTranslator.Text == "مترجم")
            {
                txtTranslator.Text = string.Empty;
                txtTranslator.ForeColor = Color.Black;
            }
        }

        private void txtPrice_MouseLeave(object sender, EventArgs e)
        {
            if (txtPrice.Text == "")
            {
                txtPrice.ForeColor = Color.DimGray;
                txtPrice.Text = "قیمت کتاب";
            }
        }

        private void txtPrice_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
            if (txtPrice.Text == "")
            {
                txtPrice.ForeColor = Color.DimGray;
                txtPrice.Text = "قیمت کتاب";
            }
        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift == true && txtPrice.Text == "قیمت کتاب")
            {
                txtPrice.Text = string.Empty;
                txtPrice.ForeColor = Color.Black;
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
                if (txtPrice.Text == "قیمت کتاب")
                {
                    txtPrice.Text = string.Empty;
                    txtPrice.ForeColor = Color.Black;
                }
            }
        }
        
        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
            // clear TextBox Fill "قیمت کتاب"
            if (txtPrice.Text == "قیمت کتاب")
            {
                txtPrice.Text = string.Empty;
                txtPrice.ForeColor = Color.Black;
            }
        }

        private void txtPrice_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPrice.Text == "قیمت کتاب")
            {
                txtPrice.Text = string.Empty;
                txtPrice.ForeColor = Color.Black;
            }
        }

        private void txtNumberPage_MouseLeave(object sender, EventArgs e)
        {
            if (txtNumberPage.Text == "")
            {
                txtNumberPage.ForeColor = Color.DimGray;
                txtNumberPage.Text = "تعداد صفحات";
            }
        }

        private void txtNumberPage_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
            if (txtNumberPage.Text == "")
            {
                txtNumberPage.ForeColor = Color.DimGray;
                txtNumberPage.Text = "تعداد صفحات";
            }
        }

        private void txtNumberPage_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtNumberPage.Text == "تعداد صفحات")
            {
                txtNumberPage.Text = string.Empty;
                txtNumberPage.ForeColor = Color.Black;
            }
        }

        private void txtPropagator_MouseLeave(object sender, EventArgs e)
        {
            if (txtPropagator.Text == "")
            {
                txtPropagator.ForeColor = Color.DimGray;
                txtPropagator.Text = "انتشارات";
            }
        }

        private void txtPropagator_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
            if (txtPropagator.Text == "")
            {
                txtPropagator.ForeColor = Color.DimGray;
                txtPropagator.Text = "انتشارات";
            }
        }

        private void txtPropagator_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtPropagator.Text == "انتشارات")
            {
                txtPropagator.Text = string.Empty;
                txtPropagator.ForeColor = Color.Black;
            }
        }

        private void txtPropagator_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPropagator.Text == "انتشارات")
            {
                txtPropagator.Text = string.Empty;
                txtPropagator.ForeColor = Color.Black;
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

        private void txtIsbn_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
            if (txtIsbn.Text == "")
            {
                txtIsbn.ForeColor = Color.DimGray;
                txtIsbn.Text = "شابک";
            }
        }

        private void txtIsbn_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtIsbn.Text == "شابک")
            {
                txtIsbn.Text = string.Empty;
                txtIsbn.ForeColor = Color.Black;
            }
        }

        private void txtDateOfBook_MouseLeave(object sender, EventArgs e)
        {
            if (txtDateOfBook.Text == "")
            {
                txtDateOfBook.ForeColor = Color.DimGray;
                txtDateOfBook.Text = "تاریخ انتشار";
            }
        }

        private void txtDateOfBook_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
            if (txtDateOfBook.Text == "")
            {
                txtDateOfBook.ForeColor = Color.DimGray;
                txtDateOfBook.Text = "تاریخ انتشار";
            }
        }

        private void txtDateOfBook_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtDateOfBook.Text == "تاریخ انتشار")
            {
                txtDateOfBook.Text = string.Empty;
                txtDateOfBook.ForeColor = Color.Black;
            }
        }

        private void txtDateOfBook_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtDateOfBook.Text == "تاریخ انتشار")
            {
                txtDateOfBook.Text = string.Empty;
                txtDateOfBook.ForeColor = Color.Black;
            }
        }

        private void chbCD_CheckedChanged(object sender, EventArgs e)
        {
            if (chbCD.Checked)
            {
                DialogResult result = MessageBox.Show("If your book have CD or DVD please Choose Yes"
                    + "\nSo go to Add New CD - DVD Form and added your Book CD"
                    + "\nElse Choose No and Close Massage and Clear CheckBox"
                    + "\nاگر کتاب شما دارای لوح فشرده می باشد لطفاً کلید تایید را فشار دهید"
                    + "\nتا در فرم ای لوح فشرده مربوطه را ثبت کنید"
                    + "\nدر غیر این صورت کلید انصراف را فشار دهید", "Add New CD - DVD Masseage",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.No)
                    chbCD.Checked = false;
                else if (result == DialogResult.Yes)
                {
                    FormAddC AddC = new FormAddC();
                    AddC.ShowDialog();
                }
            }
            StatusText = "Ready";
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
            txtWriterName.ForeColor = Color.DimGray;
            txtWriterName.Text = "نام نویسنده کتاب";
            txtTranslator.ForeColor = Color.DimGray;
            txtTranslator.Text = "مترجم";
            txtPrice.ForeColor = Color.DimGray;
            txtPrice.Text = "قیمت کتاب";
            comboBoxUnit.Text = "ریال";
            txtPropagator.ForeColor = Color.DimGray;
            txtPropagator.Text = "انتشارات";
            txtIsbn.ForeColor = Color.DimGray;
            txtIsbn.Text = "شابک";
            txtNumberPage.ForeColor = Color.DimGray;
            txtNumberPage.Text = "تعداد صفحات";
            txtDateOfBook.ForeColor = Color.DimGray;
            txtDateOfBook.Text = "تاریخ انتشار";
            chbCD.Checked = false;
            StatusText = "All Text box cleared!";
            txtBookName.Focus();
        }
        private void tbrClear_Click(object sender, EventArgs e)
        {
            ClearText();
        }
        public void UppercaseText()
        {
            // Make the text Uppercase
            txtBookName.Text = txtBookName.Text.ToUpper();
            txtWriterName.Text = txtWriterName.Text.ToUpper();
            txtTranslator.Text = txtTranslator.Text.ToUpper();
            txtPropagator.Text = txtPropagator.Text.ToUpper();
            txtDateOfBook.Text = txtDateOfBook.Text.ToUpper();
            // Update the status bar text
            StatusText = "The text is all UpperCase";
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void btnCleartxt_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void tbrUpperCase_Click(object sender, EventArgs e)
        {
            UppercaseText();
        }
        public void LowercaseText()
        {
            // Make the text Lowercase
            txtBookName.Text = txtBookName.Text.ToLower();
            txtWriterName.Text = txtWriterName.Text.ToLower();
            txtTranslator.Text = txtTranslator.Text.ToLower();
            txtPropagator.Text = txtPropagator.Text.ToLower();
            txtDateOfBook.Text = txtDateOfBook.Text.ToLower();
            // Update the status bar text
            StatusText = "The text is all LowerCase";
        }

        private void tbrLowerCase_Click(object sender, EventArgs e)
        {
            LowercaseText();
        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void txtWriterName_TextChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void txtTranslator_TextChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
            if (txtPrice.Text != "قیمت کتاب" && txtPrice.Text != "")
            {
                char[] Spil = txtPrice.Text.ToCharArray();
                for (int i = 0; i < Spil.Length; i++)
                {
                    if (Spil[i] == '0' || Spil[i] == '1' || Spil[i] == '2' || Spil[i] == '3' || Spil[i] == '4' ||
                        Spil[i] == '5' || Spil[i] == '6' || Spil[i] == '7' || Spil[i] == '8' || Spil[i] == '9')
                        continue;
                    else
                    {
                        MessageBox.Show("Please Enter Just Number. This TextBox don't Accept Other Key!" +
                            "\nلطفاً فقط عدد وارد کنید. این فیلد کلید دیگری را قبول نمی کند ", "Enter InCorrect Key"
                            , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        undoToolStripMenuItem_Click(sender, e);
                        break;
                    }
                }
                return;
            }
        }

        private void comboBoxUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void txtPropagator_TextChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }
        public string UndoISBN = "شابک";
        private void txtIsbn_TextChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
            bool Corrent = true;
            if (txtIsbn.Text == "شابک" || txtIsbn.Text == "")
            {
                picOK.Visible = false;
                picNO.Visible = false;
            }
            else
            {
                if (Form1.arrBookInfo.ContainsKey(txtIsbn.Text) == true)
                {
                    picOK.Visible = false;
                    picNO.Visible = true;
                }
                else
                {
                    picNO.Visible = false;
                    picOK.Visible = true;
                }
            }
            if (txtIsbn.Text != "شابک" && txtIsbn.Text !="")
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

        private void txtNumberPage_TextChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
            if (txtNumberPage.Text != "تعداد صفحات" && txtNumberPage.Text != "")
            {
                char[] Spil = txtNumberPage.Text.ToCharArray();
                for (int i = 0; i < Spil.Length; i++)
                {
                    if (Spil[i] == '0' || Spil[i] == '1' || Spil[i] == '2' || Spil[i] == '3' || Spil[i] == '4' ||
                        Spil[i] == '5' || Spil[i] == '6' || Spil[i] == '7' || Spil[i] == '8' || Spil[i] == '9')
                        continue;
                    else
                    {
                        MessageBox.Show("Please Enter Just Number. This TextBox don't Accept Other Key!" +
                            "\nلطفاً فقط عدد وارد کنید. این فیلد کلید دیگری را قبول نمی کند ", "Enter InCorrect Key"
                            , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        undoToolStripMenuItem_Click(sender, e);
                        break;
                    }
                }
                return;
            }
        }

        private void txtDateOfBook_TextChanged(object sender, EventArgs e)
        {
            StatusText = "Ready";
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

        private void BailmentBStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBailment Bailment = new FormBailment();
            Bailment.ShowDialog();
        }

        private void AddDStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddC AddC = new FormAddC();
            AddC.ShowDialog();
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
            if (comboBoxUnit == ActiveControl)
            {
                txtBookName.Select();
            }
            // Declare a TextBox object and
            // set it to the ActiveControl
            TextBox objTextBox = (TextBox)this.ActiveControl;
            // Undo the last operation
            objTextBox.Undo();
            switch (ActiveControl.Name.ToString())
            {
                case "txtPrice":
                    {
                        if (txtPrice.Text == "")
                        {
                            txtPrice.ForeColor = Color.DimGray;
                            txtPrice.Text = "قیمت کتاب";
                        }
                    }
                    break;
                case "txtNumberPage":
                    {
                        if (txtNumberPage.Text == "")
                        {
                            txtNumberPage.ForeColor = Color.DimGray;
                            txtNumberPage.Text = "تعداد صفحات";
                        }
                    }
                    break;
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBoxUnit == ActiveControl)
            {
                txtBookName.Select();
            }
            // Declare a TextBox object and
            // set it to the ActiveControl
            TextBox objTextBox = (TextBox)this.ActiveControl;
            // Copy the text to the clipboard and clear the field
            objTextBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBoxUnit == ActiveControl)
            {
                txtBookName.Select();
            }
            // Declare a TextBox object and
            // set it to the ActiveControl
            TextBox objTextBox = (TextBox)this.ActiveControl;
            // Copy the text to the clipboard
            objTextBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pasteToolStripButton_Click(sender, e);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBoxUnit == ActiveControl)
            {
                txtBookName.Select();
            } 
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

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            if (comboBoxUnit == ActiveControl)
            {
                txtBookName.Select();
            } 
            // Declare a TextBox object and
            // set it to the ActiveControl
            TextBox objTextBox = (TextBox)this.ActiveControl;
            // Copy the text to the clipboard and clear the field
            objTextBox.Cut();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            if (comboBoxUnit == ActiveControl)
            {
                txtBookName.Select();
            }
            else
            {
                // set it to the ActiveControl
                TextBox objTextBox = (TextBox)this.ActiveControl;
                // Copy the data from the clipboard to the textbox
                switch (ActiveControl.Name.ToString())
                {
                    case "txtIsbn":
                        if (txtIsbn.Text == "" || txtIsbn.Text == "شابک")
                        {
                            txtIsbn.Text = string.Empty;
                            txtIsbn.ForeColor = Color.Black;
                            objTextBox.Paste();
                        }
                        break;
                    case "txtNumberPage":
                        if (txtNumberPage.Text == "" || txtNumberPage.Text == "تعداد صفحات")
                        {
                            txtNumberPage.Text = string.Empty;
                            txtNumberPage.ForeColor = Color.Black;
                            objTextBox.Paste();
                        }
                        break;
                    case "txtPrice":
                        if (txtPrice.Text == "" || txtPrice.Text == "قیمت کتاب")
                        {
                            txtPrice.Text = string.Empty;
                            txtPrice.ForeColor = Color.Black;
                            objTextBox.Paste();
                        }
                        break;
                    case "txtBookName":
                        if (txtBookName.Text == "" || txtBookName.Text == "نام کتاب")
                        {
                            txtBookName.Text = string.Empty;
                            txtBookName.ForeColor = Color.Black;
                            objTextBox.Paste();
                        }
                        break;
                    case "txtWriterName": 
                        if (txtWriterName.Text == "" || txtWriterName.Text == "نام نویسنده کتاب")
                        {
                            txtWriterName.Text = string.Empty;
                            txtWriterName.ForeColor = Color.Black;
                            objTextBox.Paste();
                        }
                        break;
                    case "txtTranslator": 
                        if (txtTranslator.Text == "" || txtTranslator.Text == "مترجم")
                        {
                            txtTranslator.Text = string.Empty;
                            txtTranslator.ForeColor = Color.Black;
                            objTextBox.Paste();
                        }
                        break;
                    case "txtPropagator": 
                        if (txtPropagator.Text == "" || txtPropagator.Text == "انتشارات")
                        {
                            txtPropagator.Text = string.Empty;
                            txtPropagator.ForeColor = Color.Black;
                            objTextBox.Paste();
                        }
                        break;
                    case "txtDateOfBook": 
                        if (txtDateOfBook.Text == "" || txtDateOfBook.Text == "تاریخ انتشار")
                        {
                            txtDateOfBook.Text = string.Empty;
                            txtDateOfBook.ForeColor = Color.Black;
                            objTextBox.Paste();
                        }
                        break;
                    default: return;
                }
            }
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            if (comboBoxUnit == ActiveControl)
            {
                txtBookName.Select();
            }
            // Declare a TextBox object and
            // set it to the ActiveControl
            TextBox objTextBox = (TextBox)this.ActiveControl;
            // Copy the text to the clipboard
            objTextBox.Copy();
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
        private void chbCD_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void txtBookName_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtBookName_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtBookName == ActiveControl) ToggleMenus();
        }

        private void txtWriterName_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtTranslator_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtPrice_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtPropagator_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtIsbn_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtNumberPage_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtDateOfBook_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtWriterName_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtWriterName == ActiveControl) ToggleMenus();
        }

        private void txtTranslator_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtTranslator == ActiveControl) ToggleMenus();
        }

        private void txtPrice_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtPrice == ActiveControl) ToggleMenus();
        }

        private void txtPropagator_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtPropagator == ActiveControl) ToggleMenus();
        }

        private void txtIsbn_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtIsbn == ActiveControl) ToggleMenus();
        }

        private void txtNumberPage_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtNumberPage == ActiveControl) ToggleMenus();
        }

        private void txtDateOfBook_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtDateOfBook == ActiveControl) ToggleMenus();
        }

        private void btnCleartxt_Enter(object sender, EventArgs e)
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

        private void lstAdd_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void menuStrip_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void tspMain_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void statusStrip1_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }
        string price(int p, string unit)  // Convert Price Example ( 1000000 ) To ( 1,000,000 )
        {
            int[] price = new int[10];
            int i, t;
            string Pool;
            for (i = 0; p != 0; i++)
            {
                price[i] = p % 10;
                p = (p / 10);
            }
            Pool = price[i - 1].ToString();
            i--;
            for (t = i % 3; t != 0; t--, i--)
                Pool += price[i - 1].ToString();
            while (i != 0)
            {
                if (i % 3 == 0) Pool += ",";
                Pool += price[i - 1].ToString();
                i--;
            }
            return Pool + "  " + unit;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            Thread.Sleep(100);
            if (txtBookName.Text == "نام کتاب" || txtWriterName.Text == "نام نویسنده کتاب" ||
                txtTranslator.Text == "مترجم" || txtPrice.Text == "قیمت کتاب" ||
                txtPropagator.Text == "انتشارات" || txtIsbn.Text == "شابک" ||
                txtNumberPage.Text == "تعداد صفحات" || txtDateOfBook.Text == "تاریخ انتشار")
            {
                progressBar1.Value = 100;
                MessageBox.Show("Please Fill the All Textbox", "TextBox Empty Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                StatusText = "TextBox Empty Error";
            }
            else
            {
                if (Form1.arrBookInfo.Contains(txtIsbn.Text) == true)
                {
                    MessageBox.Show("This Book Already Exist in library", "Exist Book Warning", MessageBoxButtons.OK
                        , MessageBoxIcon.Warning);
                    ClearText();
                    StatusText = "The Book Already Exist in library!";
                    progressBar1.Visible = false;
                    return;
                }
                Thread.Sleep(60);
                progressBar1.Value = 1;
                BookInfo Fill = new BookInfo();
                Thread.Sleep(60);
                progressBar1.Value = 10;
                // Search Repeat Book Name ---------------------------------------
                string re = txtBookName.Text;
                if (Form1.arrBookInfo.Count != 0)
                {
                    Boolean Find = true;
                    while (Find == true)
                    {
                        foreach (BookInfo Repeat in Form1.arrBookInfo.Values)
                        {
                            if (string.Compare(Repeat.BookName, re, true) == 0)
                            {
                                re += " ";
                                Find = true;
                                break;
                            }
                            else Find = false;
                        }
                    }
                }
                Fill.BookName = re;
                //----------------------------------------------------------------
                Thread.Sleep(50);
                progressBar1.Value = 20;
                // Search Repeat Book Name ---------------------------------------
                string re2 = txtWriterName.Text;
                if (Form1.arrBookInfo.Count != 0)
                {
                    Boolean Find = true;
                    while (Find == true)
                    {
                        foreach (BookInfo Repeat in Form1.arrBookInfo.Values)
                        {
                            if (string.Compare(Repeat.WriterName, re2, true) == 0)
                            {
                                re2 += " ";
                                Find = true;
                                break;
                            }
                            else Find = false;
                        }
                    }
                }
                Fill.WriterName = re2;
                //----------------------------------------------------------------
                Thread.Sleep(50);
                progressBar1.Value = 30;
                Fill.Translator = txtTranslator.Text;
                progressBar1.Value = 40;
                // Convert Price (Exmple : 0001234 --> 1,234)
                int p = int.Parse(txtPrice.Text);
                if (p != 0) Fill.Price = price(p, comboBoxUnit.Text);
                else Fill.Price = "0  " + comboBoxUnit.Text;
                Thread.Sleep(60);
                progressBar1.Value = 55;
                Fill.Propagator = txtPropagator.Text;
                progressBar1.Value = 60;
                Thread.Sleep(60);
                Fill.Isbn = txtIsbn.Text;
                progressBar1.Value = 65;
                // Conver Number Page (Exmple : 00123  -->  123)
                int number = int.Parse(txtNumberPage.Text);
                Fill.NumberPage = number.ToString();
                progressBar1.Value = 70;
                Fill.DateOfBook = txtDateOfBook.Text;
                Thread.Sleep(60);
                progressBar1.Value = 75;
                Fill.Bailment = "false";
                Thread.Sleep(60);
                progressBar1.Value = 80;
                if (chbCD.Checked == true) Fill.HaveCd = "true";
                else if (chbCD.Checked == false) Fill.HaveCd = "false";
                // Display in ListBox
                Thread.Sleep(60);
                progressBar1.Value = 85;
                lstAdd.Items.Add(Fill);
                Thread.Sleep(60);
                progressBar1.Value = 90;
                Form1.SavedBookInfo = false;
                Thread.Sleep(60);
                progressBar1.Value = 95;
                Fill.Bailment = "false";
                Form1.arrBookInfo.Add(Fill.Isbn, Fill);
                txtPropagator.AutoCompleteCustomSource.Add(txtPropagator.Text);
                txtWriterName.AutoCompleteCustomSource.Add(txtWriterName.Text);
                txtTranslator.AutoCompleteCustomSource.Add(txtTranslator.Text);
                ClearText();
                Thread.Sleep(100);
                progressBar1.Value = 100;
                StatusText = "The new book added to Library";
            }
            Thread.Sleep(100);
            progressBar1.Visible = false;
        }

        private void comboBoxUnit_KeyUp(object sender, KeyEventArgs e)
        {
            if (comboBoxUnit.Text != "")
            {
                int index = comboBoxUnit.FindString(comboBoxUnit.Text);
                comboBoxUnit.SelectedIndex = index;
            }
        }
    }
}
