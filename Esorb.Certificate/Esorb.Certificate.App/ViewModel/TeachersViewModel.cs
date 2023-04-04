using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Esorb.Certificate.App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.ViewModel;

public class TeachersViewModel : ObservableObject
{
    public TeachersViewModel(CertificateModel certificateModel)
    {
        this.certificateModel = certificateModel;
        BuildTeacherViewModel();
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

    private CertificateModel certificateModel;
    private ObservableCollection<TeacherViewModel> teachers;
    private void BuildTeacherViewModel()
    {
        teachers = new ObservableCollection<TeacherViewModel>();

        foreach (var t in certificateModel.Teachers)
        {
            teachers.Add(new TeacherViewModel(t, certificateModel.DbHelper));
        }

        //teachersViewModel = new ObservableCollection<TeacherViewModel>(teachersViewModel.OrderBy(tvm => tvm.FullName).ToList());
    }
    private void ExecuteAddTeacher()
    {

    }

    private bool CanExecuteAddTeacher()
    {
        return false;
    }
    private void ExecuteRemoveTeacher()
    {

    }

    private bool CanExecuteRemoveTeacher()
    {
        return false;
    }

}
