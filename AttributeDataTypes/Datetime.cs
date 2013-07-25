using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace XHTMLClassLibrary.AttributeDataTypes
{
    /// <summary>
    ///     Date and time information in the ISO-8601 format. For example: YYYY-MM-DDThh:mm:ss.
    /// </summary>
    public class Datetime
    {
        private DateTime date = DateTime.MinValue;
        public string Value
        {
            get
            {
                return date.ToString("O");
            }
            set
            {
                date = DateTime.MinValue;
                try
                {
                    date = DateTime.Parse(value);
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
