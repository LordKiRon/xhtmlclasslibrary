using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.Attributes;
using XHTMLClassLibrary.BaseElements.BlockElements;
using XHTMLClassLibrary.BaseElements.InlineElements;
using XHTMLClassLibrary.Exceptions;

namespace XHTMLClassLibrary.BaseElements.TableElements
{
    /// <summary>
    /// The td element defines a data cell in a table (i.e. cells that are not header cells).
    /// </summary>
    public class TableData : BaseTableElement
    {
        internal const string ElementName = "td";

        private readonly List<IXHTMLItem> content = new List<IXHTMLItem>();

        // Basic attributes
        private readonly AbbreviatedAttribute abbrAttribute = new AbbreviatedAttribute();
        private readonly AlignAttribute alignAttribute = new AlignAttribute();
        private readonly ColSpanAttribute colSpanAttribute = new ColSpanAttribute();
        private readonly RowSpanAttribute rowSpanAttribue = new RowSpanAttribute();
        private readonly VAlignAttribute valignAttribute = new VAlignAttribute();

        // Advanced attributes 
        private readonly AxisAttribute axisAttribute = new AxisAttribute();
        private readonly CharAttribute charAttribute = new CharAttribute();
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
        /// When present, this attribute specifies the offset to the first occurrence of the alignment character on each line.
        /// </summary>
        public CharOffAttribute CharOff { get { return charOffAtribute; } }

        /// <summary>
        /// Abbreviated form of the cell's content.
        /// </summary>
        public AbbreviatedAttribute Abbr { get { return abbrAttribute; } }


        /// <summary>
        /// This attribute specifies the number of columns spanned by the current cell.
        /// </summary>
        public ColSpanAttribute ColSpan { get { return colSpanAttribute; } }


        /// <summary>
        /// This attribute specifies the number of rows spanned by the current cell.
        /// </summary>
        public RowSpanAttribute RowSpan { get { return rowSpanAttribue; } }


        /// <summary>
        /// This attribute may be used to place a cell into conceptual categories that can be considered to form axes in an n-dimensional space. 
        /// Some Web browsers or devices may present cells grouped by these categories.
        /// </summary>
        public AxisAttribute Axis { get { return axisAttribute; } }



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
            abbrAttribute.ReadAttribute(xElement);
            alignAttribute.ReadAttribute(xElement);
            colSpanAttribute.ReadAttribute(xElement);
            rowSpanAttribue.ReadAttribute(xElement);
            valignAttribute.ReadAttribute(xElement);

            // Advanced attributes
            axisAttribute.ReadAttribute(xElement);
            charAttribute.ReadAttribute(xElement);
            charOffAtribute.ReadAttribute(xElement);

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

            // Base attributes
            abbrAttribute.AddAttribute(xElement);
            alignAttribute.AddAttribute(xElement);
            colSpanAttribute.AddAttribute(xElement);
            rowSpanAttribue.AddAttribute(xElement);
            valignAttribute.AddAttribute(xElement);

            // Advanced attributes
            axisAttribute.AddAttribute(xElement);
            charAttribute.AddAttribute(xElement);
            charOffAtribute.AddAttribute(xElement);

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
