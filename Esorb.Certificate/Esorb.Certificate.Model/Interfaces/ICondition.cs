﻿using Esorb.Certificate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.Model.Interfaces
{
    public interface ICondition
    {
        string Name { get; }
        public bool IsFullfilledFor(Pupil pupil);
    }
}
