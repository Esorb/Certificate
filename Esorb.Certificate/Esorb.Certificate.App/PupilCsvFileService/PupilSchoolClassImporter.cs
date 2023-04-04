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
    private IList<Pupil> pupils = new List<Pupil>();
    private IList<SchoolClass> schoolClasses = new List<SchoolClass>();
    private DbHelper dbHelper = new();
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

    public void ImportPupilsAndSchoolClasses(string? filePath)
    {
        if (!IsPupilSchoolClassFile(filePath)) return;

        ReadRawData(filePath!);

        if (RawDatas.Count == 0) return;

        DeleteOldPupilAndSchoolClasses();
        TransferRawDatas();
    }

    private void TransferRawDatas()
    {
        // Do not change the order, SchoolClasses have to be transfered first
        TransferRawDatasToSchoolClass();
        TransferRawDatasToPupil();
    }

    private void DeleteOldPupilAndSchoolClasses()
    {
        dbHelper.DropTable(typeof(Pupil).ToString());
        dbHelper.DropTable(typeof(SchoolClass).ToString());
        dbHelper.CreateCertificateTables();
    }

    private void TransferRawDatasToSchoolClass()
    {
        foreach (var rawData in RawDatas)
        {
            if (rawData != null && !string.IsNullOrEmpty(rawData.ClassName))
            {
                if (!schoolClasses.Any(sc => sc.ClassName == rawData.ClassName))
                {
                    var sc = new SchoolClass
                    {
                        ClassName = rawData.ClassName ?? "",
                        Yearlevel = GetIntFromString(rawData.YearLevel ?? ""),
                        HalfYear = GetIntFromString(rawData.HalfYear ?? "")
                    };

                    dbHelper.Save(sc);
                    schoolClasses.Add(sc);
                }
            }
        }
    }

    private void TransferRawDatasToPupil()
    {
        foreach (var rawData in RawDatas)
        {
            if (rawData != null && !string.IsNullOrEmpty(rawData.Firstname))
            {
                var p = new Pupil
                {
                    FirstName = rawData.Firstname ?? "",
                    LastName = rawData.Lastname ?? "",
                    YearsAtSchool = GetIntFromString(rawData.YearsAtSchool ?? "")
                };
                if (!string.IsNullOrEmpty(rawData.DateOfBirth))
                {
                    DateTime date;
                    if (DateTime.TryParseExact(rawData.DateOfBirth, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    {
                        p.DateOfBirth = date;
                    }
                }

                var schoolClass = schoolClasses.FirstOrDefault(sc => sc.ClassName == rawData.ClassName);
                p.SchoolClassId = schoolClass.ID ?? "";

                dbHelper.Save(p);
                pupils.Add(p);
            }
        }
    }

    public bool IsPupilSchoolClassFile(string? filePath)
    {
        if (string.IsNullOrEmpty(filePath)) return false;
        if (!File.Exists(filePath)) return false;
        if (new FileInfo(filePath).Length < 84) return false;
        if (!filePath[^4..].Equals(".csv")) return false;

        using StreamReader reader = new(filePath, Encoding.UTF8);
        string? firstLine = reader.ReadLine();
        if (string.IsNullOrEmpty(firstLine)) return false;
        return firstLine.Equals("Vorname;Nachname;Geburtsdatum;Schulbesuchsjahre;Klasse;Aktuelles Halbjahr;Jahrgang");
    }

    public int GetIntFromString(string str)
    {
        int result = 0;
        if (!string.IsNullOrEmpty(str))
        {
            int num;
            if (int.TryParse(str, out num))
            {
                result = num;
            }
        }
        return result;
    }

}
