using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XHTMLClassLibrary.Attributes
{
    public class InputTypeAttribute : BaseAttribute
    {
        private enum InputTypeEnum
        {
            Invalid,
            Text,
            Password,
            CheckBox,
            Radio,
            Submit,
            Image,
            Reset,
            Button,
            Hidden,
            File,
        }

        private InputTypeEnum type = InputTypeEnum.Invalid;

        internal const string attributeName = "type";

        public override string Value
        {
            get
            {
                switch (type)
                {
                    case InputTypeEnum.Password:
                        return "password";
                    case InputTypeEnum.Radio:
                        return "radio";
                    case InputTypeEnum.CheckBox:
                        return "checkbox";
                    case InputTypeEnum.Text:
                        return "text";
                    case InputTypeEnum.Submit:
                        return "submit";
                    case InputTypeEnum.Image:
                        return "image";
                    case InputTypeEnum.Reset:
                        return "reset";
                    case InputTypeEnum.Button:
                        return "button";
                    case InputTypeEnum.Hidden:
                        return "hidden";
                    case InputTypeEnum.File:
                        return "file";
                }
                return string.Empty;
            }

            set
            {
                hasValue = true;
                switch (value.ToLower())
                {
                    case "password":
                        type = InputTypeEnum.Password;
                        break;
                    case "radio":
                        type = InputTypeEnum.Radio;
                        break;
                    case "checkbox":
                        type = InputTypeEnum.CheckBox;
                        break;
                    case "text":
                        type = InputTypeEnum.Text;
                        break;
                    case "submit":
                        type = InputTypeEnum.Submit;
                        break;
                    case "image":
                        type = InputTypeEnum.Image;
                        break;
                    case "reset":
                        type =  InputTypeEnum.Reset;
                        break;
                    case "button":
                        type = InputTypeEnum.Button;
                        break;
                    case "hidden":
                        type = InputTypeEnum.Hidden;
                        break;
                    case "file":
                        type = InputTypeEnum.File;
                        break;
                    default:
                        type = InputTypeEnum.Invalid;
                        hasValue = false;
                        break;
                }
            }
        }

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
