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
