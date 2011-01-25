using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using XHTMLClassLibrary.Attributes;
using XHTMLClassLibrary.BaseElements.InlineElements;
using XHTMLClassLibrary.Exceptions;

namespace XHTMLClassLibrary.BaseElements.BlockElements
{
    public class PreFormated : BaseBlockElement
    {
        internal const string ElementName = "pre";

        private readonly XMLSpaceAttribute xmlspaceAttribute = new XMLSpaceAttribute();


        /// <summary>
        /// This attribute indicates if white space (extra spaces, tabs) should be preserved. 
        /// Possible value is "preserve".
        /// </summary>
        public XMLSpaceAttribute PreserveSpace { get { return xmlspaceAttribute; } }

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

            xmlspaceAttribute.ReadAttribute(xElement);

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
                // TODO: check at any depth
                if (item is Image)
                {
                    return false;
                }
                if (item is EmbededObject)
                {
                    return false;
                }
                if (item is BigText)
                {
                    return false;
                }
                if (item is SmallText)
                {
                    return false;
                }
                if (item is Sub)
                {
                    return false;
                }
                if (item is Sup)
                {
                    return false;
                }
                return item.IsValid();
            }
            if (item is SimpleEPubText)
            {
                return item.IsValid();
            }
            return false;
        }


        /// <summary>
        /// Generates element to XNode from data
        /// </summary>
        /// <returns>generated XNode</returns>
        public override XNode Generate()
        {
            XElement xElement = new XElement(XhtmlNameSpace + ElementName);

            AddAtributes(xElement);
            xmlspaceAttribute.AddAttribute(xElement);

            foreach (var item in content)
            {
                xElement.Add(item.Generate());
            }
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

        #endregion

    }
}
