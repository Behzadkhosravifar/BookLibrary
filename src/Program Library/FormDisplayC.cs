using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Collections;


namespace Program_Library
{
    public partial class FormDisplayC : Form
    {
        public FormDisplayC()
        {
            InitializeComponent();
        }

        public void printBToFill()
        {
            int maxLengthCD = 9;
            int maxLengthDateOfCd = 11;
            int maxLengthType = 13;
            foreach (CdInfo Clength in Form1.arrCdInfo.Values)
            {
                if (Clength.CdName.Length > maxLengthCD)
                    maxLengthCD = Clength.CdName.Length;
                if (Clength.DateOfCd.Length > maxLengthDateOfCd)
                    maxLengthDateOfCd = Clength.DateOfCd.Length;
                if (Clength.Type.Length > maxLengthType)
                    maxLengthType = Clength.Type.Length;
            }
            string[] text = new string[Form1.arrCdInfo.Count + 3];
            //
            // Write Carachters SPACE to Continue of Book Name
            //
            string CdName = "CD Name";
            string Type = "Type Of CD-DVD";
            string Number = "Number Of CD-DVD";
            while (CdName.Length < (maxLengthCD + 8))
                CdName += " ";
            while (Type.Length < (maxLengthType + 8))
                Type += " ";
            //
            // Fill String text[] & Extra " " to All Name.
            //
            text[0] = CdName + Type + Number;
            text[1] = "";
            text[2] = "";
            int i = 3;
            foreach (CdInfo FillS in Form1.arrCdInfo.Values)
            {
                string B = FillS.CdName;
                string I = FillS.Type;
                while (B.Length < (maxLengthCD + 8))
                    B += " ";
                while (I.Length < (maxLengthType + 8))
                    I += " ";
                text[i] = B + I + FillS.NumberOfCd;
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

        private void FormDisplayC_Load(object sender, EventArgs e)
        {
            RefreshToolStripButton_Click(sender, e);
            printBToFill();
        }

        private void RefreshToolStripButton_Click(object sender, EventArgs e)
        {
            lstDisplay.Items.Clear();
            foreach (CdInfo Refresh in Form1.arrCdInfo.Values)
            {
                lstDisplay.Items.Add(Refresh);
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
        public void LoadCD()
        {
            // Load CdInfo
            string[] LcName, LcDate, LcNumberCd, LcType, LcSpecifications, LcB; // LcB ==> Load cd Bailment.
            LcName = System.IO.File.ReadAllLines((Form1.patchCD + @"\BehzadCName.sys"));
            LcDate = System.IO.File.ReadAllLines((Form1.patchCD + @"\BehzadCDate.sys"));
            LcNumberCd = System.IO.File.ReadAllLines((Form1.patchCD + @"\BehzadCNumberCd.sys"));
            LcType = System.IO.File.ReadAllLines((Form1.patchCD + @"\BehzadCType.sys"));
            LcSpecifications = System.IO.File.ReadAllLines((Form1.patchCD + @"\BehzadCSpecifications.sys"));
            LcB = System.IO.File.ReadAllLines((Form1.patchCD + @"\BehzadCdBailment.sys"));
            long i = LcName.LongCount() - 1;
            for (; i >= 0; i--)
            {
                CdInfo Copy = new CdInfo();
                Copy.CdName = LcName[i];
                Copy.DateOfCd = LcDate[i];
                Copy.NumberOfCd = LcNumberCd[i];
                Copy.Specifications = LcSpecifications[i];
                Copy.Type = LcType[i];
                Copy.Bailment = LcB[i];
                if (Form1.arrCdInfo.Contains(Copy.CdName) == false)
                    Form1.arrCdInfo.Add(Copy.CdName, Copy);
                else
                {
                    DialogResult returnE = MessageBox.Show("The CD by Name (" + Copy.CdName + ") Already is Exist in Club!"
                        + "\nAre you to continue Import other CDs of patch (" + Form1.patchCD + ") ?", "Error Repeat in Import Data"
                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (returnE == DialogResult.No) return;
                    else if (returnE == DialogResult.Yes) continue;
                }
            }
            // Show In ListBox
            foreach (CdInfo name in Form1.arrCdInfo.Values)
            {
                lstDisplay.Items.Add(name);
            }
            // Load Cd Bailment
            string[] LcBName, LcBDate, LcBType, LcBCdNumber, LcBCdName; // LcBCdName ==> Load cd Bailment Cd Name
            LcBName = System.IO.File.ReadAllLines((Form1.patchCD + @"\BehzadCBName.sys"));
            LcBDate = System.IO.File.ReadAllLines((Form1.patchCD + @"\BehzadCBDate.sys"));
            LcBType = System.IO.File.ReadAllLines((Form1.patchCD + @"\BehzadCBType.sys"));
            LcBCdName = System.IO.File.ReadAllLines((Form1.patchCD + @"\BehzadCBCdName.sys"));
            LcBCdNumber = File.ReadAllLines((Form1.patchCD + @"\BehzadCBNumberCd.sys"));

            i = LcBName.LongCount() - 1;
            for (; i >= 0; i--)
            {
                CdBailment Copy = new CdBailment();
                Copy.BailmentName = LcBName[i];
                Copy.CdName = LcBCdName[i];
                Copy.DateOfBailment = LcBDate[i];
                Copy.BailmentCdType = LcBType[i];
                Copy.NumberCd = LcBCdNumber[i];

                if (Form1.arrCdBailment.Contains(Copy.CdName) == false)
                    Form1.arrCdBailment.Add(Copy.CdName, Copy);
                else
                {
                    DialogResult returnE = MessageBox.Show("The Bailment CD by Name (" + Copy.CdName + ") Already is Exist in Bailment Club!"
                        + "\nAre you to continue Import other CDs of patch (" + Form1.patchCD + ") ?", "Error Repeat in Import Data"
                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (returnE == DialogResult.No) return;
                    else if (returnE == DialogResult.Yes) continue;
                }
            }
        }
        public void OpenCD()
        {
            if (Form1.SavedCdInfo == false)  // If User Click On Open button and the changed Data Did Not Saved In Hard!
            {
                DialogResult Close = MessageBox.Show("Do you want to save the changes to Database ?", "Program Library",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (Close == DialogResult.No)
                {
                    Form1.SavedCdInfo = true;
                    FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                    // Set the FolderBrowserDialog control properties
                    folderBrowserDialog1.Description = "Select your folder for Open CDs Database:";
                    folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
                    folderBrowserDialog1.ShowNewFolderButton = false;
                    // Show the Browse For Folder dialog
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string p = folderBrowserDialog1.SelectedPath;
                        if (!File.Exists(p + @"\BehzadCName.sys") || !File.Exists(p + @"\BehzadCDate.sys")
                            || !File.Exists(p + @"\BehzadCNumberCd.sys") || !File.Exists(p + @"\BehzadCType.sys")
                            || !File.Exists(p + @"\BehzadCSpecifications.sys") || !File.Exists(p + @"\BehzadCdBailment.sys")
                            || !File.Exists(p + @"\BehzadCBName.sys") || !File.Exists(p + @"\BehzadCBDate.sys")
                            || !File.Exists(p + @"\BehzadCBCdName.sys") || !File.Exists(p + @"\BehzadCBType.sys"))
                        {
                            MessageBox.Show("File Not Found!" + "\nPlease Choose Other Path...", "File not found"
                                , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            OpenCD();
                        }
                        else
                        {
                            Form1.patchCD = folderBrowserDialog1.SelectedPath;
                            System.IO.File.WriteAllText(@"Program library DB\PatchC.dll", Form1.patchCD);
                            Form1.arrCdInfo.Clear();
                            Form1.arrCdBailment.Clear();
                            LoadCD();
                            Form1.SavedNewC = true;
                        }
                    }
                }
                else if (Close == DialogResult.Yes)
                {
                    SaveCD();
                    FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                    // Set the FolderBrowserDialog control properties
                    folderBrowserDialog1.Description = "Select your folder for Open CDs Database:";
                    folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
                    folderBrowserDialog1.ShowNewFolderButton = false;
                    // Show the Browse For Folder dialog
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string p = folderBrowserDialog1.SelectedPath;
                        if (!File.Exists(p + @"\BehzadCName.sys") || !File.Exists(p + @"\BehzadCDate.sys")
                            || !File.Exists(p + @"\BehzadCNumberCd.sys") || !File.Exists(p + @"\BehzadCType.sys")
                            || !File.Exists(p + @"\BehzadCSpecifications.sys") || !File.Exists(p + @"\BehzadCdBailment.sys")
                            || !File.Exists(p + @"\BehzadCBName.sys") || !File.Exists(p + @"\BehzadCBDate.sys")
                            || !File.Exists(p + @"\BehzadCBCdName.sys") || !File.Exists(p + @"\BehzadCBType.sys"))
                        {
                            MessageBox.Show("File Not Found!" + "\nPlease Choose Other Path...", "File not found"
                                , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            OpenCD();
                        }
                        else
                        {
                            Form1.patchCD = folderBrowserDialog1.SelectedPath;
                            System.IO.File.WriteAllText(@"Program library DB\PatchC.dll", Form1.patchCD);
                            Form1.arrCdInfo.Clear();
                            Form1.arrCdBailment.Clear();
                            LoadCD();
                            Form1.SavedNewC = true;
                        }
                    }
                }
                else if (Close == DialogResult.Cancel) return;
            }
            else if (Form1.SavedCdInfo == true)
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                // Set the FolderBrowserDialog control properties
                folderBrowserDialog1.Description = "Select your folder for Open CDs Database:";
                folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
                folderBrowserDialog1.ShowNewFolderButton = false;
                // Show the Browse For Folder dialog
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    string p = folderBrowserDialog1.SelectedPath;
                    if (!File.Exists(p + @"\BehzadCName.sys") || !File.Exists(p + @"\BehzadCDate.sys")
                        || !File.Exists(p + @"\BehzadCNumberCd.sys") || !File.Exists(p + @"\BehzadCType.sys")
                        || !File.Exists(p + @"\BehzadCSpecifications.sys") || !File.Exists(p + @"\BehzadCdBailment.sys")
                        || !File.Exists(p + @"\BehzadCBName.sys") || !File.Exists(p + @"\BehzadCBDate.sys")
                        || !File.Exists(p + @"\BehzadCBCdName.sys") || !File.Exists(p + @"\BehzadCBType.sys"))
                    {
                        MessageBox.Show("File Not Found!" + "\nPlease Choose Other Path...", "File not found"
                            , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        OpenCD();
                    }
                    else
                    {
                        Form1.patchCD = folderBrowserDialog1.SelectedPath;
                        System.IO.File.WriteAllText(@"Program library DB\PatchC.dll", Form1.patchCD);
                        Form1.arrCdInfo.Clear();
                        Form1.arrCdBailment.Clear();
                        LoadCD();
                    }
                }
            }
        }
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenCD();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveCD();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCD();
        }

        private void ChangePassStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChangePass ChangePass = new FormChangePass();
            ChangePass.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCD();
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddC AddC = new FormAddC();
            AddC.ShowDialog();
        }

        private void BilmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBailmentC BailmentC = new FormBailmentC();
            BailmentC.ShowDialog();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDeleteC DeleteC = new FormDeleteC();
            DeleteC.ShowDialog();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Dispose();
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

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Declare a TextBox object and
            // set it to the ActiveControl
            TextBox objTextBox = (TextBox)this.ActiveControl;
            // Select all text
            objTextBox.SelectAll();
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

        private void lstDisplay_Enter(object sender, EventArgs e)
        {
            DisableButton();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            DisableButton();
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

        private void txtCDName_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtType_Enter(object sender, EventArgs e)
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

        private void txtDateOfWrite_Enter(object sender, EventArgs e)
        {
            ToggleMenus();
        }

        private void txtCDName_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtType_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtSpecifications_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtNumber_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtDateOfWrite_KeyUp(object sender, KeyEventArgs e)
        {
            ToggleMenus();
        }

        private void txtCDName_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtCDName == ActiveControl) ToggleMenus();
        }

        private void txtBailment_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtBailment == ActiveControl) ToggleMenus();
        }

        private void txtType_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtType == ActiveControl) ToggleMenus();
        }

        private void txtSpecifications_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtSpecifications == ActiveControl) ToggleMenus();
        }

        private void txtNumber_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtNumber == ActiveControl) ToggleMenus();
        }

        private void txtDateOfWrite_MouseMove(object sender, MouseEventArgs e)
        {
            if (txtDateOfWrite == ActiveControl) ToggleMenus();
        }

        private void ImportToolStripButton_Click(object sender, EventArgs e)
        {
            if (Form1.SavedCdInfo == false)  // If User Click On Open button and the changed Data Did Not Saved In Hard!
            {
                DialogResult Close = MessageBox.Show("Do you want to save the changes to CD-DVD Database ?", "Program Library",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (Close == DialogResult.No)
                {
                    FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                    // Set the FolderBrowserDialog control properties
                    folderBrowserDialog1.Description = "Select your folder for Import CD-DVD Database:";
                    folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
                    folderBrowserDialog1.ShowNewFolderButton = false;
                    // Show the Browse For Folder dialog
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string p = folderBrowserDialog1.SelectedPath;
                        if (!File.Exists(p + @"\BehzadCName.sys") || !File.Exists(p + @"\BehzadCDate.sys")
                            || !File.Exists(p + @"\BehzadCNumberCd.sys") || !File.Exists(p + @"\BehzadCType.sys")
                            || !File.Exists(p + @"\BehzadCSpecifications.sys") || !File.Exists(p + @"\BehzadCdBailment.sys")
                            || !File.Exists(p + @"\BehzadCBName.sys") || !File.Exists(p + @"\BehzadCBDate.sys")
                            || !File.Exists(p + @"\BehzadCBCdName.sys") || !File.Exists(p + @"\BehzadCBType.sys")
                            || !File.Exists(p + @"\BehzadCBNumberCd.sys"))
                        {
                            MessageBox.Show("File Not Found!" + "\nPlease Choose Other Path...", "File not found"
                                , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            ImportToolStripButton_Click(sender, e);
                        }
                        else
                        {
                            string PatchBuffer = Form1.patchCD;
                            Form1.patchCD = folderBrowserDialog1.SelectedPath;
                            LoadCD();
                            Form1.SavedCdInfo = false;
                            Form1.SavedNewC = true;
                        }
                    }
                }
                else if (Close == DialogResult.Yes)
                {
                    SaveCD();
                    FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                    // Set the FolderBrowserDialog control properties
                    folderBrowserDialog1.Description = "Select your folder for Import CD-DVD Database:";
                    folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
                    folderBrowserDialog1.ShowNewFolderButton = false;
                    // Show the Browse For Folder dialog
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string p = folderBrowserDialog1.SelectedPath;
                        if (!File.Exists(p + @"\BehzadCName.sys") || !File.Exists(p + @"\BehzadCDate.sys")
                            || !File.Exists(p + @"\BehzadCNumberCd.sys") || !File.Exists(p + @"\BehzadCType.sys")
                            || !File.Exists(p + @"\BehzadCSpecifications.sys") || !File.Exists(p + @"\BehzadCdBailment.sys")
                            || !File.Exists(p + @"\BehzadCBName.sys") || !File.Exists(p + @"\BehzadCBDate.sys")
                            || !File.Exists(p + @"\BehzadCBCdName.sys") || !File.Exists(p + @"\BehzadCBType.sys")
                            || !File.Exists(p + @"\BehzadCBNumberCd.sys"))
                        {
                            MessageBox.Show("File Not Found!" + "\nPlease Choose Other Path...", "File not found"
                                , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            ImportToolStripButton_Click(sender, e);
                        }
                        else
                        {
                            string PatchBuffer = Form1.patchCD;
                            Form1.patchCD = folderBrowserDialog1.SelectedPath;
                            LoadCD();
                            Form1.SavedCdInfo = false;
                            Form1.SavedNewC = true;
                        }
                    }
                }
                else if (Close == DialogResult.Cancel) return;
            }
            else if (Form1.SavedCdInfo == true)
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                // Set the FolderBrowserDialog control properties
                folderBrowserDialog1.Description = "Select your folder for Import CD-DVD Database:";
                folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
                folderBrowserDialog1.ShowNewFolderButton = false;
                // Show the Browse For Folder dialog
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    string p = folderBrowserDialog1.SelectedPath;
                    if (!File.Exists(p + @"\BehzadCName.sys") || !File.Exists(p + @"\BehzadCDate.sys")
                        || !File.Exists(p + @"\BehzadCNumberCd.sys") || !File.Exists(p + @"\BehzadCType.sys")
                        || !File.Exists(p + @"\BehzadCSpecifications.sys") || !File.Exists(p + @"\BehzadCdBailment.sys")
                        || !File.Exists(p + @"\BehzadCBName.sys") || !File.Exists(p + @"\BehzadCBDate.sys")
                        || !File.Exists(p + @"\BehzadCBCdName.sys") || !File.Exists(p + @"\BehzadCBType.sys")
                        || !File.Exists(p + @"\BehzadCBNumberCd.sys"))
                    {
                        MessageBox.Show("File Not Found!" + "\nPlease Choose Other Path...", "File not found"
                            , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        ImportToolStripButton_Click(sender, e);
                    }
                    else
                    {
                        string PatchBuffer = Form1.patchCD;
                        Form1.patchCD = folderBrowserDialog1.SelectedPath;
                        LoadCD();
                        Form1.SavedCdInfo = false;
                        Form1.SavedNewC = true;
                    }
                }
            }
        }

        private void ExportToolStripButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            // Set the FolderBrowserDialog control properties
            folderBrowserDialog1.Description = "Select a folder for Export CD-DVD Data :";
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.ShowNewFolderButton = true;
            // Show the Browse For Folder dialog
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string Patchbuffer = Form1.patchCD;
                Form1.patchCD = folderBrowserDialog1.SelectedPath;
                Form1.SaveCdInfo();
                Form1.SaveCdBailment();
                Form1.patchCD = Patchbuffer;
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printToolStripButton_Click(sender, e);
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPrintPreView Preview = new FormPrintPreView();
            Preview.ShowDialog();
        }

        public CdInfo SelectedCD
        {
            get
            {
                // Return the selected Student
                return (CdInfo)lstDisplay.Items[lstDisplay.SelectedIndex];
            }
        }
        public void ReadListBox()
        {
            if (lstDisplay.SelectedIndex >= 0)
            {
                // Clear All CheckBox ....................................................................
                chbDriver.Enabled = false;
                chbDriver.Checked = false;
                chbDataCd.Enabled = false;
                chbDataCd.Checked = false;
                chbDataDvd.Enabled = false;
                chbDataDvd.Checked = false;
                chbFloppyDisk.Enabled = false;
                chbFloppyDisk.Checked = false;
                chbFloppyZipDisk.Enabled = false;
                chbFloppyZipDisk.Checked = false;
                chbMultimediaCd.Enabled = false;
                chbMultimediaCd.Checked = false;
                chbMultimediaDvd.Enabled = false;
                chbMultimediaDvd.Checked = false;
                chbMusicCd.Enabled = false;
                chbMusicCd.Checked = false;
                chbMusicDvd.Enabled = false;
                chbMusicDvd.Checked = false;
                chbOtherCD.Enabled = false;
                chbOtherCD.Checked = false;
                chbOtherCdRw.Enabled = false;
                chbOtherCdRw.Checked = false;
                chbOtherDvd.Enabled = false;
                chbOtherDvd.Checked = false;
                chbOtherDvdRw.Enabled = false;
                chbOtherDvdRw.Checked = false;
                chbPictureCd.Enabled = false;
                chbPictureCd.Checked = false;
                chbPictureDvd.Enabled = false;
                chbPictureDvd.Checked = false;
                chbVideoCd.Enabled = false;
                chbVideoCd.Checked = false;
                chbVideoDvd.Enabled = false;
                chbVideoDvd.Checked = false;
                chbWindows.Enabled = false;
                chbWindows.Checked = false;
                //........................................................................................
                CdInfo objInfo = SelectedCD;
                Hashtable read = new Hashtable();
                read.Add(objInfo.CdName, Form1.arrCdInfo[objInfo.CdName]);
                txtCDName.ForeColor = Color.Black;
                txtSpecifications.ForeColor = Color.Black;
                txtNumber.ForeColor = Color.Black;
                txtType.ForeColor = Color.Black;
                txtDateOfWrite.ForeColor = Color.Black;
                txtBailment.ForeColor = Color.Black;
                foreach (CdInfo fill in read.Values)
                {
                    txtCDName.Text = fill.CdName;
                    txtSpecifications.Text = fill.Specifications;
                    txtNumber.Text = fill.NumberOfCd;
                    txtType.Text = fill.Type;
                    SelectTypePic(fill.Type);
                    txtDateOfWrite.Text = fill.DateOfCd;
                    if (string.Compare(fill.Bailment, "true", true) == 0)
                    {
                        Hashtable readB = new Hashtable();
                        readB.Add(fill.CdName, Form1.arrCdBailment[fill.CdName]);
                        foreach (CdBailment fillB in readB.Values)
                        {
                            txtBailment.Text = "Yes (By: " + fillB.BailmentName + ")";
                        }
                    }
                    else txtBailment.Text = "No";
                }
            }
        }

        private void SelectTypePic(string p)
        {
            switch (p)
            {   
                case "Data - CD":
                    {
                        chbDataCd.Enabled = true;
                        chbDataCd.Checked = true;
                    }
                    break;
                case "Data - DVD":
                    {
                        chbDataDvd.Enabled = true;
                        chbDataDvd.Checked = true;
                    }
                    break;
                case "Driver CD - DVD":
                    {
                        chbDriver.Enabled = true;
                        chbDriver.Checked = true;
                    }
                    break;
                case "Floppy Disk":
                    {
                        chbFloppyDisk.Enabled = true;
                        chbFloppyDisk.Checked = true;
                    }
                    break;
                case "Floppy Zip Disk":
                    {
                        chbFloppyZipDisk.Enabled = true;
                        chbFloppyZipDisk.Checked = true;
                    }
                    break;
                case "Multimedia - CD":
                    {
                        chbMultimediaCd.Enabled = true;
                        chbMultimediaCd.Checked = true;
                    }
                    break;
                case "Multimedia - DVD":
                    {
                        chbMultimediaDvd.Enabled = true;
                        chbMultimediaDvd.Checked = true;
                    }
                    break;
                case "Music - CD":
                    {
                        chbMusicCd.Enabled = true;
                        chbMusicCd.Checked = true;
                    }
                    break;
                case "Music - DVD":
                    {
                        chbMusicDvd.Enabled = true;
                        chbMusicDvd.Checked = true;
                    }
                    break;
                case "Other  CD-R":
                    {
                        chbOtherCD.Enabled = true;
                        chbOtherCD.Checked = true;
                    }
                    break;
                case "Other  CD-RW":
                    {
                        chbOtherCdRw.Enabled = true;
                        chbOtherCdRw.Checked = true;
                    }
                    break;
                case "Other  DVD":
                    {
                        chbOtherDvd.Enabled = true;
                        chbOtherDvd.Checked = true;
                    }
                    break;

                case "Other  DVD-RW":
                    {
                        chbOtherDvdRw.Enabled = true;
                        chbOtherDvdRw.Checked = true;
                    }
                    break;
                case "Picture - CD":
                    {
                        chbPictureCd.Enabled = true;
                        chbPictureCd.Checked = true;
                    }
                    break;
                case "Picture - DVD":
                    {
                        chbPictureDvd.Enabled = true;
                        chbPictureDvd.Checked = true;
                    }
                    break;
                case "Video - CD":
                    {
                        chbVideoCd.Enabled = true;
                        chbVideoCd.Checked = true;
                    }
                    break;
                case "Video - DVD":
                    {
                        chbVideoDvd.Enabled = true;
                        chbVideoDvd.Checked = true;
                    }
                    break;
                case "Windows - CD or DVD":
                    {
                        chbWindows.Enabled = true;
                        chbWindows.Checked = true;
                    }
                    break;
            }
        }

        private void lstDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            ReadListBox();
        }

        private void lstDisplay_KeyUp(object sender, KeyEventArgs e)
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

        private void lstDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadListBox();
        }
    }
}
