﻿using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.Attributes;
using XHTMLClassLibrary.BaseElements.BlockElements;

namespace XHTMLClassLibrary.BaseElements.InlineElements
{
    public class PreFormated : TextBasedElement
    {
        internal const string ElementName = "pre";

        private readonly XMLSpaceAttribute _xmlspaceAttribute = new XMLSpaceAttribute();


        /// <summary>
        /// This attribute indicates if white space (extra spaces, tabs) should be preserved. 
        /// Possible value is "preserve".
        /// </summary>
        public XMLSpaceAttribute PreserveSpace { get { return _xmlspaceAttribute; } }

        protected override string GetElementName()
        {
            return ElementName;
        }


        protected override bool IsValidSubType(IXHTMLItem item)
        {
            if (!base.IsValidSubType(item))
            {
                return false;
            }
            if (item is Image || item is BigText ||
                item is SmallText || item is Sub ||
                item is Sup)
            {
                return false;
            }
            if (item.SubElements().FindAll((x) => x is Image).Count > 0)
            {
                return false;
            }
            if (item.SubElements().FindAll((x) => x is BigText).Count > 0)
            {
                return false;
            }
            if (item.SubElements().FindAll((x) => x is SmallText).Count > 0)
            {
                return false;
            }
            if (item.SubElements().FindAll((x) => x is Sub).Count > 0)
            {
                return false;
            }
            if (item.SubElements().FindAll((x) => x is Sup).Count > 0)
            {
                return false;
            }
            return true;
        }
    }
}
