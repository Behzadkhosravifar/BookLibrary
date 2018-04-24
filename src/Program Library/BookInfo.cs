using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program_Library
{
    public struct BookInfo
    {
        public string BookName;
        public string WriterName;
        public string Price;
        public string Isbn;
        public string Propagator;
        public string DateOfBook;
        public string NumberPage;
        public string Translator;
        public string HaveCd; // Yes - No
        public string Bailment;  // Yes - No
        /// <summary>
        /// Override the default ToString method
        /// </summary>
        /// <returns>String</returns>
        /// <remarks>Return the StudentInfo BookName & WriterName & ISBN</remarks>
        public override string ToString()
        {
            return Isbn + "                              " + BookName;
        }
    };
}
