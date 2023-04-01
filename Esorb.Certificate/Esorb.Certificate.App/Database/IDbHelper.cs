using Esorb.Certificate.App.Model;
using System.Collections.Generic;

namespace Esorb.Certificate.App.Database
{
    public interface IDbHelper
    {
        int Count(string Type);
        void CreateCertificateTables();
        void CreateTable(string Type);
        void Delete(PersistentObject Object);
        void DropTable(string Type);
        bool IsSQLiteFile(string filePath);
        IList<T> LoadAll<T>() where T : class, new();
        T LoadById<T>(string SearchID) where T : class, new();
        void Save(PersistentObject Object);
    }
}