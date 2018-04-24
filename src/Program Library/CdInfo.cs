using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program_Library
{
    public struct CdInfo
    {
        public string CdName;
        public string Specifications;
        public string DateOfCd;
        public string NumberOfCd;
        public string Type;
        public string Bailment;  // Yes - No
        /// <summary>
        /// Override the default ToString method
        /// </summary>
        /// <returns>String</returns>
        /// <remarks>Return the CDInfo CdName & DateOfCd & Type & NumberOfCD ...</remarks>
        public override string ToString()
        {
            return "( " + NumberOfCd + " )                       " + Type + "                                            " + CdName;
        }
    };
}
