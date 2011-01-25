using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.Attributes;
using XHTMLClassLibrary.Attributes.Events;
using XHTMLClassLibrary.Attributes.FlaggedAttributes;
using XHTMLClassLibrary.Exceptions;

namespace XHTMLClassLibrary.BaseElements.InlineElements
{
    /// <summary>
    /// The button element is used to create button controls for forms. 
    /// Buttons created using the button element are similar in functionality to buttons created using the input element, 
    /// but offer greater rendering options.
    /// </summary>
    public class Button : BaseInlineItem
    {

        private enum ButtonTypeEnum
        {
            Invalid,
            Submit,
            Reset,
            Button,
        }

        /// <summary>
        /// Used to store "shape" atrtribute data
        /// </summary>
        public class ButtonTypeClass
        {
            private ButtonTypeEnum buttonType = ButtonTypeEnum.Invalid;

            public string Value
            {
                get
                {
                    switch (buttonType)
                    {
                        case ButtonTypeEnum.Reset:
                            return "reset";
                        case ButtonTypeEnum.Button:
                            return "button";
                        case ButtonTypeEnum.Submit:
                            return "submit";
                    }
                    return string.Empty;
                }

                set
                {
                    switch (value.ToLower())
                    {
                        case "reset":
                            buttonType = ButtonTypeEnum.Reset;
                            break;
                        case "button":
                            buttonType = ButtonTypeEnum.Button;
                            break;
                        case "submit":
                            buttonType = ButtonTypeEnum.Submit;
                            break;
                        default:
                            buttonType = ButtonTypeEnum.Invalid;
                            break;
                    }
                }
            }
        }


        /// <summary>
        /// Internal containt of the element
        /// </summary>
        private readonly List<IXHTMLItem> content = new List<IXHTMLItem>();

        // Basic attributes
        private readonly NameAttribute nameAttribute = new NameAttribute();
        private readonly ValueAttribute valueAttribute = new ValueAttribute();

        private readonly LanguageAttr language = new LanguageAttr();
        private readonly DirectionAttr direction = new DirectionAttr();



        // advanced attributes
        private readonly AccessKeyAttribute accessKeyAttrib = new AccessKeyAttribute();
        private readonly OnBlurEventAttribute onBlurEvent = new OnBlurEventAttribute();
        private readonly OnFocusEventAttribute onFocus = new OnFocusEventAttribute();
        private readonly TabIndexAttribute tabIndexAttrib = new TabIndexAttribute();
        private readonly DisabledAttribute disabledAttribute = new DisabledAttribute();

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


#region public_attributes

        /// <summary>
        /// Disables a form control. Possible value is "disabled".
        /// </summary>
        public DisabledAttribute Disabled { get { return disabledAttribute; } }

        /// <summary>
        /// Value associated with this control.
        /// </summary>
        public ValueAttribute ButtonValue { get { return valueAttribute; } }

        /// <summary>
        /// Form control name
        /// </summary>
        public NameAttribute Name { get { return nameAttribute; } }

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
        /// This attribute declares the type of the button. Possible values:
        /// * submit: Creates a submit button. This is the default value.
        /// * reset: Creates a reset button.
        /// * button: Creates a push button.
        /// </summary>
        public ButtonTypeClass ButtonType { get; set; }

        #endregion

        internal const string ElementName = "button";

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

            // Basic attributes
            nameAttribute.ReadAttribute(xElement);
            ButtonType = null;
            XAttribute xShape = xElement.Attribute("type");
            if (xShape != null)
            {
                ButtonType = new ButtonTypeClass();
                ButtonType.Value = xShape.Value;
            }
            valueAttribute.ReadAttribute(xElement);


            language.ReadAttribute(xElement);
            direction.ReadAttribute(xElement);

            //Advanced attributes
            accessKeyAttrib.ReadAttribute(xElement);
            onBlurEvent.ReadAttribute(xElement);
            onFocus.ReadAttribute(xElement);
            tabIndexAttrib.ReadAttribute(xElement);
            disabledAttribute.ReadAttribute(xElement);

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

            content.Clear();
            IEnumerable<XNode> descendants = xElement.Nodes();
            foreach (var node in descendants)
            {
                IXHTMLItem item = ElementFactory.CreateElement(node);
                if ((item != null) && IsValidSubType(item)) // element can't contain some specific elements
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

        private static bool IsValidSubType(object ob)
        {
            /// TODO: Add more tipes 
            /// # Block elements, except form and fieldset, at any depth
            /// # Inline elements, except button, input, label, select, and textarea, at any depth
            if (ob is Button)
            {
                return false;
            }
            return true;
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

            // Basic attributes
            nameAttribute.AddAttribute(xElement);
            if (ButtonType != null)
            {
                xElement.Add(new XAttribute("type", ButtonType.Value));
            }
            valueAttribute.AddAttribute(xElement);


            language.AddAttribute(xElement);
            direction.AddAttribute(xElement);

            // advanced attributes
            accessKeyAttrib.AddAttribute(xElement);
            onBlurEvent.AddAttribute(xElement);
            onFocus.AddAttribute(xElement);
            tabIndexAttrib.AddAttribute(xElement);
            disabledAttribute.AddAttribute(xElement);

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

            foreach (var item in content)
            {
                xElement.Add(item.Generate());
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
