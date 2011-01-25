using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.Attributes;
using XHTMLClassLibrary.Attributes.Events;
using XHTMLClassLibrary.Attributes.FlaggedAttributes;

namespace XHTMLClassLibrary.BaseElements.InlineElements
{
    public class Input : BaseInlineItem
    {

        private readonly LanguageAttr language = new LanguageAttr();
        private readonly DirectionAttr direction = new DirectionAttr();

        // basic attributes
        private readonly AltAttribute altAttribute = new AltAttribute();
        private readonly NameAttribute nameAttribute = new NameAttribute();
        private readonly CheckedAttribute checkedAttribute = new CheckedAttribute();
        private readonly MaxLengthAttribute maxLenghtAttribute = new MaxLengthAttribute();
        private readonly SizeAttribute sizeAttribute = new SizeAttribute();
        private readonly InputTypeAttribute inputTypeAttribute = new InputTypeAttribute();
        private readonly ValueAttribute valueAttribute = new ValueAttribute();

        // Advanced attributes
        private readonly AcceptAttribute acceptAttribute = new AcceptAttribute();
        private readonly AccessKeyAttribute accessKeyAttrib = new AccessKeyAttribute();
        private readonly DisabledAttribute disabledAttribute = new DisabledAttribute();
        private readonly ISMapAttribute isMapAttribute = new ISMapAttribute();
        private readonly OnBlurEventAttribute onBlurEvent = new OnBlurEventAttribute();
        private readonly OnChangeEventAttribute onChange = new OnChangeEventAttribute();
        private readonly OnFocusEventAttribute onFocus = new OnFocusEventAttribute();
        private readonly OnSelectEventAttribute onSelect = new OnSelectEventAttribute();
        private readonly ReadOnlyAttribute readonlyAttribute = new ReadOnlyAttribute();
        private readonly SourceAttribute srcAttribute = new SourceAttribute();
        private readonly TabIndexAttribute tabIndexAttrib = new TabIndexAttribute();
        private readonly UseMapAttribute useMapAttribute = new UseMapAttribute();

        // Common event attributes
        private readonly OnClickEventAttribute onClick = new OnClickEventAttribute();
        private readonly OnDblClickEventAttribute onDblClick = new OnDblClickEventAttribute();
        private readonly OnMouseDownEventAttribute onMouseDown = new OnMouseDownEventAttribute();
        private readonly OnMouseUpEventAttribute onMouseUp = new OnMouseUpEventAttribute();
        private readonly OnMouseOverEventAttribute onMouseOver = new OnMouseOverEventAttribute();
        private readonly OnMouseMoveEventAttribute onMouseMove = new OnMouseMoveEventAttribute();
        private readonly OnMouseOutEventAttribute onMouseOut = new OnMouseOutEventAttribute();
        private readonly OnKeyPressEventAttribute onKeyPress = new OnKeyPressEventAttribute();
        private readonly OnKeyDownEventAttribute onKeyDown = new OnKeyDownEventAttribute();
        private readonly OnKeyUpEventAttribute onKeyUp = new OnKeyUpEventAttribute();


        internal const string ElementName = "input";

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
        /// A client-side script event that occurs when a pointing device button is clicked over an element.
        /// </summary>
        public OnClickEventAttribute OnClick
        {
            get { return onClick; }
        }


        /// <summary>
        /// A client-side script event that occurs when a pointing device button is double-clicked over an element.
        /// </summary>
        public OnDblClickEventAttribute OnDblClick { get { return onDblClick; } }


        /// <summary>
        /// A client-side script event that occurs when a pointing device button is pressed down over an element.
        /// </summary>
        public OnMouseDownEventAttribute OnMouseDown { get { return onMouseDown; } }

        /// <summary>
        /// A client-side script event that occurs when a pointing device button is released over an element.
        /// </summary>
        public OnMouseUpEventAttribute OnMouseUp { get { return onMouseUp; } }


        /// <summary>
        /// A client-side script event that occurs when a pointing device is moved onto an element.
        /// </summary>
        public OnMouseOverEventAttribute OnMouseOver { get { return onMouseOver; } }

        /// <summary>
        /// A client-side script event that occurs when a pointing device is moved within an element.
        /// </summary>
        public OnMouseMoveEventAttribute OnMouseMove { get { return onMouseMove; } }


        /// <summary>
        /// A client-side script event that occurs when a pointing device is moved away from an element.
        /// </summary>
        public OnMouseOutEventAttribute OnMouseOut { get { return onMouseOut; } }

        /// <summary>
        /// A client-side script event that occurs when a key is pressed down over an element then released.
        /// </summary>
        public OnKeyPressEventAttribute OnKeyPress { get { return onKeyPress; } }

        /// <summary>
        /// A client-side script event that occurs when a key is pressed down over an element.
        /// </summary>
        public OnKeyDownEventAttribute OnKeyDown { get { return onKeyDown; } }

        /// <summary>
        /// A client-side script event that occurs when a key is released over an element.
        /// </summary>
        public OnKeyUpEventAttribute OnKeyUp { get { return onKeyUp; } }

        /// <summary>
        /// This attribute specifies the base language of an element's attribute values and text content.
        /// </summary>
        public LanguageAttr Language
        {
            get { return language; }
        }

        /// <summary>
        /// Alternate text for controls of the type image.
        /// </summary>
        public AltAttribute Alt
        {
            get { return altAttribute; }
        }

        /// <summary>
        /// Form control name.
        /// </summary>
        public NameAttribute Name
        {
            get { return nameAttribute; }
        }

        /// <summary>
        /// When the type attribute has the value radio or checkbox, 
        /// this attribute specifies that the radio/checkbox is selected.
        /// </summary>
        public CheckedAttribute Checked
        {
            get { return checkedAttribute; }
        }

        /// <summary>
        /// When the type attribute has the value text or password, this attribute specifies the maximum number of characters the user may enter. 
        /// This number should not exceed the value specified in the size attribute.
        /// </summary>
        public MaxLengthAttribute MaxLength
        {
            get { return maxLenghtAttribute; }
        }

        /// <summary>
        /// This attribute tells the Web browser the initial width of the control. 
        /// The width is given in pixels except when the type attribute has the value text or password. 
        /// In such cases, its value is the number of characters.
        /// </summary>
        public SizeAttribute Size
        {
            get { return sizeAttribute; }
        }

        /// <summary>
        /// Type of control to create.
        /// </summary>
        public InputTypeAttribute InputType
        {
            get { return inputTypeAttribute; }
        }


        /// <summary>
        /// Accessibility key character
        /// </summary>
        public AccessKeyAttribute AccessKey { get { return accessKeyAttrib; } }

        /// <summary>
        /// A client-side script event that occurs when an element loses focus either by the pointing device or by tabbing navigation.
        /// </summary>
        public OnBlurEventAttribute OnBlur { get { return onBlurEvent; } }

        /// <summary>
        /// A client-side script event that occurs when an element receives focus either by the pointing device or by tabbing navigation.
        /// </summary>
        public OnFocusEventAttribute OnFocus { get { return onFocus; } }


        /// <summary>
        /// Position in tabbing order.
        /// </summary>
        public TabIndexAttribute TabIndex { get { return tabIndexAttrib; } }


        /// <summary>
        /// This attribute specifies a comma-separated list of content types that a server processing this form will handle correctly.
        /// </summary>
        public AcceptAttribute Accept { get { return acceptAttribute; } }


        /// <summary>
        /// Disables the control for user input. Possible value is disabled.
        /// </summary>
        public DisabledAttribute Disabled { get { return disabledAttribute; } }

        /// <summary>
        /// If present, this attribute specifies that a server-side image map should be used. Possible value is ismap.
        /// </summary>
        public ISMapAttribute ISMap { get { return isMapAttribute; } }

        /// <summary>
        /// A client-side script event that occurs when a control loses the input focus and its value is modified prior
        /// to its next receiving focus
        /// </summary>
        public OnChangeEventAttribute OnChange { get { return onChange; } }

        /// <summary>
        /// A client-side script event that occurs when a user selects some text in a text field.
        /// </summary>
        public OnSelectEventAttribute OnSelect { get { return onSelect; } }

        /// <summary>
        /// If present, this attribute prohibits changes to the value in the control. 
        /// Possible value is "readonly".
        /// </summary>
        public ReadOnlyAttribute ReadOnly { get { return readonlyAttribute; } }


        /// <summary>
        /// When the type attribute has the value image, 
        /// this attribute specifies the location of the image to be used to decorate the graphical submit button.
        /// </summary>
        public SourceAttribute Src { get { return srcAttribute; } }

        /// <summary>
        /// When the type attribute has the value image, this attribute associates the image to a client-side image map defined by a map element. 
        /// The value of this attribute must match the id attribute of the map element.
        /// </summary>
        public UseMapAttribute UseMap { get { return useMapAttribute; } }


        /// <summary>
        /// Value associated with a control.
        /// </summary>
        public ValueAttribute Value { get { return valueAttribute; } }

        #region Overrides of BaseInlineItem

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

            // Basic atributes
            altAttribute.ReadAttribute(xElement);
            nameAttribute.ReadAttribute(xElement);
            checkedAttribute.ReadAttribute(xElement);
            maxLenghtAttribute.ReadAttribute(xElement);
            sizeAttribute.ReadAttribute(xElement);
            inputTypeAttribute.ReadAttribute(xElement);
            valueAttribute.ReadAttribute(xElement);

            //Advanced attributes
            acceptAttribute.ReadAttribute(xElement);
            accessKeyAttrib.ReadAttribute(xElement);
            disabledAttribute.ReadAttribute(xElement);
            isMapAttribute.ReadAttribute(xElement);
            onBlurEvent.ReadAttribute(xElement);
            onChange.ReadAttribute(xElement);
            onFocus.ReadAttribute(xElement);
            onSelect.ReadAttribute(xElement);
            readonlyAttribute.ReadAttribute(xElement);
            srcAttribute.ReadAttribute(xElement);
            tabIndexAttrib.ReadAttribute(xElement);
            useMapAttribute.ReadAttribute(xElement);


            language.ReadAttribute(xElement);
            direction.ReadAttribute(xElement);

            onClick.ReadAttribute(xElement);
            onDblClick.ReadAttribute(xElement);
            onMouseDown.ReadAttribute(xElement);
            onMouseUp.ReadAttribute(xElement);
            onMouseOver.ReadAttribute(xElement);
            onMouseMove.ReadAttribute(xElement);
            onMouseOut.ReadAttribute(xElement);
            onKeyPress.ReadAttribute(xElement);
            onKeyDown.ReadAttribute(xElement);
            onKeyUp.ReadAttribute(xElement);
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

            //Basic attributes
            altAttribute.AddAttribute(xElement);
            nameAttribute.AddAttribute(xElement);
            checkedAttribute.AddAttribute(xElement);
            maxLenghtAttribute.AddAttribute(xElement);
            sizeAttribute.AddAttribute(xElement);
            inputTypeAttribute.AddAttribute(xElement);
            valueAttribute.AddAttribute(xElement);


            // advanced attributes
            acceptAttribute.AddAttribute(xElement);
            accessKeyAttrib.AddAttribute(xElement);
            disabledAttribute.AddAttribute(xElement);
            isMapAttribute.AddAttribute(xElement);
            onBlurEvent.AddAttribute(xElement);
            onChange.AddAttribute(xElement);
            onFocus.AddAttribute(xElement);
            onSelect.AddAttribute(xElement);
            readonlyAttribute.AddAttribute(xElement);
            srcAttribute.AddAttribute(xElement);
            tabIndexAttrib.AddAttribute(xElement);
            useMapAttribute.AddAttribute(xElement);

            language.AddAttribute(xElement);
            direction.AddAttribute(xElement);

            onClick.AddAttribute(xElement);
            onDblClick.AddAttribute(xElement);
            onMouseDown.AddAttribute(xElement);
            onMouseUp.AddAttribute(xElement);
            onMouseOver.AddAttribute(xElement);
            onMouseMove.AddAttribute(xElement);
            onMouseOut.AddAttribute(xElement);
            onKeyPress.AddAttribute(xElement);
            onKeyDown.AddAttribute(xElement);
            onKeyUp.AddAttribute(xElement);

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

        #endregion
    }
}
