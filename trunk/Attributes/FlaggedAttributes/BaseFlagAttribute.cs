using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XHTMLClassLibrary.AttributeDataTypes;

namespace XHTMLClassLibrary.Attributes.FlaggedAttributes
{
    public abstract class BaseFlagAttribute : BaseAttribute
    {
        private Text attrObject = new Text();

        public abstract string GetElementName();

        #region Overrides of BaseAttribute

        /// <summary>
        /// Set the attribute to on/off (disabled or not)
        /// </summary>
        /// <param name="disabled"></param>
        public void SetFlag(bool flag)
        {
            if (flag)
            {
                attrObject.Value = GetElementName();
                hasValue = true;
            }
            else
            {
                attrObject.Value = string.Empty;
                hasValue = false;
            }
        }

        public override void AddAttribute(XElement xElement)
        {
            if (!hasValue)
            {
                return;
            }
            xElement.Add(new XAttribute(GetElementName(), attrObject.Value));
        }

        public override void ReadAttribute(XElement element)
        {
            hasValue = false;
            attrObject = null;
            XAttribute xObject = element.Attribute(GetElementName());
            if (xObject != null)
            {
                attrObject = new Text();
                attrObject.Value = xObject.Value;
                hasValue = true;
            }
        }

        public override string Value
        {
            get
            {
                return attrObject.Value;
            }
            set
            {
                attrObject.Value = value;
                hasValue = (value != string.Empty);
            }
        }

        #endregion

    }
}