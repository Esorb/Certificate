using Esorb.Certificate.App.Basics;
using Esorb.Certificate.App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esorb.Certificate.App.Model.Enumerables;

namespace Esorb.Certificate.App.Model;

public class Subject : ViewModelBase
{
    private long subjectID;
    private string subjectName;
    private SubjectHierarchy hierarchy;
    private bool calculateGrade;


    private ObservableCollection<PartialSubject> partialSubjects;
    private ObservableCollection<Rating> ratings;



    public Subject()
    {
        subjectName = "";
        partialSubjects = new ObservableCollection<PartialSubject>();
        ratings = new ObservableCollection<Rating>();
    }

    public long SubjectID
    {
        get
        {
            return subjectID;
        }
        set
        {
            subjectID = value;
            OnPropertyChanged(nameof(SubjectID));
        }
    }
    public string SubjectName
    {
        get
        {
            return subjectName;
        }
        set
        {
            subjectName = value;
            OnPropertyChanged(nameof(SubjectName));
        }
    }

    public SubjectHierarchy Hierarchy
    {
        get
        {
            return hierarchy;
        }
        set
        {
            hierarchy = value;
            OnPropertyChanged(nameof(Hierarchy));
        }
    }

    public bool CalculateGrade
    {
        get
        {
            return calculateGrade;
        }
        set
        {
            calculateGrade = value;
            OnPropertyChanged(nameof(CalculateGrade));
        }
    }


    public ObservableCollection<PartialSubject> PartialSubjects
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

    public ObservableCollection<Rating> Ratings
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
