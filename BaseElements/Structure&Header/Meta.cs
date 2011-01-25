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
    /// The meta element is a generic mechanism for specifying metadata for a Web page. 
    /// Some search engines use this information.
    /// </summary>
    public class Meta : IXHTMLItem
    {
        internal const string ElementName = "meta";


        private readonly LanguageAttr language = new LanguageAttr();
        private readonly DirectionAttr direction = new DirectionAttr();

        // Base attributes
        private readonly ContentAttribute contentAttribute = new ContentAttribute();
        private readonly TNameAttribute nameAttribute = new TNameAttribute();
        

        // Advanced attributes
        private readonly HTTPEquivAttribute httpEqvAttribute = new HTTPEquivAttribute();
        private readonly SchemeAttribute schemeAttribute = new SchemeAttribute();




        /// <summary>
        /// This attribute, used in conjunction with the profile attribute in the head element, 
        /// names a scheme to be used to interpret the property's value.
        /// </summary>
        public SchemeAttribute Scheme { get { return schemeAttribute; } }


        /// <summary>
        /// This attribute may be used in place of the name attribute. 
        /// Web servers use this attribute to gather information for HTTP response message headers.
        /// </summary>
        public HTTPEquivAttribute HTTPEquvalent { get { return httpEqvAttribute; } }

        /// <summary>
        /// This attribute specifies the base language of an element's attribute values and text content.
        /// </summary>
        public LanguageAttr Language
        {
            get { return language; }
        }

        /// <summary>
        /// This attribute specifies the base direction of text. 
        /// Possible values:
        /// ltr: Left-to-right 
        /// rtl: Right-to-left
        /// </summary>
        public DirectionAttr Direction
        {
            get { return direction; }
        }

        /// <summary>
        /// The property's value.
        /// </summary>
        public ContentAttribute Content { get { return contentAttribute; } }


        /// <summary>
        /// Property name. 
        /// This attribute is required.
        /// </summary>
        public TNameAttribute Name { get { return nameAttribute; } }


        /// <summary>
        /// Specifies an absolute URL that acts as the base URL for resolving relative URLs. 
        /// This attribute is required.
        /// </summary>
        public static XNamespace XhtmlNameSpace = @"http://www.w3.org/1999/xhtml";

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

            language.ReadAttribute(xElement);
            direction.ReadAttribute(xElement);

            contentAttribute.ReadAttribute(xElement);
            nameAttribute.ReadAttribute(xElement);

            httpEqvAttribute.ReadAttribute(xElement);
            schemeAttribute.ReadAttribute(xElement);
        }

        public XNode Generate()
        {
            XElement xElement = new XElement(XhtmlNameSpace + ElementName);

            language.AddAttribute(xElement);
            direction.AddAttribute(xElement);

            contentAttribute.AddAttribute(xElement);
            nameAttribute.AddAttribute(xElement);

            httpEqvAttribute.AddAttribute(xElement);
            schemeAttribute.AddAttribute(xElement);

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
