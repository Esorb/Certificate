using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.Model.Interfaces;

public interface IContent
{
    string Name { get; }
    int Position { get; set; }
    string ContentID { get; set; }
    string FormatID { get; set; }
    string CertificateTemplatePageId { get; set; }
    IValueInput Value { get; set; }
    bool OnlyOne { get; set; }
}
