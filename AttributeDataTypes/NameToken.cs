﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHTMLClassLibrary.AttributeDataTypes
{
    /// <summary>
    /// A name composed of letters, numbers, hypens, underscores or periods. 
    /// The name should start with a letter or an underscore. For example: heading-2 or _paragraph.text.
    /// </summary>
    public class NameToken
    {
        public string Value { get; set; }
    }
}
