﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XHTMLClassLibrary.AttributeDataTypes;

namespace XHTMLClassLibrary.Attributes
{
    public class ProfileAttribute : BaseAttribute
    {
        private URIs attrObject = new URIs();

        internal const string attributeName = "profile";

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
            if (xObject != null)
            {
                attrObject = new URIs();
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
