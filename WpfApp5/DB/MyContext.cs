using Microsoft.EntityFrameworkCore;


namespace WpfApp5.DB
{
    public  class MyContext : DbContext
    {
        string cs = "Server=192.168.10.134; database=Ahtyamov_04_05; user id = stud;password=stud;";


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(cs);
        }

        public DbSet<MyGroup> MyGroups { get; set;  }

        public DbSet<Student> Students { get; set; }

    }

}
