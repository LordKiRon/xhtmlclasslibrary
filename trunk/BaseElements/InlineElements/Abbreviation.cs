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
    /// An abbreviation is a shortened form of a word or phrase. 
    /// The abbr element is used to identify an abbreviation,
    /// and can help assistive technologies to correctly pronounce abbreviated text.
    /// </summary>
    public class Abbreviation : TextBasedElement
    {
        internal const string ElementName = "abbr";

        #region Overrides of TextBasedElement

        protected override string GetElementName()
        {
            return ElementName;
        }

        #endregion
    }
}
