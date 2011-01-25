using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISOLanguages;

namespace XHTMLClassLibrary.AttributeDataTypes
{
    /// <summary>
    /// A language code. For example, fr or en-gb
    /// </summary>
    public class LanguageCode
    {
        private readonly Languages language = new Languages();

        public string Value
        {
            get
            {
                return language.GetAsIsoName();
            }

            set
            {
                language.SetLanguageId(value);
            }
        }
    }
}
