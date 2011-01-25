﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.Attributes;
using XHTMLClassLibrary.BaseElements.InlineElements;

namespace XHTMLClassLibrary.BaseElements.TableElements
{
    /// <summary>
    /// In XHTML, tables are physically constructed from rows, rather than columns. 
    /// Table rows contain table cells. 
    /// In visual Web browsers, when cells line up beneath each other, they are perceived as columns.
    /// </summary>
    public class ColElement : BaseTableElement
    {
        internal const string ElementName = "col";


        // Basic attributes
        private readonly AlignAttribute alignAttribute = new AlignAttribute();
        private readonly SpanAttribute spanAttribute = new SpanAttribute();
        private readonly VAlignAttribute valignAttribute = new VAlignAttribute();
        private readonly WidthAttribute widthAttribute = new WidthAttribute();

        // Advanced attributes 
        private readonly  CharAttribute charAttribute = new CharAttribute();
        private readonly CharOffAttribute charOffAtribute = new CharOffAttribute();

        /// <summary>
        /// Horizontal alignment in cells. Possible values are:
        /// 
        /// * left: Left-justify text. This is the default value for table data cells.
        /// * center: Center-justify text. This is the default value for table header cells.
        /// * right: Right-justify text.
        /// * justify: Left- and right-justify text.
        /// * char: Align text around a specific character.
        /// </summary>
        public AlignAttribute Align { get { return alignAttribute; } }

        /// <summary>
        /// A single col element can represent (or "span") multiple columns. 
        /// This attribute contains a number of columns "spanned" by the col element.
        /// </summary>
        public SpanAttribute Span { get { return spanAttribute; } }


        /// <summary>
        /// Vertical alignment in cells. Possible values are:
        /// 
        /// * top: Cell data is flush with the top of the cell.
        /// * middle: Cell data is centered vertically within the cell. This is the default value.
        /// * bottom: Cell data is flush with the bottom of the cell.
        /// * baseline: All cells found in the same row as a cell whose valign attribute has this value will have their textual data positioned so that the first text line occurs on a baseline common to all cells in the row.
        /// </summary>
        public VAlignAttribute VerticalAlign { get { return valignAttribute; } }


        /// <summary>
        /// his attribute specifies a single character within a text fragment to act as an axis for alignment. 
        /// The default value for this attribute is the decimal point character for the current language as set by the xml:lang attribute. 
        /// For example, the period (".") in English and the comma (",") in French.
        /// </summary>
        public CharAttribute AlignChar { get { return charAttribute; } }

        /// <summary>
        /// Default column width.
        /// </summary>
        public WidthAttribute Width { get { return widthAttribute; } }


        /// <summary>
        /// When present, this attribute specifies the offset to the first occurrence of the alignment character on each line.
        /// </summary>
        public CharOffAttribute CharOff { get { return charOffAtribute; } }

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

            // Base attributes
            alignAttribute.ReadAttribute(xElement);
            spanAttribute.ReadAttribute(xElement);
            valignAttribute.ReadAttribute(xElement);
            widthAttribute.ReadAttribute(xElement);

            // Advanced attributes
            charAttribute.ReadAttribute(xElement);
            charOffAtribute.ReadAttribute(xElement);
        }


        public override XNode Generate()
        {
            XElement xElement = new XElement(XhtmlNameSpace + ElementName);

            AddAtributes(xElement);

            // Base attributes
            alignAttribute.AddAttribute(xElement);
            spanAttribute.AddAttribute(xElement);
            valignAttribute.AddAttribute(xElement);
            widthAttribute.AddAttribute(xElement);

            // Advanced attributes
            charAttribute.AddAttribute(xElement);
            charOffAtribute.AddAttribute(xElement);

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
    }
}
