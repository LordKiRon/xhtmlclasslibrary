using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.Attributes;
using XHTMLClassLibrary.BaseElements.BlockElements;

namespace XHTMLClassLibrary.BaseElements.InlineElements
{
    public class PreFormated : TextBasedElement
    {
        internal const string ElementName = "pre";

        private readonly XMLSpaceAttribute _xmlspaceAttribute = new XMLSpaceAttribute();


        /// <summary>
        /// This attribute indicates if white space (extra spaces, tabs) should be preserved. 
        /// Possible value is "preserve".
        /// </summary>
        public XMLSpaceAttribute PreserveSpace { get { return _xmlspaceAttribute; } }

        protected override string GetElementName()
        {
            return ElementName;
        }
    }
}
