using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program_Library
{
    public struct CdBailment
    {
        public string CdName;
        public string DateOfBailment;
        public string BailmentName;
        public string BailmentCdType;  // Dont Show for User Just use by Programmer!
        public string NumberCd;
        /// <summary>
        /// Override the default ToString method
        /// </summary>
        /// <returns>String</returns>
        /// <remarks>Return the StudentInfo BookName & WriterName & ISBN & Bailment & Price ...</remarks>
        public override string ToString()
        {
            return BailmentName + "    (" + CdName + ")    [" + DateOfBailment + "]    Number CD = " + NumberCd;
        }
    };
}
