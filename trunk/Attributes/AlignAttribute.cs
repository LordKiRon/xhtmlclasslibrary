using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XHTMLClassLibrary.Attributes
{
    public class AlignAttribute : BaseAttribute
    {
        private enum Align
        {
            Invalid,
            Left,
            Center,
            Right,
            Justify,
            Char,
        }

        public override string Value
        {
            get
            {
                switch (align)
                {
                    case Align.Center:
                        return "center";
                    case Align.Justify:
                        return "justify";
                    case Align.Right:
                        return "right";
                    case Align.Left:
                        return "left";
                    case Align.Char:
                        return "char";
                }
                return string.Empty;
            }

            set
            {
                switch (value.ToLower())
                {
                    case "center":
                        align = Align.Center;
                        break;
                    case "justify":
                        align = Align.Justify;
                        break;
                    case "right":
                        align = Align.Right;
                        break;
                    case "left":
                        align = Align.Left;
                        break;
                    case "char":
                        align = Align.Char;
                        break;
                    default:
                        align = Align.Invalid;
                        break;
                }
            }
        }


        private Align align = Align.Invalid;

        internal const string attributeName = "align";

        #region Overrides of BaseAttribute

        public override void AddAttribute(XElement xElement)
        {
            if (!hasValue)
            {
                return;
            }
            xElement.Add(new XAttribute(attributeName, Value));
        }

        public override void ReadAttribute(XElement element)
        {
            hasValue = false;
            XAttribute xObject = element.Attribute(attributeName);
            if (xObject != null)
            {
                Value = xObject.Value;
            }
        }

        #endregion

    }
}
