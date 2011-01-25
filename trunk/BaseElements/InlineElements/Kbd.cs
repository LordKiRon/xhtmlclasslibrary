using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHTMLClassLibrary.BaseElements.InlineElements
{
    /// <summary>
    /// The kbd element indicates input to be entered by the user.
    /// </summary>
    public class Kbd : TextBasedElement
    {
        internal const string ElementName = "kbd";

        #region Overrides of TextBasedElement

        protected override string GetElementName()
        {
            return ElementName;
        }

        #endregion
    }
}
