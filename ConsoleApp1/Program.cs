using Question2library.Repositories;
using Question2library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Question2library.DbcontextCLASS;
using Question2library.Dbmodel;
using System.Net;

namespace ConsoleApp1
{
    //Imssqlserver imssqlserver = new MsSqlServerDetails();
    //string OutputEntity = imssqlserver.GetoutputEntity();
    //string OutputAdo = imssqlserver.GetoutputAdo();
    //Console.WriteLine("OutputEntity:"+OutputEntity);
    //        Console.WriteLine("OutputAdo:"+OutputAdo);
    //        Console.ReadLine();
    internal class Program
    {
     

        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1 for ReadAll students");
            Console.WriteLine("Enter 2 for Insert student");
            Console.WriteLine("Enter 3 for Update studentby id");
            Console.WriteLine("Enter 4 for Delete studentby Id");
            Console.WriteLine("Enter  5 for read studentby Id");
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)

            {
                case 1:
                    Console.WriteLine("------------");
                    readall();
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("------------");
                    Insertdata();
                    Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("------------");
                    Updatedata();
                    Console.ReadLine();
                    break;
                case 4:
                    Console.WriteLine("------------");
                    Delete();
                    Console.ReadLine();
                    break;
                case 5:
                    Console.WriteLine("---enter valid number---------");
            
                    Console.ReadLine();
                    break;


            }
            Console.ReadLine();

        }
        static void readall()
        {
            Istudent istudent = null;
            istudent = new StudentRepo();
            var _data = istudent.ReadAll();
            foreach (var item in _data.studentDatas)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Age);
                Console.WriteLine(item.Address);

            }

        }
        static void Insertdata()
        {
           
                Istudent istudent = new StudentRepo();
                Console.WriteLine("Enter First name");
                string fname = Console.ReadLine();
                Console.WriteLine("Enter Last name");
                string lname = Console.ReadLine();
                Console.WriteLine("Enter Age");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter  Address");
                string address = Console.ReadLine();
                StudentViewModels studentViewModels1 = new StudentViewModels();
                studentViewModels1.Fname = fname;
                studentViewModels1.Lname = lname;
                studentViewModels1.Age = age;
                studentViewModels1.Address = address;
                istudent.Create(studentViewModels1);
                Console.WriteLine("data inserted");
            
           
        }
        static void Updatedata()
        {
            readall();
            Console.WriteLine("please enter the id for update");
            long ID=Convert.ToInt64(Console.ReadLine());
            //GetstudbyId(ID);
            Istudent istudent = new StudentRepo();
            Console.WriteLine("Enter First name");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter Last name");
            string lname = Console.ReadLine();
            Console.WriteLine("Enter Age");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter  Address");
            string address = Console.ReadLine();
            StudentViewModels studentViewModels1 = new StudentViewModels();
            studentViewModels1.Fname = fname;
            studentViewModels1.Lname = lname;
            studentViewModels1.Age = age;
            studentViewModels1.Address = address;
            istudent.Update(ID,studentViewModels1);
            Console.WriteLine("data updated");
        }
        static bool Delete()
        {
            readall();
            Istudent istudent = new StudentRepo();
            Console.WriteLine("Enter id for delete");     
            long ID = Convert.ToInt64(Console.ReadLine());
            StudentViewModels studentViewModels1 = new StudentViewModels();        
            istudent.Delete(ID);
            readall();           
            Console.WriteLine("data deleted");
            return true;
        }
        static void GetstudbyId(long ID)
        {
            Istudent istudent = new StudentRepo();
            var data = istudent.Read(ID);
            Console.WriteLine(data.errormessage + "\n");
            foreach (var item in data.studentDStudentViewModels1)
            {
                Console.WriteLine("stud_fname:" + item.Fname);
                Console.WriteLine("stud_lname:" + item.Lname);
                Console.WriteLine("stud_age:" + item.Age);
                Console.WriteLine("stud_address:" + item.Address);
                Console.ReadKey();
            }

        }
    }
}
