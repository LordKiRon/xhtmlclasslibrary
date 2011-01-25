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
    /// An acronym is a word formed from the initial letters of a series of words. 
    /// The acronym element identifies acronyms, and can help assistive technologies to correctly pronounce the acronym.
    /// </summary>
    public class Acronym : TextBasedElement
    {
        internal const string ElementName = "acronym";

        #region Overrides of TextBasedElement

        protected override string GetElementName()
        {
            return ElementName;
        }

        #endregion

    }
}
