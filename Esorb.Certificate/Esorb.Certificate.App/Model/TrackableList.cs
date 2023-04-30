using System.Collections.Generic;

namespace Esorb.Certificate.App.Model;

public class TrackableList : List<PersistentObject>
{
    public void Add(PersistentObject item)
    {
        item!.AddTrackedList(this);
        base.Add(item);
    }
}
