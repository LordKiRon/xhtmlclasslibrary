using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.Attributes;
using XHTMLClassLibrary.Attributes.Events;
using XHTMLClassLibrary.Exceptions;

namespace XHTMLClassLibrary.BaseElements.BlockElements
{
    /// <summary>
    /// The form element is used to create data entry forms. 
    /// Data collected in the form is sent to the server for processing by server-side scripts such as PHP, ASP, etc.
    /// </summary>
    public class Form : BaseBlockElement
    {
        internal const string ElementName = "form";

        // Basic attributes
        private readonly ActionAttribute actionAttribute = new ActionAttribute();
        private readonly MethodAttribute methodAttribute = new MethodAttribute();

        // Advanced attributes
        private readonly AcceptAttribute acceptAttribute = new AcceptAttribute();
        private readonly AcceptCharsetsAttribute acceptCharsetsAttribute = new AcceptCharsetsAttribute();
        private readonly EncTypeAttribute encTypeAttribute = new EncTypeAttribute();
        private readonly OnResetEventAttribute onReset = new OnResetEventAttribute();
        private readonly OnSubmitEventAttribute onSubmit = new OnSubmitEventAttribute();



        /// <summary>
        /// Specifies the location of the server-side script used to process data collected in the form.
        /// </summary>
        public ActionAttribute Action { get { return actionAttribute; } }


        /// <summary>
        /// Specifies the type of HTTP method used to send data to the server. 
        /// The default is get when the form data is sent to the server encoded into the URL specified in the action attribute. 
        /// Most forms use post when form data is sent to the server in the body of the HTTP message.
        /// </summary>
        public MethodAttribute Method { get { return methodAttribute; } }


        /// <summary>
        /// This attribute specifies a comma-separated list of content types that a server processing the form will handle correctly.
        /// </summary>
        public AcceptAttribute Accept { get { return acceptAttribute; } }


        /// <summary>
        /// This attribute specifies the list of character encodings for input data that are accepted by the server processing the form.
        /// </summary>
        public AcceptCharsetsAttribute AcceptCharsets { get { return acceptCharsetsAttribute; } }


        /// <summary>
        /// This attribute specifies the content type used to send form data to the server when the value of method is post. 
        /// The default value for this attribute is "application/x-www-form-urlencoded". 
        /// If a form contains a file upload control (input element with type value of file), then this attribute value should be "multipart/form-data".
        /// </summary>
        public EncTypeAttribute EncType { get { return encTypeAttribute; } }


        /// <summary>
        /// A client-side script event that occurs when a form is reset (all form controls are set to their initial values).
        /// </summary>
        public OnResetEventAttribute OnReset { get { return onReset; } }


        /// <summary>
        /// A client-side script event that occurs when a form is submitted (form data is sent to server-side scripts for processing).
        /// </summary>
        public OnSubmitEventAttribute OnSubmit { get { return onSubmit; } }



        #region Overrides of BaseBlockElement

        /// <summary>
        /// Loads the element from XNode
        /// </summary>
        /// <param name="xNode">node to load element from</param>
        public override void Load(XNode xNode)
        {
            if (xNode.NodeType != XmlNodeType.Element)
            {
                throw new Exception("xNode is not of element type");
            }
            XElement xElement = (XElement)xNode;
            if (xElement.Name.LocalName != ElementName)
            {
                throw new Exception(string.Format("xNode is not {0} element", ElementName));
            }

            ReadAttributes(xElement);

            // Basic attributes
            actionAttribute.ReadAttribute(xElement);
            methodAttribute.ReadAttribute(xElement);

            // Advanced attributes
            acceptAttribute.ReadAttribute(xElement);
            acceptCharsetsAttribute.ReadAttribute(xElement);
            encTypeAttribute.ReadAttribute(xElement);
            onReset.ReadAttribute(xElement);
            onSubmit.ReadAttribute(xElement);

            content.Clear();
            IEnumerable<XNode> descendants = xElement.Nodes();
            foreach (var node in descendants)
            {
                IXHTMLItem item = ElementFactory.CreateElement(node);
                if ((item != null) && IsValidSubType(item))
                {
                    try
                    {
                        item.Load(node);
                        content.Add(item);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }

        }

        protected override bool IsValidSubType(IXHTMLItem item)
        {
            if (item is IBlockElement)
            {
                if (item is Form)
                {
                    // TODO: check into the full depth to avoid FORM elements
                    return false;
                }
                return item.IsValid();
            }
            if (item is FieldSet)
            {
                return item.IsValid();
            }
            return false;
        }


        /// <summary>
        /// Generates element to XNode from data
        /// </summary>
        /// <returns>generated XNode</returns>
        public override XNode Generate()
        {
            XElement xElement = new XElement(XhtmlNameSpace + ElementName);

            AddAtributes(xElement);

            // Basic attributes
            actionAttribute.AddAttribute(xElement);
            methodAttribute.AddAttribute(xElement);

            // Advanced attributes
            acceptAttribute.AddAttribute(xElement);
            acceptCharsetsAttribute.AddAttribute(xElement);
            encTypeAttribute.AddAttribute(xElement);
            onReset.AddAttribute(xElement);
            onSubmit.AddAttribute(xElement);

            foreach (var item in content)
            {
                xElement.Add(item.Generate());
            }
            return xElement;
        }

        /// <summary>
        /// Checks it element data is valid
        /// </summary>
        /// <returns>true if valid</returns>
        public override bool IsValid()
        {
            return true;
        }

        #endregion
    }
}
