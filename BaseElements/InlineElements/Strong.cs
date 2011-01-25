using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHTMLClassLibrary.BaseElements.InlineElements
{
    /// <summary>
    /// The strong element is used to indicate stronger emphasis.
    /// </summary>
    public class Strong : TextBasedElement
    {
        internal const string ElementName = "strong";

        #region Overrides of TextBasedElement

        protected override string GetElementName()
        {
            return ElementName;
        }

        #endregion
    }
}
