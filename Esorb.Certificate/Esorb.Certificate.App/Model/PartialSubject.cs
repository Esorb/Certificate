using Esorb.Certificate.App.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.Model;

public class PartialSubject : ViewModelBase
{
    private long partialSubjectID;

    public long PartialSubjectID
    {
        get { return partialSubjectID; }
        set { partialSubjectID = value; }
    }

}
