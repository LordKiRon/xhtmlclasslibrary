using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.Attributes;
using XHTMLClassLibrary.BaseElements.Ruby;
using XHTMLClassLibrary.Exceptions;

namespace XHTMLClassLibrary.BaseElements.InlineElements
{
    /// <summary>
    /// Ruby is mechanism for adding annotations to characters of East Asian languages such as Chinese and Japanese. 
    /// These annotations typically appear in smaller typeface above or to the side of regular text, 
    /// and are meant to help with pronunciation of obscure characters or as a language learning aid.
    /// </summary>
    public class RubyElement : IInlineItem, ICommonAttributes
    {
        // Common core attributes
        private readonly ClassAttr classattr = new ClassAttr();
        private readonly IdAttribute idattr = new IdAttribute();
        private readonly TitleAttribute titleattr = new TitleAttribute();
        private readonly StyleAttribute styleAttr = new StyleAttribute();

        /// <summary>
        /// Internal containt of the element
        /// </summary>
        private readonly List<IXHTMLItem> content = new List<IXHTMLItem>();

        internal const string ElementName = "ruby";

        public static XNamespace XhtmlNameSpace = @"http://www.w3.org/1999/xhtml";

        #region Implementation of IEPubTextItem

        /// <summary>
        /// Loads the element from XNode
        /// </summary>
        /// <param name="xNode">node to load element from</param>
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

            classattr.ReadAttribute(xElement);
            idattr.ReadAttribute(xElement);
            titleattr.ReadAttribute(xElement);
            styleAttr.ReadAttribute(xElement);
        }

        private bool IsValidSubType(IXHTMLItem item)
        {
            // TODO: full check for ruby sequence
            if (item is IRubyItem)
            {
                return item.IsValid();
            }
            return false;
        }

        /// <summary>
        /// Generates element to XNode from data
        /// </summary>
        /// <returns>generated XNode</returns>
        public XNode Generate()
        {
            XElement xElement = new XElement(XhtmlNameSpace + ElementName);

            if (content.Count > 0)
            {
                foreach (var item in content)
                {
                    xElement.Add(item.Generate());
                }
            }

            classattr.AddAttribute(xElement);
            idattr.AddAttribute(xElement);
            titleattr.AddAttribute(xElement);
            styleAttr.AddAttribute(xElement);

            return xElement;
        }

        /// <summary>
        /// Checks it element data is valid
        /// </summary>
        /// <returns>true if valid</returns>
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
            if ((item != null) && IsValidSubType(item))
            {
                content.Add(item);
                item.Parent = this;
            }
            else
            {
                throw new XHTMLViolationException();
            }
        }

        public void Remove(IXHTMLItem item)
        {
            if(content.Remove(item))
            {
                item.Parent = null;
            }
        }

        public List<IXHTMLItem> SubElements()
        {
            return content;
        }

        /// <summary>
        /// Get/Set item parent in the XHTML "tree"
        /// </summary>
        public IXHTMLItem Parent { get; set; }

        #endregion

        #region Implementation of ICommonAttributes

        public ClassAttr Class
        {
            get { return classattr; }
        }

        public IdAttribute ID
        {
            get { return idattr; }
        }

        public TitleAttribute Title
        {
            get { return titleattr; } 
        }

        public StyleAttribute Style
        {
            get { return styleAttr; }
        }

        #endregion
    }
}
