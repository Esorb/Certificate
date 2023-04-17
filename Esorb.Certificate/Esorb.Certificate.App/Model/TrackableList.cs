using System.Collections.Generic;

namespace Esorb.Certificate.App.Model;

public class TrackableList<ITrackableObject> : List<ITrackableObject>
{
    public new void Add(ITrackableObject item)
    {
        //item!.AddTrackedList(this);
        base.Add(item);
    }
}
