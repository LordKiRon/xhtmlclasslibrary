using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.Attributes;
using XHTMLClassLibrary.BaseElements.BlockElements;

namespace XHTMLClassLibrary.BaseElements.Structure_Header
{
    /// <summary>
    /// The style element can contain CSS rules (called embedded CSS) or 
    /// a URL that leads to a file containing CSS rules (called external CSS).
    /// </summary>
    public class Style : IXHTMLItem
    {
        internal const string ElementName = "style";

        private readonly SimpleEPubText content = new SimpleEPubText();

        public static XNamespace XhtmlNameSpace = @"http://www.w3.org/1999/xhtml";

        // Basic attributes 
        private readonly TitleAttribute titleattr = new TitleAttribute();
        private readonly MediaAttribute mediaAttribute = new MediaAttribute();
        private readonly ContentTypeAttribute typeAttribute = new ContentTypeAttribute();


        // Advanced attributes
        private readonly XMLSpaceAttribute spaceAttribute = new XMLSpaceAttribute();

        private readonly LanguageAttr language = new LanguageAttr();
        private readonly DirectionAttr direction = new DirectionAttr();


        public SimpleEPubText Content
        {
            get { return content; }
        }

        /// <summary>
        /// This attribute indicates if white space (extra spaces, tabs) should be preserved. 
        /// Possible value is "preserve".
        /// </summary>
        public XMLSpaceAttribute PreserveSpace { get { return spaceAttribute; } }

        /// <summary>
        /// This attribute specifies the intended destination medium for style information. 
        /// It may be a single media descriptor or a comma-separated list. 
        /// The default value for this attribute is screen.
        /// </summary>
        public MediaAttribute Media { get { return mediaAttribute; } }

        /// <summary>
        /// This attribute offers advisory information
        /// </summary>
        public TitleAttribute Title
        {
            get { return titleattr; }
        }

        /// <summary>
        /// This attribute specifies the style sheet language of the element's contents. 
        /// The style sheet language is specified as a content type. 
        /// For example: text/css. 
        /// This attribute is required.
        /// </summary>
        public ContentTypeAttribute Type { get { return typeAttribute; } }

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
        /// This attribute specifies the base language of an element's attribute values and text content.
        /// </summary>
        public LanguageAttr Language
        {
            get { return language; }
        }


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

            mediaAttribute.ReadAttribute(xElement);
            titleattr.ReadAttribute(xElement);
            typeAttribute.ReadAttribute(xElement);

            spaceAttribute.ReadAttribute(xElement);

            language.ReadAttribute(xElement);
            direction.ReadAttribute(xElement);

            content.Load(xNode);
        }

        public XNode Generate()
        {
            XElement xElement = new XElement(XhtmlNameSpace + ElementName);

            mediaAttribute.AddAttribute(xElement);
            titleattr.AddAttribute(xElement);
            typeAttribute.AddAttribute(xElement);

            spaceAttribute.AddAttribute(xElement);

            language.AddAttribute(xElement);
            direction.AddAttribute(xElement);

            xElement.Add(content.Generate());
            return xElement;

        }

        public bool IsValid()
        {
            return typeAttribute.HasValue();
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
