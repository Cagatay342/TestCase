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
        public DbSet<Kisi> Kisiler { get; set; }
        public DataBaseContext()
        {
            Database.SetInitializer(new DBCreator());
        }
    }

    public class DBCreator : CreateDatabaseIfNotExists<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            for (int i = 0; i < 1000; i++)
            {
                context.Kisiler.Add(new Kisi
                {
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Mail = FakeData.NetworkData.GetEmail()
                });

            }

            context.SaveChanges();
        }
    }


    
}
