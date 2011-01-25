using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHTMLClassLibrary.Attributes.FlaggedAttributes
{
    public class MultipleAttribute : BaseFlagAttribute
    {
        internal string attributeName = "multiple";

        #region Overrides of BaseFlagAttribute

        public override string GetElementName()
        {
            return attributeName;
        }

        #endregion

    }
}
