using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Drawing.Printing;

namespace Program_Library
{
    public partial class FormDisplay : Form
    {
        public FormDisplay()
        {
            InitializeComponent();
        }
        public void LoadBook()
        {
            // Load BookInfo
            string[] LbName, LbWriter, LbPrice, LbPropagator, LbIsbn, LbNumberPage, LbDate,
                LbTranslator, LbHaveCd, LbB; // LbB ==> Load book Bailment
            LbName = System.IO.File.ReadAllLines((Form1.patchBook + @"\BehzadBName.sys"));
            LbWriter = System.IO.File.ReadAllLines((Form1.patchBook + @"\BehzadBWriter.sys"));
            LbPrice = System.IO.File.ReadAllLines((Form1.patchBook + @"\BehzadBPrice.sys"));
            LbPropagator = System.IO.File.ReadAllLines((Form1.patchBook + @"\BehzadBPropagator.sys"));
            LbIsbn = System.IO.File.ReadAllLines((Form1.patchBook + @"\BehzadBIsbn.sys"));
            LbNumberPage = System.IO.File.ReadAllLines((Form1.patchBook + @"\BehzadBNumberPage.sys"));
            LbDate = System.IO.File.ReadAllLines((Form1.patchBook + @"\BehzadBDate.sys"));
            LbTranslator = System.IO.File.ReadAllLines((Form1.patchBook + @"\BehzadBTranslator.sys"));
            LbHaveCd = System.IO.File.ReadAllLines((Form1.patchBook + @"\BehzadBHaveCd.sys"));
            LbB = System.IO.File.ReadAllLines((Form1.patchBook + @"\BehzadBookBailment.sys"));
            long i = LbName.LongCount() - 1;
            for (; i >= 0; i--)
            {
                BookInfo Copy = new BookInfo();
                Copy.BookName = LbName[i];
                Copy.WriterName = LbWriter[i];
                Copy.Price = LbPrice[i];
                Copy.Propagator = LbPropagator[i];
                Copy.Isbn = LbIsbn[i];
                Copy.NumberPage = LbNumberPage[i];
                Copy.DateOfBook = LbDate[i];
                Copy.Translator = LbTranslator[i];
                Copy.HaveCd = LbHaveCd[i];
                Copy.Bailment = LbB[i];
                Form1.arrBookInfo.Add(Copy.Isbn, Copy);
            }
            // Show In ListBox
            lstBookInfo.Items.Clear();
            foreach (BookInfo name in Form1.arrBookInfo.Values)
            {
                lstBookInfo.Items.Add(name);
            }
            //
            // Load Book Bailment
            string[] LbBName, LbBDate, LbBBookName, LbBIsbn; // LbBIsbn ==> Load book Bailment ISBN
            LbBName = System.IO.File.ReadAllLines((Form1.patchBook + @"\BehzadBBName.sys"));
            LbBDate = System.IO.File.ReadAllLines((Form1.patchBook + @"\BehzadBBDate.sys"));
            LbBBookName = System.IO.File.ReadAllLines((Form1.patchBook + @"\BehzadBBBookName.sys"));
            LbBIsbn = System.IO.File.ReadAllLines((Form1.patchBook + @"\BehzadBBIsbn.sys"));
            i = LbBName.LongCount() - 1;
            for (; i >= 0; i--)
            {
                BookBailment Copy = new BookBailment();
                Copy.BailmentName = LbBName[i];
                Copy.BookName = LbBBookName[i];
                Copy.DateOfBailment = LbBDate[i];
                Copy.BailmentBookIsbn = LbBIsbn[i];
                Form1.arrBookBailment.Add(Copy.BailmentBookIsbn, Copy);
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
                }
            }
            else
            {
                Form1.SaveBookInfo();
                Form1.SaveBookBailment();
                Form1.SavedBookInfo = true;
            }
        }
        public void OpenBook()
        {
            if (Form1.SavedBookInfo == false)  // If User Click On Open button and the changed Data Did Not Saved In Hard!
            {
                DialogResult Close = MessageBox.Show("Do you want to save the changes to BOOK Database ?", "Program Library",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (Close == DialogResult.No)
                {
                    Form1.SavedBookInfo = true;
                    FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                    // Set the FolderBrowserDialog control properties
                    folderBrowserDialog1.Description = "Select your folder for Open Books Database:";
                    folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
                    folderBrowserDialog1.ShowNewFolderButton = false;
                    // Show the Browse For Folder dialog
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string p = folderBrowserDialog1.SelectedPath;
                        if (!File.Exists(p + @"\BehzadBName.sys") ||
                            !File.Exists(p + @"\BehzadBWriter.sys") || !File.Exists(p + @"\BehzadBPrice.sys")
                            || !File.Exists(p + @"\BehzadBPropagator.sys") || !File.Exists(p + @"\BehzadBIsbn.sys")
                            || !File.Exists(p + @"\BehzadBNumberPage.sys") || !File.Exists(p + @"\BehzadBDate.sys")
                            || !File.Exists(p + @"\BehzadBTranslator.sys") || !File.Exists(p + @"\BehzadBHaveCd.sys")
                            || !File.Exists(p + @"\BehzadBookBailment.sys") || !File.Exists(p + @"\BehzadBBName.sys")
                            || !File.Exists(p + @"\BehzadBBDate.sys") || !File.Exists(p + @"\BehzadBBBookName.sys")
                            || !File.Exists(p + @"\BehzadBBIsbn.sys"))
                        {
                            MessageBox.Show("File Not Found!" + "\nPlease Choose Other Path...", "File not found"
                                , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            OpenBook();
                        }
                        else
                        {
                            Form1.patchBook = folderBrowserDialog1.SelectedPath;
                            System.IO.File.WriteAllText(@"Program library DB\PatchB.dll", Form1.patchBook);
                            Form1.arrBookInfo.Clear();
                            Form1.arrBookBailment.Clear();
                            LoadBook();
                            Form1.SavedNewB = true;
                        }
                    }
                }
                else if (Close == DialogResult.Yes)
                {
                    SaveBook();
                    FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                    // Set the FolderBrowserDialog control properties
                    folderBrowserDialog1.Description = "Select your folder for Open Books Database:";
                    folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
                    folderBrowserDialog1.ShowNewFolderButton = false;
                    // Show the Browse For Folder dialog
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string p = folderBrowserDialog1.SelectedPath;
                        if (!File.Exists(p + @"\BehzadBName.sys") ||
                            !File.Exists(p + @"\BehzadBWriter.sys") || !File.Exists(p + @"\BehzadBPrice.sys")
                            || !File.Exists(p + @"\BehzadBPropagator.sys") || !File.Exists(p + @"\BehzadBIsbn.sys")
                            || !File.Exists(p + @"\BehzadBNumberPage.sys") || !File.Exists(p + @"\BehzadBDate.sys")
                            || !File.Exists(p + @"\BehzadBTranslator.sys") || !File.Exists(p + @"\BehzadBHaveCd.sys")
                            || !File.Exists(p + @"\BehzadBookBailment.sys") || !File.Exists(p + @"\BehzadBBName.sys")
                            || !File.Exists(p + @"\BehzadBBDate.sys") || !File.Exists(p + @"\BehzadBBBookName.sys")
                            || !File.Exists(p + @"\BehzadBBIsbn.sys"))
                        {
                            MessageBox.Show("File Not Found!" + "\nPlease Choose Other Path...", "File not found"
                                , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            OpenBook();
                        }
                        else
                        {
                            Form1.patchBook = folderBrowserDialog1.SelectedPath;
                            System.IO.File.WriteAllText(@"Program library DB\PatchB.dll", Form1.patchBook);
                            Form1.arrBookInfo.Clear();
                            Form1.arrBookBailment.Clear();
                            LoadBook();
                            Form1.SavedNewB = true;
                        }
                    }
                }
                else if (Close == DialogResult.Cancel) return;
            }
            else if (Form1.SavedCdInfo == true)
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                // Set the FolderBrowserDialog control properties
                folderBrowserDialog1.Description = "Select your folder for Open Books Database:";
                folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
                folderBrowserDialog1.ShowNewFolderButton = false;
                // Show the Browse For Folder dialog
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    string p = folderBrowserDialog1.SelectedPath;
                    if (!File.Exists(p + @"\BehzadBName.sys") ||
                        !File.Exists(p + @"\BehzadBWriter.sys") || !File.Exists(p + @"\BehzadBPrice.sys")
                        || !File.Exists(p + @"\BehzadBPropagator.sys") || !File.Exists(p + @"\BehzadBIsbn.sys")
                        || !File.Exists(p + @"\BehzadBNumberPage.sys") || !File.Exists(p + @"\BehzadBDate.sys")
                        || !File.Exists(p + @"\BehzadBTranslator.sys") || !File.Exists(p + @"\BehzadBHaveCd.sys")
                        || !File.Exists(p + @"\BehzadBookBailment.sys") || !File.Exists(p + @"\BehzadBBName.sys")
                        || !File.Exists(p + @"\BehzadBBDate.sys") || !File.Exists(p + @"\BehzadBBBookName.sys")
                        || !File.Exists(p + @"\BehzadBBIsbn.sys"))
                    {
                        MessageBox.Show("File Not Found!" + "\nPlease Choose Other Path...", "File not found"
                            , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        OpenBook();
                    }
                    else
                    {
                        Form1.patchBook = folderBrowserDialog1.SelectedPath;
                        System.IO.File.WriteAllText(@"Program library DB\PatchB.dll", Form1.patchBook);
                        Form1.arrBookInfo.Clear();
                        Form1.arrBookBailment.Clear();
                        LoadBook();
                        Form1.SavedNewB = true;
                    }
                }
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenBook();
        }

        private void ChangePassStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChangePass ChangePass = new FormChangePass();
            ChangePass.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveBook();
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdd Add = new FormAdd();
            Add.ShowDialog();
        }

        private void BilmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBailment Bailment = new FormBailment();
            Bailment.ShowDialog();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDelete Delete = new FormDelete();
            Delete.ShowDialog();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Toggle the visibility of the Main toolbar
            // based on this menu item's Checked property
            if (toolStripMenuItem2.Checked)
            {
                toolStrip1.Visible = true;
            }
            else
            {
                toolStrip1.Visible = false;
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

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            FormAbout About = new FormAbout();
            About.ShowDialog();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenBook();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

        private void RefreshToolStripButton_Click(object sender, EventArgs e)
        {
            lstBookInfo.Items.Clear();
            foreach (BookInfo Refresh in Form1.arrBookInfo.Values)
            {
                lstBookInfo.Items.Add(Refresh);
            }
        }

        private void FormDisplay_Load(object sender, EventArgs e)
        {
            RefreshToolStripButton_Click(sender, e);
            printBToFill();
        }

        private void ImportToolStripButton_Click(object sender, EventArgs e)
        {
            if (Form1.SavedBookInfo == false)  // If User Click On Open button and the changed Data Did Not Saved In Hard!
            {
                DialogResult Close = MessageBox.Show("Do you want to save the changes to Book Database ?", "Program Library",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (Close == DialogResult.No)
                {
                    FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                    // Set the FolderBrowserDialog control properties
                    folderBrowserDialog1.Description = "Select your folder for Import Book Database:";
                    folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
                    folderBrowserDialog1.ShowNewFolderButton = false;
                    // Show the Browse For Folder dialog
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string p = folderBrowserDialog1.SelectedPath;
                        if (!File.Exists(p + @"\BehzadBName.sys") ||
                            !File.Exists(p + @"\BehzadBWriter.sys") || !File.Exists(p + @"\BehzadBPrice.sys")
                            || !File.Exists(p + @"\BehzadBPropagator.sys") || !File.Exists(p + @"\BehzadBIsbn.sys")
                            || !File.Exists(p + @"\BehzadBNumberPage.sys") || !File.Exists(p + @"\BehzadBDate.sys")
                            || !File.Exists(p + @"\BehzadBTranslator.sys") || !File.Exists(p + @"\BehzadBHaveCd.sys")
                            || !File.Exists(p + @"\BehzadBookBailment.sys") || !File.Exists(p + @"\BehzadBBName.sys")
                            || !File.Exists(p + @"\BehzadBBDate.sys") || !File.Exists(p + @"\BehzadBBBookName.sys")
                            || !File.Exists(p + @"\BehzadBBIsbn.sys"))
                        {
                            MessageBox.Show("File Not Found!" + "\nPlease Choose Other Path...", "File not found"
                                , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            ImportToolStripButton_Click(sender, e);
                        }
                        else
                        {
                            string PatchBuffer = Form1.patchBook;
                            Form1.patchBook = folderBrowserDialog1.SelectedPath;
                            LoadBook();
                            Form1.SavedBookInfo = false;
                            Form1.SavedNewB = true;
                        }
                    }
                }
                else if (Close == DialogResult.Yes)
                {
                    SaveBook();
                    FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                    // Set the FolderBrowserDialog control properties
                    folderBrowserDialog1.Description = "Select your folder for Import Book Database:";
                    folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
                    folderBrowserDialog1.ShowNewFolderButton = false;
                    // Show the Browse For Folder dialog
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string p = folderBrowserDialog1.SelectedPath;
                        if (!File.Exists(p + @"\BehzadBName.sys") ||
                            !File.Exists(p + @"\BehzadBWriter.sys") || !File.Exists(p + @"\BehzadBPrice.sys")
                            || !File.Exists(p + @"\BehzadBPropagator.sys") || !File.Exists(p + @"\BehzadBIsbn.sys")
                            || !File.Exists(p + @"\BehzadBNumberPage.sys") || !File.Exists(p + @"\BehzadBDate.sys")
                            || !File.Exists(p + @"\BehzadBTranslator.sys") || !File.Exists(p + @"\BehzadBHaveCd.sys")
                            || !File.Exists(p + @"\BehzadBookBailment.sys") || !File.Exists(p + @"\BehzadBBName.sys")
                            || !File.Exists(p + @"\BehzadBBDate.sys") || !File.Exists(p + @"\BehzadBBBookName.sys")
                            || !File.Exists(p + @"\BehzadBBIsbn.sys"))
                        {
                            MessageBox.Show("File Not Found!" + "\nPlease Choose Other Path...", "File not found"
                                , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            ImportToolStripButton_Click(sender, e);
                        }
                        else
                        {
                            string PatchBuffer = Form1.patchBook;
                            Form1.patchBook = folderBrowserDialog1.SelectedPath;
                            LoadBook();
                            Form1.SavedBookInfo = false;
                            Form1.SavedNewB = true;
                        }
                    }
                }
                else if (Close == DialogResult.Cancel) return;
            }
            else if (Form1.SavedBookInfo == true)
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                // Set the FolderBrowserDialog control properties
                folderBrowserDialog1.Description = "Select your folder for Import Book Database:";
                folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
                folderBrowserDialog1.ShowNewFolderButton = false;
                // Show the Browse For Folder dialog
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    string p = folderBrowserDialog1.SelectedPath;
                    if (!File.Exists(p + @"\BehzadBName.sys") ||
                        !File.Exists(p + @"\BehzadBWriter.sys") || !File.Exists(p + @"\BehzadBPrice.sys")
                        || !File.Exists(p + @"\BehzadBPropagator.sys") || !File.Exists(p + @"\BehzadBIsbn.sys")
                        || !File.Exists(p + @"\BehzadBNumberPage.sys") || !File.Exists(p + @"\BehzadBDate.sys")
                        || !File.Exists(p + @"\BehzadBTranslator.sys") || !File.Exists(p + @"\BehzadBHaveCd.sys")
                        || !File.Exists(p + @"\BehzadBookBailment.sys") || !File.Exists(p + @"\BehzadBBName.sys")
                        || !File.Exists(p + @"\BehzadBBDate.sys") || !File.Exists(p + @"\BehzadBBBookName.sys")
                        || !File.Exists(p + @"\BehzadBBIsbn.sys"))
                    {
                        MessageBox.Show("File Not Found!" + "\nPlease Choose Other Path...", "File not found"
                            , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        ImportToolStripButton_Click(sender, e);
                    }
                    else
                    {
                        string PatchBuffer = Form1.patchBook;
                        Form1.patchBook = folderBrowserDialog1.SelectedPath;
                        LoadBook();
                        Form1.SavedBookInfo = false;
                        Form1.SavedNewB = true;
                    }
                }
            }
        }

        private void ExportToolStripButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            // Set the FolderBrowserDialog control properties
            folderBrowserDialog1.Description = "Select a folder for Export Book Data :";
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.ShowNewFolderButton = true;
            // Show the Browse For Folder dialog
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string Patchbuffer = Form1.patchBook;
                Form1.patchBook = folderBrowserDialog1.SelectedPath;
                Form1.SaveBookInfo();
                Form1.SaveBookBailment();
                Form1.patchBook = Patchbuffer;
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveBook();
        }
        public BookInfo SelectedBook
        {
            get
            {
                // Return the selected Student
                return (BookInfo)lstBookInfo.Items[lstBookInfo.SelectedIndex];
            }
        }
        public void ReadListBox()
        {
            if (lstBookInfo.SelectedIndex >= 0)
            {
                BookInfo objInfo = SelectedBook;
                Hashtable read = new Hashtable();
                read.Add(objInfo.Isbn, Form1.arrBookInfo[objInfo.Isbn]);
                foreach (BookInfo fill in read.Values)
                {
                    txtBookName.Text = fill.BookName;
                    txtWriterName.Text = fill.WriterName;
                    txtTranslator.Text = fill.Translator;
                    txtPropagator.Text = fill.Propagator;
                    txtPrice.Text = fill.Price;
                    txtNumberPage.Text = fill.NumberPage;
                    txtIsbn.Text = fill.Isbn;
                    txtDateOfBook.Text = fill.DateOfBook;
                    if (string.Compare(fill.HaveCd, "true", true) == 0)
                        chbxCD.Checked = true;
                    else chbxCD.Checked = false;
                    if (string.Compare(fill.Bailment, "true", true) == 0)
                    {
                        Hashtable readB = new Hashtable();
                        readB.Add(fill.Isbn, Form1.arrBookBailment[fill.Isbn]);
                        foreach (BookBailment fillB in readB.Values)
                        {
                            txtBilment.Text = "Yes (By: " + fillB.BailmentName + ")";
                        }
                    }
                    else txtBilment.Text = "No";
                }
            }
        }
        private void lstBookInfo_MouseClick(object sender, MouseEventArgs e)
        {
            ReadListBox();
        }

        private void lstBookInfo_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    {
                        ReadListBox();
                    }
                    break;
                case Keys.Up:
                    {
                        ReadListBox();
                    }
                    break;
                case Keys.Left:
                    {
                        ReadListBox();
                    }
                    break;
                case Keys.Right:
                    {
                        ReadListBox();
                    }
                    break;
            }
        }

        private void lstBookInfo_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void chbxCD_Enter(object sender, EventArgs e)
        {
            DisableButton();
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
            // Toggle the Select All menu items
            selectAllToolStripMenuItem.Enabled = (objTextBox.SelectionLength < objTextBox.Text.Length);
        }

        private void txtBookName_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtPrice_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtIsbn_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtDateOfBook_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtBilment_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtWriterName_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtPropagator_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtNumberPage_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtTranslator_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtBookName_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtPrice_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtIsbn_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtDateOfBook_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtBilment_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtWriterName_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtPropagator_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtNumberPage_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtTranslator_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtBookName_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtBookName == ActiveControl) ToggleMenus();
        }

        private void txtPrice_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtPrice == ActiveControl) ToggleMenus();
        }

        private void txtIsbn_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtIsbn == ActiveControl) ToggleMenus();
        }

        private void txtDateOfBook_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtDateOfBook == ActiveControl) ToggleMenus();
        }

        private void txtBilment_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtBilment == ActiveControl) ToggleMenus();
        }

        private void txtWriterName_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtWriterName == ActiveControl) ToggleMenus();
        }

        private void txtPropagator_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtPropagator == ActiveControl) ToggleMenus();
        }

        private void txtNumberPage_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtNumberPage == ActiveControl) ToggleMenus();
        }

        private void txtTranslator_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtTranslator == ActiveControl) ToggleMenus();
        }
        public void printBToFill()
        {
            int maxLengthBook = 9;
            int maxLengthWriter = 11;
            int maxLengthIsbn = 13;
            foreach (BookInfo Blength in Form1.arrBookInfo.Values)
            {
                if (Blength.BookName.Length > maxLengthBook)
                    maxLengthBook = Blength.BookName.Length;
                if (Blength.WriterName.Length > maxLengthWriter)
                    maxLengthWriter = Blength.WriterName.Length;
                if (Blength.Isbn.Length > maxLengthIsbn)
                    maxLengthIsbn = Blength.Isbn.Length;
            }
            string[] text = new string[Form1.arrBookInfo.Count + 3];
            //
            // Write Carachters SPACE to Continue of Book Name
            //
            string BookName = "Book Name";
            string WriterName = "Writer Name";
            string Isbn = "ISBN شابک    ";
            string Price = "Price";
            while (BookName.Length < (maxLengthBook + 8))
                BookName += " ";
            while (WriterName.Length < (maxLengthWriter + 8))
                WriterName += " ";
            while (Isbn.Length < (maxLengthIsbn + 8))
                Isbn += " ";
            //
            // Fill String text[] & Extra " " to All Name.
            //
            text[0] = BookName + WriterName + Isbn + Price;
            text[1] = "";
            text[2] = "";
            int i = 3;
            foreach (BookInfo FillS in Form1.arrBookInfo.Values)
            {
                string B = FillS.BookName;
                string W = FillS.WriterName;
                string I = FillS.Isbn;
                while (B.Length < (maxLengthBook + 8))
                    B += " ";
                while (W.Length < (maxLengthWriter + 8))
                    W += " ";
                while (I.Length < (maxLengthIsbn + 8))
                    I += " ";
                text[i] = B + W + I + FillS.Price;
                i++;
            }
            File.WriteAllLines(@"Program Library DB\Print.txt", text);
        }

        private string strFileName = @"Program Library DB\Print.txt";
        private StreamReader objStreamToPrint;
        private Font objPrintFont;
        private void prtPage(object sender, PrintPageEventArgs e)
        {
            // Declare variables
            float sngLinesPerpage = 0;
            float sngVerticalPosition = 0;
            int intLineCount = 0;
            float sngLeftMargin = e.MarginBounds.Left;
            float sngTopMargin = e.MarginBounds.Top;
            string strLine;
            // Work out the number of lines per page.
            // Use the MarginBounds on the event to do this
            sngLinesPerpage = e.MarginBounds.Height / objPrintFont.GetHeight(e.Graphics);
            // Now iterate through the file printing out each line.
            // This assumes that a single line is not wider than
            // the page width. Check intLineCount first so that we
            // don’t read a line that we won’t print
            strLine = objStreamToPrint.ReadLine();
            while ((intLineCount < sngLinesPerpage) && (strLine != null))
            {
                // Calculate the vertical position on the page
                sngVerticalPosition = sngTopMargin + (intLineCount * objPrintFont.GetHeight(e.Graphics));
                // Pass a StringFormat to DrawString for the
                // Print Preview control
                e.Graphics.DrawString(strLine, objPrintFont, Brushes.Black, sngLeftMargin, sngVerticalPosition, new StringFormat());
                // Increment the line count
                intLineCount = intLineCount + 1;
                // If the line count is less than the lines per
                // page then read another line of text
                if (intLineCount < sngLinesPerpage)
                {
                    strLine = objStreamToPrint.ReadLine();
                }
            }
            // If we have more lines then print another page
            if (strLine != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }
        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            printBToFill();
            // Declare an object for the PrintDocument class
            PrintDocument objPrintDocument = new PrintDocument();
            // Set the DocumentName property
            objPrintDocument.DocumentName = "Program Library";
            // Set the PrintDialog properties
            printDialog1.AllowPrintToFile = false;
            printDialog1.AllowSelection = false;
            printDialog1.AllowSomePages = false;
            // Set the Document property for
            // the objPrintDocument object
            printDialog1.Document = objPrintDocument;
            // Show the Print dialog
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                // If the user clicked on the OK button
                // then set the StreamReader object to
                // the file name in the strFileName variable
                objStreamToPrint = new StreamReader(strFileName);
                // Set the printer font
                objPrintFont = new Font("Simplified Arabic Fixed", 10);
                // Set the PrinterSettings property of the
                // objPrintDocument Object to the
                // PrinterSettings property returned from the
                // PrintDialog control
                objPrintDocument.PrinterSettings = printDialog1.PrinterSettings;
                // Add an event handler for the PrintPage event of
                // the objPrintDocument object
                objPrintDocument.PrintPage += new PrintPageEventHandler(prtPage);
                // Print the text file
                objPrintDocument.Print();
                // Clean up
                objStreamToPrint.Close();
                objStreamToPrint = null;
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPrintPreView Preview = new FormPrintPreView();
            Preview.ShowDialog();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printToolStripButton_Click(sender, e);
        }

        private void lstBookInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadListBox();
        }

    }
}
