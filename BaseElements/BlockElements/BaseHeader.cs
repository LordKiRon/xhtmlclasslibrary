using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.BaseElements.InlineElements;
using XHTMLClassLibrary.Exceptions;

namespace XHTMLClassLibrary.BaseElements.BlockElements
{
    public interface IHeader
    {
        
    }

    /// <summary>
    /// The elements h1 to h6 group the contents of a document into sections, and briefly describe the topic of each section. 
    /// There are six levels of headings, h1 being the most important and h6 the least important.
    /// </summary>
    public abstract class BaseHeader : BaseBlockElement  , IHeader
    {
        protected abstract string GetElementName();

        public override void Load(XNode xNode)
        {
            if (xNode.NodeType != XmlNodeType.Element)
            {
                throw new Exception("xNode is not of element type");
            }
            XElement xElement = (XElement)xNode;
            if (xElement.Name.LocalName != GetElementName())
            {
                throw new Exception(string.Format("xNode is not {0} element", GetElementName()));
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
            if (item is IInlineItem)
            {
                return item.IsValid();
            }
            if (item is SimpleEPubText)
            {
                return item.IsValid();
            }
            return false;
        }

        public override XNode Generate()
        {
            XElement xElement = new XElement(XhtmlNameSpace + GetElementName());

            AddAtributes(xElement);

            foreach (var item in content)
            {
                xElement.Add(item.Generate());
            }
            return xElement;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
