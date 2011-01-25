using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XHTMLClassLibrary.Attributes
{
    public class MethodAttribute : BaseAttribute
    {
        private enum MethodEnum
        {
            Invalid,
            Get,
            Post,
        }

        public override string Value
        {
            get
            {
                switch (method)
                {
                    case MethodEnum.Post:
                        return "post";
                    case MethodEnum.Get:
                        return "get";
                }
                return string.Empty;
            }

            set
            {
                switch (value.ToLower())
                {
                    case "post":
                        method = MethodEnum.Post;
                        break;
                    case "get":
                        method = MethodEnum.Get;
                        break;
                    default:
                        method = MethodEnum.Invalid;
                        break;
                }
            }
        }


        private MethodEnum method = MethodEnum.Invalid;

        internal const string attributeName = "method";

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
