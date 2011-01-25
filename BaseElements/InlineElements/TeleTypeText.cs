using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHTMLClassLibrary.BaseElements.InlineElements
{
    /// <summary>
    /// The tt element renders text in a teletype or a monospaced font.
    /// Although the tt element is part of the spec, its use is discouraged, because the element has no semantic meaning and is used only for formatting. 
    /// Equivalent formatting can be achieved using CSS.
    /// </summary>
    public class TeleTypeText : TextBasedElement
    {
        internal const string ElementName = "tt";

        #region Overrides of TextBasedElement

        protected override string GetElementName()
        {
            return ElementName;
        }

        #endregion
    }
}
