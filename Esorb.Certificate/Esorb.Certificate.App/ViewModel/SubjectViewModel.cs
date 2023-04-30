using CommunityToolkit.Mvvm.ComponentModel;
using Esorb.Certificate.App.Database;
using Esorb.Certificate.App.Model;
using Esorb.Certificate.App.Model.Enumerables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.ViewModel;

public partial class SubjectViewModel : ObservableObject
{
    private readonly Subject subject;
    private readonly DbHelper dbHelper;

    public SubjectViewModel(Subject subject, DbHelper dbHelper)
    {
        this.subject = subject;
        this.dbHelper = dbHelper;
    }

    public string SubjectName
    {
        get => subject.SubjectName;
        set
        {
            if (value != subject.SubjectName)
            {
                subject.SubjectName = value;
                OnPropertyChanged(nameof(SubjectName));
                dbHelper.Save(subject);
            }
        }
    }
    public Evaluation Evaluation
    {
        get => subject.Evaluation;
        set
        {
            if (value != subject.Evaluation)
            {
                subject.Evaluation = value;
                OnPropertyChanged(nameof(Evaluation));
                dbHelper.Save(subject);
            }
        }
    }
    public bool HasPartialSubjects
    {
        get => subject.HasPartialSubjects;
        set
        {
            if (value != subject.HasPartialSubjects)
            {
                subject.HasPartialSubjects = value;
                OnPropertyChanged(nameof(HasPartialSubjects));
                dbHelper.Save(subject);
            }
        }
    }
    public bool CalculateGrade
    {
        get => subject.CalculateGrade;
        set
        {
            if (value != subject.CalculateGrade)
            {
                subject.CalculateGrade = value;
                OnPropertyChanged(nameof(CalculateGrade));
                dbHelper.Save(subject);
            }
        }
    }
    public int PositionOnPage
    {
        get => subject.PositionOnPage;
        set
        {
            if (subject.PositionOnPage != value)
            {
                subject.PositionOnPage = value;
                OnPropertyChanged(nameof(PositionOnPage));
                dbHelper.Save(subject);
            }
        }
    }
    public bool HasComment
    {
        get => subject.HasComment;
        set
        {
            if (value != subject.HasComment)
            {
                subject.HasComment = value;
                OnPropertyChanged(nameof(HasComment));
                dbHelper.Save(subject);
            }
        }
    }
    public int MaxNumberOfCommentLines
    {
        get => subject.MaxNumberOfCommentLines;
        set
        {
            if (value != subject.MaxNumberOfCommentLines)
            {
                subject.MaxNumberOfCommentLines = value;
                OnPropertyChanged(nameof(MaxNumberOfCommentLines));
                dbHelper.Save(subject);
            }
        }
    }
    public CertificateTemplateViewModel? CertificateTemplateViewModel { get; set; }
    public CertificateTemplatePageViewModel? CertificateTemplatePageViewModel { get; set; }
    //public IList<PartialSubject> PartialSubjects { get; private set; } = new List<PartialSubject>();
    //public IList<Rating> Ratings { get; private set; } = new List<Rating>();
    public IList<SubjectViewModel> ContainingSubjectViewModels { get; set; } = new List<SubjectViewModel>();

}
