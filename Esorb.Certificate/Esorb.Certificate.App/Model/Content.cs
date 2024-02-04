using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xceed.Words.NET;

namespace Esorb.Certificate.App.Model
{
    public class Content : PersistentObject
    {
        public long Position { get; set; } = 0;
        public string Format { get; set; } = string.Empty;
        public string Field { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public long Length { get; set; } = 0;
        public long WeightLevel1 { get; set; } = 0;
        public long WeightLevel2 { get; set; } = 0;
        public string RatingCalculation { get; set; } = string.Empty;

        public Boolean RatingCalculationLevel1
        {
            get { return RatingCalculation.Contains('1'); }
        }
        public Boolean RatingCalculationLevel2
        {
            get { return RatingCalculation.Contains('2'); }
        }
        public long ElectiveSubjectGroup { get; set; } = 0;
        public string ElectiveSubject { get; set; } = string.Empty;
        public string CertificateTemplateID { get; set; } = string.Empty;
    }
}
