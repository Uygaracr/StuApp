#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using BLL.DAL;

namespace BLL.Models
{
    public class StudentModel
    {
        public Student Record { get; set; }

        public string Name => Record.Name;

        [DisplayName("Gender")]
        public string IsFemale => Record.IsFemale ? "Female" : "Male";

        [DisplayName("Birth Date")]
        public string BirthDate => Record.BirthDate is null ? string.Empty : Record.BirthDate.ToString();
        public string Class => Record.Class?.Name;

    }
}
