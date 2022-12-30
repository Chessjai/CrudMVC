using Question2library.DbcontextCLASS;
using Question2library.Dbmodel;
using Question2library.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Question2library.Repositories
{
    public class StudentRepo : Istudent
    {
        DefaultDbcontext db = new DefaultDbcontext();
        Istudent istudent = null;

        public StudentViewModels Create(StudentViewModels model)
        {
            try
            {              
                var _data = db._studentDbModels.Add(new Dbmodel.StudentDbModel()
                {
                    Age = model.Age,
                    Fname =model.Fname,
                    Lname=model.Lname,
                    Address= model.Address,
                });
                if (db.SaveChanges()>0)
                {
                    model.errorstatus = true;
                    model.errormessage = "Created Successfully";
                }
            }
            catch (Exception ex)
            {

                model.errorstatus = false;
                model.errormessage = ex.Message;
            }
            return model;
        }



        public bool Delete(long ID)
        {
            StudentViewModels studentViewModels1 = new StudentViewModels();
            try
            {
                using (var db = new DefaultDbcontext())
                {
                    var del = db._studentDbModels.FirstOrDefault(x => x.Id == ID);
                    if (del != null)
                    {
                        db._studentDbModels.Remove(del);
                        if (db.SaveChanges() > 0)
                        {
                            studentViewModels1.errorstatus = true;
                            studentViewModels1.errormessage = "Data deleted successfully";

                        }
                    }
                    else
                    {
                        studentViewModels1.errorstatus = false;
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                studentViewModels1.errormessage = ex.Message;
            }
            return false;
        }
                    
         
        

        public StudentViewModels Read(long ID)
        {
            StudentViewModels studentViewModels1= new StudentViewModels();
            try
            {

                studentViewModels1.studentDStudentViewModels1 = db.Database.SqlQuery<StudentViewModels>
                    ("select * from tbl_student where Id=" + Convert.ToInt64(ID)).ToList();
                studentViewModels1.errorstatus = true;
                studentViewModels1.errormessage = "data fetched";
          

            }
            catch (Exception ex)
            {

               studentViewModels1.errorstatus=false;
                studentViewModels1.errormessage=ex.Message;
            }
            return studentViewModels1;
        }

       

        public StudentViewModels Update(long id,StudentViewModels model)
        {
        
            try
            {
                
                var model1 = db._studentDbModels.FirstOrDefault(x => x.Id == id);
                if (model1!=null)
                {
                    model1.Fname = model.Fname;
                    model1.Lname = model.Lname;
                    model1.Age = model.Age;
                    model1.Address = model.Address;
                 

                    if (db.SaveChanges() > 0)
                    {
                        model.errorstatus = true;
                        model.errormessage = "Created Successfully";
                    }
                   
                }
            }
            catch (Exception ex)
            {
                model.errorstatus = false;
                model.errormessage = ex.Message;
            }
            return model;
        }

        

       public StudentMasterDataViewmodel ReadAll()
        { 
            StudentMasterDataViewmodel model = new StudentMasterDataViewmodel();
            try
            {
                model.studentDatas = db.Database.SqlQuery<StudentData>("select Id, CONCAT(Fname,'',Lname) as Name,Age,Address from tbl_student")
                    .ToList();
                model.errorstatus = true;
                model.errormessage = "Fectched";
            }
            catch (Exception ex)
            {

                model.errorstatus = false;
                model.errormessage = ex.Message;
            }
            return model;
        }

        
    }

 
}
