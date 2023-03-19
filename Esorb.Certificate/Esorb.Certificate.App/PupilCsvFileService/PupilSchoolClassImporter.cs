using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Esorb.Certificate.App.Database;
using Esorb.Certificate.App.Model;
using System.Security.Cryptography.X509Certificates;
using System;

namespace Esorb.Certificate.App.PupilCsvFileService;

public class PupilSchoolClassImporter
{
    private CertificateModel _certificateModel { get; set; }
    public IList<PupilRawData> RawDatas { get; set; } = new List<PupilRawData>();

    public void ReadRawData(string fileName)
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

    public void ImportPupilsAndSchoolClasses(string? filePath, CertificateModel certificateModel)
    {
        if (!IsPupilSchoolClassFile(filePath)) return;

        ReadRawData(filePath!);

        if (RawDatas.Count == 0) return;

        _certificateModel = certificateModel;

        DeleteOldPupilAndSchoolClasses();



    }

    public void DeleteOldPupilAndSchoolClasses()
    {
        _certificateModel.Pupils.Clear();
        _certificateModel.DbHelper.DropTable("Pupil");
        _certificateModel.SchoolClasses.Clear();
        _certificateModel.DbHelper.DropTable("SchoolClass");
        _certificateModel.DbHelper.CreateCertificateTables();
    }

    public void TransferRawDatasToPupil()
    {
        foreach (var rawData in RawDatas)
        {
            var p = new Pupil();
            p.FirstName = rawData.Firstname ?? "";
            p.LastName = rawData.Lastname ?? "";
            if (!string.IsNullOrEmpty(rawData.YearsAtSchool))
            {
                int num;
                if (int.TryParse(rawData.YearsAtSchool, out num))
                {
                    p.YearsAtSchool = num;
                }
            }
            //if (!string.IsNullOrEmpty(rawData.DateOfBirth))
            //{
            //    DateTime date;
            //    if (DateTime.TryParse(rawData.DateOfBirth, "dd.MM.yyyy", null, out date))
            //    {
            //        p.DateOfBirth = date;
            //    }
            //}
        }
    }


    public bool IsPupilSchoolClassFile(string? filePath)
    {
        if (string.IsNullOrEmpty(filePath)) return false;
        if (!File.Exists(filePath)) return false;
        if (new FileInfo(filePath).Length < 84) return false;
        if (!filePath.Substring(filePath.Length - 4).Equals(".csv")) return false;

        using (StreamReader reader = new(filePath, Encoding.UTF8))
        {
            string? firstLine = reader.ReadLine();
            if (string.IsNullOrEmpty(firstLine)) return false;
            return firstLine.Equals("Vorname;Nachname;Geburtsdatum;Schulbesuchsjahre;Klasse;Aktuelles Halbjahr;Jahrgang");
        }
    }
}
