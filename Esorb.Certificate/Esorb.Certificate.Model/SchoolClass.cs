using Esorb.Certificate.Basics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.Model
{
    public class SchoolClass : ViewModelBase
    {
        private long schoolClassId;
        private string className;
        private short yearlevel;
        private short halfYear;
        private ObservableCollection<Pupil> pupils;



        public SchoolClass()
        {
            className = string.Empty;
            pupils = new ObservableCollection<Pupil>();
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

        public ObservableCollection<Pupil> Pupils
        {
            get
            {
                return pupils;
            }
            set
            {
                pupils = value;
            }
        }

    }
}
