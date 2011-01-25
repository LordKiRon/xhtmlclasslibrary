using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHTMLClassLibrary.BaseElements.InlineElements
{
    /// <summary>
    /// The sup element indicates that its contents should regarded as superscript.
    /// </summary>
    public class Sup : TextBasedElement
    {
        internal const string ElementName = "sup";

        #region Overrides of TextBasedElement

        protected override string GetElementName()
        {
            return ElementName;
        }

        #endregion

    }
}
