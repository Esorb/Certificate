﻿using Esorb.Certificate.App.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.Model
{
    public class CertificateTemplatePage : PersistentObject
    {
        public int PageNumber { get; set; }
        public string? CertificateTemplateId { get; set; }
        public CertificateTemplate? CertificateTemplate { get; set; }
        public IList<Subject> Subjects { get; private set; } = new List<Subject>();
    }
}
