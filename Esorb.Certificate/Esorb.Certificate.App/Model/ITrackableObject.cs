namespace Esorb.Certificate.App.Model;

public interface ITrackableObject
{
    void AddTrackedList<T>(TrackableList<T> listToBeTracked) where T : ITrackableObject;
    void RemoveMyselfFromAllTrackedLists();
}