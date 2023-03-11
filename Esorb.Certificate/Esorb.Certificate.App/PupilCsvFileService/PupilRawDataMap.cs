using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.PupilCsvFileService;

internal class PupilRawDataMap : ClassMap<PupilRawData>
{
    public PupilRawDataMap()
    {
        Map(p => p.Firstname).Index(0);
        Map(p => p.Lastname).Index(1);
        Map(p => p.DateOfBirth).Index(2);
        Map(p => p.YearsAtSchool).Index(3);
        Map(p => p.ClassName).Index(4);
        Map(p => p.HalfYear).Index(5);
        Map(p => p.YearLevel).Index(6);
    }
}
