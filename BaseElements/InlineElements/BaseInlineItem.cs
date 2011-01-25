﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using ISOLanguages;
using XHTMLClassLibrary.AttributeDataTypes;
using XHTMLClassLibrary.Attributes;

namespace XHTMLClassLibrary.BaseElements.InlineElements
{
    public interface IInlineItem : IXHTMLItem
    {

    }

    abstract public class BaseInlineItem : IInlineItem, ICommonAttributes
    {
        // Common core attributes
        private readonly ClassAttr classattr = new ClassAttr();
        private readonly IdAttribute idattr = new IdAttribute();
        private readonly TitleAttribute titleattr = new TitleAttribute();

        private readonly StyleAttribute styleAttr = new StyleAttribute();

        public static XNamespace XhtmlNameSpace = @"http://www.w3.org/1999/xhtml";

#region public_properties

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

        internal void AddAtributes(XElement xElement)
        {
            classattr.AddAttribute(xElement);
            idattr.AddAttribute(xElement);
            titleattr.AddAttribute(xElement);
            

            styleAttr.AddAttribute(xElement);

        }

        internal void ReadAttributes(XElement xElement)
        {
            classattr.ReadAttribute(xElement);
            idattr.ReadAttribute(xElement);
            titleattr.ReadAttribute(xElement);

            styleAttr.ReadAttribute(xElement);
        }


        public abstract void Load(XNode xNode);
        public abstract XNode Generate();
        public abstract bool IsValid();

        /// <summary>
        /// Adds subitem to the item , only if 
        /// allowed by the rules and element can accept content
        /// </summary>
        /// <param name="item">subitem to add</param>
        public abstract void Add(IXHTMLItem item);

        public abstract void Remove(IXHTMLItem item);

        public abstract List<IXHTMLItem> SubElements();

        /// <summary>
        /// Get/Set item parent in the XHTML "tree"
        /// </summary>
        public IXHTMLItem Parent { get; set; }
    }
}