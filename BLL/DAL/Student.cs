using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool IsFemale { get; set; }

        public DateTime? BirthDate { get; set; }

        public int? ClassId { get; set; }
        public Class Class { get; set; }  // navigational

        public List<StudentParent> StudentParent { get; set; } = new List<StudentParent>();
    }
}
