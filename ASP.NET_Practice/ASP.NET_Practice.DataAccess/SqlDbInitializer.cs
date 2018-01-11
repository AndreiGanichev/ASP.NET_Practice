using System.Data.Entity;
using System.IO;

namespace ASP.NET_Practice.DataAccess
{
    public class SqlDbInitializer : DropCreateDatabaseIfModelChanges<PracticeContext>
    {
        protected override void Seed(PracticeContext context)
        {
            base.Seed(context);
            string fullName = "..//..//Scripts//InitScript.sql";

            if (File.Exists(fullName))
            {
                context.Database.ExecuteSqlCommand(File.ReadAllText(fullName));
            }
        }
    }
}
