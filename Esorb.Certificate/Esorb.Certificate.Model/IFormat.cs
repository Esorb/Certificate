using System.Drawing;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace Esorb.Certificate.Model
{
    interface IFormat
    {
        long FormatID { get; set; }
        int PageNumber { get; set; }
        int PositionOnPage { get; set; }
        List<IContent> Contents { get; set; }
        ICondition Condition { get; set; }

        public void PrintTo(DocX document);
    }
}