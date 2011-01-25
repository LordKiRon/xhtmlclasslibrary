using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.Attributes;
using XHTMLClassLibrary.Attributes.FlaggedAttributes;
using XHTMLClassLibrary.Exceptions;

namespace XHTMLClassLibrary.BaseElements.FormMenuOptions
{
    /// <summary>
    /// The optgroup element is used to group the choices offered in select form controls. 
    /// Users find it easier to work with long lists if related sections are grouped together. 
    /// </summary>
    public class OptionGroup : BaseOptionItem
    {
        internal const string ElementName = "optgroup";

        /// <summary>
        /// Internal containt of the element
        /// </summary>
        private readonly List<IXHTMLItem> content = new List<IXHTMLItem>();


        // Basic attributes
        private readonly LabelAttribute labelAttribute = new LabelAttribute();

        // Advanced attributes
        private readonly DisabledAttribute disabledAttribute = new DisabledAttribute();



        /// <summary>
        /// Label for the option group.
        /// </summary>
        public LabelAttribute Label { get { return labelAttribute; } }


        /// <summary>
        /// Disables the control for user input. 
        /// Possible value is "disabled".
        /// </summary>
        public DisabledAttribute Disabled { get { return disabledAttribute; } }


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

            // Basic attributes
            labelAttribute.ReadAttribute(xElement);

            // Advanced attributes
            disabledAttribute.ReadAttribute(xElement);

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

        public override XNode Generate()
        {
            XElement xElement = new XElement(XhtmlNameSpace + ElementName);

            AddAtributes(xElement);

            // Basic attributes
            labelAttribute.AddAttribute(xElement);

            // Advanced attributes
            disabledAttribute.AddAttribute(xElement);

            if (content.Count > 0)
            {
                foreach (var item in content)
                {
                    xElement.Add(item.Generate());
                }
            }
            

            return xElement;
        }

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
            if ( content.Remove(item) )
            {
                item.Parent = null;
            }
        }

        public override List<IXHTMLItem> SubElements()
        {
            return content;
        }

        private bool IsValidSubType(IXHTMLItem item)
        {
            if (item is Option)
            {
                return item.IsValid();
            }
            return false;
        }
    }
}
