using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_19.Models
{
    public class Employee
    {
        private DateTime _SetDefaultDate = DateTime.Now;
        public int Id { get; set; }

        [Required]
        public string emp_name { get; set; }

        [Required]
        public string emp_salary { get; set; }


        [ForeignKey("Dept_Id")]
        public Department Department { get; set; }
        [Required]
        public int Dept_Id { get; set; }

        [Required]
        public string Emp_Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime JoiningDate
        {
            get
            {
                return _SetDefaultDate;
            }
            set
            {
                _SetDefaultDate = value;
            }
        }
        public bool emp_status { get; set; }
    }
}

