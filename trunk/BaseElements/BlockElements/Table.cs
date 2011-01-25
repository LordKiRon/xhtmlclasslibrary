using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.Attributes;
using XHTMLClassLibrary.BaseElements.InlineElements;
using XHTMLClassLibrary.BaseElements.TableElements;
using XHTMLClassLibrary.Exceptions;

namespace XHTMLClassLibrary.BaseElements.BlockElements
{
    /// <summary>
    /// The table element is used to define a table. 
    /// A table is a construct where data is organized into rows and columns of cells.
    /// </summary>
    public class Table : BaseBlockElement
    {
        internal const string ElementName = "table";

        // Basic attributes
        private readonly BorderAttribute borderAttribute = new BorderAttribute();
        private readonly CellPaddingAttribute cellPaddingAttribute = new CellPaddingAttribute();
        private readonly CellSpacingAttribute cellSpacingAttribute = new CellSpacingAttribute();
        private readonly SummaryAttribute summaryAttribute = new SummaryAttribute();
        private readonly WidthAttribute widthAttribute = new WidthAttribute();


        // Advanced attributes
        private readonly FrameAttribute frameAttribute = new FrameAttribute();
        private readonly RulesAttribute rulesAttribute = new RulesAttribute();

        /// <summary>
        /// This attributes specifies the width (in pixels) of the border around table cells. 
        /// </summary>
        public BorderAttribute Border { get { return borderAttribute; } }


        /// <summary>
        /// This attribute specifies the amount of space between the border of the cell and its contents.
        /// </summary>
        public CellPaddingAttribute CellPadding { get { return cellPaddingAttribute; } }


        /// <summary>
        /// This attribute specifies the amount of space between the border of the cell and the table frame or other cells.
        /// </summary>
        public CellSpacingAttribute CellSpacing { get { return cellSpacingAttribute; } }


        /// <summary>
        /// This attribute provides a summary of the table's purpose and structure, 
        /// for devices rendering to non-visual media such as speech and Braille.
        /// </summary>
        public SummaryAttribute Summary { get { return summaryAttribute; } }


        /// <summary>
        /// This attribute specifies the desired width of the entire table in pixels, 
        /// or as a percentage of the available horizontal space of the parent element.
        /// </summary>
        public WidthAttribute Width { get { return widthAttribute; } }


        /// <summary>
        ///     This attribute specifies which sides of the frame surrounding a table will be visible. 
        /// Possible values:
        /// 
        /// * void: No sides. This is the default value.
        /// * above: The top side only.
        /// * below: The lower side only.
        /// * hsides: The top and lower sides only.
        /// * vsides: The right and left sides only.
        /// * lhs: The left-hand side only.
        /// * rhs: The right-hand side only.
        /// * box: All four sides.
        /// * border: All four sides.
        /// </summary>
        public FrameAttribute Frame { get { return frameAttribute; } }


        /// <summary>
        /// This attribute specifies which rules (lines) will appear between cells within a table. 
        /// Not all Web browsers support this feature. 
        /// Possible values:
        /// 
        /// * none: No rules. This is the default value.
        /// * groups: Rules will appear between row groups (thead, tfoot and tbody) and column groups (colgroup and col) only.
        /// * rows: Rules will appear between rows only.
        /// * cols: Rules will appear between columns only.
        /// * all: Rules will appear between all rows and columns.
        /// </summary>
        public RulesAttribute Rules { get { return rulesAttribute; } }



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

            // Basic attributes
            borderAttribute.ReadAttribute(xElement);
            cellPaddingAttribute.ReadAttribute(xElement);
            cellSpacingAttribute.ReadAttribute(xElement);
            summaryAttribute.ReadAttribute(xElement);
            widthAttribute.ReadAttribute(xElement);

            // Advanced attributes
            frameAttribute.ReadAttribute(xElement);
            rulesAttribute.ReadAttribute(xElement);

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

        protected override bool IsValidSubType(IXHTMLItem item)
        {
            // may appear only once and only as first element
            if (item is TableCaption)
            {
                if (content.Count > 0)
                {
                    return false;
                }
                IXHTMLItem seekItem = content.Find(x => x is TableCaption);
                if (seekItem != null)
                {
                    return false;
                }
                return item.IsValid();
            }
            if (item is ColElement)
            {
                return item.IsValid();
            }
            if (item is ColGroup)
            {
                return item.IsValid();
            }
            if (item is TableBody)
            {
                IXHTMLItem seekItem = content.Find(x => x is TableBody);
                if (seekItem != null)
                {
                    return false;
                }
                seekItem = content.Find(x => x is TableRow);
                if (seekItem != null)
                {
                    return false;
                }
                return item.IsValid();
            }
            if (item is TableRow)
            {
                IXHTMLItem seekItem = content.Find(x => x is TableBody);
                if (seekItem != null)
                {
                    return false;
                }
                seekItem = content.Find(x => x is TableHead);
                if (seekItem != null)
                {
                    return false;
                }
                seekItem = content.Find(x => x is TableFooter);
                if (seekItem != null)
                {
                    return false;
                }
                return item.IsValid();
            }
            return false;
        }

        public override XNode Generate()
        {
            XElement xElement = new XElement(XhtmlNameSpace + ElementName);

            AddAtributes(xElement);

            // Basic attributes
            borderAttribute.AddAttribute(xElement);
            cellPaddingAttribute.AddAttribute(xElement);
            cellSpacingAttribute.AddAttribute(xElement);
            summaryAttribute.AddAttribute(xElement);
            widthAttribute.AddAttribute(xElement);

            // Advanced attributes
            frameAttribute.AddAttribute(xElement);
            rulesAttribute.AddAttribute(xElement);

            foreach (var item in content)
            {
                xElement.Add(item.Generate());
            }
            return xElement;
        }

        public override bool IsValid()
        {
            // TODO: perform full validation based on:
            //
            // The following element may appear only as the first one inside table :
            // * caption may appear at most once
            // Either one or the other or neither of the following two elements may then appear:
            //
            // * col may appear any number of times or not at all
            // * colgroup may appear any number of times or not at all
            //
            // Finally, one or more of the following elements must then appear in the order listed:
            // * thead may appear at most once, and only if tbody appears
            // * tfoot may appear at most once, and only if tbody appears
            // * tbody must appear at least once if, and only if, tr does not appear
            // * tr must appear at least once if, and only if, tbody does not appear
            return true;
        }
    }
}
