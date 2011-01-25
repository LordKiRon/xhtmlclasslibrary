using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHTMLClassLibrary.AttributeDataTypes
{
    /// <summary>
    /// A space-separated list of character encodings.
    /// </summary>
    public class Charsets
    {
        private readonly List<Charset> charsets = new List<Charset>();

        public string Value
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                foreach (var charset in charsets)
                {
                    builder.AppendFormat("{0} ",charset.Value);
                }
                return builder.ToString();
            }

            set
            {
                charsets.Clear();
                string[] ar = value.Split(' ');
                foreach (var s in ar)
                {
                    Charset charset = new Charset();
                    charset.Value = s;
                    charsets.Add(charset);
                }
            }
        }
    }
}
