using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.Model.Interfaces
{
    public interface IContent
    {
        long ContentID { get; set; }
        long FormatID { get; set; }
        string Name { get; }
        IValueInput Value { get; set; }
        bool OnlyOne { get; set; }
    }
}
