using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHTMLClassLibrary.AttributeDataTypes
{
    /// <summary>
    ///     One or more digits.
    /// </summary>
    public class Number
    {
        private int? number = null;

        public string Value
        {
            get
            {
                if (number.HasValue)
                {
                    return number.ToString();
                }
                return string.Empty;
            }

            set
            {
                number = null;
                int temp;
                if(int.TryParse(value, out temp))
                {
                    number = temp;
                }
            }
        }
    }
}
