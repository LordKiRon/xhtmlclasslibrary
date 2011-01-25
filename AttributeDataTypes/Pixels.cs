﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHTMLClassLibrary.AttributeDataTypes
{
    /// <summary>
    /// The value is an integer that represents the number of pixels of the canvas (screen, paper). 
    /// Thus, the value "50" means fifty pixels.
    /// </summary>
    public class Pixels
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
                if (int.TryParse(value, out temp))
                {
                    number = temp;
                }
            }
        }

    }
}
