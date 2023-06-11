using Esorb.Certificate.App.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.Model;

public abstract class PersistentObject
{
    private static readonly DbHelper _dbHelper;
    private static readonly object _lock = new object();
    private List<TrackableList<ITrackableObject>> _trackedLists = new List<TrackableList<ITrackableObject>>();
    public string? ID { get; set; }

    public DbHelper DbHelper
    {
        get => _dbHelper;
    }

    static PersistentObject()
    {
        lock (_lock)
        {
            if (_dbHelper == null)
            {
                _dbHelper = new DbHelper();
            }
        }
    }
    public void Save()
    {
        _dbHelper?.Save(this);
    }

    public void Delete()
    {
        //RemoveMyselfFromAllTrackedLists();
        DeleteMyselfFromDatabase();
    }

    private void DeleteMyselfFromDatabase()
    {
        _dbHelper?.Delete(this);
    }

    //public void AddTrackedList<T>(TrackableList<T> listToBeTracked) where T : ITrackableObject
    //{
    //    _trackedLists.Add((TrackableList<ITrackableObject>)(object)listToBeTracked);
    //}

    //public void RemoveMyselfFromAllTrackedLists()
    //{
    //    foreach (var list in _trackedLists)
    //    {
    //        list.Remove((ITrackableObject)this);
    //    }

    //    _trackedLists.Clear();
    //}
}
