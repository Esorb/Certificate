using Esorb.Certificate.Model;
using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.Database
{
    public class DbHelper
    {
        public DbHelper()
        {
            InitPupil();
            CreateTable(typeof(Pupil).ToString());
            InitSchoolClass();
            CreateTable(typeof(SchoolClass).ToString());
        }

        private Dictionary<string, ObjectSQL> StandardSQLStatements = new Dictionary<string, ObjectSQL>();

        private static string ConnectionString()
        {
            //return Properties.Settings.Default.ConnectionString;
            //return "Data Source = C:/Users/frank/Documents/Versuche.db;Version=3;";
            return "Data Source = C:/Users/frank/Documents/Versuche.db;";
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

    }
}
