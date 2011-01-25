using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XHTMLClassLibrary.Attributes
{
    public enum TextDirection
    {
        Unknown,
        LtR, // left to right
        RtL, // Right to left
    }

    public class DirectionAttr : BaseAttribute
    {
        private TextDirection direction = TextDirection.Unknown;

        internal const string attributeName = "dir";

        #region Implementation of IBaseAttribute

        public override void AddAttribute(XElement xElement)
        {
            if (!hasValue)
            {
                return;
            }
            string dir = "ltr";
            if (direction == TextDirection.RtL)
            {
                dir = "rtl";
            }
            XAttribute xLang = new XAttribute(attributeName, dir);
            xElement.Add(xLang);

        }

        public override void ReadAttribute(XElement element)
        {
            direction = TextDirection.Unknown;
            hasValue = false;
            XAttribute xDirection = element.Attribute(attributeName);
            if (xDirection != null)
            {
                hasValue = true;
                switch (xDirection.Value.ToLower())
                {
                    case "ltr":
                        direction = TextDirection.LtR;
                        break;
                    case "rtl":
                        direction = TextDirection.RtL;
                        break;
                }
            }

        }

        public override string Value
        {
            get
            {
                switch (direction)
                {
                    case TextDirection.LtR:
                        return "ltr";
                    case TextDirection.RtL:
                        return "rtl";
                }
                return string.Empty;
            }
            set
            {
                hasValue = true;
                switch (value.ToLower())
                {
                    case "ltr":
                        direction = TextDirection.LtR;
                        break;
                    case "rtl":
                        direction = TextDirection.RtL;
                        break;
                    default:
                        direction = TextDirection.Unknown;
                        hasValue = false;
                        break;
                }
                
            }
        }

        #endregion
    }
}
