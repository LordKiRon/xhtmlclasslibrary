﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.Attributes;
using XHTMLClassLibrary.BaseElements;

namespace XHTMLClassLibrary.ObjectParameters
{
    /// <summary>
    /// The param element is used to customize embedded objects that are loaded into a Web browser via the object element. 
    /// The param element is a generic way of passing data to embedded objects in the form of name/value pairs. 
    /// The need for param elements and the number of param elements depends on the embedded object.
    /// </summary>
    public class Param : IXHTMLItem
    {
        // Base attributes
        private readonly NameAttribute nameAttribute = new NameAttribute();
        private readonly ValueAttribute valueAttribute = new ValueAttribute();


        // Advanced attributes
        private readonly IdAttribute idattr = new IdAttribute();
        private readonly ContentTypeAttribute contentTypeAttribute = new ContentTypeAttribute();
        private readonly ValueTypeAttribute valueTypeAttribute = new ValueTypeAttribute();


        public static XNamespace XhtmlNameSpace = @"http://www.w3.org/1999/xhtml";



        internal const string ElementName = "param";



        #region public_properties



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
        /// his attribute defines the name of a run-time parameter, assumed to be known by the inserted object. 
        /// Whether the property name is case-sensitive or not depends on the specific object implementation. 
        /// This attribute is required.
        /// </summary>
        public NameAttribute Name { get { return nameAttribute; } }

        /// <summary>
        /// This attribute specifies the value of a run-time parameter specified by the name attribute. 
        /// Property values have no meaning in XHTML; their meaning is determined by the object in question.
        /// </summary>
        public ValueAttribute Value { get { return valueAttribute; } }

        /// <summary>
        /// This attribute specifies the content type of the resource designated by the value attribute, 
        /// only in the case where valuetype attribute is set to "ref".
        /// </summary>
        public ContentTypeAttribute ContentType { get { return contentTypeAttribute; } }

        public ValueTypeAttribute ValueType { get { return valueTypeAttribute;}}

        #endregion

        #region Implementation of IEPubTextItem

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

            nameAttribute.ReadAttribute(xElement);
            valueAttribute.ReadAttribute(xElement);

            idattr.ReadAttribute(xElement);
            contentTypeAttribute.ReadAttribute(xElement);
            valueTypeAttribute.ReadAttribute(xElement);

        }

        /// <summary>
        /// Generates element to XNode from data
        /// </summary>
        /// <returns>generated XNode</returns>
        public XNode Generate()
        {
            XElement xElement = new XElement(XhtmlNameSpace + ElementName);

            nameAttribute.AddAttribute(xElement);
            valueAttribute.AddAttribute(xElement);

            idattr.AddAttribute(xElement);
            contentTypeAttribute.AddAttribute(xElement);
            valueTypeAttribute.AddAttribute(xElement);

            return xElement;
        }

        /// <summary>
        /// Checks it element data is valid
        /// </summary>
        /// <returns>true if valid</returns>
        public bool IsValid()
        {
            return (nameAttribute.HasValue());
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