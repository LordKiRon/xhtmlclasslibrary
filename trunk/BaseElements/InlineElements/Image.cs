﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.Attributes;
using XHTMLClassLibrary.Attributes.Events;

namespace XHTMLClassLibrary.BaseElements.InlineElements
{
    /// <summary>
    /// The img element is used to define an image.
    /// </summary>
    public class Image : BaseInlineItem
    {
        private readonly LanguageAttr _language = new LanguageAttr();
        private readonly DirectionAttr _direction = new DirectionAttr();


        // basic attributes
        private readonly AltAttribute _altAttribute = new AltAttribute();
        private readonly HeightAttribute _heightAttribute = new HeightAttribute();
        private readonly WidthAttribute _widthAttribute = new WidthAttribute();
        private readonly SourceAttribute _srcAttribute = new SourceAttribute();

        // advanced attributes 
        private readonly ISMapAttribute _ismapAttribute = new ISMapAttribute();
        private readonly LongDescriptionAttribute _longDescAttribute = new LongDescriptionAttribute();
        private readonly UseMapAttribute _useMapAttribute = new UseMapAttribute();

        // Common event attributes
        private readonly OnClickEventAttribute _onClick = new OnClickEventAttribute();
        private readonly OnDblClickEventAttribute _onDblClick = new OnDblClickEventAttribute();
        private readonly OnMouseDownEventAttribute _onMouseDown = new OnMouseDownEventAttribute();
        private readonly OnMouseUpEventAttribute _onMouseUp = new OnMouseUpEventAttribute();
        private readonly OnMouseOverEventAttribute _onMouseOver = new OnMouseOverEventAttribute();
        private readonly OnMouseMoveEventAttribute _onMouseMove = new OnMouseMoveEventAttribute();
        private readonly OnMouseOutEventAttribute _onMouseOut = new OnMouseOutEventAttribute();
        private readonly OnKeyPressEventAttribute _onKeyPress = new OnKeyPressEventAttribute();
        private readonly OnKeyDownEventAttribute _onKeyDown = new OnKeyDownEventAttribute();
        private readonly OnKeyUpEventAttribute _onKeyUp = new OnKeyUpEventAttribute();


        #region public_attributes


        /// <summary>
        /// This attribute specifies the base direction of text. 
        /// Possible values:
        /// ltr: Left-to-right 
        /// rtl: Right-to-left
        /// </summary>
        public DirectionAttr Direction
        {
            get { return _direction; }
        }

        /// <summary>
        /// A client-side script event that occurs when a pointing device button is clicked over an element.
        /// </summary>
        public OnClickEventAttribute OnClick
        {
            get { return _onClick; }
        }


        /// <summary>
        /// A client-side script event that occurs when a pointing device button is double-clicked over an element.
        /// </summary>
        public OnDblClickEventAttribute OnDblClick { get { return _onDblClick; } }


        /// <summary>
        /// A client-side script event that occurs when a pointing device button is pressed down over an element.
        /// </summary>
        public OnMouseDownEventAttribute OnMouseDown { get { return _onMouseDown; } }

        /// <summary>
        /// A client-side script event that occurs when a pointing device button is released over an element.
        /// </summary>
        public OnMouseUpEventAttribute OnMouseUp { get { return _onMouseUp; } }


        /// <summary>
        /// A client-side script event that occurs when a pointing device is moved onto an element.
        /// </summary>
        public OnMouseOverEventAttribute OnMouseOver { get { return _onMouseOver; } }

        /// <summary>
        /// A client-side script event that occurs when a pointing device is moved within an element.
        /// </summary>
        public OnMouseMoveEventAttribute OnMouseMove { get { return _onMouseMove; } }


        /// <summary>
        /// A client-side script event that occurs when a pointing device is moved away from an element.
        /// </summary>
        public OnMouseOutEventAttribute OnMouseOut { get { return _onMouseOut; } }

        /// <summary>
        /// A client-side script event that occurs when a key is pressed down over an element then released.
        /// </summary>
        public OnKeyPressEventAttribute OnKeyPress { get { return _onKeyPress; } }

        /// <summary>
        /// A client-side script event that occurs when a key is pressed down over an element.
        /// </summary>
        public OnKeyDownEventAttribute OnKeyDown { get { return _onKeyDown; } }

        /// <summary>
        /// A client-side script event that occurs when a key is released over an element.
        /// </summary>
        public OnKeyUpEventAttribute OnKeyUp { get { return _onKeyUp; } }

        /// <summary>
        /// This attribute specifies the base language of an element's attribute values and text content.
        /// </summary>
        public LanguageAttr Language
        {
            get { return _language; }
        }

        /// <summary>
        /// Alternate text for the image. This attribute is required. 
        /// The value should be left blank for decorative images.
        /// </summary>
        public AltAttribute Alt
        {
            get
            {
                return _altAttribute;
            }
        }

        /// <summary>
        /// Image height.
        /// </summary>
        public HeightAttribute Height
        {
            get { return _heightAttribute; }
        }

        /// <summary>
        /// Image width.
        /// </summary>
        public  WidthAttribute Width
        {
            get { return _widthAttribute; }
        }

        /// <summary>
        /// This required attribute specifies the location of the image source.
        /// </summary>
        public  SourceAttribute Source
        {
            get { return _srcAttribute; }
        }

        /// <summary>
        /// If present, this attribute specifies that a server-side image map should be used. 
        /// Possible value is "ismap".
        /// </summary>
        public ISMapAttribute ISMap
        {
            get { return _ismapAttribute; }
        }

        /// <summary>
        /// This attribute specifies the location of a Web page that describes the image. 
        /// This attribute should only be used for non-decorative images.
        /// </summary>
        public LongDescriptionAttribute LongDescription
        {
            get { return _longDescAttribute; }
        }

        /// <summary>
        /// This attribute associates the image to a client-side image map defined by a map element. 
        /// The value of this attribute must match the id attribute of the map element.
        /// </summary>
        public UseMapAttribute UseMap
        {
            get { return _useMapAttribute; }
        }

        #endregion


        internal const string ElementName = "img";


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

            _altAttribute.ReadAttribute(xElement);
            _heightAttribute.ReadAttribute(xElement);
            _widthAttribute.ReadAttribute(xElement);
            _srcAttribute.ReadAttribute(xElement);

            _ismapAttribute.ReadAttribute(xElement);
            _longDescAttribute.ReadAttribute(xElement);
            _useMapAttribute.ReadAttribute(xElement);

            _language.ReadAttribute(xElement);
            _direction.ReadAttribute(xElement);

            _onClick.ReadAttribute(xElement);
            _onDblClick.ReadAttribute(xElement);
            _onMouseDown.ReadAttribute(xElement);
            _onMouseUp.ReadAttribute(xElement);
            _onMouseOver.ReadAttribute(xElement);
            _onMouseMove.ReadAttribute(xElement);
            _onMouseOut.ReadAttribute(xElement);
            _onKeyPress.ReadAttribute(xElement);
            _onKeyDown.ReadAttribute(xElement);
            _onKeyUp.ReadAttribute(xElement);
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

            _altAttribute.AddAttribute(xElement);
            _heightAttribute.AddAttribute(xElement);
            _widthAttribute.AddAttribute(xElement);
            _srcAttribute.AddAttribute(xElement);

            _ismapAttribute.AddAttribute(xElement);
            _longDescAttribute.AddAttribute(xElement);
            _useMapAttribute.AddAttribute(xElement);

            _language.AddAttribute(xElement);
            _direction.AddAttribute(xElement);

            _onClick.AddAttribute(xElement);
            _onDblClick.AddAttribute(xElement);
            _onMouseDown.AddAttribute(xElement);
            _onMouseUp.AddAttribute(xElement);
            _onMouseOver.AddAttribute(xElement);
            _onMouseMove.AddAttribute(xElement);
            _onMouseOut.AddAttribute(xElement);
            _onKeyPress.AddAttribute(xElement);
            _onKeyDown.AddAttribute(xElement);
            _onKeyUp.AddAttribute(xElement);

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
            return (_srcAttribute.HasValue());
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
