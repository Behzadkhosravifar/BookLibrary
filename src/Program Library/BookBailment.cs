using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program_Library
{
    public struct BookBailment
    {
        public string BookName;
        public string DateOfBailment;
        public string BailmentName;
        public string BailmentBookIsbn;  // Dont Show for User Just use by Programmer!
        /// <summary>
        /// Override the default ToString method
        /// </summary>
        /// <returns>String</returns>
        /// <remarks>Return the BailmentBookInfo BookName & UserName & ISBN & DateOfBailment </remarks>
        public override string ToString()
        {
            return BailmentName + "   (" + BookName + ")   [" + DateOfBailment + "]   (ISBN: " + BailmentBookIsbn + ")";
        }
    };
}
