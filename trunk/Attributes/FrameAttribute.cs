using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XHTMLClassLibrary.Attributes
{
    public class FrameAttribute : BaseAttribute
    {
        private enum FrameTypeEnum
        {
            Invalid,
            Void,
            Above,
            Below,
            HSides,
            VSides,
            LeftHandSide,
            RightHandSide,
            Box,
            Border,
        }

        public override string Value
        {
            get
            {
                switch (type)
                {
                    case FrameTypeEnum.Above:
                        return "above";
                    case FrameTypeEnum.HSides:
                        return "hsides";
                    case FrameTypeEnum.Below:
                        return "below";
                    case FrameTypeEnum.Void:
                        return "void";
                    case FrameTypeEnum.VSides:
                        return "vsides";
                    case FrameTypeEnum.LeftHandSide:
                        return "lhs";
                    case FrameTypeEnum.RightHandSide:
                        return "rhs";
                    case FrameTypeEnum.Box:
                        return "box";
                    case FrameTypeEnum.Border:
                        return "border";
                }
                return string.Empty;
            }

            set
            {
                switch (value.ToLower())
                {
                    case "above":
                        type = FrameTypeEnum.Above;
                        break;
                    case "hsides":
                        type = FrameTypeEnum.HSides;
                        break;
                    case "below":
                        type = FrameTypeEnum.Below;
                        break;
                    case "void":
                        type = FrameTypeEnum.Void;
                        break;
                    case "vsides":
                        type = FrameTypeEnum.VSides;
                        break;
                    case "lhs":
                        type = FrameTypeEnum.LeftHandSide;
                        break;
                    case "rhs":
                        type = FrameTypeEnum.RightHandSide;
                        break;
                    case "box":
                        type = FrameTypeEnum.Box;
                        break;
                    case "border":
                        type = FrameTypeEnum.Border;
                        break;
                    default:
                        type = FrameTypeEnum.Invalid;
                        break;
                }
            }
        }


        private FrameTypeEnum type = FrameTypeEnum.Invalid;

        internal const string attributeName = "frame";

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
