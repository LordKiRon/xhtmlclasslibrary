using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XHTMLClassLibrary.Attributes
{
    public class ValueTypeAttribute : BaseAttribute
    {
        private enum ValueTypeEnum
        {
            Invalid,
            Data,
            Ref,
            Object,
        }

        public override string Value
        {
            get
            {
                switch (type)
                {
                    case ValueTypeEnum.Ref:
                        return "ref";
                    case ValueTypeEnum.Object:
                        return "object";
                    case ValueTypeEnum.Data:
                        return "data";
                }
                return string.Empty;
            }

            set
            {
                switch (value.ToLower())
                {
                    case "ref":
                        type = ValueTypeEnum.Ref;
                        break;
                    case "object":
                        type = ValueTypeEnum.Object;
                        break;
                    case "data":
                        type = ValueTypeEnum.Data;
                        break;
                    default:
                        type = ValueTypeEnum.Invalid;
                        break;
                }
            }
        }


        private ValueTypeEnum type = ValueTypeEnum.Invalid;

        internal const string attributeName = "valuetype";

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
