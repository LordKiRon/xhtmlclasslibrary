using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHTMLClassLibrary.Exceptions
{
    public class XHTMLViolationException : Exception
    {
        public XHTMLViolationException()
            : base("Adding this element violates XHTML structure rulls")
        {
        }
        public XHTMLViolationException(string addMessage)
            : base(string.Format("Adding this element violates XHTML structure rulls: {0}",addMessage))
        {
            
        }

        public override string Message
        {
            get
            {
                return string.Format("{0} - {1}",base.StackTrace,base.Message);

            }
        }
    }
}
