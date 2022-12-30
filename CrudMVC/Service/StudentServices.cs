using CrudMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace CrudMVC.Service
{
    public class StudentServices
    {
        public string connet = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        private SqlDataAdapter Sql_adapter;
        private DataSet DataSetds;

        public IList<StudentModel> GetStudentsList()
        {
            IList<StudentModel> studentslist=new List<StudentModel>();
            DataSetds = new DataSet();
            using (SqlConnection con=new SqlConnection(connet))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("StudentOrInsert", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetStudentList");
                Sql_adapter = new SqlDataAdapter(cmd);
                Sql_adapter.Fill(DataSetds);
                if (DataSetds.Tables.Count>0)
                {
                    for (int i = 0; i < DataSetds.Tables[0].Rows.Count;i++)
                    {
                        StudentModel studentModel = new StudentModel();
                        studentModel.Id = Convert.ToInt32(DataSetds.Tables[0].Rows[i]["Id"]);
                        studentModel.FName = Convert.ToString(DataSetds.Tables[0].Rows[i]["Fname"]);
                        studentModel.LName = Convert.ToString(DataSetds.Tables[0].Rows[i]["Lname"]);
                        studentModel.Age = Convert.ToInt32(DataSetds.Tables[0].Rows[i]["Age"]);
                        studentslist.Add(studentModel);  

                    }
                }
            }

                return studentslist;
        }


        public void InsertStudent(StudentModel model)
        {
            using(SqlConnection con = new SqlConnection(connet))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("StudentOrInsert", con);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "AddStudent1");
                cmd.Parameters.AddWithValue("@Fname", model.FName);
                cmd.Parameters.AddWithValue("@Lname", model.LName);
                cmd.Parameters.AddWithValue("@Age", model.Age);
                cmd.ExecuteNonQuery();

            }

        }

        public StudentModel GetEditByid(int id)
        {
            var model=new StudentModel();
            using(SqlConnection con=new SqlConnection(connet))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("StudentOrInsert", con);
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetStudentById");
                cmd.Parameters.AddWithValue("@StudId",id);
                Sql_adapter = new SqlDataAdapter(cmd);
                DataSetds = new DataSet();
                Sql_adapter.Fill(DataSetds);
                if (DataSetds.Tables.Count>0 && DataSetds.Tables[0].Rows.Count>0)
                {
                    model.Id = Convert.ToInt32(DataSetds.Tables[0].Rows[0]["Id"]);
                    model.FName = Convert.ToString(DataSetds.Tables[0].Rows[0]["Fname"]);
                    model.LName = Convert.ToString(DataSetds.Tables[0].Rows[0]["Lname"]);
                    model.Age = Convert.ToInt32(DataSetds.Tables[0].Rows[0]["Age"]);
                }
            }
            return model;
        }


        public void UpdateStudent(StudentModel model)
        {
            using (SqlConnection con=new SqlConnection(connet))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("StudentOrInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "UpdateStudent");
                cmd.Parameters.AddWithValue("@Fname", model.FName);
                cmd.Parameters.AddWithValue("@Lname", model.LName);
                cmd.Parameters.AddWithValue("@Age", model.Age);
                cmd.Parameters.AddWithValue("@StudId", model.Id);
                cmd.ExecuteNonQuery();
            }
        }


        public void DeleteStudent(int Id)
        {
            using(SqlConnection con=new SqlConnection(connet))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("StudentOrInsert", con);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "DeleteStudent");
                cmd.Parameters.AddWithValue("@StudId",Id);
                cmd.ExecuteNonQuery();
            }
        }




    }
}