using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XHTMLClassLibrary.AttributeDataTypes
{
    /// <summary>
    /// The value may be either in pixels or a percentage of the available horizontal or vertical space. 
    /// Thus, the value "50%" means half of the available space.
    /// </summary>
    public class Length
    {
        private enum DataType
        {
            Unknown,
            Points,
            Percents
        }

        private DataType valueType = DataType.Unknown;
        private int dataValue;


        public string Value
        {
            get
            {
                switch (valueType)
                {
                    case DataType.Percents:
                        return string.Format("{0}%", valueType);
                    case DataType.Points:
                        return dataValue.ToString();
                }
                return string.Empty;
            }

            set
            {
                valueType = DataType.Unknown;
                if (value.Contains("%"))
                {
                    int pos = value.IndexOf("%");
                    string temp = value.Remove(pos);
                    if (int.TryParse(temp,out dataValue))
                    {
                       valueType = DataType.Percents;
                    }
                }
                else
                {
                    if (int.TryParse(value,out dataValue))
                    {
                       valueType = DataType.Points;
                    }
                }
            }
        }
    }
}
