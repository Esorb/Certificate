using Esorb.Certificate.App.Database;

namespace Esorb.Certificate.App.Model
{
    public interface IPersistentObject
    {
        DbHelper DbHelper { get; }
        string? ID { get; set; }
        void Delete();
        void Save();
    }
}