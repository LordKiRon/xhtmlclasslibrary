using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XHTMLClassLibrary.Attributes
{
    public class VAlignAttribute : BaseAttribute
    {
        private enum VAlign
        {
            Invalid,
            Top,
            Middle,
            Bottom,
            BaseLine,
        }

        public override string Value
        {
            get
            {
                switch (valign)
                {
                    case VAlign.Middle:
                        return "middle";
                    case VAlign.BaseLine:
                        return "baseline";
                    case VAlign.Bottom:
                        return "bottom";
                    case VAlign.Top:
                        return "top";
                }
                return string.Empty;
            }

            set
            {
                switch (value.ToLower())
                {
                    case "middle":
                        valign = VAlign.Middle;
                        break;
                    case "baseline":
                        valign = VAlign.BaseLine;
                        break;
                    case "bottom":
                        valign = VAlign.Bottom;
                        break;
                    case "top":
                        valign = VAlign.Top;
                        break;
                    default:
                        valign = VAlign.Invalid;
                        break;
                }
            }
        }


        private VAlign valign = VAlign.Invalid;

        internal const string attributeName = "valign";

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
