using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHTMLClassLibrary.BaseElements.InlineElements
{
    /// <summary>
    /// The small element renders text in a small font.
    /// Although the small element is part of the XHTML specification, its use is discouraged, 
    /// because the element has no semantic meaning and is used only for formatting. 
    /// Equivalent formatting can be achieved using CSS.
    /// </summary>
    public class SmallText : TextBasedElement
    {
        internal const string ElementName = "small";

        #region Overrides of TextBasedElement

        protected override string GetElementName()
        {
            return ElementName;
        }

        #endregion
    }
}
