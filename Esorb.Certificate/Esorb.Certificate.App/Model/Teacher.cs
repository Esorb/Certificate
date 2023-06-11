using System;
using Esorb.Certificate.App.Model.Enumerables;

namespace Esorb.Certificate.App.Model;

public class Teacher : PersistentObject
{
    public Teacher()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Gender = GenderValues.weiblich;
        IsAdmin = false;
        IsHeadmaster = false;
        Password = string.Empty;
    }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public GenderValues Gender { get; set; }
    public Boolean IsHeadmaster { get; set; }
    public Boolean IsAdmin { get; set; }
    public string Password { get; set; } = String.Empty;
    public string FullName
    {
        get
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }
    }
}
