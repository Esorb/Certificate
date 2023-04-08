using CommunityToolkit.Mvvm.ComponentModel;
using Esorb.Certificate.App.Model;
using System.Collections.ObjectModel;

namespace Esorb.Certificate.App.ViewModel;

public class SchoolClassesViewModel : ObservableObject
{
    public SchoolClassesViewModel(CertificateModel certificateModel)
    {
        this.certificateModel = certificateModel;
        BuildSchoolClassesViewModel();
    }

    public ObservableCollection<SchoolClassViewModel> SchoolClasses { get; set; }

    private CertificateModel certificateModel;

    private void BuildSchoolClassesViewModel()
    {
        SchoolClassViewModel scvm;
        PupilViewModel pvm;

        SchoolClasses = new ObservableCollection<SchoolClassViewModel>();

        foreach (SchoolClass sc in certificateModel.SchoolClasses)
        {
            scvm = new SchoolClassViewModel(sc);
            SchoolClasses.Add(scvm);

            foreach (var p in sc.Pupils)
            {
                pvm = new PupilViewModel(p);
                scvm.Pupils.Add(pvm);
                pvm.SchoolClass = scvm;
            }
        }
    }
}
