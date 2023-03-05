﻿using Esorb.Certificate.Basics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.Model
{
    public class SchoolClass : PersistentObject
    {
        public string ClassName { get; set; } = string.Empty;
        public short Yearlevel { get; set; }
        public short HalfYear { get; set; }
        public ObservableCollection<Pupil> Pupils { get; set; } = new ObservableCollection<Pupil>();

    }
}
