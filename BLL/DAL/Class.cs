using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Class
    {
        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string Name { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();
    }
}