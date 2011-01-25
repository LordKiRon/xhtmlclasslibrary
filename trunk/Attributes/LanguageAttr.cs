using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using ISOLanguages;

namespace XHTMLClassLibrary.Attributes
{
    public class LanguageAttr : BaseAttribute
    {
        private Languages  Language = new Languages();
        internal const string attributeName = "lang";

        #region Overrides of BaseAttribute

        public override void AddAttribute(XElement xElement)
        {
            if (!hasValue)
            {
                return;
            }
            xElement.Add(new XAttribute(XNamespace.Xml + attributeName, Language.GetAsIsoName()));

        }

        public override void ReadAttribute(XElement element)
        {
            hasValue = false;
            XAttribute xLanguage = element.Attribute(XNamespace.Xml + attributeName);
            if (xLanguage != null)
            {
                Language = new Languages();
                Language.SetLanguageId(xLanguage.Value);
                hasValue = true;
            }

        }
        public override string Value
        {
            get { return Language.GetAsIsoName(); }
            set
            {
                Language.SetLanguageId(value);
                hasValue = (Language.Language != LanguagesEnum.Unknown);
            }
        }

        #endregion
    }
}
