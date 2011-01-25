using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XHTMLClassLibrary.Attributes
{
    internal interface IBaseAttribute
    {
        void AddAttribute(XElement xElement);
        void ReadAttribute(XElement element);
        bool HasValue();
        string Value { get; set;}
    }

    public  abstract class BaseAttribute : IBaseAttribute
    {
        protected bool hasValue = false;
        #region Implementation of IBaseAttribute

        public abstract void AddAttribute(XElement xElement);
        public abstract void ReadAttribute(XElement element);
        
        public bool HasValue()
        {
            return hasValue;
        }

        public abstract string Value { get; set; }

        #endregion
    }
}
