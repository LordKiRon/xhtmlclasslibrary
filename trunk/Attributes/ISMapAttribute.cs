using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XHTMLClassLibrary.AttributeDataTypes;

namespace XHTMLClassLibrary.Attributes
{
    public class ISMapAttribute : BaseAttribute
    {
        private Text attrObject = new Text();

        internal const string attributeName = "ismap";

        #region Overrides of BaseAttribute

        /// <summary>
        /// Set the attribute to on/off (ismap or not)
        /// </summary>
        /// <param name="disabled"></param>
        public void SetISMap(bool disabled)
        {
            if (disabled)
            {
                attrObject.Value = "ismap";
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
            xElement.Add(new XAttribute(attributeName, attrObject.Value));
        }

        public override void ReadAttribute(XElement element)
        {
            hasValue = false;
            attrObject = null;
            XAttribute xObject = element.Attribute(attributeName);
            if (xObject != null)
            {
                attrObject = new Text();
                attrObject.Value = xObject.Value;
                hasValue = true;
            }
        }

        public override string Value
        {
            get { return attrObject.Value; }
            set
            {
                attrObject.Value = value;
                hasValue = (value != string.Empty);
            }
        }
        #endregion
    }
}
