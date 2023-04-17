namespace Esorb.Certificate.App.Model
{
    public interface ITrackableObject
    {
        void AddTrackedList(TrackableList<ITrackableObject> trackedList);
    }
}