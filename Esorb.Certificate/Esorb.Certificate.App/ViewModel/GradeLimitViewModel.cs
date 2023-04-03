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
        private GradeLimit _gradeLimit;
        private DbHelper _dbHelper;
        public GradeLimitViewModel(GradeLimit gradeLimit, DbHelper dbHelper)
        {
            _gradeLimit = gradeLimit;
            _dbHelper = dbHelper;
        }

        public double PercentageLimit
        { 
            get => _gradeLimit.PercentageLimit;
            set 
            {
                if (_gradeLimit.PercentageLimit != value)
                {
                    _gradeLimit.PercentageLimit = value;
                    OnPropertyChanged();
                    _dbHelper.Save(_gradeLimit);
                }

            }
        }
        public string Grade
        {
            get => _gradeLimit.Grade;
            set
            {
                if (_gradeLimit.Grade != value)
                {
                    _gradeLimit.Grade = value;
                    OnPropertyChanged();
                    _dbHelper.Save(_gradeLimit);
                }

            }
        }
        public int GradeNumeric
        {
            get => _gradeLimit.GradeNumeric;
            set
            {
                if (_gradeLimit.GradeNumeric != value)
                {
                    _gradeLimit.GradeNumeric = value;
                    OnPropertyChanged();
                    _dbHelper.Save(_gradeLimit);
                }
            }
        }
    }
}
