using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XHTMLClassLibrary.BaseElements.InlineElements
{
    public class Strike : TextBasedElement
    {
        internal const string ElementName = "strike";
        protected override string GetElementName()
        {
            return ElementName;
        }
    }
}
