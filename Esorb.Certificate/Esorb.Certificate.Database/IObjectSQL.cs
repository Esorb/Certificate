using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.Database
{
    public interface IObjectSQL
    {
        public string Insert { get; }
        public string Update { get; }
        public string SelectById { get; }
        public string SelectAll { get; }
        public string DeleteById { get; }
        public string DeleteAll { get; }
        public string Count { get; }
        public string CreateTable { get; }
        public string DropTable { get; }

    }
}
