using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHTMLClassLibrary.AttributeDataTypes
{
    /// <summary>
    ///     Comma separated list of coordinates to use in defining areas. For example: 0,0,118,28.
    /// </summary>
    public class Coords
    {
        private readonly List<int> coords = new List<int>();

        public string Value
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                foreach (var content in coords)
                {
                    builder.AppendFormat("{0},", content);
                }
                // remove last one
                builder.Remove(builder.Length - 1, 1);
                return builder.ToString();
            }

            set
            {
                coords.Clear();
                string[] ar = value.Split(',');
                foreach (var s in ar)
                {
                    coords.Add(int.Parse(s));
                }
            }
            
        }
    }
}
