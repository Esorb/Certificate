using CommunityToolkit.Mvvm.ComponentModel;
using Esorb.Certificate.App.Database;
using Esorb.Certificate.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.ViewModel
{
    public partial class GradeLimitViewModel : ObservableObject
    {
        public GradeLimitViewModel(GradeLimit gradeLimit, DbHelper dbHelper)
        {
            this.gradeLimit = gradeLimit;
            dbHelper = dbHelper;
        }

        private GradeLimit gradeLimit { get; }
        private DbHelper dbHelper { get; }


        public double PercentageLimit
        {
            get => gradeLimit.PercentageLimit;
            set
            {
                if (gradeLimit.PercentageLimit != value)
                {
                    gradeLimit.PercentageLimit = value;
                    OnPropertyChanged();
                    dbHelper.Save(gradeLimit);
                }

            }
        }
        public string Grade
        {
            get => gradeLimit.Grade;
            set
            {
                if (gradeLimit.Grade != value)
                {
                    gradeLimit.Grade = value;
                    OnPropertyChanged();
                    dbHelper.Save(gradeLimit);
                }

            }
        }
        public int GradeNumeric
        {
            get => gradeLimit.GradeNumeric;
            set
            {
                if (gradeLimit.GradeNumeric != value)
                {
                    gradeLimit.GradeNumeric = value;
                    OnPropertyChanged();
                    dbHelper.Save(gradeLimit);
                }
            }
        }
    }
}
