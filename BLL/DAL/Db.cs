using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BLL.DAL
{
    public class Db : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<StudentParent> StudentParents { get; set; }

        public Db(DbContextOptions options) : base(options)
        {           
        }
    }
}
