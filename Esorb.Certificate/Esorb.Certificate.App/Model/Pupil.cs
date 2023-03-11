using System;

namespace Esorb.Certificate.App.Model;

public class Pupil : PersistentObject
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public short YearsAtSchool { get; set; }
    public string SchoolClassId { get; set; } = string.Empty;

    public string FullName
    {
        get
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }
    }
    public SchoolClass? SchoolClass { get; set; }
}
