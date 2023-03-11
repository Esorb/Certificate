using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App
{
    public class CertificateSettings
    {
        public CertificateSettings()
        {
            //databasePath = Properties.Settings.DatabasePath;
        }

        private string? databasePath;
        public string? DatabasePath
        {
            get { return databasePath; }
            set { databasePath = value; }
        }
    }
}
