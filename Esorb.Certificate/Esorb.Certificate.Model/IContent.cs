using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.Model
{
    interface IContent
    {
        long ContentID { get; set; }
        long FormatID { get; set; }
        string Name { get; }
        bool OnlyOne { get; set; }
        public string GetFormatedOutput();
    }
}
