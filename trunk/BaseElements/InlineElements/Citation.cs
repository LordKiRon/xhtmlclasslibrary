using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.Attributes;
using XHTMLClassLibrary.Attributes.Events;

namespace XHTMLClassLibrary.BaseElements.InlineElements
{
    /// <summary>
    /// The cite element contains a citation or reference to another source.
    /// </summary>
    public class Citation : TextBasedElement
    {
        internal const string ElementName = "cite";

        #region Overrides of TextBasedElement

        protected override string GetElementName()
        {
            return ElementName;
        }

        #endregion
    }
}
