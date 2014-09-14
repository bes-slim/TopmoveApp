using System.Data.Entity.Migrations;
using System.Runtime.InteropServices;

namespace TopMove.Lettings.Accounts.Data
{
    public class EFConfig
    {
        public static void Initialize()
        {
            RunMigrations();
        }

        private static void RunMigrations()
        {
            var efMigrationSettings = new TopMove.Lettings.Accounts.Data.Migrations.Configuration();
            var efMigrator = new DbMigrator(efMigrationSettings);
            efMigrator.Update();
        }
    }
}