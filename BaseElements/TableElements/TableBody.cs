using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.Attributes;
using XHTMLClassLibrary.Exceptions;

namespace XHTMLClassLibrary.BaseElements.TableElements
{
    /// <summary>
    /// The tbody element can be used to group table data rows. 
    /// This can be useful when a Web browser supports scrolling of table rows in longer tables. 
    /// Multiple tbody elements can be used for independent scrolling.
    /// </summary>
    public class TableBody : BaseTableElement
    {
        internal const string ElementName = "tbody";

        private readonly List<IXHTMLItem> content = new List<IXHTMLItem>();

        // Basic attributes
        private readonly AlignAttribute alignAttribute = new AlignAttribute();
        private readonly VAlignAttribute valignAttribute = new VAlignAttribute();

        // Advanced attributes 
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
            valignAttribute.ReadAttribute(xElement);

            // Advanced attributes
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
            if (item is TableRow)
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
            alignAttribute.AddAttribute(xElement);
            valignAttribute.AddAttribute(xElement);

            // Advanced attributes
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
