using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using XHTMLClassLibrary.BaseElements.BlockElements;
using XHTMLClassLibrary.BaseElements.FormMenuOptions;
using XHTMLClassLibrary.BaseElements.InlineElements;
using XHTMLClassLibrary.BaseElements.Legends;
using XHTMLClassLibrary.BaseElements.ListElements;
using XHTMLClassLibrary.BaseElements.MapAreas;
using XHTMLClassLibrary.BaseElements.Ruby;
using XHTMLClassLibrary.BaseElements.Structure_Header;
using XHTMLClassLibrary.BaseElements.TableElements;
using XHTMLClassLibrary.ObjectParameters;

namespace XHTMLClassLibrary.BaseElements
{
    public static class ElementFactory
    {
        public static IXHTMLItem CreateElement(XNode xNode)
        {
            if (xNode.NodeType == XmlNodeType.Element)
            {
                XElement element = (XElement) xNode;
                switch (element.Name.LocalName)
                {
                    case Anchor.ElementName:
                        return new Anchor();
                    case Abbreviation.ElementName:
                        return new Abbreviation();
                    case Acronym.ElementName:
                        return new Acronym();
                    case BoldText.ElementName:
                        return new BoldText();
                    case BiDirectionalOverride.ElementName:
                        return new BiDirectionalOverride();
                    case BigText.ElementName:
                        return new BigText();
                    case EmptyLine.ElementName:
                        return new EmptyLine();
                    case Button.ElementName:
                        return new Button();
                    case Citation.ElementName:
                        return new Citation();
                    case CodeText.ElementName:
                        return new CodeText();
                    case Definition.ElementName:
                        return new Definition();
                    case DeletedText.ElementName:
                        return new DeletedText();
                    case EmphasisedText.ElementName:
                        return new EmphasisedText();
                    case ItalicText.ElementName:
                        return new ItalicText();
                    case Image.ElementName:
                        return new Image();
                    case InsertedText.ElementName:
                        return new InsertedText();
                    case Input.ElementName:
                        return new Input();
                    case Label.ElementName:
                        return new Label();
                    case Area.ElementName:
                        return new Area();
                    case Map.ElementName:
                        return new Map();
                    case Kbd.ElementName:
                        return new Kbd();
                    case Param.ElementName:
                        return new Param();
                    case EmbededObject.ElementName:
                        return new EmbededObject();
                    case ShortQuote.ElementName:
                        return new ShortQuote();
                    case RbElement.ElementName:
                        return new RbElement();
                    case RbContainer.ElementName:
                        return new RbContainer();
                    case RpElement.ElementName:
                        return new RpElement();
                    case RtElement.ElementName:
                        return new RtElement();
                    case RtContainer.ElementName:
                        return new RtContainer();
                    case RubyElement.ElementName:
                        return new RubyElement();
                    case SampleText.ElementName:
                        return new SampleText();
                    case Script.ElementName:
                        return new Script();
                    case Select.ElementName:
                        return new Select();
                    case Option.ElementName:
                        return new Option();
                    case OptionGroup.ElementName:
                        return new OptionGroup();
                    case SmallText.ElementName:
                        return new SmallText();
                    case Span.ElementName:
                        return new Span();
                    case Strong.ElementName:
                        return new Strong();
                    case Sub.ElementName:
                        return new Sub();
                    case Sup.ElementName:
                        return new Sup();
                    case TextArea.ElementName:
                        return new TextArea();
                    case TeleTypeText.ElementName:
                        return new TeleTypeText();
                    case Var.ElementName:
                        return new Var();
                    case Base.ElementName:
                        return new Base();
                    case Body.ElementName:
                        return new Body();
                    case Link.ElementName:
                        return new Link();
                    case Meta.ElementName:
                        return new Meta();
                    case Style.ElementName:
                        return new Style();
                    case Title.ElementName:
                        return new Title();
                    case Head.ElementName:
                        return new Head();
                    case HTML.ElementName:
                        return new HTML();
                    case Address.ElementName:
                        return new Address();
                    case BlockQuoteElement.ElementName:
                        return new BlockQuoteElement();
                    case Div.ElementName:
                        return new Div();
                    case H1.ElementName:
                        return new H1();
                    case H2.ElementName:
                        return new H2();
                    case H3.ElementName:
                        return new H3();
                    case H4.ElementName:
                        return new H4();
                    case H5.ElementName:
                        return new H5();
                    case H6.ElementName:
                        return new H6();
                    case HorizontalRule.ElementName:
                        return new HorizontalRule();
                    case NoScript.ElementName:
                        return new NoScript();
                    case Paragraph.ElementName:
                        return new Paragraph();
                    case PreFormated.ElementName:
                        return new PreFormated();
                    case DefinitionDescription.ElementName:
                        return new DefinitionDescription();
                    case DefinitionTerms.ElementName:
                        return new DefinitionTerms();
                    case DefinitionList.ElementName:
                        return new DefinitionList();
                    case ListItem.ElementName:
                        return new ListItem();
                    case OrderedList.ElementName:
                        return new OrderedList();
                    case UnorderedList.ElementName:
                        return new UnorderedList();
                    case Legend.ElementName:
                        return new Legend();    
                    case FieldSet.ElementName:
                        return new FieldSet();
                    case TableCaption.ElementName:
                        return new TableCaption();
                    case ColElement.ElementName:
                        return new ColElement();
                    case ColGroup.ElementName:
                        return new ColGroup();
                    case TableBody.ElementName:
                        return new TableBody();
                    case TableRow.ElementName:
                        return new TableRow();
                    case HeaderCell.ElementName:
                        return new HeaderCell();
                    case TableData.ElementName:
                        return new TableData();
                    case TableFooter.ElementName:
                        return new TableFooter();
                    case TableHead.ElementName:
                        return new TableHead();
                    case Table.ElementName:
                        return new Table();
                    case Form.ElementName:
                        return new Form();
                }
                
            }
            else if (xNode.NodeType == XmlNodeType.Text)
            {
                return new SimpleEPubText();
            }
            return null;
        }
    }
}
