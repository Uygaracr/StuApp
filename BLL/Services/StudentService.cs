using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public interface IStudentService
    {
        public IQueryable<StudentModel> Query();

        public ServiceBase Create(Student Record);
        public ServiceBase Update(Student Record);
        public ServiceBase Delete(int id);
    }
    public class StudentService : ServiceBase, IStudentService
    {
        public StudentService(Db db) : base(db)
        {
        }

        public ServiceBase Create(Student Record)
        {
            if (_db.Students.Any(s=>s.Name.ToLower() == Record.Name.ToLower().Trim() && s.IsFemale == Record.IsFemale && 
                    s.BirthDate==Record.BirthDate))
                return Error("Student with the same name,btday and gender exists.");
            Record.Name = Record.Name?.Trim();
            _db.Students.Add(Record);
            _db.SaveChanges();
            return Success("Student Created");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Students.Include(s=> s.StudentParent).SingleOrDefault(s=>s.Id==id);
            if (entity is null)
                return Error("Student cant be found.");
            _db.StudentParents.RemoveRange(entity.StudentParent);
            _db.Students.Remove(entity);
            _db.SaveChanges();
            return Success("Stu deleted!");
        }

        public IQueryable<StudentModel> Query()
        {
            return _db.Students.OrderByDescending(s => s.BirthDate).ThenByDescending(s => s.IsFemale).ThenBy(s => s.Name).
            Select(s => new StudentModel() { Record = s });
        }

        public ServiceBase Update(Student Record)
        {
            if (_db.Students.Any(s => s.Id != Record.Id && s.Name.ToLower() == Record.Name.ToLower().Trim() && s.IsFemale == Record.IsFemale &&
                   s.BirthDate == Record.BirthDate))
                return Error("Student with the same name,btday and gender exists.");
            Record.Name = Record.Name?.Trim();
            _db.Students.Add(Record);
            _db.SaveChanges();
            return Success("Student Updated");
        }
    }
}
