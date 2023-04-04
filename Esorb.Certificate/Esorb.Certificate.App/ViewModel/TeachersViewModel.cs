using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Esorb.Certificate.App.Model;

namespace Esorb.Certificate.App.ViewModel;

public class TeachersViewModel : ObservableObject
{
    public TeachersViewModel(CertificateModel certificateModel)
    {
        this.certificateModel = certificateModel;
        BuildTeachersViewModel();
        AddTeacher = new RelayCommand(ExecuteAddTeacher, CanExecuteAddTeacher);
        RemoveTeacher = new RelayCommand(ExecuteRemoveTeacher, CanExecuteRemoveTeacher);
    }
    public ObservableCollection<TeacherViewModel> Teachers
    {
        get => teachers;
        set { teachers = value; }
    }

    public RelayCommand AddTeacher { get; private set; }
    public RelayCommand RemoveTeacher { get; private set; }

    public TeacherViewModel SelectedTeacher
    {
        get { return selectedTeacher; }
        set
        {
            selectedTeacher = value;
            OnPropertyChanged(nameof(SelectedTeacher));
            RemoveTeacher.NotifyCanExecuteChanged();
        }
    }

    private CertificateModel certificateModel;
    private ObservableCollection<TeacherViewModel> teachers;
    private TeacherViewModel selectedTeacher;

    private void BuildTeachersViewModel()
    {
        teachers = new ObservableCollection<TeacherViewModel>();

        foreach (var t in certificateModel.Teachers)
        {
            teachers.Add(new TeacherViewModel(t, certificateModel.DbHelper));
        }
    }

    private void ExecuteAddTeacher()
    {
        Teacher teacher = new();
        TeacherViewModel teacherViewModel = new(teacher, certificateModel.DbHelper);
        Teachers.Add(teacherViewModel);
    }

    private bool CanExecuteAddTeacher()
    {
        return true;
    }
    private void ExecuteRemoveTeacher()
    {
        SelectedTeacher.Delete();
        teachers.Remove(SelectedTeacher);
    }

    private bool CanExecuteRemoveTeacher()
    {
        return SelectedTeacher != null;
    }

}
