using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.Model;

public class SchoolClass : PersistentObject
{
    public string ClassName { get; set; } = string.Empty;
    public int Yearlevel { get; set; }
    public int HalfYear { get; set; }
    public IList<Pupil> Pupils { get; set; } = new List<Pupil>();
}
