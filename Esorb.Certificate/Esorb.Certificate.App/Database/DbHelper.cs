using Esorb.Certificate.App.Model;
using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esorb.Certificate.App.Model.Enumerables;
using Esorb.Certificate.App;
using System.IO;
using System.Windows;

namespace Esorb.Certificate.App.Database;

public class DbHelper
{
    public DbHelper()
    {
        InitPupil();
        CreateTable(typeof(Pupil).ToString());
        InitSchoolClass();
        CreateTable(typeof(SchoolClass).ToString());
        InitTeacher();
        CreateTable(typeof(Teacher).ToString());
        InitCertificateData();
        CreateTable(typeof(CertificateData).ToString());
    }

    private Dictionary<string, ObjectSQL> StandardSQLStatements = new Dictionary<string, ObjectSQL>();

    private static string ConnectionString()
    {
        //StringBuilder sb = new StringBuilder();
        //sb.Append("Data Source = ");
        //sb.Append(Properties.Settings.DatabasePath);
        //sb.Append(';');
        return "Data Source = C:/Users/frank/Documents/Versuche.db;";
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
        T Result = new T();
        var Type = Result.GetType().ToString();
        if (!StandardSQLStatements.ContainsKey(Type)) { return Result; }

        using var connection = new SqliteConnection(ConnectionString());
        var parameter = new { ID = SearchID };
        Result = connection.QuerySingle(StandardSQLStatements[Type].SelectById, parameter);
        return Result;
    }

    public IEnumerable<T> LoadAll<T>() where T : class, new()
    {
        var Type = typeof(T).ToString();
        IEnumerable<T> Result = new List<T>();
        return LoadAll<T>();
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
            { "DateOfSchoolConference", "TEXT" },
            { "DateOfCertificateDistribution", "TEXT" },
            { "DateOfRestartLessons", "TEXT" },
            { "TimeOfRestartLessons", "TEXT" },
            { "CertificateTemplateID", "TEXT" }
        };

        ObjectSQL SQL = new ObjectSQL("CertificateData", Fields);
        StandardSQLStatements.Add(typeof(CertificateData).ToString(), SQL);
    }
}
