using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using XHTMLClassLibrary.Exceptions;

namespace XHTMLClassLibrary.AttributeDataTypes
{
    /// <summary>
    /// A document-unique identifier. For maximum compatability, 
    /// this value should start with a letter from the English aphabet (A-Z or a-z) and 
    /// then followed by either letters, numbers, dashes, underscores or periods.
    /// </summary>
    public class Id
    {
        private string intValue = string.Empty;

        const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_";

        public string Value 
        { 
            get
            {
                return intValue;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    Regex pattern = new Regex(@"[^a-zA-Z]");
                    if ((value.Length == 0) || pattern.IsMatch(value[0].ToString()))
                    {
                        throw new XHTMLViolationException();
                    }
                    foreach (var character in value)
                    {
                        if (!validChars.Contains(character.ToString()))
                        {
                            throw new XHTMLViolationException();
                        }
                    }
                }
                intValue = value;
            }
        }
    }
}
