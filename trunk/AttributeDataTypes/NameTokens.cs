using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHTMLClassLibrary.AttributeDataTypes
{
    /// <summary>
    /// One or more white space separated NameToken values.
    /// </summary>
    public class NameTokens
    {
        private readonly List<NameToken> tokens = new List<NameToken>();

        public string Value
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                foreach (var token in tokens)
                {
                    builder.AppendFormat("{0} ", token.Value);
                }
                return builder.ToString().TrimEnd();
            }

            set
            {
                tokens.Clear();
                string[] ar = value.Split(' ');
                foreach (var s in ar)
                {
                    NameToken token = new NameToken();
                    token.Value = s;
                    tokens.Add(token);
                }
            }
            
        }
    }
}
