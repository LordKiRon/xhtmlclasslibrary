using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XHTMLClassLibrary.BaseElements.InlineElements
{
    // this element is deprecated and should NOT be used in XHTML, use <del> instead
    public class Strike : TextBasedElement
    {
        internal const string ElementName = "strike";
        protected override string GetElementName()
        {
            return ElementName;
        }
    }
}
