using Esorb.Certificate.Model;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// @"C:\Users\frank\source\repos\Esorb\Certificate\Esorb.Certificate\Esorb.Certificate.UnitTests\TestData\Certificate.db;Version=3;UseUTF32Encoding=True"

namespace Esorb.Certificate.Model
{
    public class CertificateContext : DbContext
    {
        private readonly string _connectionString;

        public CertificateContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CertificateContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DebugConnection"].ConnectionString;
        }

        public CertificateContext(DbContextOptionsBuilder builder)
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DebugConnection"].ConnectionString;
        }

        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<CertificateData> CertificateData { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlite(_connectionString);
            optionsBuilder.UseSqlite(_connectionString);
        }
    }
}
