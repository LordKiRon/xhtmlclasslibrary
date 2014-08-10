using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.Attributes;
using XHTMLClassLibrary.BaseElements.BlockElements;
using XHTMLClassLibrary.BaseElements.InlineElements;
using XHTMLClassLibrary.Exceptions;

namespace XHTMLClassLibrary.BaseElements.Structure_Header
{
    /// <summary>
    /// The head element contains information about the current document, such as its title, 
    /// keywords that may be useful to search engines, 
    /// and other data that is not considered to be document content. 
    /// This information is usually not displayed by browsers.
    /// </summary>
    public class Head : BaseContainingElement
    {
        internal const string ElementName = "head";

        private readonly LanguageAttr language = new LanguageAttr();
        private readonly DirectionAttr direction = new DirectionAttr();

        // Advanced attributes 
        private readonly ProfileAttribute profileAttribute = new ProfileAttribute();

        public static XNamespace XhtmlNameSpace = @"http://www.w3.org/1999/xhtml";



        /// <summary>
        /// A space-separated list of unique names (in the form of URI) that help search engines, 
        /// Web browsers and other devices determine how meta and link elements are encoded.
        /// </summary>
        public ProfileAttribute Profile { get { return profileAttribute; } }

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

            language.ReadAttribute(xElement);
            direction.ReadAttribute(xElement);

            // Advanced attributes
            profileAttribute.ReadAttribute(xElement);

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
            if (item is Title)
            {
                return item.IsValid();
            }
            if (item is Base)
            {
                return item.IsValid();
            }
            if (item is Link)
            {
                return item.IsValid();
            }
            if (item is Meta)
            {
                return item.IsValid();
            }
            if (item is Script)
            {
                return item.IsValid();
            }
            if (item is Style)
            {
                return item.IsValid();
            }
            if (item is EmbededObject)
            {
                return item.IsValid();
            }
            return false;
        }


        public override XNode Generate()
        {
            XElement xElement = new XElement(XhtmlNameSpace + ElementName);

            language.AddAttribute(xElement);
            direction.AddAttribute(xElement);

            // Advanced attributes
            profileAttribute.AddAttribute(xElement);

            foreach (var item in content)
            {
                xElement.Add(item.Generate());
            }

            return xElement;

        }

        public override bool IsValid()
        {
            return (content.Count(x => x is Title) <= 1);
        }

    }
}
