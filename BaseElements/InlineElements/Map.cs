using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.Attributes;
using XHTMLClassLibrary.Attributes.Events;
using XHTMLClassLibrary.BaseElements.BlockElements;
using XHTMLClassLibrary.BaseElements.MapAreas;
using XHTMLClassLibrary.Exceptions;

namespace XHTMLClassLibrary.BaseElements.InlineElements
{
    /// <summary>
    /// The map element specifies a client-side image map that may be referenced by elements such as img, select and object.
    /// </summary>
    public class Map : BaseInlineItem
    {
        /// <summary>
        /// Internal containt of the element
        /// </summary>
        private readonly List<IXHTMLItem> content = new List<IXHTMLItem>();

        private readonly LanguageAttr language = new LanguageAttr();
        private readonly DirectionAttr direction = new DirectionAttr();


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


        internal const string ElementName = "map";


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
            if (item is Area)
            {
                return item.IsValid();
            }
            if (item is IBlockElement)
            {
                return item.IsValid();
            }            
            return false;
        }

        public override XNode Generate()
        {
            XElement xElement = new XElement(XhtmlNameSpace + ElementName);

            AddAtributes(xElement);

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

            foreach (var item in content)
            {
                xElement.Add(item.Generate());
            }
            return xElement;

        }

        public override bool IsValid()
        {
            return (ID.HasValue());
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
    }
}
