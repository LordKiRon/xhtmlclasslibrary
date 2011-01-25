using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHTMLClassLibrary.Attributes.FlaggedAttributes
{
    public class DeferAttribute : BaseFlagAttribute
    {
        internal string attributeName = "defer";

        public override string GetElementName()
        {
            return attributeName;
        }
    }
}
