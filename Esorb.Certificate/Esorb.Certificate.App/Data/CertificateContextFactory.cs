using Esorb.Certificate.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Esorb.Certificate.App.Data
{
    public class CertificateContextFactory : IDesignTimeDbContextFactory<CertificateContext>
    {
        private readonly string _connectionString;

        public CertificateContextFactory()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DebugConnection"].ConnectionString;
        }


        public CertificateContext CreateDbContext(string[] args)
        {

            var builder = new DbContextOptionsBuilder<CertificateContext>();
            builder.UseSqlite(_connectionString, b => b.MigrationsAssembly("Esorb.Certificate.App"));
            return new CertificateContext(builder);
        }
    }

}
