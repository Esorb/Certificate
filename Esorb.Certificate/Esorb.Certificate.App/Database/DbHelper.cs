﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Dapper;
using Microsoft.Data.Sqlite;

using Esorb.Certificate.App.Model;

namespace Esorb.Certificate.App.Database;

public class DbHelper
{
    private static DbHelper instance;
    private readonly CertificateSettings settings = new();
    private readonly List<string> Tables = new();

    private DbHelper()
    {
        InitPupil();
        InitSchoolClass();
        InitTeacher();
        InitCertificateData();
        InitCertificateTemplate();
        InitGradeLimit();
        InitCertificateTemplatePage();
        InitSubject();
        InitContent();

    }

    public static DbHelper GetInstance()
    {
        if (instance == null)
        {
            instance = new DbHelper();
        }
        return instance;
    }

    private readonly Dictionary<string, ObjectSQL> StandardSQLStatements = new();

    public void CreateCertificateTables()
    {
        CreateTable(typeof(Pupil).ToString());
        CreateTable(typeof(SchoolClass).ToString());
        CreateTable(typeof(Teacher).ToString());
        CreateTable(typeof(CertificateData).ToString());
        CreateTable(typeof(CertificateTemplate).ToString());
        CreateTable(typeof(GradeLimit).ToString());
        CreateTable(typeof(CertificateTemplatePage).ToString());
        CreateTable(typeof(Subject).ToString());
        CreateTable(typeof(Content).ToString());
    }

    public void DropCertificateTables()
    {
        DropTable(typeof(Pupil).ToString());
        DropTable(typeof(SchoolClass).ToString());
        DropTable(typeof(Teacher).ToString());
        DropTable(typeof(CertificateData).ToString());
        DropTable(typeof(CertificateTemplate).ToString());
        DropTable(typeof(GradeLimit).ToString());
        DropTable(typeof(CertificateTemplatePage).ToString());
        DropTable(typeof(Subject).ToString());
        DropTable(typeof(Content).ToString());
    }

    private static string ConnectionString(string filePath)
    {
        StringBuilder sb = new();

        sb.Append("Data Source = ");
        sb.Append(filePath);
        sb.Append(';');

        return sb.ToString();
    }

    public bool IsCertificateFile(string filePath)
    {
        if (string.IsNullOrEmpty(filePath)) return false;
        if (!File.Exists(filePath)) return false;

        try
        {
            using var connection = new SqliteConnection(ConnectionString(filePath));
            connection.Open();
            string sql = "SELECT name FROM sqlite_master WHERE type='table'";
            List<string> result = connection.Query<string>(sql).AsList();

            foreach (var t in Tables)
            {
                if (!result.Contains(t)) return false;
            }

            return true;
        }
        catch
        {
            return false;
        }
    }

    public void ShrinkDatabaseFile()
    {
        using var connection = new SqliteConnection(ConnectionString(settings.DatabasePath));
        connection.Open();
        using var command = new SqliteCommand("VACUUM", connection);
        command.ExecuteNonQuery();
    }

    public void Save(PersistentObject Object)
    {
        if (!StandardSQLStatements.ContainsKey(Object.GetType().ToString()))
        {
            return;
        }

        if (String.IsNullOrEmpty(Object.ID))
        {
            Object.ID = Guid.NewGuid().ToString();
            CreateDbInstance(Object);
        }
        else
        {
            UpdateDbInstance(Object);
        }
    }

    public void Delete(PersistentObject Object)
    {
        if (!StandardSQLStatements.ContainsKey(Object.GetType().ToString())) { return; }
        if (String.IsNullOrEmpty(Object.ID)) { return; }

        DeleteDbInstance(Object);
    }

    public int Count(string Type)
    {
        if (!StandardSQLStatements.ContainsKey(Type))
        {
            return 0;
        }

        using var connection = new SqliteConnection(ConnectionString(settings.DatabasePath));
        return connection.ExecuteScalar<int>(StandardSQLStatements[Type].Count);
    }

    public T LoadById<T>(string SearchID) where T : class, new()
    {
        T result = new();
        var Type = result.GetType().ToString();
        if (!StandardSQLStatements.ContainsKey(Type)) { return result; }

        using var connection = new SqliteConnection(ConnectionString(settings.DatabasePath));
        var parameter = new { ID = SearchID };
        result = connection.QuerySingle<T>(StandardSQLStatements[Type].SelectById, parameter);
        return result;
    }

    public IList<T> LoadAll<T>() where T : class, new()
    {
        var Type = typeof(T).ToString();

        using var connection = new SqliteConnection(ConnectionString(settings.DatabasePath));
        return connection.Query<T>(StandardSQLStatements[Type].SelectAll).ToList();
    }

    public void CreateTable(string Type)
    {
        if (!StandardSQLStatements.ContainsKey(Type)) { return; }

        using var connection = new SqliteConnection(ConnectionString(settings.DatabasePath));
        connection.ExecuteScalar(StandardSQLStatements[Type].CreateTable);
    }


    public void DropTable(string Type)
    {
        if (!StandardSQLStatements.ContainsKey(Type)) { return; }

        using var connection = new SqliteConnection(ConnectionString(settings.DatabasePath));
        connection.Execute(StandardSQLStatements[Type].DropTable);
    }


    private void CreateDbInstance(PersistentObject Object)
    {
        using var connection = new SqliteConnection(ConnectionString(settings.DatabasePath));
        {
            connection.ExecuteScalar(StandardSQLStatements[Object.GetType().ToString()].Insert, Object);
        };
    }


    private void UpdateDbInstance(PersistentObject Object)
    {
        using var connection = new SqliteConnection(ConnectionString(settings.DatabasePath));
        connection.ExecuteScalar(StandardSQLStatements[Object.GetType().ToString()].Update, Object);
    }


    private void DeleteDbInstance(PersistentObject Object)
    {
        using var connection = new SqliteConnection(ConnectionString(settings.DatabasePath));
        connection.ExecuteScalar(StandardSQLStatements[Object.GetType().ToString()].DeleteById, Object);
    }


    private void InitPupil()
    {

        var Fields = new Dictionary<string, string>
        {
            { "FirstName", "TEXT" },
            { "LastName", "TEXT" },
            { "DateOfBirth", "TEXT" },
            { "YearsAtSchool", "INTEGER" },
            { "SchoolClassId", "TEXT" }
        };
        ObjectSQL SQL = new("Pupil", Fields);
        StandardSQLStatements.Add(typeof(Pupil).ToString(), SQL);
        Tables.Add("Pupil");
    }

    private void InitSchoolClass()
    {
        var Fields = new Dictionary<string, string>
        {
            { "ClassName", "TEXT" },
            { "Yearlevel", "INTEGER" },
            { "HalfYear", "INTEGER" }
        };
        ObjectSQL SQL = new("SchoolClass", Fields);
        StandardSQLStatements.Add(typeof(SchoolClass).ToString(), SQL);
        Tables.Add("SchoolClass");
    }

    private void InitTeacher()
    {
        var Fields = new Dictionary<string, string>
        {
            { "FirstName", "TEXT" },
            { "LastName", "TEXT" },
            { "Gender", "INTEGER" },
            { "IsHeadmaster", "INTEGER" },
            { "IsAdmin", "INTEGER" },
            { "Password", "TEXT" }
        };
        ObjectSQL SQL = new("Teacher", Fields);
        StandardSQLStatements.Add(typeof(Teacher).ToString(), SQL);
        Tables.Add("Teacher");
    }

    private void InitCertificateData()
    {
        var Fields = new Dictionary<string, string>
        {
            { "SchoolYear", "TEXT" },
            { "HalfYear", "INTEGER" },
            { "DateOfSchoolConference", "DATETIME" },
            { "DateOfCertificateDistribution", "DATETIME" },
            { "DateOfRestartLessons", "DATETIME" },
            { "TimeOfRestartLessons", "DATETIME" },
        };
        ObjectSQL SQL = new("CertificateData", Fields);
        StandardSQLStatements.Add(typeof(CertificateData).ToString(), SQL);
        Tables.Add("CertificateData");
    }

    private void InitCertificateTemplate()
    {
        var Fields = new Dictionary<string, string>
        {
            { "Yearlevel", "INTEGER" },
            { "HalfYear", "INTEGER" },
            { "IsFullYearReport", "BOOLEAN" },
            { "PupilTransferDecision", "BOOLEAN" },
            { "AbbForFileName", "TEXT" },
        };
        ObjectSQL SQL = new("CertificateTemplate", Fields);
        StandardSQLStatements.Add(typeof(CertificateTemplate).ToString(), SQL);
        Tables.Add("CertificateTemplate");
    }

    private void InitGradeLimit()
    {
        var Fields = new Dictionary<string, string>
        {
            { "PercentageLimit", "REAL" },
            { "Grade", "TEXT" },
            { "GradeNumeric", "INTEGER" },
            { "Explanation", "TEXT" },
        };
        ObjectSQL SQL = new("GradeLimit", Fields);
        StandardSQLStatements.Add(typeof(GradeLimit).ToString(), SQL);
        Tables.Add("GradeLimit");
    }

    private void InitCertificateTemplatePage()
    {
        var Fields = new Dictionary<string, string>
        {
            { "PageNumber", "INTEGER" },
            { "CertificateTemplateId", "TEXT" },
        };

        ObjectSQL SQL = new("CertificateTemplatePage", Fields);
        StandardSQLStatements.Add(typeof(CertificateTemplatePage).ToString(), SQL);
        Tables.Add("CertificateTemplatePage");
    }
    private void InitSubject()
    {
        var Fields = new Dictionary<string, string>
        {
            { "SubjectName", "TEXT" },
            { "Evaluation", "INTEGER" },
            { "HasPartialSubjects", "BOOLEAN" },
            { "CalculateGrade", "BOOLEAN" },
            { "HasComment", "BOOLEAN" },
            { "MaxNumberOfCommentLines", "INTEGER" },
            { "PositionOnPage", "INTEGER" },
            { "CertificateTemplateId", "TEXT" },
            { "CertificateTemplatePageId", "TEXT" },
        };

        ObjectSQL SQL = new("Subject", Fields);
        StandardSQLStatements.Add(typeof(Subject).ToString(), SQL);
        Tables.Add("Subject");
    }

    private void InitContent()
    {
        var Fields = new Dictionary<string, string>
        {
            { "Position", "INTEGER" },
            { "Format", "TEXT"},
            { "Field", "TEXT" },
            { "Text", "TEXT" },
            { "Length", "INTEGER" },
            { "WeightLevel1", "INTEGER" },
            { "WeightLevel2", "INTEGER" },
            { "RatingCalculation", "TEXT" },
            { "ElectiveSubjectGroup", "INTEGER" },
            { "ElectiveSubject", "TEXT" },
            { "CertificateTemplateID", "TEXT" },
        };

        ObjectSQL SQL = new("Content", Fields);
        StandardSQLStatements.Add(typeof(Content).ToString(), SQL);
        Tables.Add("Content");

    }
    public void PrepareDatabaseForCertificateTemplateUpdate()
    {
        DropTable(typeof(CertificateTemplate).ToString());
        DropTable(typeof(GradeLimit).ToString());
        DropTable(typeof(Content).ToString());

        CreateTable(typeof(CertificateTemplate).ToString());
        CreateTable(typeof(GradeLimit).ToString());
        CreateTable(typeof(Content).ToString());
    }
}
