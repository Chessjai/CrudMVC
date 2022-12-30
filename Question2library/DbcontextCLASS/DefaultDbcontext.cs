using Question2library.Dbmodel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2library.DbcontextCLASS
{
    
        public class DefaultDbcontext:DbContext
        {
            public DefaultDbcontext() : base("Connection")
            {
                Database.SetInitializer<DefaultDbcontext>(null);
            }
            public DbSet<StudentDbModel> _studentDbModels { get; set; }

        public System.Data.Entity.DbSet<Question2library.ViewModels.StudentData> StudentDatas { get; set; }

        public System.Data.Entity.DbSet<Question2library.ViewModels.StudentViewModels> StudentViewModels { get; set; }
    }

   
}
