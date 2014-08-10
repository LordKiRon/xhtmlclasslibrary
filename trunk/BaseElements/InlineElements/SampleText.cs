using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHTMLClassLibrary.BaseElements.InlineElements
{
    /// <summary>
    /// The samp element is used to designate sample output from programs, scripts, etc.
    /// </summary>
    public class SampleText : TextBasedElement
    {
        internal const string ElementName = "samp";

        #region Overrides of TextBasedElement

        protected override string GetElementName()
        {
            return ElementName;
        }

        #endregion

    }
}
