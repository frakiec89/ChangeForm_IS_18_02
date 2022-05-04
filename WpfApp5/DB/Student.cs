using System.ComponentModel.DataAnnotations;

namespace WpfApp5.DB
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public int StudentAge { get; set; }

        public int MyGroupId { get; set; }

        public MyGroup MyGroup { get; set; }
    }
}