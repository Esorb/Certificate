using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Dapper;
using Microsoft.Data.Sqlite;

using Esorb.Certificate.App.Model;

namespace Esorb.Certificate.App.Database;

public class DbHelper : IDbHelper
{
    private CertificateSettings _settings = new();
    public DbHelper()
    {
        InitPupil();
        InitSchoolClass();
        InitTeacher();
        InitCertificateData();
        InitCertificateTemplate();
        InitGradeLimit();
    }

    private Dictionary<string, ObjectSQL> StandardSQLStatements = new Dictionary<string, ObjectSQL>();

    public void CreateCertificateTables()
    {
        CreateTable(typeof(Pupil).ToString());
        CreateTable(typeof(SchoolClass).ToString());
        CreateTable(typeof(Teacher).ToString());
        CreateTable(typeof(CertificateData).ToString());
        CreateTable(typeof(CertificateTemplate).ToString());
        CreateTable(typeof(GradeLimit).ToString());
    }

    private string ConnectionString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("Data Source = ");
        sb.Append(_settings.DatabasePath);
        sb.Append(';');

        return sb.ToString();
    }

    public bool IsSQLiteFile(string filePath)
    {
        if (string.IsNullOrEmpty(filePath)) return false;
        if (!File.Exists(filePath)) return false;

        try
        {
            using (var connection = new SqliteConnection($"Data Source={filePath}"))
            {
                connection.Open();
                using (var command = new SqliteCommand("SELECT name FROM sqlite_master WHERE type='table'", connection))
                {
                    command.ExecuteReader();
                }
            }
            return true;
        }
        catch
        {
            return false;
        }
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

        using var connection = new SqliteConnection(ConnectionString());
        return connection.ExecuteScalar<int>(StandardSQLStatements[Type].Count);
    }

    public T LoadById<T>(string SearchID) where T : class, new()
    {
        T result = new T();
        var Type = result.GetType().ToString();
        if (!StandardSQLStatements.ContainsKey(Type)) { return result; }

        using var connection = new SqliteConnection(ConnectionString());
        var parameter = new { ID = SearchID };
        result = connection.QuerySingle<T>(StandardSQLStatements[Type].SelectById, parameter);
        return result;
    }

    public IList<T> LoadAll<T>() where T : class, new()
    {
        var Type = typeof(T).ToString();
        IList<T> result = new List<T>();

        using var connection = new SqliteConnection(ConnectionString());
        result = connection.Query<T>(StandardSQLStatements[Type].SelectAll).ToList();

        return result;
    }

    public void CreateTable(string Type)
    {
        if (!StandardSQLStatements.ContainsKey(Type)) { return; }

        using var connection = new SqliteConnection(ConnectionString());
        connection.ExecuteScalar(StandardSQLStatements[Type].CreateTable);
    }


    public void DropTable(string Type)
    {
        if (!StandardSQLStatements.ContainsKey(Type)) { return; }

        using var connection = new SqliteConnection(ConnectionString());
        connection.Execute(StandardSQLStatements[Type].DropTable);
    }


    private void CreateDbInstance(PersistentObject Object)
    {
        using var connection = new SqliteConnection(ConnectionString());
        {
            connection.ExecuteScalar(StandardSQLStatements[Object.GetType().ToString()].Insert, Object);
        };
    }


    private void UpdateDbInstance(PersistentObject Object)
    {
        using var connection = new SqliteConnection(ConnectionString());
        connection.ExecuteScalar(StandardSQLStatements[Object.GetType().ToString()].Update, Object);
    }


    private void DeleteDbInstance(PersistentObject Object)
    {
        using var connection = new SqliteConnection(ConnectionString());
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

        ObjectSQL SQL = new ObjectSQL("Pupil", Fields);
        StandardSQLStatements.Add(typeof(Pupil).ToString(), SQL);
    }

    private void InitSchoolClass()
    {
        var Fields = new Dictionary<string, string>
        {
            { "ClassName", "TEXT" },
            { "Yearlevel", "INTEGER" },
            { "HalfYear", "INTEGER" }
        };

        ObjectSQL SQL = new ObjectSQL("SchoolClass", Fields);
        StandardSQLStatements.Add(typeof(SchoolClass).ToString(), SQL);
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

        ObjectSQL SQL = new ObjectSQL("Teacher", Fields);
        StandardSQLStatements.Add(typeof(Teacher).ToString(), SQL);
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

        ObjectSQL SQL = new ObjectSQL("CertificateData", Fields);
        StandardSQLStatements.Add(typeof(CertificateData).ToString(), SQL);
    }

    private void InitCertificateTemplate()
    {
        var Fields = new Dictionary<string, string>
        {
            { "Yearlevel", "INTEGER" },
            { "HalfYear", "INTEGER" },
        };

        ObjectSQL SQL = new ObjectSQL("CertificateTemplate", Fields);
        StandardSQLStatements.Add(typeof(CertificateTemplate).ToString(), SQL);
    }

    private void InitGradeLimit()
    {
        var Fields = new Dictionary<string, string>
        {
            { "PercentageLimit", "REAL" },
            { "Grade", "TEXT" },
            { "GradeNumeric", "INTEGER" },
        };

        ObjectSQL SQL = new ObjectSQL("GradeLimit", Fields);
        StandardSQLStatements.Add(typeof(GradeLimit).ToString(), SQL);

    }
}
