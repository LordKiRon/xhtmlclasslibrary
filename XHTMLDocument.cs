using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XHTMLClassLibrary.BaseElements;
using XHTMLClassLibrary.BaseElements.Structure_Header;

namespace XHTMLClassLibrary
{
    public enum XHTMRulesEnum
    {
        Version1_Strict,
        Version1_Transitional,
        Version1_FrameSet,
        Version1_1,
        EPUBCompatible, // XHTML 1.1 Strict without
        // forms, server side Image maps , Intrinsic Events , Scripting
    }

    /// <summary>
    /// This class is implements base XHTML document
    /// </summary>
    public class XHTMLDocument 
    {
        private readonly HTML htmlRoot = new HTML();

        private XHTMRulesEnum compatibilityType = XHTMRulesEnum.EPUBCompatible;


        /// <summary>
        /// Get pointer to document's root HTML element
        /// </summary>
        public HTML RootHTML { get { return htmlRoot; } }



        public XHTMLDocument(XHTMRulesEnum versionType)
        {
            compatibilityType = versionType;
        }


        public XHTMLDocument()
        {
        }


        public XDocument Generate()
        {
            XDocument mainDocument = new XDocument();
            mainDocument.Add(GetDocumentType());
            mainDocument.Add(htmlRoot.Generate());
            return mainDocument;
        }

        public void Load(XDocument xDocument)
        {
            // TODO: check that it's valid document type etc
            htmlRoot.Load(xDocument.Root);
        }


        private XDocumentType GetDocumentType()
        {
            switch(compatibilityType)
            {
                case XHTMRulesEnum.EPUBCompatible:
                case XHTMRulesEnum.Version1_1:
                    return new XDocumentType("html", @"-//W3C//DTD XHTML 1.1//EN",
                                             @"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd", null);
                case XHTMRulesEnum.Version1_Strict:
                    return new XDocumentType("html", @"-//W3C//DTD XHTML 1.0 Strict//EN",
                                             @"DTD/xhtml1-strict.dtd", null);
                case XHTMRulesEnum.Version1_Transitional:
                    return new XDocumentType("html", @"-//W3C//DTD XHTML 1.0 Transitional//EN",
                                             @"DTD/xhtml1-transitional.dtd", null);
                case XHTMRulesEnum.Version1_FrameSet:
                    return new XDocumentType("html", @"-//W3C//DTD XHTML 1.0 Frameset//EN",
                                             @"DTD/xhtml1-frameset.dtd", null);
            }
            throw new NotImplementedException(string.Format("The case of {0} not implemented yet",compatibilityType));
        }

    }
}
