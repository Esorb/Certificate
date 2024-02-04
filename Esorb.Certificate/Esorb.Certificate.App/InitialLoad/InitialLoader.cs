using Esorb.Certificate.App.Database;
using Esorb.Certificate.App.Model.Enumerables;
using Esorb.Certificate.App.Model;
using Esorb.Certificate.App.PupilCsvFileService;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esorb.Certificate.App.ViewModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Diagnostics.Eventing.Reader;

namespace Esorb.Certificate.App.InitialLoad;

public class InitialLoader
{
    private string filePath = @"C:\Users\frank\Dropbox\Astrid\MeineZeugnisse\Zeugnis-Master.xlsx";
    public void Load()
    {
        CreateEmptyCertificateDatabase();
        LoadPupilsAndSchoolClassesIntoDatabase();
        LoadExcelFileIntoDatabase();
        CreateTeachers();
        //CreateCertificateTemplates();
        //CreateCertificateTemplatePages();
        //CreateSubjects();
        CreateCertificateData();

    }

    private void CreateEmptyCertificateDatabase()
    {
        var dbh = new DbHelper();
        dbh.DropCertificateTables();
        dbh.ShrinkDatabaseFile();
        dbh.CreateCertificateTables();
    }

    private void LoadExcelFileIntoDatabase()
    {
        using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            IWorkbook workbook = new XSSFWorkbook(stream);

            for (int i = 0; i < workbook.NumberOfSheets; i++)
            {
                ISheet sheet = workbook.GetSheetAt(i);

                if (sheet.SheetName == "Zensuren")
                {
                    Grades2Database(sheet);
                }

                if (sheet.SheetName.StartsWith("Jahrgang"))
                {
                    Templates2Database(sheet);
                }

            }
        }
    }

    private void Grades2Database(ISheet sheet)
    {
        for (int j = 1; j <= sheet.LastRowNum; j++)
        {
            IRow row = sheet.GetRow(j);
            GradeLimit gl = new();
            for (int k = 0; k < row.LastCellNum; k++)
            {
                ICell cell = row.GetCell(k);
                if (k == 0)
                {
                    gl.PercentageLimit = cell.NumericCellValue;
                }
                if (k == 1)
                {
                    gl.Grade = cell.StringCellValue;
                }
                if (k == 2)
                {
                    gl.GradeNumeric = (int)cell.NumericCellValue;
                }
            }
            gl.Save();
        }

    }

    private void Templates2Database(ISheet sheet)
    {
        CertificateTemplate ct = new();

        IRow row = sheet.GetRow(1);
        ICell cell = row.GetCell(1);
        ct.Yearlevel = (int)cell.NumericCellValue;

        row = sheet.GetRow(0);
        cell = row.GetCell(1);
        ct.AbbForFileName = cell.StringCellValue;

        row = sheet.GetRow(2);
        cell = row.GetCell(1);
        string Abb = cell.StringCellValue;

        if (Abb.Equals("Ja"))
        {
            ct.PupilTransferDecision = true;
        }
        else
        {
            ct.PupilTransferDecision = false;
        }

        if (sheet.SheetName.Contains("HJ 1"))
        {
            ct.HalfYear = 1;
            ct.IsFullYearReport = false;
        }

        else if (sheet.SheetName.Contains("HJ 2"))
        {
            ct.HalfYear = 2;
            ct.IsFullYearReport = false;
        }

        else
        {
            ct.HalfYear = 2;
            ct.IsFullYearReport = true;
        }

        ct.Save();
        Content2Database(sheet, ct);
    }

    private void Content2Database(ISheet sheet, CertificateTemplate ct)
    {
        ICell cell;

        for (int j = 6; j <= sheet.LastRowNum; j++)
        {
            IRow row = sheet.GetRow(j);
            cell = row.GetCell(0);
            if (cell.CellType != CellType.Blank)
            {
                Content con = new()
                {
                    Position = j,
                    CertificateTemplateID = ct.ID!
                };
                for (int k = 0; k < row.LastCellNum; k++)
                {
                    cell = row.GetCell(k);
                    if (cell != null)
                    {
                        if (k == 0)
                        {
                            con.Format = cell.StringCellValue;
                        }
                        if (k == 1)
                        {
                            con.Field = cell.StringCellValue;
                        }
                        if (k == 2)
                        {
                            con.Text = cell.StringCellValue;
                        }
                        if (k == 3 && cell.CellType != CellType.Blank)
                        {
                            con.Length = (int)cell.NumericCellValue;
                        }
                        if (k == 4 && cell.CellType != CellType.Blank)
                        {
                            con.WeightLevel1 = (int)cell.NumericCellValue;
                        }
                        if (k == 5 && cell.CellType != CellType.Blank)
                        {
                            con.WeightLevel2 = (int)cell.NumericCellValue;
                        }
                        if (k == 6 && cell.CellType != CellType.Blank)
                        {
                            con.RatingCalculation = cell.StringCellValue;
                        }
                        if (k == 7 && cell.CellType != CellType.Blank)
                        {
                            con.ElectiveSubjectGroup = (int)cell.NumericCellValue;
                        }
                        if (k == 8 && cell.CellType != CellType.Blank)
                        {
                            con.ElectiveSubject = cell.StringCellValue;
                        }
                    }
                }
                con.Save();
            }
        }
    }
    private static void CreateCertificateData()
    {
        var cd = new CertificateData
        {
            SchoolYear = "2024 / 2025",
            HalfYear = 1,
            DateOfRestartLessons = DateTime.Now.AddDays(100),
            DateOfSchoolConference = DateTime.Now.AddDays(1),
            DateOfCertificateDistribution = DateTime.Now.AddDays(7),
            TimeOfRestartLessons = DateTime.Now
        };
        cd.Save();
    }

    private void LoadPupilsAndSchoolClassesIntoDatabase()
    {
        var psci = new PupilSchoolClassImporter();
        psci.ImportPupilsAndSchoolClasses("C:/Users/frank/source/repos/Esorb/Certificate/Esorb.Certificate/Esorb.Certificate.UnitTests/TestData/PupilsClassesTest.csv");
    }

    public void CreateTeachers()
    {
        var dbh = new DbHelper();
        var t1 = new Teacher
        {
            FirstName = "Astrid",
            LastName = "Gerbracht",
            Gender = GenderValues.weiblich,
            IsHeadmaster = false,
            IsAdmin = true,
            Password = "Pappnase"
        };
        var t2 = new Teacher
        {
            FirstName = "Bettina",
            LastName = "Nebel",
            Gender = GenderValues.weiblich,
            IsHeadmaster = true,
            IsAdmin = false
        };
        var t3 = new Teacher
        {
            FirstName = "Caroline",
            LastName = "Schäfer",
            Gender = GenderValues.weiblich,
            IsHeadmaster = false,
            IsAdmin = false
        };
        var t4 = new Teacher
        {
            FirstName = "Herbert",
            LastName = "Böttcher",
            Gender = GenderValues.männlich,
            IsHeadmaster = false,
            IsAdmin = false
        };
        dbh.Save(t1);
        dbh.Save(t2);
        dbh.Save(t3);
        dbh.Save(t4);
    }

    //    private static void CreateCertificateTemplates()
    //    {
    //        var dbh = new DbHelper();

    //        CertificateTemplate ct1 = new();
    //        CertificateTemplate ct2 = new();
    //        CertificateTemplate ct3 = new();
    //        CertificateTemplate ct4 = new();
    //        CertificateTemplate ct5 = new();
    //        CertificateTemplate ct6 = new();
    //        CertificateTemplateViewModel ct1VM = new(ct1, dbh);
    //        CertificateTemplateViewModel ct2VM = new(ct2, dbh);
    //        CertificateTemplateViewModel ct3VM = new(ct3, dbh);
    //        CertificateTemplateViewModel ct4VM = new(ct4, dbh);
    //        CertificateTemplateViewModel ct5VM = new(ct5, dbh);
    //        CertificateTemplateViewModel ct6VM = new(ct6, dbh);

    //        ct1VM.Yearlevel = 1;
    //        ct1VM.IsFullYearReport = true;
    //        ct2VM.Yearlevel = 2;
    //        ct2VM.IsFullYearReport = true;
    //        ct3VM.Yearlevel = 3;
    //        ct3VM.HalfYear = 1;
    //        ct3VM.IsFullYearReport = false;
    //        ct4VM.Yearlevel = 3;
    //        ct4VM.HalfYear = 2;
    //        ct4VM.IsFullYearReport = false;
    //        ct5VM.Yearlevel = 4;
    //        ct5VM.HalfYear = 1;
    //        ct5VM.IsFullYearReport = false;
    //        ct6VM.Yearlevel = 4;
    //        ct6VM.HalfYear = 2;
    //        ct6VM.IsFullYearReport = false;
    //    }

    //    public static void CreateCertificateTemplatePages()
    //    {
    //        var dbh = new DbHelper();
    //        int max;

    //        List<CertificateTemplate> cts = new List<CertificateTemplate>();
    //        cts = dbh.LoadAll<CertificateTemplate>().OrderBy(ct => ct.Yearlevel).ThenBy(ct => ct.HalfYear).ToList();
    //        CertificateTemplatePage ctp;

    //        foreach (CertificateTemplate ct in cts)
    //        {
    //            if (ct.Yearlevel <= 3)
    //            {
    //                max = 4;
    //            }
    //            else
    //            {
    //                if (ct.HalfYear == 1)
    //                {
    //                    max = 3;
    //                }
    //                else
    //                {
    //                    max = 1;
    //                }
    //            }
    //            for (int i = 1; i <= max; i++)
    //            {
    //                ctp = new CertificateTemplatePage();
    //                ctp.CertificateTemplateId = ct.ID!;
    //                ctp.PageNumber = i;
    //                ct.CertificateTemplatePages.Add(ctp);
    //                dbh.Save(ctp);
    //            }
    //        }

    //    }

    //    private void CreateSubjects()
    //    {
    //        var dbh = new DbHelper();

    //        CertificateModel CM = new CertificateModel();
    //        Subject s;

    //        foreach (CertificateTemplate ct in CM.CertificateTemplates)
    //        {
    //            foreach (CertificateTemplatePage ctp in CM.CertificateTemplatePages)
    //            {
    //                if (ctp.CertificateTemplateId == ct.ID)
    //                {
    //                    if (ct.Yearlevel == 1 && ct.HalfYear == 2)
    //                    {
    //                        if (ctp.PageNumber == 1)
    //                        {
    //                            s = new Subject();
    //                            s.SubjectName = "Arbeitsverhalten";
    //                            s.Evaluation = Evaluation.Bewertung;
    //                            s.HasPartialSubjects = false;
    //                            s.CalculateGrade = false;
    //                            s.PositionOnPage = 1;
    //                            s.CertificateTemplateId = ct.ID!;
    //                            s.CertificateTemplatePageId = ctp.ID!;
    //                            dbh.Save(s);

    //                            s = new Subject();
    //                            s.SubjectName = "Sozialverhalten";
    //                            s.Evaluation = Evaluation.Bewertung;
    //                            s.HasPartialSubjects = false;
    //                            s.CalculateGrade = false;
    //                            s.PositionOnPage = 2;
    //                            s.CertificateTemplateId = ct.ID!;
    //                            s.CertificateTemplatePageId = ctp.ID!;
    //                            dbh.Save(s);
    //                        }
    //                        if (ctp.PageNumber == 2)
    //                        {
    //                            s = new Subject();
    //                            s.SubjectName = "Deutsch";
    //                            s.Evaluation = Evaluation.Bewertung;
    //                            s.HasPartialSubjects = true;
    //                            s.CalculateGrade = false;
    //                            s.PositionOnPage = 1;
    //                            s.HasComment = true;
    //                            s.MaxNumberOfCommentLines = 6;
    //                            s.CertificateTemplateId = ct.ID!;
    //                            s.CertificateTemplatePageId = ctp.ID!;
    //                            dbh.Save(s);

    //                            s = new Subject();
    //                            s.SubjectName = "Mathematik";
    //                            s.Evaluation = Evaluation.Bewertung;
    //                            s.HasPartialSubjects = true;
    //                            s.CalculateGrade = false;
    //                            s.PositionOnPage = 2;
    //                            s.HasComment = true;
    //                            s.MaxNumberOfCommentLines = 6;
    //                            s.CertificateTemplateId = ct.ID!;
    //                            s.CertificateTemplatePageId = ctp.ID!;
    //                            dbh.Save(s);
    //                        }
    //                        if (ctp.PageNumber == 3)
    //                        {
    //                            s = new Subject();
    //                            s.SubjectName = "Sachunterricht";
    //                            s.Evaluation = Evaluation.Bewertung;
    //                            s.HasPartialSubjects = false;
    //                            s.CalculateGrade = false;
    //                            s.PositionOnPage = 1;
    //                            s.HasComment = true;
    //                            s.MaxNumberOfCommentLines = 6;
    //                            s.CertificateTemplateId = ct.ID!;
    //                            s.CertificateTemplatePageId = ctp.ID!;
    //                            dbh.Save(s);

    //                            s = new Subject();
    //                            s.SubjectName = "Sport";
    //                            s.Evaluation = Evaluation.Bewertung;
    //                            s.HasPartialSubjects = false;
    //                            s.CalculateGrade = false;
    //                            s.PositionOnPage = 2;
    //                            s.HasComment = true;
    //                            s.MaxNumberOfCommentLines = 6;
    //                            s.CertificateTemplateId = ct.ID!;
    //                            s.CertificateTemplatePageId = ctp.ID!;
    //                            dbh.Save(s);

    //                            s = new Subject();
    //                            s.SubjectName = "Musik";
    //                            s.Evaluation = Evaluation.Bewertung;
    //                            s.HasPartialSubjects = false;
    //                            s.CalculateGrade = false;
    //                            s.PositionOnPage = 3;
    //                            s.HasComment = true;
    //                            s.MaxNumberOfCommentLines = 6;
    //                            s.CertificateTemplateId = ct.ID!;
    //                            s.CertificateTemplatePageId = ctp.ID!;
    //                            dbh.Save(s);

    //                            s = new Subject();
    //                            s.SubjectName = "Kunst";
    //                            s.Evaluation = Evaluation.Bewertung;
    //                            s.HasPartialSubjects = false;
    //                            s.CalculateGrade = false;
    //                            s.PositionOnPage = 4;
    //                            s.HasComment = true;
    //                            s.MaxNumberOfCommentLines = 6;
    //                            s.CertificateTemplateId = ct.ID!;
    //                            s.CertificateTemplatePageId = ctp.ID!;
    //                            dbh.Save(s);
    //                        }
    //                        if (ctp.PageNumber == 4)
    //                        {
    //                            s = new Subject();
    //                            s.SubjectName = "Religion";
    //                            s.Evaluation = Evaluation.Bewertung;
    //                            s.HasPartialSubjects = false;
    //                            s.CalculateGrade = false;
    //                            s.PositionOnPage = 1;
    //                            s.HasComment = true;
    //                            s.MaxNumberOfCommentLines = 6;
    //                            s.CertificateTemplateId = ct.ID!;
    //                            s.CertificateTemplatePageId = ctp.ID!;
    //                            dbh.Save(s);
    //                        }

    //                    }
    //                }
    //            }
    //        }
    //    }
}
