using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.AttributeDataTypes;
using XHTMLClassLibrary.Attributes;
using XHTMLClassLibrary.Attributes.Events;
using XHTMLClassLibrary.Exceptions;

namespace XHTMLClassLibrary.BaseElements.InlineElements
{
    /// <summary>
    /// Hyperlink
    /// </summary>
    public class Anchor : BaseInlineItem
    {
        /// <summary>
        /// Internal containt of the element
        /// </summary>
        private readonly List<IXHTMLItem> content = new List<IXHTMLItem>();

        private readonly LanguageAttr language = new LanguageAttr();
        private readonly DirectionAttr direction = new DirectionAttr();


        private readonly HrefAttribute hrefAttrib = new HrefAttribute();


        // advanced attributes
        private readonly AccessKeyAttribute accessKeyAttrib = new AccessKeyAttribute();
        private readonly CharsetAttribute charsetAttrib = new CharsetAttribute();
        private readonly CoordinatesAttribute coordAttrib = new CoordinatesAttribute();
        private readonly HRefLanguageAttribute hrefLangAttrib = new HRefLanguageAttribute();
        private readonly OnBlurEventAttribute onBlurEvent = new OnBlurEventAttribute();
        private readonly OnFocusEventAttribute onFocus = new OnFocusEventAttribute();
        private readonly RelationAttribute relAttrib = new RelationAttribute();
        private readonly ReverseRelationAttribute revRelAttrib = new ReverseRelationAttribute();
        private readonly ShapeAttribute shapeAttribute = new ShapeAttribute();
        private readonly TabIndexAttribute tabIndexAttrib = new TabIndexAttribute();
        private readonly ContentTypeAttribute contentTypeAttrib = new ContentTypeAttribute();

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
        /// Get list of the sub elements
        /// </summary>
        public List<IXHTMLItem> Content { get { return content; } }

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
        /// This attribute specifies the location of a Web resource. 
        /// For example: http://xhtml.com/ or mailto:info@xhtml.com.
        /// </summary>
        public HrefAttribute HRef { get { return hrefAttrib; } }

        /// <summary>
        /// Accessibility key character
        /// </summary>
        public AccessKeyAttribute AccessKey { get { return accessKeyAttrib; } }

        /// <summary>
        /// Character encoding of the resource designated by href.
        /// </summary>
        public CharsetAttribute CharSet { get { return charsetAttrib; } }

        /// <summary>
        /// For use with client-side image maps. 
        /// Example: 0,0,118,28.
        /// </summary>
        public CoordinatesAttribute Coordinates { get { return coordAttrib; } }

        /// <summary>
        /// Specifies the primary language of the resource designated by href and may only be used when href is specified.
        /// </summary>
        public HRefLanguageAttribute HrefLanguage { get { return hrefLangAttrib; } }

        /// <summary>
        /// A client-side script event that occurs when an element loses focus either by the pointing device or by tabbing navigation.
        /// </summary>
        public OnBlurEventAttribute OnBlur { get { return onBlurEvent; } }

        /// <summary>
        /// A client-side script event that occurs when an element receives focus either by the pointing device or by tabbing navigation.
        /// </summary>
        public OnFocusEventAttribute OnFocus { get { return onFocus; } }

        /// <summary>
        /// Describes the relationship from the current document to the resource specified by the href attribute. The value of this attribute is a space-separated list of link types. 
        /// For example: appendix.
        /// </summary>
        public RelationAttribute Rel { get { return relAttrib; } }


        /// <summary>
        /// Describes the reverse relationship from the resource specified by the href attribute to the current document. The value of this attribute is a space-separated list of link types. 
        /// For example: index.
        /// </summary>
        public ReverseRelationAttribute Rev { get { return revRelAttrib; } }


        /// <summary>
        /// For use with client-side image maps. 
        /// Possible values are rect or circle or poly or default.
        /// </summary>
        public ShapeAttribute Shape { get { return shapeAttribute; } }

        /// <summary>
        /// Position in tabbing order.
        /// </summary>
        public TabIndexAttribute TabIndex { get { return tabIndexAttrib; } }


        /// <summary>
        /// A hint to Web browsers regarding the type of resource designated by href. 
        /// For example: application/pdf.
        /// </summary>
        public ContentTypeAttribute Type { get { return contentTypeAttrib; } }


#endregion

        internal const string ElementName = "a";

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
                if ((item != null) && IsValidSubType(item)) // anchor can't contain anchor
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

            if (item is IInlineItem)
            {
                if (item is Anchor)
                {
                    return false;
                }
                return item.IsValid();
            }
            if (item is SimpleEPubText)
            {
                return true;
            }
            return false;
        }


        public override XNode Generate()
        {
            XElement anchor = new XElement(XhtmlNameSpace + ElementName);

            if (HRef == null)
            {
                throw new Exception("HRef can't be null when generating");
            }

            AddAtributes(anchor);

            if (content.Count > 0)
            {
                foreach (var item in content)
                {
                    anchor.Add(item.Generate());
                }
            }
            return anchor;
        }


        public override bool IsValid()
        {
            if (HRef == null)
            {
                return false;
            }
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

        internal new  void ReadAttributes(XElement xElement)
        {
            base.ReadAttributes(xElement);

            language.ReadAttribute(xElement);
            direction.ReadAttribute(xElement);

            // Basic attributes
            hrefAttrib.ReadAttribute(xElement);

            //Advanced attributes
            accessKeyAttrib.ReadAttribute(xElement);
            charsetAttrib.ReadAttribute(xElement);
            coordAttrib.ReadAttribute(xElement);
            hrefLangAttrib.ReadAttribute(xElement);
            onBlurEvent.ReadAttribute(xElement);
            onFocus.ReadAttribute(xElement);
            relAttrib.ReadAttribute(xElement);
            revRelAttrib.ReadAttribute(xElement);
            shapeAttribute.ReadAttribute(xElement);
            tabIndexAttrib.ReadAttribute(xElement);
            contentTypeAttrib.ReadAttribute(xElement);

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


        internal new void AddAtributes(XElement xElement)
        {
            base.AddAtributes(xElement);

            language.AddAttribute(xElement);
            direction.AddAttribute(xElement);

            // basic attributes
            hrefAttrib.AddAttribute(xElement);

            // advanced attributes
            accessKeyAttrib.AddAttribute(xElement);
            charsetAttrib.AddAttribute(xElement);
            coordAttrib.AddAttribute(xElement);
            if (HRef.HasValue())
            {
                hrefLangAttrib.AddAttribute(xElement);
            }
            onBlurEvent.AddAttribute(xElement);
            onFocus.AddAttribute(xElement);
            relAttrib.AddAttribute(xElement);
            revRelAttrib.AddAttribute(xElement);
            shapeAttribute.AddAttribute(xElement);
            tabIndexAttrib.AddAttribute(xElement);
            contentTypeAttrib.AddAttribute(xElement);

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
        }
    }
}