using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.PupilCsvFileService
{
    public class PupilSchoolClassImporter
    {
        private readonly string fileName;
        public IList<PupilRawData> RawDatas { get; set; } = new List<PupilRawData>();
        public PupilSchoolClassImporter(string fileName)
        {
            this.fileName = fileName;
        }

        public void ReadRawData()
        {
            CsvConfiguration configuration = new(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                Encoding = Encoding.UTF8
            };

            using StreamReader reader = new(fileName);
            using var csv = new CsvReader(reader, configuration);
            csv.Context.RegisterClassMap<PupilRawDataMap>();
            RawDatas = csv.GetRecords<PupilRawData>().ToList();
        }
    }
}
