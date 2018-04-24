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
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            // Create new links using the Add method of the LinkCollection class.
            // Underline the appropriate words in the LinkLabel's Text property.
            // The words 'Register', 'Microsoft', and 'MSN' will 
            // all be underlined and behave as hyperlinks.

            // First check that the Text property is long enough to accommodate
            // the desired hyperlinked areas.  If it's not, don't add hyperlinks.
            if (this.linkLabel1.Text.Length >= 17)
            {
                // Below Code mean's this.linkLabel1.Links.Add(0, 17, "www.Azerbaycan.ir");
                this.linkLabel1.Links[0].LinkData = "www.Azerbaycan.ir";  
            }
            if (this.linkLabel2.Text.Length >= 20)
            {
                this.linkLabel2.Links[0].LinkData = "mailto:Behzad.kh.2006@Gmail.com";
            }
            btnOk.Focus();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Determine which link was clicked within the LinkLabel.
            this.linkLabel1.Links[linkLabel1.Links.IndexOf(e.Link)].Visited = true;

            // Display the appropriate link based on the value of the 
            // LinkData property of the Link object.
            string target = e.Link.LinkData as string;

            // If the value looks like a URL, navigate to it.
            // Otherwise, display it in a message box.
            if (null != target && target.StartsWith("www"))
            {
                System.Diagnostics.Process.Start(target);
            }
            else
            {
                MessageBox.Show("Item clicked: " + target);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel2.Links[linkLabel2.Links.IndexOf(e.Link)].Visited = true;
            string target2 = e.Link.LinkData as string;
            if (null != target2)
            {
                System.Diagnostics.Process.Start(target2);
            }
            else
            {
                MessageBox.Show("Item clicked: " + target2);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
