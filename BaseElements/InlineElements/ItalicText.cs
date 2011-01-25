using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHTMLClassLibrary.BaseElements.InlineElements
{
    /// <summary>
    /// The i element renders text in italic style.
    /// Although the i element is part of the XHTML specification, 
    /// its use is discouraged, since it has no semantic meaning and is only used for formatting. 
    /// Equivalent formatting can be achived using CSS.
    /// </summary>
    public class ItalicText : TextBasedElement
    {
        internal const string ElementName = "i";

        #region Overrides of TextBasedElement

        protected override string GetElementName()
        {
            return ElementName;
        }

        #endregion

    }
}
