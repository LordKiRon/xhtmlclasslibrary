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
using XHTMLClassLibrary.Exceptions;
using XHTMLClassLibrary.ObjectParameters;

namespace XHTMLClassLibrary.BaseElements.InlineElements
{
    /// <summary>
    /// The object element provides a generic way of embedding objects such as images, 
    /// movies and applications (Java applets, browser plug-ins, etc.) into Web pages. 
    /// param elements contained inside the object element are used to configure the embedded object. 
    /// Besides param elements, the object element can contain alternate content which can be text or another object element. 
    /// Alternate content serves as a fall-back mechanism for browsers that are unable to process the embedded object.
    /// </summary>
    public class EmbededObject : BaseInlineItem
    {
        /// <summary>
        /// Internal containt of the element
        /// </summary>
        private readonly List<IXHTMLItem> content = new List<IXHTMLItem>();


        // Base attributes
        private readonly ClassIDAttribute classIdAttribute = new ClassIDAttribute();
        private readonly CodeBaseAttribute codeBaseAttribute = new CodeBaseAttribute();
        private readonly HeightAttribute heightAttribute = new HeightAttribute();
        private readonly NameAttribute nameAttribute = new NameAttribute();
        private readonly ContentTypeAttribute contentTypeAttribute = new ContentTypeAttribute();
        private readonly WidthAttribute widthAttribute = new WidthAttribute();

        // Advanced attributes
        private readonly ArchiveAttribute archiveAttribute = new ArchiveAttribute();
        private readonly CodeTypeAttribute codeTypeAttribute = new CodeTypeAttribute();
        private readonly DataAttribute dataAttribute = new DataAttribute();
        private readonly DeclareAttribute declareAttribute = new DeclareAttribute();
        private readonly StandByAttribute standbyAttribute = new StandByAttribute();
        private readonly TabIndexAttribute tabIndexAttribute = new TabIndexAttribute();
        private readonly UseMapAttribute useMapAttribute = new UseMapAttribute();


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


        internal const string ElementName = "object";


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
        /// This attribute may be used to specify the location of an object's implementation via a URI. 
        /// It may be used together with, or as an alternative to, the data attribute, depending on the type of object involved. 
        /// For example: clsid:D27CDB6E-AE6D-11cf-96B8-444553540000.
        /// </summary>
        public ClassIDAttribute ClassId { get { return classIdAttribute; } }

        /// <summary>
        /// This attribute specifies the base path used to resolve relative URIs specified by the classid, data, and archive attributes. 
        /// When absent, its default value is the base URI of the current document. 
        /// Some Web browser like Internet Explorer use this attribute to point to CAB or INF files in order to download the object.
        /// </summary>
        public CodeBaseAttribute CodeBase { get { return codeBaseAttribute; } }

        /// <summary>
        /// Object height.
        /// </summary>
        public HeightAttribute Height { get { return heightAttribute; } }

        /// <summary>
        /// When the object is used as a form control, this attribute is the name of the form control.
        /// </summary>
        public NameAttribute Name { get { return nameAttribute; } }

        /// <summary>
        /// This attribute specifies the content type for the object. 
        /// This attribute may be used with or without the data attribute. 
        /// Most Web browsers use this attribute (instead of classid) to determine how to process the object. 
        /// For example: application/x-shockwave-flash.
        /// </summary>
        public ContentTypeAttribute ContentType { get { return contentTypeAttribute; } }

        /// <summary>
        /// Object width.
        /// </summary>
        public WidthAttribute Width { get { return widthAttribute; } }

        /// <summary>
        /// This attribute may be used to specify a space-separated list of URIs for archives containing resources relevant to the object.
        /// </summary>
        public ArchiveAttribute Archive { get { return archiveAttribute; } }

        /// <summary>
        /// This attribute specifies the content type of data expected when downloading the object specified by classid.
        /// </summary>
        public CodeTypeAttribute CodeType { get { return codeTypeAttribute; } }

        /// <summary>
        /// This attribute may be used to specify the location of the object's data, 
        /// for instance image data for objects defining images, 
        /// or more generally, a serialized form of an object which can be used to recreate it.
        /// </summary>
        public DataAttribute Data { get { return dataAttribute; } }

        /// <summary>
        /// When present, this attribute makes the current object definition a declaration only. 
        /// This means another object element will be used to load the object. 
        /// Possible value is "declare".
        /// </summary>
        public DeclareAttribute Declare { get { return declareAttribute; } }


        /// <summary>
        /// This attribute specifies a message that a Web browser may display while loading the object
        /// </summary>
        public StandByAttribute Standby { get { return standbyAttribute; } }

        /// <summary>
        /// Position in tabbing order.
        /// </summary>
        public TabIndexAttribute TabIndex { get { return tabIndexAttribute; } }

        /// <summary>
        /// This attribute associates the object to a client-side image map defined by a map element. 
        /// The value of this attribute must match the id attribute of the map element.
        /// </summary>
        public UseMapAttribute UseMap { get { return useMapAttribute; } }



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

            classIdAttribute.ReadAttribute(xElement);
            codeBaseAttribute.ReadAttribute(xElement);
            heightAttribute.ReadAttribute(xElement);
            nameAttribute.ReadAttribute(xElement);
            contentTypeAttribute.ReadAttribute(xElement);
            widthAttribute.ReadAttribute(xElement);

            archiveAttribute.ReadAttribute(xElement);
            codeTypeAttribute.ReadAttribute(xElement);
            dataAttribute.ReadAttribute(xElement);
            declareAttribute.ReadAttribute(xElement);
            standbyAttribute.ReadAttribute(xElement);
            tabIndexAttribute.ReadAttribute(xElement);
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
            if (item is IInlineItem)
            {
                return item.IsValid();
            }
            if (item is IBlockElement)
            {
                return item.IsValid();
            }
            if (item is Param)
            {
                return item.IsValid();
            }
            if (item is SimpleEPubText)
            {
                return item.IsValid();
            }
            return false;
        }

        public override XNode Generate()
        {
            XElement xElement = new XElement(XhtmlNameSpace + ElementName);

            AddAtributes(xElement);

            classIdAttribute.AddAttribute(xElement);
            codeBaseAttribute.AddAttribute(xElement);
            heightAttribute.AddAttribute(xElement);
            nameAttribute.AddAttribute(xElement);
            contentTypeAttribute.AddAttribute(xElement);
            widthAttribute.AddAttribute(xElement);

            archiveAttribute.AddAttribute(xElement);
            codeTypeAttribute.AddAttribute(xElement);
            dataAttribute.AddAttribute(xElement);
            declareAttribute.AddAttribute(xElement);
            standbyAttribute.AddAttribute(xElement);
            tabIndexAttribute.ReadAttribute(xElement);
            useMapAttribute.ReadAttribute(xElement);

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
    }
}
