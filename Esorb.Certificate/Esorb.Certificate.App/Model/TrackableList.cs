using System.Collections.Generic;

namespace Esorb.Certificate.App.Model;

public class TrackableList<T> : List<T> where T : ITrackableObject
{
    public new void Add(T item)
    {
        base.Add(item);
        item.AddTrackedList(this);
    }
}