using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models.Managers
{
   public class DataBaseContext:DbContext
    {
        public DbSet<Haber> Haberler { get; set; }
        public DataBaseContext()
        {
            Database.SetInitializer(new DBCreator());
        }
    }

    public class DBCreator : CreateDatabaseIfNotExists<DataBaseContext>
    {
    
    }
    
}
