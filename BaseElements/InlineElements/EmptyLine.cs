using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace XHTMLClassLibrary.BaseElements.InlineElements
{
    public class EmptyLine : BaseInlineItem // <br>
    {
        internal const string ElementName = "br";

        public override void Load(XNode xNode)
        {
            if (xNode.NodeType != XmlNodeType.Element)
            {
                throw new Exception("xNode is not of element type");
            }
            XElement xElement = (XElement) xNode;
            if (xElement.Name.LocalName != ElementName)
            {
                throw new Exception("xNode is not empty line element");
            }
            ReadAttributes(xElement);
        }

        public override XNode Generate()
        {
            XElement xElement =  new XElement(XhtmlNameSpace + ElementName);
            AddAtributes(xElement);
            return xElement;
        }

        public override bool IsValid()
        {
            return true;
        }

        /// <summary>
        /// Adds subitem to the item , only if 
        /// allowed by the rules and element can accept content
        /// </summary>
        /// <param name="item">subitem to add</param>
        public override void Add(IXHTMLItem item)
        {
            throw new Exception("This element does not contain subitems");
        }

        public override void Remove(IXHTMLItem item)
        {
            throw new Exception("This element does not contain subitems");
        }

        public override List<IXHTMLItem> SubElements()
        {
            return null;
        }
    }
}