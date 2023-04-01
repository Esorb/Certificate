using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.Model;

public abstract class PersistentObject : IPersistentObject
{
    //public PersistentObject()
    //{
    //    ID = Guid.NewGuid().ToString();
    //}
    public string? ID { get; set; }
}
