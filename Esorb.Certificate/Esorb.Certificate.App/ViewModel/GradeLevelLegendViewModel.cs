using CommunityToolkit.Mvvm.ComponentModel;
using Esorb.Certificate.App.Database;
using Esorb.Certificate.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.ViewModel;

public class GradeLevelLegendViewModel : ObservableObject
{
    public GradeLevelLegendViewModel(GradeLimit gradeLimit, DbHelper dbHelper)
    {
        this.gradeLimit = gradeLimit;
        this.dbHelper = dbHelper;
    }

    private GradeLimit gradeLimit;
    private DbHelper dbHelper;

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

    public string Explanation
    {
        get => gradeLimit.Explanation;
        set
        {
            if (gradeLimit.Explanation != value)
            {
                gradeLimit.Explanation = value;
                OnPropertyChanged();
                dbHelper.Save(gradeLimit);
            }
        }
    }

}
