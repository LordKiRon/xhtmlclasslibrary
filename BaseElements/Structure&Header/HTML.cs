using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.AttributeDataTypes;
using XHTMLClassLibrary.Attributes;
using XHTMLClassLibrary.BaseElements.BlockElements;
using XHTMLClassLibrary.Exceptions;

namespace XHTMLClassLibrary.BaseElements.Structure_Header
{
    public class HTML :BaseContainingElement
    {
        private class XmlNsAttribute : BaseAttribute
        {
            public override void AddAttribute(XElement xElement)
            {
                xElement.Add(new XAttribute("xmlns", @"http://www.w3.org/1999/xhtml"));
            }

            public override void ReadAttribute(XElement element)
            {
                
            }

            public override string Value
            {
                get { throw new NotImplementedException(); }
                set { throw new NotImplementedException(); }
            }
        }

        public class VersionAttribute : BaseAttribute
        {
            private Text attrObject = new Text();
            internal string attributeName = "version";

            public override void AddAttribute(XElement xElement)
            {
                if (!hasValue)
                {
                    return;
                }
                xElement.Add(new XAttribute(attributeName, attrObject.Value));

            }

            public override void ReadAttribute(XElement element)
            {
                hasValue = false;
                attrObject = null;
                XAttribute xObject = element.Attribute(attributeName);
                if (xObject != null)
                {
                    attrObject = new Text();
                    attrObject.Value = xObject.Value;
                    hasValue = true;
                }
            }

            public override string Value
            {
                get { throw new NotImplementedException(); }
                set { throw new NotImplementedException(); }
            }
        }

        internal const string ElementName = "html";

        private readonly LanguageAttr language = new LanguageAttr();
        private readonly DirectionAttr direction = new DirectionAttr();

        private readonly XmlNsAttribute XhtmlNameSpaceAttribute = new XmlNsAttribute();
        private readonly VersionAttribute versionAttribute = new VersionAttribute();


        public static XNamespace XhtmlNameSpace = @"http://www.w3.org/1999/xhtml";


        /// <summary>
        /// This attribute has been deprecated (made outdated). 
        /// It is redundant, because version information is now provided by the DOCTYPE.
        /// </summary>
        public VersionAttribute Version { get {return versionAttribute;}}

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

            // XhtmlNameSpaceAttribute.ReadAttribute(xElement); - no need to read , always the same value should be there
            versionAttribute.ReadAttribute(xElement);


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
            if (content.Count >= 2) // no more than two sub elements
            {
                return false;
            }
            if (content.Count == 0) // head have to be first
            {
                if (!(item is Head)  )
                {
                    return false;
                }
            }
            if (content.Count == 1) // body have to be second
            {
                if (!(item is Body)  )
                {
                    return false;
                }
            }

            return item.IsValid();
        }

        public override XNode Generate()
        {
            XElement xElement = new XElement(XhtmlNameSpace + ElementName);

            XhtmlNameSpaceAttribute.AddAttribute(xElement);
            versionAttribute.AddAttribute(xElement);

            language.AddAttribute(xElement);
            direction.AddAttribute(xElement);

            foreach (var item in content)
            {
                xElement.Add(item.Generate());
            }


            return xElement;

        }

        public override bool IsValid()
        {
            if (content.Count != 2)
            {
                return false;
            }
            if (!(content[0] is Head))
            {
                return false;
            }
            if (!(content[1] is Body))
            {
                return false;
            }
            return (content[0].IsValid() && content[1].IsValid());
        }
    }
}
