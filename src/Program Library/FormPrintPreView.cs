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

namespace Program_Library
{
    public partial class FormPrintPreView : Form
    {
        public FormPrintPreView()
        {
            InitializeComponent();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            FormAbout About = new FormAbout();
            About.ShowDialog();
        }
        public string strFileName = @"Program Library DB\Print.txt";
        private void FormPrintPreView_Load(object sender, EventArgs e)
        {
            if (File.Exists(strFileName) == true)
                txtPreview.Text = System.IO.File.ReadAllText(strFileName);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            // Set the save dialog properties
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.FileName = "Print Preview Book";
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.Title = "Save Print Preview Text";
            // Show the Save file dialog and if the user clicks the 
            // Save button, save the file
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Save the file name
                strFileName = saveFileDialog1.FileName;
                // Write the contents of the text box in file
                System.IO.File.WriteAllText(strFileName, txtPreview.Text);
            }
        }

        private void FontToolStripButton_Click(object sender, EventArgs e)
        {
            // Set the FontDialog control properties
            fontDialog1.ShowColor = true;
            fontDialog1.AllowScriptChange = true;
            fontDialog1.FontMustExist = true;
            fontDialog1.MaxSize = 24;
            fontDialog1.MinSize = 1;
            fontDialog1.ShowEffects = true;
            // Show the Font dialog
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                // If the OK button was clicked set the font
                // in the text box on the form
                txtPreview.Font = fontDialog1.Font;
                // Set the color of the font in the text box
                // on the form
                txtPreview.ForeColor = fontDialog1.Color;
            }
        }

        private void ColorToolStripButton1_Click(object sender, EventArgs e)
        {
            // Show the Color dialog
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                // Set the BackColor property of the form
                this.txtPreview.ForeColor = colorDialog1.Color;
            }
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            // set it to the ActiveControl
            TextBox objTextBox = (TextBox)this.ActiveControl;
            // Copy the text to the clipboard
            objTextBox.Copy();
        }
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

        private void ZoomOutToolStripButton_Click(object sender, EventArgs e)
        {
            ZoomInToolStripButton2.Enabled = true;
            float SizeOut = txtPreview.Font.Size - 1;
            if (SizeOut <= 1) SizeOut = 1;
            string FontOut = txtPreview.Font.Name;
            txtPreview.Font = new Font(FontOut, SizeOut);
            if (SizeOut <= 1) ZoomOutToolStripButton.Enabled = false;
        }

        private void ZoomInToolStripButton2_Click(object sender, EventArgs e)
        {
            ZoomOutToolStripButton.Enabled = true;
            float SizeIn = txtPreview.Font.Size + 1;
            if (SizeIn > 24) SizeIn = 24;
            string FontIn = txtPreview.Font.Name;
            txtPreview.Font = new Font(FontIn, SizeIn);
            if (SizeIn >= 24) ZoomInToolStripButton2.Enabled = false;
        }
    }
}
