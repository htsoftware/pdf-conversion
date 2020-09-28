using iText.Html2pdf.Attach;
using iText.Html2pdf.Attach.Impl;
using iText.Html2pdf.Attach.Impl.Tags;
using iText.Html2pdf.Html;
using iText.Layout;
using iText.StyledXmlParser.Node;
using PdfConversion.Constant;

namespace FSReport.Custom
{
    public class CustomTagWorkerFactory : DefaultTagWorkerFactory
    {
        public override ITagWorker GetCustomTagWorker(IElementNode tag, ProcessorContext context)
        {
            if (TagConstants.HTML.Equals(tag.Name()))
            {
                return new CustomMarginHtmlTagWorker(tag, context);
            }

            return null;
        }
    }

    public class CustomMarginHtmlTagWorker : HtmlTagWorker
    {
        public CustomMarginHtmlTagWorker(IElementNode element, ProcessorContext context) : base(element, context)
        {
            Document doc = (Document)GetElementResult();
            doc.SetMargins(PdfFormation.PAGE_MARGIN_TOP, PdfFormation.PAGE_MARGIN_RIGHT, PdfFormation.PAGE_MARGIN_BOTTOM, PdfFormation.PAGE_MARGIN_LEFT);
        }
    }
}
