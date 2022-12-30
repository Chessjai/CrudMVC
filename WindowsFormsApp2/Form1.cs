using Question2library.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2;
using Question2library.DbcontextCLASS;
using Question2library.Dbmodel;

using Question2library.ViewModels;
using System.Web.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace WindowsFormsApp2
{
    
    public partial class Form1 : Form
    {

        StudentViewModels studentViewModels1 = new StudentViewModels();
        Istudent istudent = new StudentRepo();
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'question2DbDataSet.tbl_student' table. You can move, or remove it, as needed.
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataBinding();
        }
        void DataBinding()
        { 
            var read = istudent.ReadAll();
                dataGridView1.DataSource = read.studentDatas;
            }
        void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox3.Text != string.Empty)
            {
                long id = Convert.ToInt64(textBox6.Text);
                Istudent istudent = new StudentRepo();
                istudent.Delete(id);
                string msg = "Student" + id + "deleted";
                MessageBox.Show(msg);
                clear();
            }
            else
            {
                MessageBox.Show("please select id for delete");
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
     
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        void clear1()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text= string.Empty;
          

        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text!=string.Empty)
            {
                StudentViewModels studentViewModels1 = new StudentViewModels();
                studentViewModels1.Fname = textBox1.Text;
                studentViewModels1.Lname = textBox2.Text;
                studentViewModels1.Age = Convert.ToInt32(textBox3.Text);
                studentViewModels1.Address = textBox4.Text;
                var data=istudent.Create(studentViewModels1);
               
                DataBinding();
                clear1();
                MessageBox.Show("inserted student");
            }
            else
            {
                MessageBox.Show("fname or age or address not empty");
            }
        

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void buttonupdate_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text != string.Empty)
            {
                long id = Convert.ToInt64(textBox5.Text);
                StudentRepo std = new StudentRepo();
                std.Read(id);
                StudentViewModels studentViewModels1=new StudentViewModels();
                studentViewModels1.Fname=textBox1.Text;
                studentViewModels1.Lname=textBox2.Text;
                studentViewModels1.Age= Convert.ToInt32(textBox3.Text);
                studentViewModels1.Address = textBox4.Text;
                istudent = new StudentRepo();
                var data = istudent.Update(id, studentViewModels1);
                MessageBox.Show("Entered new data is:" + data.Fname + ","+data.Lname+"," + data.Age + ","+data.Address+"");
                MessageBox.Show("data updaed");
                clear();
                
            }

            else
            {
                MessageBox.Show("Fname or age or address not empty");
            }
        }

        private void tblstudentBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
       
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        public long id1;
        private void dataGridView1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
        //    istudent = new StudentRepo();
        //    var id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        //    id1 = Convert.ToInt64(id);
        //    var data = istudent.Read(id1);
        //    textBox1.Text = data.studentDStudentViewModels1[0].Fname;
        //    textBox2.Text = data.studentDStudentViewModels1[0].Lname;
        //    textBox3.Text = data.studentDStudentViewModels1[0].Age.ToString();
        //    textBox4.Text = data.studentDStudentViewModels1[0].Address;

           
        }
    }
}

