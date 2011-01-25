using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHTMLClassLibrary.BaseElements.InlineElements
{
    /// <summary>
    /// The var element is used to indicate an instance of a computer code variable or program argument.
    /// </summary>
    public class Var : TextBasedElement
    {
        internal const string ElementName = "var";

        #region Overrides of TextBasedElement

        protected override string GetElementName()
        {
            return ElementName;
        }

        #endregion
    }
}
