using System.ComponentModel.DataAnnotations;

namespace WpfApp5.DB
{
    public class MyGroup
    {
        [Key]
        public int MyGroupId { get; set; }
        public string MyGroupName { get; set; }


        public override string ToString()
        {
            return MyGroupName;
        }
    }
}

