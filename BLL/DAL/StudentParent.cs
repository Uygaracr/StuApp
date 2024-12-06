namespace BLL.DAL
{
    public class StudentParent
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int ParentId { get; set; }

        public Parent Parent { get; set; }
    }
}
