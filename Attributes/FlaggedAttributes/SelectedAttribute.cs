using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHTMLClassLibrary.Attributes.FlaggedAttributes
{
    public class SelectedAttribute : BaseFlagAttribute
    {
        internal string attributeName = "selected";

        #region Overrides of BaseFlagAttribute

        public override string GetElementName()
        {
            return attributeName;
        }

        #endregion
    }
}
