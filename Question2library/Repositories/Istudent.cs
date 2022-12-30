using Question2library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2library.Repositories
{
    public interface Istudent
    {
        StudentViewModels Create(StudentViewModels model);

        StudentViewModels Read(long ID);

        StudentMasterDataViewmodel ReadAll();

        StudentViewModels Update(long id,StudentViewModels model);

        bool Delete(long ID);
      
    }
}
