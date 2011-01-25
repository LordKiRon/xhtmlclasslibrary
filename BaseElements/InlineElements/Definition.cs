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
    /// The dfn element contains the defining instance of the enclosed term.
    /// </summary>
    public class Definition : TextBasedElement
    {
        internal const string ElementName = "dfn";

        #region Overrides of TextBasedElement

        protected override string GetElementName()
        {
            return ElementName;
        }

        #endregion
    }
}
