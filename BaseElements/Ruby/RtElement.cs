using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.Attributes.RubyAttributes;
using XHTMLClassLibrary.BaseElements.InlineElements;
using XHTMLClassLibrary.Exceptions;

namespace XHTMLClassLibrary.BaseElements.Ruby
{
    /// <summary>
    /// The rt element contains ruby text annotations.
    /// </summary>
    public class RtElement : BaseRubyItem
    {
        /// <summary>
        /// Internal containt of the element
        /// </summary>
        private readonly List<IXHTMLItem> content = new List<IXHTMLItem>();

        internal const string ElementName = "rt";

        // Basic attribute 
        private readonly RbSpanAttribute rbSpanAttribute = new RbSpanAttribute();

        #region Overrides of BaseRubyItem

        /// <summary>
        /// This attribute is used to indicate that a single rt element spans (is associated with) multiple rb elements. 
        /// This is similar to the colspan attribute of the th and td elements in tables.
        /// </summary>
        public RbSpanAttribute RbSpan { get { return rbSpanAttribute; } }

        /// <summary>
        /// Loads the element from XNode
        /// </summary>
        /// <param name="xNode">node to load element from</param>
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

        private bool IsValidSubType(IXHTMLItem item)
        {
            if (item is SimpleEPubText)
            {
                return item.IsValid();
            }
            if (item is IInlineItem)
            {
                if (item is RubyElement)
                {
                    return false;
                }
                return item.IsValid();
            }
            return false;
        }

        /// <summary>
        /// Generates element to XNode from data
        /// </summary>
        /// <returns>
        /// generated XNode
        /// </returns>
        public override XNode Generate()
        {
            XElement xElement = new XElement(XhtmlNameSpace + ElementName);

            AddAtributes(xElement);

            if (content.Count > 0)
            {
                foreach (var item in content)
                {
                    xElement.Add(item.Generate());
                }
            }
            return xElement;
        }

        /// <summary>
        /// Checks it element data is valid
        /// </summary>
        /// <returns>
        /// true if valid
        /// </returns>
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

        public override void Remove(IXHTMLItem item)
        {
            if(content.Remove(item))
            {
                item.Parent = null;
            }
        }

        public override List<IXHTMLItem> SubElements()
        {
            return content;
        }

        #endregion
    }
}
