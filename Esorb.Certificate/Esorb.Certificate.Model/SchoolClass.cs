using Esorb.Certificate.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.School_Certificate.Model
{
    public class SchoolClass : ViewModelBase
    {
        private long schoolClassId;
        private string className;
        private short yearlevel;
        private short halfYear;

        public SchoolClass()
        {
            className = string.Empty;
        }

        public long SchoolClassId
        {
            get
            {
                return schoolClassId;
            }
            set
            {
                schoolClassId = value;
                OnPropertyChanged(nameof(SchoolClassId));
            }
        }

        public string ClassName
        {
            get
            {
                return className;
            }
            set
            {
                className = value;
                OnPropertyChanged(nameof(ClassName));
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
