using Esorb.Certificate.App.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace Esorb.Certificate.App.Model.Formats;

public class SimpleLineOfText : IFormat
{
    public long FormatID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int PageNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int PositionOnPage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool ExpectedConditionValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    List<IContent> IFormat.Contents { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    ICondition IFormat.Condition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void PrintTo(DocX document)
    {
        throw new NotImplementedException();
    }
}
