using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XHTMLClassLibrary.AttributeDataTypes;

namespace XHTMLClassLibrary.Attributes
{
    public class AccessKeyAttribute : BaseAttribute
    {
        private Character attrObject = new Character();

        internal const string attributeName = "accesskey";

        #region Overrides of BaseAttribute

        public override void AddAttribute(XElement xElement)
        {
            if (!hasValue)
            {
                return;
            }
            xElement.Add(new XAttribute(attributeName, attrObject.Value));
        }

        public override void ReadAttribute(XElement element)
        {
            hasValue = false;
            attrObject = null;
            XAttribute xObject = element.Attribute(attributeName);
            if ((xObject != null) && (xObject.Value.Length > 0))
            {
                attrObject = new Character();
                attrObject.Value = xObject.Value[0];
                hasValue = true;
            }

        }

        public override string Value
        {
            get { return string.Format("{0}",attrObject.Value); }
            set
            {
                if (value != string.Empty)
                {
                    attrObject.Value = value[0];
                    hasValue = true;
                }
                else
                {
                    hasValue = false;
                }
            }
        }
        #endregion
    }
}
