using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.Attributes;
using XHTMLClassLibrary.Attributes.Events;
using XHTMLClassLibrary.Attributes.FlaggedAttributes;
using XHTMLClassLibrary.BaseElements.BlockElements;

namespace XHTMLClassLibrary.BaseElements.MapAreas
{
    /// <summary>
    /// The area element identifies geometric regions of a client-side image map, and provides a hyperlink for each region.
    /// </summary>
    public class Area : IXHTMLItem, ICommonAttributes
    {
        public static XNamespace XhtmlNameSpace = @"http://www.w3.org/1999/xhtml";

        private readonly LanguageAttr language = new LanguageAttr();
        private readonly DirectionAttr direction = new DirectionAttr();

        // Base attributes 
        private readonly AltAttribute altAttribute = new AltAttribute();
        private readonly CoordinatesAttribute coordAttribute = new CoordinatesAttribute();
        private readonly HrefAttribute hrefAttribute = new HrefAttribute();
        private readonly ShapeAttribute shapeAttribute = new ShapeAttribute();

        // Advanced attributes 
        private readonly AccessKeyAttribute accessKeyAttrib = new AccessKeyAttribute();
        private readonly OnBlurEventAttribute onBlurEvent = new OnBlurEventAttribute();
        private readonly OnFocusEventAttribute onFocus = new OnFocusEventAttribute();
        private readonly NoHRefAttribute nohrefAttribute = new NoHRefAttribute();
        private readonly TabIndexAttribute tabIndexAttrib = new TabIndexAttribute();

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

        // Common core attributes
        private readonly ClassAttr classattr = new ClassAttr();
        private readonly IdAttribute idattr = new IdAttribute();
        private readonly TitleAttribute titleattr = new TitleAttribute();

        private readonly StyleAttribute styleAttr = new StyleAttribute();

        internal const string ElementName = "area";



        /// <summary>
        /// This attribute assigns a class name or set of class names to an element. 
        /// Any number of elements may be assigned the same class name or set of class names. 
        /// Multiple class names must be separated by white space characters. 
        /// Class names are typically used to apply CSS formatting rules to an element.
        /// </summary>
        public ClassAttr Class
        {
            get { return classattr; }
        }


        /// <summary>
        /// This attribute assigns an ID to an element. 
        /// This ID must be unique in a document. 
        /// This ID can be used by client-side scripts (such as JavaScript) to select elements, apply CSS formatting rules, or to build relationships between elements.
        /// </summary>
        public IdAttribute ID
        {
            get { return idattr; }
        }

        /// <summary>
        /// This attribute offers advisory information. 
        /// Some Web browsers will display this information as tooltips. 
        /// Assistive technologies may make this information available to users as additional information about the element.
        /// </summary>
        public TitleAttribute Title
        {
            get { return titleattr; }
        }


        /// <summary>
        /// This attribute specifies formatting style information for the current element. 
        /// The content of this attribute is called inline CSS. The style attribute is deprecated (considered outdated), 
        /// because it fuses together content and formatting.
        /// </summary>
        public StyleAttribute Style { get { return styleAttr; } }

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
        /// Alternate text. This attribute is required.
        /// </summary>
        public AltAttribute Alt { get { return altAttribute; } }


        /// <summary>
        /// Specifies the position and shape on the screen. 
        /// The number and order of values depends on the shape being defined. 
        /// Possible combinations:
        /// * rect: left-x, top-y, right-x, bottom-y.
        /// * circle: center-x, center-y, radius.
        /// * poly: x1, y1, x2, y2, ..., xN, yN. 
        /// The first and the last x and y coordinate pair should be the same, in order to close the polygon.
        /// Coordinates are relative to the top-left corner of the object. All values are separated by commas.
        /// </summary>
        public CoordinatesAttribute Coords { get { return coordAttribute; } }

        /// <summary>
        /// Specifies the location of a Web resource.
        /// </summary>
        public HrefAttribute HRef { get { return hrefAttribute; } }

        /// <summary>
        /// Specifies the shape of a region. 
        /// Possible values are:
        ///  * default: Specifies the entire region
        /// * rect: Defines a rectangular region.
        /// * circle: Defines a circular region.
        /// * poly: Defines a polygonal region.
        /// </summary>
        public ShapeAttribute Shape { get { return shapeAttribute; } }


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
        /// When set, this attribute specifies that a region has no associated hyperlink. 
        /// Possible value is nohref.
        /// </summary>
        public NoHRefAttribute NoHRef { get { return nohrefAttribute; } }

        #region Overrides of BaseBlockElement

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

            classattr.ReadAttribute(xElement);
            idattr.ReadAttribute(xElement);
            titleattr.ReadAttribute(xElement);

            styleAttr.ReadAttribute(xElement);

            // Basic attributes
            altAttribute.ReadAttribute(xElement);
            coordAttribute.ReadAttribute(xElement);
            hrefAttribute.ReadAttribute(xElement);
            shapeAttribute.ReadAttribute(xElement);

            // Advanced attributes
            accessKeyAttrib.ReadAttribute(xElement);
            onBlurEvent.ReadAttribute(xElement);
            onFocus.ReadAttribute(xElement);
            nohrefAttribute.ReadAttribute(xElement);
            tabIndexAttrib.ReadAttribute(xElement);

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
        /// <returns>generated XNode</returns>
        public XNode Generate()
        {
            XElement xElement = new XElement(XhtmlNameSpace + ElementName);

            classattr.AddAttribute(xElement);
            idattr.AddAttribute(xElement);
            titleattr.AddAttribute(xElement);

            styleAttr.AddAttribute(xElement);

            // Basic attributes
            altAttribute.AddAttribute(xElement);
            coordAttribute.AddAttribute(xElement);
            hrefAttribute.AddAttribute(xElement);
            shapeAttribute.AddAttribute(xElement);

            language.AddAttribute(xElement);
            direction.AddAttribute(xElement);

            // advanced attributes
            accessKeyAttrib.AddAttribute(xElement);
            onBlurEvent.AddAttribute(xElement);
            onFocus.AddAttribute(xElement);
            nohrefAttribute.AddAttribute(xElement);
            tabIndexAttrib.AddAttribute(xElement);

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
        /// <returns>true if valid</returns>
        public  bool IsValid()
        {
            return (altAttribute.HasValue());
        }

        /// <summary>
        /// Adds subitem to the item , only if 
        /// allowed by the rules and element can accept content
        /// </summary>
        /// <param name="item">subitem to add</param>
        public void Add(IXHTMLItem item)
        {
            throw new Exception("This element does not contain subitems");
        }

        public void Remove(IXHTMLItem item)
        {
            throw new Exception("This element does not contain subitems");
        }

        public List<IXHTMLItem> SubElements()
        {
            return null;
        }

        /// <summary>
        /// Get/Set item parent in the XHTML "tree"
        /// </summary>
        public IXHTMLItem Parent { get; set; }

        #endregion
    }
}