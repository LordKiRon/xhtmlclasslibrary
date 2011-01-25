using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XHTMLClassLibrary.Attributes
{
    public class ShapeAttribute : BaseAttribute
    {
        private enum ShapeEnum
        {
            Invalid,
            Rect,
            Circle,
            Poly,
            Default,
        }

        public override string Value
        {
            get
            {
                switch (shape)
                {
                    case ShapeEnum.Circle:
                        return "circle";
                    case ShapeEnum.Default:
                        return "default";
                    case ShapeEnum.Poly:
                        return "poly";
                    case ShapeEnum.Rect:
                        return "rect";
                }
                return string.Empty;
            }

            set
            {
                switch (value.ToLower())
                {
                    case "circle":
                        shape = ShapeEnum.Circle;
                        break;
                    case "default":
                        shape = ShapeEnum.Default;
                        break;
                    case "poly":
                        shape = ShapeEnum.Poly;
                        break;
                    case "rect":
                        shape = ShapeEnum.Rect;
                        break;
                    default:
                        shape = ShapeEnum.Invalid;
                        break;
                }
            }
        }


        private ShapeEnum shape = ShapeEnum.Invalid;

        internal const string attributeName = "shape";

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
