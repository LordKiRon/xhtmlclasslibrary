using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XHTMLClassLibrary.AttributeDataTypes;

namespace XHTMLClassLibrary.Attributes.Events
{
    public abstract class OnEventAttribute : BaseAttribute
    {
        private Script attrObject = new Script();

        protected abstract string GetAttributeName();

        #region Overrides of BaseAttribute

        public override void AddAttribute(XElement xElement)
        {
            if (!hasValue)
            {
                return;
            }
            xElement.Add(new XAttribute(GetAttributeName(), attrObject.Value));
        }

        public override void ReadAttribute(XElement element)
        {
            hasValue = false;
            attrObject = null;
            XAttribute xObject = element.Attribute(GetAttributeName());
            if (xObject != null)
            {
                attrObject = new Script();
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
                hasValue = true;
            }
        }

        #endregion
    }
}