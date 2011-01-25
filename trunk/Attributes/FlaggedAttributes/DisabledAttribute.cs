using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XHTMLClassLibrary.AttributeDataTypes;

namespace XHTMLClassLibrary.Attributes.FlaggedAttributes
{
    public class DisabledAttribute : BaseFlagAttribute
    {

        internal string attributeName = "disabled";

        #region Overrides of BaseFlagAttribute

        public override string GetElementName()
        {
            return attributeName;
        }

        #endregion
    }
}