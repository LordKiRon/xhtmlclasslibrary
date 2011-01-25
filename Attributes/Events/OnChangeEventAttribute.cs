﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHTMLClassLibrary.Attributes.Events
{
    public class OnChangeEventAttribute : OnEventAttribute
    {
        #region Overrides of OnEventAttribute

        protected override string GetAttributeName()
        {
            return "onchange";
        }

        #endregion

    }
}