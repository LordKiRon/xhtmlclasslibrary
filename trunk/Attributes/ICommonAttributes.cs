using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHTMLClassLibrary.Attributes
{
    /// <summary>
    /// Attributes that can be part of any HTML5 element
    /// </summary>
    public interface ICommonAttributes
    {
        ClassAttr Class { get; }
        IdAttribute ID { get; }
        TitleAttribute Title { get; }
        StyleAttribute Style { get; }
    }

}
