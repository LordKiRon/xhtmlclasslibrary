using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.Attributes;

namespace XHTMLClassLibrary.BaseElements.Structure_Header
{
    /// <summary>
    /// To resolve relative URLs, Web browsers will use the base URL from where the Web page was downloaded. 
    /// In some circumstances, it is necessary to instruct the Web browser to use a different base URL, 
    /// in which case the base element is used.
    /// </summary>
    public class Base : IXHTMLItem
    {
        internal const string ElementName = "base";

        // Basic attributes
        private readonly HrefAttribute hrefAttribute = new HrefAttribute();

        /// <summary>
        /// Specifies an absolute URL that acts as the base URL for resolving relative URLs. 
        /// This attribute is required.
        /// </summary>
        public static XNamespace XhtmlNameSpace = @"http://www.w3.org/1999/xhtml";


        public HrefAttribute HRef { get { return hrefAttribute; } }
        
        public void Load(XNode xNode)
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

            hrefAttribute.ReadAttribute(xElement);
        }

        public XNode Generate()
        {
            XElement xElement = new XElement(XhtmlNameSpace + ElementName);
            
            hrefAttribute.AddAttribute(xElement);

            return xElement;
        }

        public bool IsValid()
        {
            return true;
        }

        /// <summary>
        /// Adds subitem to the item , only if 
        /// allowed by the rules and element can accept content
        /// </summary>
        /// <param name="item">subitem to add</param>
        public void Add(IXHTMLItem item)
        {
            throw new Exception("This element does not contain subitems");
        }

        public void Remove(IXHTMLItem item)
        {
            throw new Exception("This element does not contain subitems");
        }

        public List<IXHTMLItem> SubElements()
        {
            return null;
        }
        /// <summary>
        /// Get/Set item parent in the XHTML "tree"
        /// </summary>
        public IXHTMLItem Parent { get; set; }
    }
}
