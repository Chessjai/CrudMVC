using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2library.ViewModels
{

    public class CommonResponseModel
    {
        public bool errorstatus { get; set; }
        public string errormessage { get; set; }
    }

    public class StudentViewModels : CommonResponseModel
    {
       

        public long Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public List<StudentViewModels> studentDStudentViewModels1 { get; set; } = new List<StudentViewModels>();
    }

    public class StudentMasterDataViewmodel:CommonResponseModel
    {
        public List<StudentData> studentDatas { get; set; } = new List<StudentData>();
      

      
    }

    public class StudentData
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
}