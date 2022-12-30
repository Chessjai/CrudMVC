using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2library.Dbmodel
{
    [Table("tbl_student")]
    public class StudentDbModel
    {
        [Key]
        public long Id { get; set; }

      
        [Required(ErrorMessage = "Firstname is required.")]
        //[ RegularExpression(@"^.*[a-zA-Z]", ErrorMessage = "Only Alphabets  allowed.")]
        
        public string Fname { get; set; }

        [Required(ErrorMessage = "Lastname is required.")]
        //[RegularExpression(@"^.*[a-zA-Z]", ErrorMessage = "Only Alphabets  allowed.")]
        public string Lname { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
    }
}
