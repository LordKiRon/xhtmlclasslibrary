using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.BaseElements.InlineElements;
using XHTMLClassLibrary.BaseElements.ListElements;
using XHTMLClassLibrary.Exceptions;

namespace XHTMLClassLibrary.BaseElements.BlockElements
{
    /// <summary>
    /// The dl element is used to create a list where each item in the list comprises two parts: a term and a description. 
    /// A glossary of terms is a typical example of a definition list, 
    /// where each item consists of the term being defined and a definition of the term.
    /// </summary>
    public class DefinitionList : BaseBlockElement
    {
        internal const string ElementName = "dl";


        public override void Load(XNode xNode)
        {
            if (xNode.NodeType != XmlNodeType.Element)
            {
                throw new Exception("xNode is not of element type");
            }
            XElement xElement = (XElement)xNode;
            if (xElement.Name.LocalName != ElementName)
            {
                throw new Exception(string.Format("xNode is not {0} element", ElementName));
            }

            ReadAttributes(xElement);

            content.Clear();
            IEnumerable<XNode> descendants = xElement.Nodes();
            foreach (var node in descendants)
            {
                IXHTMLItem item = ElementFactory.CreateElement(node);
                if ((item != null) && IsValidSubType(item))
                {
                    try
                    {
                        item.Load(node);
                        content.Add(item);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }

        }

        protected override bool IsValidSubType(IXHTMLItem item)
        {
            if (item is DefinitionDescription)
            {
                return item.IsValid();
            }
            if (item is DefinitionTerms)
            {
                return item.IsValid();
            }
            return false;
        }

        public override XNode Generate()
        {
            XElement xElement = new XElement(XhtmlNameSpace + ElementName);

            AddAtributes(xElement);

            foreach (var item in content)
            {
                xElement.Add(item.Generate());
            }
            return xElement;
        }

        public override bool IsValid()
        {
            return (content.Count > 0);
        }
    }
}
