using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.Model
{
    public class GradeLimit : PersistentObject
    {
        public double PercentageLimit { get; set; }
        public string? Grade { get; set; }
        public int GradeNumeric { get; set; }
        public string? Explanation { get; set; }
    }
}
