﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XHTMLClassLibrary.Attributes;
using XHTMLClassLibrary.Attributes.Events;

namespace XHTMLClassLibrary.BaseElements.BlockElements
{
    public interface IBlockElement : IXHTMLItem
    {
        /// <summary>
        /// This attribute specifies the base direction of text. 
        /// Possible values:
        /// ltr: Left-to-right 
        /// rtl: Right-to-left
        /// </summary>
        DirectionAttr Direction { get; }

        /// <summary>
        /// A client-side script event that occurs when a pointing device button is clicked over an element.
        /// </summary>
        OnClickEventAttribute OnClick { get; }


        /// <summary>
        /// A client-side script event that occurs when a pointing device button is double-clicked over an element.
        /// </summary>
        OnDblClickEventAttribute OnDblClick { get; }


        /// <summary>
        /// A client-side script event that occurs when a pointing device button is pressed down over an element.
        /// </summary>
        OnMouseDownEventAttribute OnMouseDown { get; }

        /// <summary>
        /// A client-side script event that occurs when a pointing device button is released over an element.
        /// </summary>
        OnMouseUpEventAttribute OnMouseUp { get; }


        /// <summary>
        /// A client-side script event that occurs when a pointing device is moved onto an element.
        /// </summary>
        OnMouseOverEventAttribute OnMouseOver { get; }

        /// <summary>
        /// A client-side script event that occurs when a pointing device is moved within an element.
        /// </summary>
        OnMouseMoveEventAttribute OnMouseMove { get; }


        /// <summary>
        /// A client-side script event that occurs when a pointing device is moved away from an element.
        /// </summary>
        OnMouseOutEventAttribute OnMouseOut { get; }

        /// <summary>
        /// A client-side script event that occurs when a key is pressed down over an element then released.
        /// </summary>
        OnKeyPressEventAttribute OnKeyPress { get; }

        /// <summary>
        /// A client-side script event that occurs when a key is pressed down over an element.
        /// </summary>
        OnKeyDownEventAttribute OnKeyDown { get; }

        /// <summary>
        /// A client-side script event that occurs when a key is released over an element.
        /// </summary>
        OnKeyUpEventAttribute OnKeyUp { get; }

        /// <summary>
        /// This attribute specifies the base language of an element's attribute values and text content.
        /// </summary>
        LanguageAttr Language { get; }

        /// <summary>
        /// This attribute assigns a class name or set of class names to an element. 
        /// Any number of elements may be assigned the same class name or set of class names. 
        /// Multiple class names must be separated by white space characters. 
        /// Class names are typically used to apply CSS formatting rules to an element.
        /// </summary>
        ClassAttr Class { get; }


        /// <summary>
        /// This attribute assigns an ID to an element. 
        /// This ID must be unique in a document. 
        /// This ID can be used by client-side scripts (such as JavaScript) to select elements, apply CSS formatting rules, or to build relationships between elements.
        /// </summary>
        IdAttribute ID { get; }

        /// <summary>
        /// This attribute offers advisory information. 
        /// Some Web browsers will display this information as tooltips. 
        /// Assistive technologies may make this information available to users as additional information about the element.
        /// </summary>
        TitleAttribute Title { get; }


        /// <summary>
        /// This attribute specifies formatting style information for the current element. 
        /// The content of this attribute is called inline CSS. The style attribute is deprecated (considered outdated), 
        /// because it fuses together content and formatting.
        /// </summary>
        StyleAttribute Style { get; }

    }


    public abstract class BaseBlockElement : BaseContainingElement, IBlockElement, ICommonAttributes
    {
        // Common core attributes
        private readonly ClassAttr classattr = new ClassAttr();
        private readonly IdAttribute idattr = new IdAttribute();
        private readonly TitleAttribute titleattr = new TitleAttribute();

        private readonly StyleAttribute styleAttr = new StyleAttribute();

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


        public static XNamespace XhtmlNameSpace = @"http://www.w3.org/1999/xhtml";

        #region public_properties

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

        #endregion

        #region Implementation of IXHTMLItem





        #endregion

        internal void AddAtributes(XElement xElement)
        {
            classattr.AddAttribute(xElement);
            idattr.AddAttribute(xElement);
            titleattr.AddAttribute(xElement);

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

            styleAttr.AddAttribute(xElement);

        }

        internal void ReadAttributes(XElement xElement)
        {
            classattr.ReadAttribute(xElement);
            idattr.ReadAttribute(xElement);
            titleattr.ReadAttribute(xElement);

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

            styleAttr.ReadAttribute(xElement);
        }
    }
}
