using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.Attributes;
using XHTMLClassLibrary.Attributes.FlaggedAttributes;

namespace XHTMLClassLibrary.BaseElements.FormMenuOptions
{
    /// <summary>
    /// The option element represents a choice offered by select form controls.
    /// </summary>
    public class Option : BaseOptionItem
    {
        internal const string ElementName = "option";

        private readonly SimpleEPubText optionText = new SimpleEPubText();

        // Basic attributes
        private readonly SelectedAttribute  selectedAttribute = new SelectedAttribute();
        private readonly ValueAttribute valueAttribute = new ValueAttribute();

        // Advanced attributes
        private readonly DisabledAttribute disabledAttribute = new DisabledAttribute();
        private readonly LabelAttribute labelAttribute = new LabelAttribute();

        /// <summary>
        /// The script text itself
        /// </summary>
        public SimpleEPubText OptionText { get { return optionText; } }


        /// <summary>
        /// When set, this attribute specifies that an option is pre-selected. 
        /// Possible value is "selected".
        /// </summary>
        public SelectedAttribute Selected { get { return selectedAttribute; } }

        /// <summary>
        /// Value associated with a selection option.
        /// </summary>
        public ValueAttribute Value { get { return valueAttribute; } }

        /// <summary>
        /// Disables an option in a list of selectable options. 
        /// Possible value is "disabled".
        /// </summary>
        public DisabledAttribute Disabled { get { return disabledAttribute; } }

        /// <summary>
        /// Shorter label.
        /// </summary>
        public LabelAttribute Label { get { return labelAttribute; } }

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
            selectedAttribute.ReadAttribute(xElement);
            valueAttribute.ReadAttribute(xElement);

            // Advanced attributes
            disabledAttribute.ReadAttribute(xElement);
            labelAttribute.ReadAttribute(xElement);

            optionText.Load(xNode);
        }

        public override XNode Generate()
        {
            XElement xElement = new XElement(XhtmlNameSpace + ElementName);

            AddAtributes(xElement);

            // Basic attributes
            selectedAttribute.AddAttribute(xElement);
            valueAttribute.AddAttribute(xElement);

            // Advanced attributes
            disabledAttribute.AddAttribute(xElement);
            labelAttribute.AddAttribute(xElement);

            xElement.Add(optionText.Generate());
            
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
            throw new Exception("This element does not contain subitems");
        }

        public override void Remove(IXHTMLItem item)
        {
            throw new Exception("This element does not contain subitems");
        }

        public override List<IXHTMLItem> SubElements()
        {
            return null;
        }
    }
}
