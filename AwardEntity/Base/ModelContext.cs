using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Microsoft.IdentityModel.Tokens;
using Utility.ConfigurationFile;

namespace AwardEntity.Base
{
    public class ModelContext : DbContext
    {
        public ModelContext() : this("")
        {
        }

        public ModelContext(string connectionString)
        {
            if (connectionString.IsNullOrEmpty())
                connectionString = ConfigurationFileHelper.GetDefaultConnectionString();

            ConnectionStringToUseOnConfigure = connectionString;
            DbConnectionToUseOnConfigure = null;
        }

        public ModelContext(DbConnection dbConnection)
        {
            DbConnectionToUseOnConfigure = dbConnection;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (DbConnectionToUseOnConfigure != null)
                optionsBuilder.UseSqlServer(DbConnectionToUseOnConfigure);
            else
                optionsBuilder.UseSqlServer(ConnectionStringToUseOnConfigure);
        } 

        private string ConnectionStringToUseOnConfigure { get; set; }

        private DbConnection? DbConnectionToUseOnConfigure { get; set; }

        #region DbSet 
        public DbSet<User> User { get; set; }
        public DbSet<Award> Award { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<UserAward> UserAward { get; set; }
        #endregion
    }
}
