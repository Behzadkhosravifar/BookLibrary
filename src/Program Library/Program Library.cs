using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace Program_Library
{
    public partial class Form1 : Form
    {
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_SHOWME)
            {

                ShowMe();
            }
            base.WndProc(ref m);
        }
        private void ShowMe()
        {

            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            // get our current "TopMost" value (ours will always be false though)
            bool top = TopMost;
            // make our form jump to the top of everything
            TopMost = true;
            // set it back to whatever it was
            TopMost = top;
        }

        ~Form1()
        {
            if (File.Exists(@"Program Library DB\Print.txt") == true)
                File.Delete(@"Program Library DB\Print.txt");
        }

        public Form1()
        {
            InitializeComponent();
        }
        public static Hashtable arrBookInfo = new Hashtable();
        public static Hashtable arrBookBailment = new Hashtable();
        public static Hashtable arrCdInfo = new Hashtable();
        public static Hashtable arrCdBailment = new Hashtable();

        public static Boolean ClearPass = false;
        public static Boolean SavedBookInfo = true;
        public static Boolean SavedCdInfo = true;
        public static Boolean SavedNewB = false;
        public static Boolean SavedNewC = false;
        public static string patchCD = "";
        public static string patchBook = "";

        // Path Of Pass
        public static string patch = @"Program Library DB\Behzad.dll";
        public static string password;
        public static Boolean passOk = false;
        // Load other Data
        public void OpenBook()
        {
            if (SavedBookInfo == false)  // If User Click On Open button and the changed Data Did Not Saved In Hard!
            {
                DialogResult Close = MessageBox.Show("Do you want to save the changes to BOOK Database ?", "Program Library",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (Close == DialogResult.No)
                {
                    SavedBookInfo = true;
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
                            patchBook = folderBrowserDialog1.SelectedPath;
                            System.IO.File.WriteAllText(@"Program library DB\PatchB.dll", patchBook);
                            arrBookInfo.Clear();
                            arrBookBailment.Clear();
                            LoadBook();
                            SavedNewB = true;
                            StatusText = "Open The Book Data in path: " + patchBook;
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
                            patchBook = folderBrowserDialog1.SelectedPath;
                            File.WriteAllText(@"Program library DB\PatchB.dll", patchBook);
                            arrBookInfo.Clear();
                            arrBookBailment.Clear();
                            LoadBook();
                            SavedNewB = true;
                            StatusText = "Open The Book Data in path: " + patchBook;
                        }
                    }
                }
                else if (Close == DialogResult.Cancel) return;
            }
            else if (SavedCdInfo == true)
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
                        patchBook = folderBrowserDialog1.SelectedPath;
                        System.IO.File.WriteAllText(@"Program library DB\PatchB.dll", patchBook);
                        arrBookInfo.Clear();
                        arrBookBailment.Clear();
                        LoadBook();
                        SavedNewB = true;
                        StatusText = "Open The Book Data in path: " + patchBook;
                    }
                }
            }
        }
        public void OpenCD()
        {
            if (SavedCdInfo == false)  // If User Click On Open button and the changed Data Did Not Saved In Hard!
            {
                DialogResult Close = MessageBox.Show("Do you want to save the changes to Database ?", "Program Library",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (Close == DialogResult.No)
                {
                    SavedCdInfo = true;
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
                            patchCD = folderBrowserDialog1.SelectedPath;
                            System.IO.File.WriteAllText(@"Program library DB\PatchC.dll", patchCD);
                            arrCdInfo.Clear();
                            arrCdBailment.Clear();
                            LoadCD();
                            SavedNewC = true;
                            StatusText = "Open The CD - DVD Data in path: " + patchCD;
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
                            patchCD = folderBrowserDialog1.SelectedPath;
                            System.IO.File.WriteAllText(@"Program library DB\PatchC.dll", patchCD);
                            arrCdInfo.Clear();
                            arrCdBailment.Clear();
                            LoadCD();
                            SavedNewC = true;
                            StatusText = "Open The CD - DVD Data in path: " + patchCD;
                        }
                    }
                }
                else if (Close == DialogResult.Cancel) return;
            }
            else if (SavedCdInfo == true)
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
                        patchCD = folderBrowserDialog1.SelectedPath;
                        System.IO.File.WriteAllText(@"Program library DB\PatchC.dll", patchCD);
                        arrCdInfo.Clear();
                        arrCdBailment.Clear();
                        LoadCD();
                        StatusText = "Open The CD - DVD Data in path: " + patchCD;
                    }
                }
            }
        }
        public void LoadBook()
        {
            // Load BookInfo
            string[] LbName, LbWriter, LbPrice, LbPropagator, LbIsbn, LbNumberPage, LbDate, 
                LbTranslator, LbHaveCd, LbB; // LbB ==> Load book Bailment
            LbName = System.IO.File.ReadAllLines((patchBook + @"\BehzadBName.sys"));
            LbWriter = System.IO.File.ReadAllLines((patchBook + @"\BehzadBWriter.sys"));
            LbPrice = System.IO.File.ReadAllLines((patchBook + @"\BehzadBPrice.sys"));
            LbPropagator = System.IO.File.ReadAllLines((patchBook + @"\BehzadBPropagator.sys"));
            LbIsbn = System.IO.File.ReadAllLines((patchBook + @"\BehzadBIsbn.sys"));
            LbNumberPage = System.IO.File.ReadAllLines((patchBook + @"\BehzadBNumberPage.sys"));
            LbDate = System.IO.File.ReadAllLines((patchBook + @"\BehzadBDate.sys"));
            LbTranslator = System.IO.File.ReadAllLines((patchBook + @"\BehzadBTranslator.sys"));
            LbHaveCd = System.IO.File.ReadAllLines((patchBook + @"\BehzadBHaveCd.sys"));
            LbB = System.IO.File.ReadAllLines((patchBook + @"\BehzadBookBailment.sys"));
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
                if (arrBookInfo.Contains(Copy.Isbn) == false)
                {
                    arrBookInfo.Add(Copy.Isbn, Copy);
                    toolStripTextBoxSearch.AutoCompleteCustomSource.Add(Copy.BookName);
                }
                else
                {
                    DialogResult returnE = MessageBox.Show("Book by Name (" + Copy.BookName + ") Already is Exist in Library!"
                        + "\nAre you to continue Import other Books of patch (" + patchBook + ") ?", "Error Repeat in Import Data"
                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (returnE == DialogResult.No) return;
                    else if (returnE == DialogResult.Yes) continue;
                }
            }
            // Show In ListBox
            foreach (BookInfo name in arrBookInfo.Values)
            {
                lstDisplay.Items.Add(name.BookName);
            }
            //
            // Load Book Bailment
            string[] LbBName, LbBDate, LbBBookName, LbBIsbn; // LbBIsbn ==> Load book Bailment ISBN
            LbBName = System.IO.File.ReadAllLines((patchBook + @"\BehzadBBName.sys"));
            LbBDate = System.IO.File.ReadAllLines((patchBook + @"\BehzadBBDate.sys"));
            LbBBookName = System.IO.File.ReadAllLines((patchBook + @"\BehzadBBBookName.sys"));
            LbBIsbn = System.IO.File.ReadAllLines((patchBook + @"\BehzadBBIsbn.sys"));
            i = LbBName.LongCount() - 1;
            for (; i >= 0; i--)
            {
                BookBailment Copy = new BookBailment();
                Copy.BailmentName = LbBName[i];
                Copy.BookName = LbBBookName[i];
                Copy.DateOfBailment = LbBDate[i];
                Copy.BailmentBookIsbn = LbBIsbn[i];
                if (arrBookBailment.Contains(Copy.BailmentBookIsbn) == false)
                    arrBookBailment.Add(Copy.BailmentBookIsbn, Copy);
                else
                {
                    DialogResult returnE = MessageBox.Show("The Bailment Book by Name (" + Copy.BookName + ") Already is Exist in Bailment Library!"
                        + "\nAre you to continue Import other Books of patch (" + patchBook + ") ?", "Error Repeat in Import Data"
                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (returnE == DialogResult.No) return;
                    else if (returnE == DialogResult.Yes) continue;
                }
                
            }
        }
        public void LoadCD()
        {
            // Load CdInfo
            string[] LcName, LcDate, LcNumberCd, LcType, LcSpecifications, LcB; // LcB ==> Load cd Bailment.
            LcName = System.IO.File.ReadAllLines((patchCD + @"\BehzadCName.sys"));
            LcDate = System.IO.File.ReadAllLines((patchCD + @"\BehzadCDate.sys"));
            LcNumberCd = System.IO.File.ReadAllLines((patchCD + @"\BehzadCNumberCd.sys"));
            LcType = System.IO.File.ReadAllLines((patchCD + @"\BehzadCType.sys"));
            LcSpecifications = System.IO.File.ReadAllLines((patchCD + @"\BehzadCSpecifications.sys"));
            LcB = System.IO.File.ReadAllLines((patchCD + @"\BehzadCdBailment.sys"));
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
                if (arrCdInfo.Contains(Copy.CdName) == false)
                    arrCdInfo.Add(Copy.CdName, Copy);
                else
                {
                    DialogResult returnE = MessageBox.Show("The CD by Name (" + Copy.CdName + ") Already is Exist in Club!"
                        + "\nAre you to continue Import other CDs of patch (" + patchCD + ") ?", "Error Repeat in Import Data"
                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (returnE == DialogResult.No) return;
                    else if (returnE == DialogResult.Yes) continue;
                }
            }
            // Show In ListBox
            foreach (CdInfo name in arrCdInfo.Values)
            {
                lstDisplayCD.Items.Add(name.CdName);
            }
            // Load Cd Bailment
            string[] LcBName, LcBDate, LcBType, LcBCdNumber, LcBCdName; // LcBCdName ==> Load cd Bailment Cd Name
            LcBName = System.IO.File.ReadAllLines((patchCD + @"\BehzadCBName.sys"));
            LcBDate = System.IO.File.ReadAllLines((patchCD + @"\BehzadCBDate.sys"));
            LcBType = System.IO.File.ReadAllLines((patchCD + @"\BehzadCBType.sys"));
            LcBCdName = System.IO.File.ReadAllLines((patchCD + @"\BehzadCBCdName.sys"));
            LcBCdNumber = File.ReadAllLines((patchCD + @"\BehzadCBNumberCd.sys"));

            i = LcBName.LongCount() - 1;
            for (; i >= 0; i--)
            {
                CdBailment Copy = new CdBailment();
                Copy.BailmentName = LcBName[i];
                Copy.CdName = LcBCdName[i];
                Copy.DateOfBailment = LcBDate[i];
                Copy.BailmentCdType = LcBType[i];
                Copy.NumberCd = LcBCdNumber[i];

                if (arrCdBailment.Contains(Copy.CdName) == false)
                    arrCdBailment.Add(Copy.CdName, Copy);
                else
                {
                    DialogResult returnE = MessageBox.Show("The Bailment CD by Name (" + Copy.CdName + ") Already is Exist in Bailment Club!"
                        + "\nAre you to continue Import other CDs of patch (" + patchCD + ") ?", "Error Repeat in Import Data"
                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (returnE == DialogResult.No) return;
                    else if (returnE == DialogResult.Yes) continue;
                }
            } 
        }
        // Sava All Data Except Password Data!
        public static void SaveBookInfo()
        {
            //
            // Load arrBookInfo
            //
            string[] LbName, LbWriter, LbPrice, LbPropagator, LbIsbn, LbNumberPage, LbDate,
                     LbTranslator, LbHaveCd, LbB; // LbB ==> Load book Bailment
            int f = arrBookInfo.Count;
            LbName = new string[f];
            LbWriter = new string[f];
            LbPrice = new string[f];
            LbPropagator = new string[f];
            LbIsbn = new string[f];
            LbNumberPage = new string[f];
            LbDate = new string[f];
            LbTranslator = new string[f];
            LbHaveCd = new string[f];
            LbB = new string[f];
            int i = 0;
            foreach (BookInfo buffer in arrBookInfo.Values) // Load Hastable Array arrBookInfo by Struct BoolInfo buffer.
            {
                LbName[i] = buffer.BookName;
                LbWriter[i] = buffer.WriterName;
                LbPrice[i] = buffer.Price;
                LbPropagator[i] = buffer.Propagator;
                LbIsbn[i] = buffer.Isbn;
                LbNumberPage[i] = buffer.NumberPage;
                LbDate[i] = buffer.DateOfBook;
                LbTranslator[i] = buffer.Translator;
                LbHaveCd[i] = buffer.HaveCd;
                LbB[i] = buffer.Bailment;
                i++;
            }  // Save to Path in Hard (Below)
            System.IO.File.WriteAllLines((patchBook + @"\BehzadBName.sys"), LbName);
            System.IO.File.WriteAllLines((patchBook + @"\BehzadBWriter.sys"), LbWriter);
            System.IO.File.WriteAllLines((patchBook + @"\BehzadBPrice.sys"), LbPrice);
            System.IO.File.WriteAllLines((patchBook + @"\BehzadBPropagator.sys"), LbPropagator);
            System.IO.File.WriteAllLines((patchBook + @"\BehzadBIsbn.sys"), LbIsbn);
            System.IO.File.WriteAllLines((patchBook + @"\BehzadBNumberPage.sys"), LbNumberPage);
            System.IO.File.WriteAllLines((patchBook + @"\BehzadBDate.sys"), LbDate);
            System.IO.File.WriteAllLines((patchBook + @"\BehzadBTranslator.sys"), LbTranslator);
            System.IO.File.WriteAllLines((patchBook + @"\BehzadBHaveCd.sys"), LbHaveCd);
            System.IO.File.WriteAllLines((patchBook + @"\BehzadBookBailment.sys"), LbB);            
        }
        public static void SaveCdInfo()
        {
            //
            // Load CdInfo
            //
            string[] LcName, LcDate, LcNumberCd, LcType, LcSpecifications, LcB; // LcB ==> Load cd Bailment.
            int f = arrCdInfo.Count;
            LcName = new string[f];
            LcDate = new string[f];
            LcNumberCd = new string[f];
            LcType = new string[f];
            LcSpecifications = new string[f];
            LcB = new string[f];
            int i = 0;
            foreach (CdInfo buffer in arrCdInfo.Values) // Load Arraylist arrCdInfo by Struct CdInfo buffer.
            {
                LcName[i] = buffer.CdName;
                LcDate[i] = buffer.DateOfCd;
                LcNumberCd[i] = buffer.NumberOfCd;
                LcType[i] = buffer.Type;
                LcSpecifications[i] = buffer.Specifications;
                LcB[i] = buffer.Bailment;
                i++;
            }  // Save to Path in Hard (Below)
            System.IO.File.WriteAllLines((patchCD + @"\BehzadCName.sys"), LcName);
            System.IO.File.WriteAllLines((patchCD + @"\BehzadCDate.sys"), LcDate);
            System.IO.File.WriteAllLines((patchCD + @"\BehzadCNumberCd.sys"), LcNumberCd);
            System.IO.File.WriteAllLines((patchCD + @"\BehzadCType.sys"), LcType);
            System.IO.File.WriteAllLines((patchCD + @"\BehzadCSpecifications.sys"), LcSpecifications);
            System.IO.File.WriteAllLines((patchCD + @"\BehzadCdBailment.sys"), LcB);
        }
        public static void SaveBookBailment()
        {
            //
            // Load Book Bailment
            //
            string[] LbBName, LbBDate, LbBBookName, LbBIsbn; // LbBIsbn ==> Load book Bailment ISBN
            int f = arrBookBailment.Count;
            LbBName = new string[f];
            LbBDate = new string[f];
            LbBBookName = new string[f];
            LbBIsbn = new string[f];
            int i = 0;
            foreach (BookBailment buffer in arrBookBailment.Values) // Load Hastable Array arrBookBailment by Struct BookBailment buffer.
            {
                LbBName[i] = buffer.BailmentName;
                LbBDate[i] = buffer.DateOfBailment;
                LbBBookName[i] = buffer.BookName;
                LbBIsbn[i] = buffer.BailmentBookIsbn;
                i++;
            }  // Save to Path in Hard (Below)
            System.IO.File.WriteAllLines((patchBook + @"\BehzadBBName.sys"), LbBName);
            System.IO.File.WriteAllLines((patchBook + @"\BehzadBBDate.sys"), LbBDate);
            System.IO.File.WriteAllLines((patchBook + @"\BehzadBBBookName.sys"), LbBBookName);
            System.IO.File.WriteAllLines((patchBook + @"\BehzadBBIsbn.sys"), LbBIsbn);
        }
        public static void SaveCdBailment()
        {
            //
            // Load Cd Bailment
            //
            string[] LcBName, LcBDate, LcBType, LcBNumberCd, LcBCdName; // LcBCdName ==> Load cd Bailment Cd Name
            int f = arrCdBailment.Count;
            LcBName = new string[f];
            LcBDate = new string[f];
            LcBType = new string[f];
            LcBCdName = new string[f];
            LcBNumberCd = new string[f]; 
            int i = 0;
            foreach (CdBailment buffer in arrCdBailment.Values) // Load Arraylist arrCdBailment by Struct CdBailment buffer.
            {
                LcBName[i] = buffer.BailmentName;
                LcBDate[i] = buffer.DateOfBailment;
                LcBType[i] = buffer.BailmentCdType;
                LcBCdName[i] = buffer.CdName;
                LcBNumberCd[i] = buffer.NumberCd;
                i++;
            }  // Save to Path in Hard (Below)
            System.IO.File.WriteAllLines((patchCD + @"\BehzadCBName.sys"), LcBName);
            System.IO.File.WriteAllLines((patchCD + @"\BehzadCBDate.sys"), LcBDate);
            System.IO.File.WriteAllLines((patchCD + @"\BehzadCBType.sys"), LcBType);
            System.IO.File.WriteAllLines((patchCD + @"\BehzadCBCdName.sys"), LcBCdName);
            System.IO.File.WriteAllLines((patchCD + @"\BehzadCBNumberCd.sys"), LcBNumberCd); 
        }
        
        public void SaveCD()
        {
            if (SavedNewC == false)
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                // Set the FolderBrowserDialog control properties
                folderBrowserDialog1.Description = "Select a folder for your CDs backups:";
                folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
                folderBrowserDialog1.ShowNewFolderButton = true;
                // Show the Browse For Folder dialog
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    patchCD = folderBrowserDialog1.SelectedPath;
                    SaveCdInfo();
                    SaveCdBailment();
                    SavedCdInfo = true;
                    SavedNewC = true;
                    StatusText = "Save The CD - DVD Data in path: " + patchCD;
                }
            }
            else
            {
                SaveCdInfo();
                SaveCdBailment();
                SavedCdInfo = true;
                StatusText = "Save The CD - DVD Data in path: " + patchCD;
            }
        }
        public void SaveBook()
        {
            if (SavedNewB == false)
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                // Set the FolderBrowserDialog control properties
                folderBrowserDialog1.Description = "Select a folder for your Books backups:";
                folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
                folderBrowserDialog1.ShowNewFolderButton = true;
                // Show the Browse For Folder dialog
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    patchBook = folderBrowserDialog1.SelectedPath;
                    SaveBookInfo();
                    SaveBookBailment();
                    SavedBookInfo = true;
                    SavedNewB = true;
                    StatusText = "Save The Book Data in path: " + patchBook;
                }
            }
            else
            {
                SaveBookInfo();
                SaveBookBailment();
                SavedBookInfo = true;
                StatusText = "Save The Book Data in path: " + patchBook;
            }
        }
        void RunFirst()
        {
            //' Run this procedure in an appropriate event.
            // Set to 1 second.
            Timer1.Interval = 500;
            // Enable timer.
            Timer1.Enabled = true;
            //------------------------------------------------------
            DateTime Date;
            Date = DateTime.Now;
            lstDate.Items.Add(Date.ToLongDateString());
            //FormPass FormPas = new FormPass();
            //FormPas.ShowDialog();
            //if (!passOk) Application.Exit();
            //else
            //{
                if (File.Exists(@"Program library DB\PatchB.dll"))
                {
                    string patchShortCut = File.ReadAllText(@"Program library DB\PatchB.dll");
                    if (patchShortCut != "")
                    {
                        ShortCutBookStripMenuItem.Text = patchShortCut;
                        ShortCutBookStripMenuItem.Visible = true;
                    }
                }
                if (File.Exists(@"Program library DB\PatchC.dll"))
                {
                    string patchShortCut = File.ReadAllText(@"Program library DB\PatchC.dll");
                    if (patchShortCut != "")
                    {
                        ShortCutCDStripMenuItem.Text = patchShortCut;
                        ShortCutCDStripMenuItem.Visible = true;
                    }
                    notifyIconP.Visible = true;
                }
            //}
        }
        
        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormAbout About = new FormAbout();
            About.ShowDialog();
        }

        private void changePassStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormChangePass ChangePass = new FormChangePass();
            ChangePass.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAdd Add = new FormAdd();
            Add.ShowDialog();
        }

        private void btnBailment_Click(object sender, EventArgs e)
        {
            FormBailment Bailment = new FormBailment();
            Bailment.ShowDialog();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            FormDisplay Display = new FormDisplay();
            Display.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FormDelete Delete = new FormDelete();
            Delete.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FormSearch Search = new FormSearch();
            Search.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            File.Delete(@"Program Library DB\Print.txt");
            // If User Click On Exit button and the changed Data Did Not Saved In Hard!
            if (SavedBookInfo == false)
            {
                DialogResult Close = MessageBox.Show("Do you want to save the changes to BOOK Database ?", "Program Library",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (Close == DialogResult.No)
                {
                    SavedBookInfo = true;
                }
                else if (Close == DialogResult.Yes)
                {
                    SaveBook();
                }
                else if (Close == DialogResult.Cancel) return;
            }
            if (SavedCdInfo == false)
            {
                DialogResult Close = MessageBox.Show("Do you want to save the changes to CD - DVD Database ?", "Program Library",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (Close == DialogResult.No)
                {
                    SavedCdInfo = true;
                    File.Delete(@"Windows\Temp\Program Library.tmp");
                    Application.Exit();
                }
                else if (Close == DialogResult.Yes)
                {
                    SaveCD();
                    File.Delete(@"Windows\Temp\Program Library.tmp");
                    Application.Exit();
                }
                else if (Close == DialogResult.Cancel) return;
            }
            else if (SavedBookInfo == true && SavedCdInfo == true)
            {
                File.Delete(@"Windows\Temp\Program Library.tmp");
                Application.Exit();
            }
            File.Delete(@"Windows\Temp\Program Library.tmp");
            Application.Exit();
        }

        private void btnDisplayC_Click(object sender, EventArgs e)
        {
            FormDisplayC DisplayC = new FormDisplayC();
            DisplayC.ShowDialog();
        }

        private void btnAddC_Click(object sender, EventArgs e)
        {
            FormAddC AddC = new FormAddC();
            AddC.ShowDialog();
        }

        private void btnBailmentC_Click(object sender, EventArgs e)
        {
            FormBailmentC BailmentC = new FormBailmentC();
            BailmentC.ShowDialog();
        }

        private void btnDeleteC_Click(object sender, EventArgs e)
        {
            FormDeleteC DeleteC = new FormDeleteC();
            DeleteC.ShowDialog();
        }

        private void btnSearchC_Click(object sender, EventArgs e)
        {
            FormSearchC SearchC = new FormSearchC();
            SearchC.ShowDialog();
        }

        private void btnExitC_Click(object sender, EventArgs e)
        {
            btnExit_Click(sender, e);
        }

        private void SearchDStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSearchC SearchC = new FormSearchC();
            SearchC.ShowDialog();
        }

        private void SearchBStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSearch Search = new FormSearch();
            Search.ShowDialog();
        }

        private void AddBStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdd Add = new FormAdd();
            Add.ShowDialog();
        }

        private void AddDStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddC AddC = new FormAddC();
            AddC.ShowDialog();
        }

        private void BailmentBStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBailment Bailment = new FormBailment();
            Bailment.ShowDialog();
        }

        private void BailmentDStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBailmentC BailmentC = new FormBailmentC();
            BailmentC.ShowDialog();
        }

        private void DelBStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDelete Delete = new FormDelete();
            Delete.ShowDialog();
        }

        private void DelDStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDeleteC DeleteC = new FormDeleteC();
            DeleteC.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnExit_Click(sender, e);
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
        private void NewDataC()
        {
            SavedNewC = false;
            arrCdBailment.Clear();
            arrCdInfo.Clear();
        }
        private void NewDataB()
        {
            SavedNewB = false;
            arrBookBailment.Clear();
            arrBookInfo.Clear();
        }
        private void SaveBStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveBook();
        }

        private void SaveDStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCD();
        }

        private void newBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SavedBookInfo == false)  // If changed Data Did Not Saved In Hard!
            {
                DialogResult Close = MessageBox.Show("Do you want to save the changes to Database ?", "Program Library",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (Close == DialogResult.No) NewDataC();
                else if (Close == DialogResult.Yes)
                {
                    SaveBook();
                    NewDataB();
                }
                else if (Close == DialogResult.Cancel) return;
            }
            else if (SavedBookInfo == true) MessageBox.Show("New Library DataBase Successfully Created!", "New Database");
            StatusText = "Created The New Library Database...";
        }

        private void newDStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (SavedCdInfo == false)  // If changed Data Did Not Saved In Hard!
            {
                DialogResult Close = MessageBox.Show("Do you want to save the changes to Database ?", "Program Library",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (Close == DialogResult.No) NewDataC();
                else if (Close == DialogResult.Yes)
                {
                    SaveCD();
                    NewDataC();
                }
                else if (Close == DialogResult.Cancel) return;
            }
            else if (SavedBookInfo == true) MessageBox.Show("New Club DataBase Successfully Created!", "New Database");
            StatusText = "Created The New Club Database...";
        }

        private void OpenBStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenBook();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If User Click On Exit button (*) on Form and the changed Data Did Not Saved In Hard!
            if (SavedBookInfo == false)
            {
                DialogResult Close = MessageBox.Show("Do you want to save the changes to BOOK Database ?", "Program Library",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (Close == DialogResult.No)
                {
                    File.Delete(@"Program Library DB\Print.txt");
                    File.Delete(@"Windows\Temp\Program Library.tmp");
                    SavedBookInfo = true;
                    e.Cancel = false;
                }
                else if (Close == DialogResult.Yes)
                {
                    File.Delete(@"Program Library DB\Print.txt");
                    File.Delete(@"Windows\Temp\Program Library.tmp");
                    SaveBook();
                    e.Cancel = false;
                }
                else if (Close == DialogResult.Cancel) e.Cancel = true;
            }
            if (SavedCdInfo == false)
            {
                DialogResult Close = MessageBox.Show("Do you want to save the changes to CD - DVD Database ?", "Program Library",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (Close == DialogResult.No)
                {
                    File.Delete(@"Program Library DB\Print.txt");
                    File.Delete(@"Windows\Temp\Program Library.tmp");
                    SavedCdInfo = true;
                    Application.Exit();
                }
                else if (Close == DialogResult.Yes)
                {
                    File.Delete(@"Program Library DB\Print.txt");
                    File.Delete(@"Windows\Temp\Program Library.tmp");
                    SaveCD();
                    Application.Exit();
                }
                else if (Close == DialogResult.Cancel) e.Cancel = true;
            }
            else if (SavedBookInfo == true && SavedCdInfo == true)
            {
                File.Delete(@"Program Library DB\Print.txt");
                File.Delete(@"Windows\Temp\Program Library.tmp");
                Application.Exit();
            }
        }

        private void OpenDStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCD();
        }

        private void ShortCutBookStripMenuItem_Click(object sender, EventArgs e)
        {
            patchBook = File.ReadAllText(@"Program library DB\PatchB.dll");
            if (SavedBookInfo == false)
            {
                DialogResult Close = MessageBox.Show("Do you want to save the changes to BOOK Database ?", "Program Library",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (Close == DialogResult.No) LoadBook();
                else if (Close == DialogResult.Yes)
                {
                    SaveBook();
                    LoadBook();
                    SavedNewB = true;
                    StatusText = "Load Book Data of Old Opened Patch (" + patchBook + ")";
                }
                else if (Close == DialogResult.Cancel) return;
            }
            else if (SavedBookInfo == true)
            {
                LoadBook();
                SavedNewB = true;
                StatusText = "Load Book Data of Old Opened Patch (" + patchBook + ")";
            }
        }
        private void ShortCutCDStripMenuItem_Click(object sender, EventArgs e)
        {
            patchCD = File.ReadAllText(@"Program library DB\PatchC.dll");
            if (SavedCdInfo == false)
            {
                DialogResult Close = MessageBox.Show("Do you want to save the changes to CD - DVD Database ?", "Program Library",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (Close == DialogResult.No) LoadCD();
                else if (Close == DialogResult.Yes)
                {
                    SaveCD();
                    LoadCD();
                    SavedNewC = true;
                    StatusText = "Load CD - DVD Data of Old Opened Patch (" + patchCD + ")";
                }
                else if (Close == DialogResult.Cancel) return;
            }
            else if (SavedCdInfo == true)
            {
                LoadCD();
                SavedNewC = true;
                StatusText = "Load CD - DVD Data of Old Opened Patch (" + patchCD + ")";
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            SaveBook();
        }

        private void btnBackupC_Click(object sender, EventArgs e)
        {
            SaveCD();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            // Set the FolderBrowserDialog control properties
            folderBrowserDialog1.Description = "Select a folder for Export Book Data :";
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.ShowNewFolderButton = true;
            // Show the Browse For Folder dialog
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string Patchbuffer = patchBook;
                patchBook = folderBrowserDialog1.SelectedPath;
                SaveBookInfo();
                SaveBookBailment();
                patchBook = Patchbuffer;
            }
        }

        private void btnExportC_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            // Set the FolderBrowserDialog control properties
            folderBrowserDialog1.Description = "Select a folder for Export CD-DVD Data :";
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.ShowNewFolderButton = true;
            // Show the Browse For Folder dialog
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string Patchbuffer = patchCD;
                patchCD = folderBrowserDialog1.SelectedPath;
                SaveCdInfo();
                SaveCdBailment();
                patchCD = Patchbuffer;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (SavedBookInfo == false)  // If User Click On Open button and the changed Data Did Not Saved In Hard!
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
                            btnImport_Click(sender, e);
                        }
                        else
                        {
                            string PatchBuffer = patchBook;
                            patchBook = folderBrowserDialog1.SelectedPath;
                            LoadBook();
                            SavedBookInfo = false;
                            SavedNewB = true;
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
                            btnImport_Click(sender, e);
                        }
                        else
                        {
                            string PatchBuffer = patchBook;
                            patchBook = folderBrowserDialog1.SelectedPath;
                            LoadBook();
                            SavedBookInfo = false;
                            SavedNewB = true;
                        }
                    }
                }
                else if (Close == DialogResult.Cancel) return;
            }
            else if (SavedBookInfo == true)
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
                        btnImport_Click(sender, e);
                    }
                    else
                    {
                        string PatchBuffer = patchBook;
                        patchBook = folderBrowserDialog1.SelectedPath;
                        LoadBook();
                        SavedBookInfo = false;
                        SavedNewB = true;
                    }
                }
            }
        }

        private void btnImportC_Click(object sender, EventArgs e)
        {
            if (SavedCdInfo == false)  // If User Click On Open button and the changed Data Did Not Saved In Hard!
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
                            btnImportC_Click(sender, e);
                        }
                        else
                        {
                            string PatchBuffer = patchCD;
                            patchCD = folderBrowserDialog1.SelectedPath;
                            LoadCD();
                            SavedCdInfo = false;
                            SavedNewC = true;
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
                            btnImportC_Click(sender, e);
                        }
                        else
                        {
                            string PatchBuffer = patchCD;
                            patchCD = folderBrowserDialog1.SelectedPath;
                            LoadCD();
                            SavedCdInfo = false;
                            SavedNewC = true;
                        }
                    }
                }
                else if (Close == DialogResult.Cancel) return;
            }
            else if (SavedCdInfo == true)
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
                        btnImportC_Click(sender, e);
                    }
                    else
                    {
                        string PatchBuffer = patchCD;
                        patchCD = folderBrowserDialog1.SelectedPath;
                        LoadCD();
                        SavedCdInfo = false;
                        SavedNewC = true;
                    }
                }
            }
        }

        private void btnRefreshC_Click(object sender, EventArgs e)
        {
            lstDisplayCD.Items.Clear();
            lstDisplayCD.Items.Add("CD - DVD Name :");
            lstDisplayCD.Items.Add("   ");
            lstDisplayCD.Items.Add("   ");
            foreach(CdInfo name in arrCdInfo.Values)
            {
                lstDisplayCD.Items.Add(name.CdName);
            }
            StatusText = "Refresh CD-DVD Database";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lstDisplay.Items.Clear();
            lstDisplay.Items.Add("Book Name :");
            lstDisplay.Items.Add("    ");
            lstDisplay.Items.Add("    ");
            foreach (BookInfo name in arrBookInfo.Values)
            {
                lstDisplay.Items.Add(name.BookName);
            }
            StatusText = "Refresh Book Database";
        }

        private void btnClaerAll_Click(object sender, EventArgs e)
        {
            if (patchBook == "") return;
            DialogResult Clear = MessageBox.Show("Are you sure to delete All Book DataBase on Patch " +
                patchBook, "Clear Data Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);
            if (Clear == DialogResult.Cancel) return;
            else if (Clear == DialogResult.OK)
            {
                FormClearPass ClearbyPass = new FormClearPass();
                ClearbyPass.ShowDialog();
                if (ClearPass == true)
                {
                    arrBookBailment.Clear();
                    arrBookInfo.Clear();
                    lstDisplay.Items.Clear();
                    lstDisplay.Items.Add("Book Name :");
                    lstDisplay.Items.Add("    ");
                    File.Delete((patchBook + @"\BehzadBName.sys"));
                    File.Delete((patchBook + @"\BehzadBWriter.sys"));
                    File.Delete((patchBook + @"\BehzadBPrice.sys"));
                    File.Delete((patchBook + @"\BehzadBPropagator.sys"));
                    File.Delete((patchBook + @"\BehzadBIsbn.sys"));
                    File.Delete((patchBook + @"\BehzadBNumberPage.sys"));
                    File.Delete((patchBook + @"\BehzadBDate.sys"));
                    File.Delete((patchBook + @"\BehzadBTranslator.sys"));
                    File.Delete((patchBook + @"\BehzadBHaveCd.sys"));
                    File.Delete((patchBook + @"\BehzadBookBailment.sys"));
                    File.Delete((patchBook + @"\BehzadBBName.sys"));
                    File.Delete((patchBook + @"\BehzadBBDate.sys"));
                    File.Delete((patchBook + @"\BehzadBBBookName.sys"));
                    File.Delete((patchBook + @"\BehzadBBIsbn.sys"));
                    StatusText = "Removed Book Database Of Patch " + patchBook;
                    patchBook = "";
                    File.WriteAllText(@"Program library DB\PatchB.dll", "");
                    ShortCutBookStripMenuItem.Visible = false;
                    ClearPass = false;
                    SavedBookInfo = true;
                }
                else return;
            }
        }

        private void btnClearAllC_Click(object sender, EventArgs e)
        {
            if (patchCD == "") return;
            DialogResult Clear = MessageBox.Show("Are you sure to delete All CD-DVD DataBase on Patch " +
                patchCD, "Clear Data Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);
            if (Clear == DialogResult.Cancel) return;
            else if (Clear == DialogResult.OK)
            {
                FormClearPass ClearbyPass = new FormClearPass();
                ClearbyPass.ShowDialog();
                if (ClearPass == true)
                {
                    arrCdBailment.Clear();
                    arrCdInfo.Clear();
                    lstDisplayCD.Items.Clear();
                    lstDisplayCD.Items.Add("CD - DVD Name :");
                    lstDisplayCD.Items.Add("    ");
                    File.Delete((patchCD + @"\BehzadCName.sys"));
                    File.Delete((patchCD + @"\BehzadCDate.sys"));
                    File.Delete((patchCD + @"\BehzadCNumberCd.sys"));
                    File.Delete((patchCD + @"\BehzadCType.sys"));
                    File.Delete((patchCD + @"\BehzadCSpecifications.sys"));
                    File.Delete((patchCD + @"\BehzadCdBailment.sys"));
                    File.Delete((patchCD + @"\BehzadCBName.sys"));
                    File.Delete((patchCD + @"\BehzadCBDate.sys"));
                    File.Delete((patchCD + @"\BehzadCBType.sys"));
                    File.Delete((patchCD + @"\BehzadCBCdName.sys"));
                    File.Delete((patchCD + @"\BehzadCBNumberCd.sys"));
                    StatusText = "Removed CD-DVD Database Of Patch " + patchCD;
                    patchCD = "";
                    File.WriteAllText(@"Program library DB\PatchC.dll", "");
                    ShortCutCDStripMenuItem.Visible = false;
                    ClearPass = false;
                    SavedCdInfo = true;
                }
            }
        }

        private void lstDate_MouseLeave(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void lstDate_MouseEnter(object sender, EventArgs e)
        {
            DateTime Date;
            Date = DateTime.Now;
            StatusText = Date.ToString();
        }

        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            StatusText = "Add New Book ...";
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void btnBailment_MouseEnter(object sender, EventArgs e)
        {
            StatusText = "Add - Delete - Display the Bailment Book Data ...";
        }

        private void btnBailment_MouseLeave(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void btnDelete_MouseEnter(object sender, EventArgs e)
        {
            StatusText = "Remove the Book ...";
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void btnSearch_MouseEnter(object sender, EventArgs e)
        {
            StatusText = "Search and Find the Book for Display it ...";
        }

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            StatusText = "Close this window and EXIT!!!";
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void btnExitC_MouseEnter(object sender, EventArgs e)
        {
            StatusText = "Close this window and EXIT!!!";
        }

        private void btnExitC_MouseLeave(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void btnAddC_MouseEnter(object sender, EventArgs e)
        {
            StatusText = "Add New CD or DVD ...";
        }

        private void btnAddC_MouseLeave(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void btnBailmentC_MouseEnter(object sender, EventArgs e)
        {
            StatusText = "Add - Delete - Display the Bailment CD - DVD Data ...";
        }

        private void btnBailmentC_MouseLeave(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void btnDeleteC_MouseEnter(object sender, EventArgs e)
        {
            StatusText = "Remove the CD - DVD ...";
        }

        private void btnDeleteC_MouseLeave(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void btnSearchC_MouseLeave(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void btnSearchC_MouseEnter(object sender, EventArgs e)
        {
            StatusText = "Search and Find the CD - DVD for Display it ...";
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            // Set the caption to the current time.
            LabelTime.Text = DateTime.Now.ToLongTimeString();
            if (lblDot.Visible == true) lblDot.Visible = false;
            else lblDot.Visible = true;
        }

        private void btnRefresh_MouseEnter(object sender, EventArgs e)
        {
            StatusText = "Refresh Book Library Data in All Forms ...";
        }

        private void btnRefresh_MouseLeave(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void btnImport_MouseLeave(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void btnExport_MouseLeave(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void btnClaerAll_MouseLeave(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void btnBackup_MouseLeave(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void btnDisplay_MouseLeave(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void btnRefreshC_MouseLeave(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void btnImportC_MouseLeave(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void btnExportC_MouseLeave(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void btnClearAllC_MouseLeave(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void btnBackupC_MouseLeave(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void btnDisplayC_MouseLeave(object sender, EventArgs e)
        {
            StatusText = "Ready";
        }

        private void btnImport_MouseEnter(object sender, EventArgs e)
        {
            StatusText = "Import Extra Book Library Data in This DataBase ...";
        }

        private void btnRefreshC_MouseEnter(object sender, EventArgs e)
        {
            StatusText = "Refresh CD-DVD Club Data in All Forms ...";
        }

        private void btnExportC_MouseEnter(object sender, EventArgs e)
        {
            StatusText = "Export This Club Data to Other Programs ...";
        }

        private void btnExport_MouseEnter(object sender, EventArgs e)
        {
            StatusText = "Export This library Data to Other Programs ...";
        }

        private void btnImportC_MouseEnter(object sender, EventArgs e)
        {
            StatusText = "Import Extra CD-DVD Club Data in This DataBase ...";
        }

        private void btnClearAllC_MouseEnter(object sender, EventArgs e)
        {
            StatusText = "Clean All Club Data of This Program Library ...";
        }

        private void btnClaerAll_MouseEnter(object sender, EventArgs e)
        {
            StatusText = "Clean All library Data of This Program Library ...";
        }

        private void btnBackup_MouseEnter(object sender, EventArgs e)
        {
            StatusText = "Save As All Book Library Data ...";
        }

        private void btnBackupC_MouseEnter(object sender, EventArgs e)
        {
            StatusText = "Save As All CD-DVD Club Data ...";
        }

        private void btnDisplayC_MouseEnter(object sender, EventArgs e)
        {
            StatusText = "Display and PrintPreview and Print CD-DVD Club Data ...";
        }

        private void btnDisplay_MouseEnter(object sender, EventArgs e)
        {
            StatusText = "Display and PrintPreview and Print Book Library Data ...";
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized && this.Visible == true)
            {
                DialogResult Min = MessageBox.Show("Are you want to Minimise to system tray ?", "Minimize Program Library"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (Min == DialogResult.Yes)
                {
                    this.ShowInTaskbar = false;
                    this.Visible = false;
                }   
            }
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            btnExit_Click(sender, e);
        }

        private void toolStripMenuItemShow_Click(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                this.ShowInTaskbar = true;
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.ShowInTaskbar = false;
                this.Visible = false;
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void notifyIconP_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.ShowInTaskbar = true;
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void toolStripTextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (toolStripTextBoxSearch.Text == "Search a Book")
            {
                toolStripTextBoxSearch.Text = string.Empty;
                toolStripTextBoxSearch.ForeColor = Color.Black;
            }
            if (e.KeyCode == Keys.Enter) toolStripTextBoxSearchFunction(toolStripTextBoxSearch.Text, e);
        }

        private void toolStripTextBoxSearchFunction(string p, KeyEventArgs e)
        {
            FormSearch FSearch = new FormSearch();
            FSearch.Show();
            FSearch.txtBookName.Text = p.ToString();
        }

        private void toolStripTextBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (toolStripTextBoxSearch.Text == "")
            {
                toolStripTextBoxSearch.ForeColor = Color.DarkGray;
                toolStripTextBoxSearch.Text = "Search a Book";
            }
        }

        private void toolStripTextBoxSearch_Click(object sender, EventArgs e)
        {
            if (toolStripTextBoxSearch.Text == "Search a Book")
            {
                toolStripTextBoxSearch.Text = string.Empty;
                toolStripTextBoxSearch.ForeColor = Color.Black;
            }
        }

        private void toolStripTextBoxSearch_MouseLeave(object sender, EventArgs e)
        {
            if (toolStripTextBoxSearch.Text == "")
            {
                toolStripTextBoxSearch.ForeColor = Color.DarkGray;
                toolStripTextBoxSearch.Text = "Search a Book";
            }
        }

        private void toolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            FormAbout About = new FormAbout();
            About.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RunFirst();
        }
        
    }
}
