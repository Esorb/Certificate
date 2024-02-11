using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Esorb.Certificate.App.Database;
using Esorb.Certificate.App.Model;

namespace Esorb.Certificate.App.ViewModel
{
    public partial class ContentViewModel : ObservableObject
    {
        private readonly Content content;
        private readonly DbHelper dbHelper;

        public ContentViewModel(Content content)
        {
            this.content = content;
        }
        public long Position { get => content.Position; }
        public string Format { get => content.Format; }
        public string Field { get => content.Field; }
        public string Text { get => content.Text; }
        public long Length { get => content.Length; }
        public long WeightLevel1 { get => content.WeightLevel1; }
        public long WeightLevel2 { get => content.WeightLevel2; }
        public string RatingCalculation { get => content.RatingCalculation; }

        public Boolean RatingCalculationLevel1 { get => content.RatingCalculationLevel1; }
        public Boolean RatingCalculationLevel2 { get => content.RatingCalculationLevel2; }
        public long ElectiveSubjectGroup { get => content.ElectiveSubjectGroup; }
        public string ElectiveSubject { get => content.ElectiveSubject; }
        public string CertificateTemplateID { get => content.CertificateTemplateID; }

        public CertificateTemplateViewModel? CertificateTemplateViewModel { get; set; }
    }
}
