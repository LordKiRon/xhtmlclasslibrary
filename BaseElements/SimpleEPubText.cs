using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.Attributes;

namespace XHTMLClassLibrary.BaseElements
{
    public enum TextStyles
    {
        Normal = 0,
        Strong, // <strong> , depricated <b>
        Emphasis, // <em>
        Sub, // <sub>
        Sup, // <sup>
        Big, // <big>
        Small, // <small>
        StrikeOut, // <strike>
        Code, // <code>
    }

    public interface ICommonAttributes
    {
        ClassAttr Class { get;}
        IdAttribute ID { get; }
        TitleAttribute Title { get; }
        StyleAttribute Style { get; }
    }

    public interface IXHTMLItem 
    {
        /// <summary>
        /// Loads the element from XNode
        /// </summary>
        /// <param name="xNode">node to load element from</param>
        void Load(XNode xNode);

        /// <summary>
        /// Generates element to XNode from data
        /// </summary>
        /// <returns>generated XNode</returns>
        XNode Generate();

        /// <summary>
        /// Checks it element data is valid
        /// </summary>
        /// <returns>true if valid</returns>
        bool IsValid();

        /// <summary>
        /// Adds subitem to the item , only if 
        /// allowed by the rules and element can accept content
        /// </summary>
        /// <param name="item">subitem to add</param>
        void Add(IXHTMLItem item);

        /// <summary>
        /// Removes subitem 
        /// </summary>
        /// <param name="item">subitem to remove</param>
        void Remove(IXHTMLItem item);

        /// <summary>
        /// Get list of all sub elements
        /// </summary>
        /// <returns></returns>
        List<IXHTMLItem> SubElements();

        /// <summary>
        /// Get/Set item parent in the XHTML "tree"
        /// </summary>
        IXHTMLItem Parent { get; set; }

    }



    public class SimpleEPubText : IXHTMLItem
    {
        private string _text;

        public string Text
        {
            get { return _text; }
            set { _text = value ?? string.Empty; }
        }


        public void Load(XNode xNode)
        {
            if (xNode.NodeType != XmlNodeType.Text)
            {
                throw new Exception("xNode is not of text type");
            }
            Text = ((XText) xNode).Value;
        }

        public XNode Generate()
        {
            return new XText(Text);

        }

        public bool IsValid()
        {
            return (Text != null);
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
    }
}