using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace XHTMLClassLibrary.BaseElements.BlockElements
{
    /// <summary>
    /// The hr element is used to separate sections of content. 
    /// Though the name of the hr element is "horizontal rule", most visual Web browsers render hr as a horizontal line.
    /// </summary>
    public class HorizontalRule : BaseBlockElement 
    {
        internal const string ElementName = "hr";

        #region Overrides of BaseBlockElement

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

        }


        /// <summary>
        /// Generates element to XNode from data
        /// </summary>
        /// <returns>generated XNode</returns>
        public override XNode Generate()
        {
            XElement xElement = new XElement(XhtmlNameSpace + ElementName);

            AddAtributes(xElement);

            return xElement;
        }

        /// <summary>
        /// Checks it element data is valid
        /// </summary>
        /// <returns>true if valid</returns>
        public override bool IsValid()
        {
            return true;
        }

        /// <summary>
        /// Adds subitem to the item , only if 
        /// allowed by the rules and element can accept content
        /// </summary>
        /// <param name="item">subitem to add</param>
        public new void Add(IXHTMLItem item)
        {
            throw new Exception("This element does not contain subitems");
        }

        public new void Remove(IXHTMLItem item)
        {
            throw new Exception("This element does not contain subitems");
        }

        public new List<IXHTMLItem> SubElements()
        {
            return null;
        }

        /// <summary>
        /// Check if element can be subelement of this element (according to XHTML rules)
        /// </summary>
        /// <param name="item">element to check</param>
        /// <returns>true if it can be subelement, false otherwise</returns>
        protected override bool IsValidSubType(IXHTMLItem item)
        {
            return false;
        }
        #endregion

    }
}
