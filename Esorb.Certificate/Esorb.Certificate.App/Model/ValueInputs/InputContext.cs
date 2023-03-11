using Esorb.Certificate.App.Model.Interfaces;
using Esorb.Certificate.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.Model.ValueInputs;

public class InputContext : PersistentObject
{
    public string ValueInputID { get; set; } = string.Empty;
    public string PupilID { get; set; } = string.Empty;
    public string CertificateID { get; set; } = string.Empty;
    public string ContentID { get; set; } = string.Empty;
    public Pupil? Pupil { get; set; }
    public Certificate? Certificate { get; set; }
    public IContent? Content { get; set; }
}
