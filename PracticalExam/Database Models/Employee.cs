using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalExam.Database_Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string lastName { get; set; }


        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}")]
        [Column(TypeName ="date")]
        
        public DateTime BirthDate { get; set; }

        public Decimal Salary { get; set; }

        public bool IsManger { get; set; }
    }
}
