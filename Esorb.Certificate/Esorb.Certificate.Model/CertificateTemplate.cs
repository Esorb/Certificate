using Esorb.Certificate.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.Model
{
    public class CertificateTemplate : ViewModelBase
    {
        private long certificateTemplateID;
        private short yearlevel;
        private short halfYear;

        public long CertificateTemplateID
        {
            get
            {
                return certificateTemplateID;
            }
            set
            {
                certificateTemplateID = value;
                OnPropertyChanged(nameof(certificateTemplateID));
            }
        }

        public short Yearlevel
        {
            get
            {
                return yearlevel;
            }
            set
            {
                yearlevel = value;
                OnPropertyChanged(nameof(Yearlevel));
            }
        }

        public short HalfYear
        {
            get
            {
                return halfYear;
            }
            set
            {
                halfYear = value;
                OnPropertyChanged(nameof(HalfYear));
            }
        }

    }
}
