using Esorb.Certificate.App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esorb.Certificate.App.Model.Enumerables;

namespace Esorb.Certificate.App.Model;

public class Subject : PersistentObject
{
    private string subjectName;
    private SubjectHierarchy hierarchy;
    private bool calculateGrade;


    private IList<PartialSubject> partialSubjects;
    private IList<Rating> ratings;

    public Subject()
    {
        subjectName = "";
        partialSubjects = new List<PartialSubject>();
        ratings = new List<Rating>();
    }

    public string SubjectName { get; set; } = string.Empty;
    public SubjectHierarchy Hierarchy { get; set; }
    public bool CalculateGrade { get; set; }
    public IList<PartialSubject> PartialSubjects
    {
        get
        {
            return partialSubjects;
        }
        set
        {
            partialSubjects = value;
        }
    }
    public IList<Rating> Ratings
    {
        get
        {
            return ratings;
        }
        set
        {
            ratings = value;
        }
    }
}
