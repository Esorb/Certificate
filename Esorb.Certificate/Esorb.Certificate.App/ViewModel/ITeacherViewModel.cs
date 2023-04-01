using Esorb.Certificate.App.Model.Enumerables;

namespace Esorb.Certificate.App.ViewModel
{
    public interface ITeacherViewModel
    {
        string FirstName { get; set; }
        string FullName { get; }
        GenderValues Gender { get; set; }
        bool IsAdmin { get; set; }
        bool IsHeadmaster { get; set; }
        string LastName { get; set; }
        string Password { get; set; }
    }
}