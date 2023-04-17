using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Esorb.Certificate.App.Model;
using System.Collections.ObjectModel;

namespace Esorb.Certificate.App.ViewModel
{
    public partial class SubjectsViewModel : ObservableObject
    {
        private readonly CertificateModel certificateModel;

        public SubjectsViewModel(CertificateModel certificateModel)
        {
            this.certificateModel = certificateModel;
        }

        public ObservableCollection<SubjectViewModel> SubjectViewModels { get; private set; }
    }
}
