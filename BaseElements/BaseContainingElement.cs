using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XHTMLClassLibrary.Exceptions;

namespace XHTMLClassLibrary.BaseElements
{
    public abstract class BaseContainingElement : IXHTMLItem 
    {
        protected readonly List<IXHTMLItem> content = new List<IXHTMLItem>();


        #region Implementation of IXHTMLItem

        /// <summary>
        /// Loads the element from XNode
        /// </summary>
        /// <param name="xNode">node to load element from</param>
        public abstract void Load(XNode xNode);

        /// <summary>
        /// Generates element to XNode from data
        /// </summary>
        /// <returns>generated XNode</returns>
        public abstract XNode Generate();

        /// <summary>
        /// Checks it element data is valid
        /// </summary>
        /// <returns>true if valid</returns>
        public abstract bool IsValid();

        /// <summary>
        /// Adds subitem to the item , only if 
        /// allowed by the rules and element can accept content
        /// </summary>
        /// <param name="item">subitem to add</param>
        public void Add(IXHTMLItem item)
        {
            if ((item != null) && IsValidSubType(item))
            {
                content.Add(item);
                item.Parent = this;
            }
            else
            {
                throw new XHTMLViolationException();
            }

        }

        /// <summary>
        /// Removes sub item 
        /// </summary>
        /// <param name="item">sub item to remove</param>
        public void Remove(IXHTMLItem item)
        {
            if (content.Remove(item))
            {
                item.Parent = null;
            }

        }

        /// <summary>
        /// Get list of all sub elements
        /// </summary>
        /// <returns></returns>
        public List<IXHTMLItem> SubElements()
        {
            return content;
        }


        /// <summary>
        /// Get/Set item parent in the XHTML "tree"
        /// </summary>
        public IXHTMLItem Parent { get; set; }


        #endregion

        /// <summary>
        /// Check if element can be sub element of this element (according to XHTML rules)
        /// </summary>
        /// <param name="item">element to check</param>
        /// <returns>true if it can be sub element, false otherwise</returns>
        protected abstract bool IsValidSubType(IXHTMLItem item);


    }
}
