using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XHTMLClassLibrary.Attributes
{
    public class ScopeAttribute : BaseAttribute
    {
        private enum ScopeEnum
        {
            Invalid,
            Row,
            Col,
            RowGroup,
            ColGroup,
        }

        public override string Value
        {
            get
            {
                switch (scope)
                {
                    case ScopeEnum.Col:
                        return "col";
                    case ScopeEnum.ColGroup:
                        return "colgroup";
                    case ScopeEnum.RowGroup:
                        return "row";
                    case ScopeEnum.Row:
                        return "rowgroup";
                }
                return string.Empty;
            }

            set
            {
                switch (value.ToLower())
                {
                    case "col":
                        scope = ScopeEnum.Col;
                        break;
                    case "colgroup":
                        scope = ScopeEnum.ColGroup;
                        break;
                    case "rowgroup":
                        scope = ScopeEnum.RowGroup;
                        break;
                    case "row":
                        scope = ScopeEnum.Row;
                        break;
                    default:
                        scope = ScopeEnum.Invalid;
                        break;
                }
            }
        }


        private ScopeEnum scope = ScopeEnum.Invalid;

        internal const string attributeName = "scope";

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
