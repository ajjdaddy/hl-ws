using HL.IdentityUtility;
using Microsoft.EntityFrameworkCore;

namespace HL.IdentityCache
{
    public class IdentityCache : DbContext
    {
        public DbSet<HuongLinh> HuongLinhList { get; set; }

        public string DbPath { get; set; }

        public IdentityCache()
        {
            SetTmpFolder();
            DbPath = System.IO.Path.Join(DbPath, "hl-identity.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        private void SetTmpFolder()
        {
            if (DbParameters.HLIdentityConfig == null)
                DbParameters.GetDbConfig();

            DbPath = DbParameters.HLIdentityConfig.CacheFolder;
        }
    }

    /// <summary>
    /// TODO (CD):
    /// Rename created database file name to hl-identity (hl-identity.db)
    /// Rename created database table to HuongLinh
    /// Replace the sample current exiting HLDatabase\hl-identity.db that has all the new fields
    /// Add all neccessary matched fields for HuongLinh table here
    /// </summary>
    public class HuongLinh
    {
        // TODO (CD): Replace the following test fields
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
    }
}
