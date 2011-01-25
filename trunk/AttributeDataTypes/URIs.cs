using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHTMLClassLibrary.AttributeDataTypes
{
    /// <summary>
    /// A space-separated list of URI values.
    /// </summary>
    public class URIs
    {
        private readonly List<URI> locations = new List<URI>();

        public string Value
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                foreach (var uri in locations)
                {
                    builder.AppendFormat("{0} ", uri.Value);
                }
                return builder.ToString();
            }

            set
            {
                locations.Clear();
                string[] ar = value.Split(' ');
                foreach (var s in ar)
                {
                    URI uri = new URI();
                    uri.Value = s;
                    locations.Add(uri);
                }
            }
        }

    }
}
