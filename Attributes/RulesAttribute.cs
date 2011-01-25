using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XHTMLClassLibrary.Attributes
{
    public class RulesAttribute : BaseAttribute
    {
        private enum RulesEnum
        {
            Invalid,
            None,
            Groups,
            Rows,
            Cols,
            All,
        }

        public override string Value
        {
            get
            {
                switch (rules)
                {
                    case RulesEnum.Groups:
                        return "groups";
                    case RulesEnum.Cols:
                        return "cols";
                    case RulesEnum.Rows:
                        return "rows";
                    case RulesEnum.None:
                        return "none";
                    case RulesEnum.All:
                        return "all";
                }
                return string.Empty;
            }

            set
            {
                switch (value.ToLower())
                {
                    case "groups":
                        rules = RulesEnum.Groups;
                        break;
                    case "cols":
                        rules = RulesEnum.Cols;
                        break;
                    case "rows":
                        rules = RulesEnum.Rows;
                        break;
                    case "none":
                        rules = RulesEnum.None;
                        break;
                    case "all":
                        rules = RulesEnum.All;
                        break;
                    default:
                        rules = RulesEnum.Invalid;
                        break;
                }
            }
        }


        private RulesEnum rules = RulesEnum.Invalid;

        internal const string attributeName = "rules";

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
