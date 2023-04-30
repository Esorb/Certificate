using Esorb.Certificate.App.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.Model;

public abstract class PersistentObject : ITrackableObject
{
    private static readonly DbHelper _dbHelper;
    private static readonly object _lock = new object();
    IList<TrackableList> _trackedLists = new List<TrackableList>();
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
        RemoveMyselfFromTrackedLists();
        DeleteMyselfFromDatabase();
    }

    private void RemoveMyselfFromTrackedLists()
    {
        foreach (var tl in _trackedLists)
        {
            tl.Remove(this);
        }
    }

    private void DeleteMyselfFromDatabase()
    {
        _dbHelper?.Delete(this);
    }

    public void AddTrackedList(TrackableList listToBeTracked)
    {
        if (!_trackedLists.Contains(listToBeTracked!))
        {
            _trackedLists.Add(listToBeTracked!);
        }
    }
}
