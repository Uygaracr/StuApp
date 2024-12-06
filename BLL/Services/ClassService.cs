using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public interface IClassService
    {
        public IQueryable<ClassModel> Query();

        public ServiceBase Create(Class Record);
        public ServiceBase Update(Class Record);
        public ServiceBase Delete(int id);
  

    }
    public class ClassService : ServiceBase , IClassService
    {
        public ClassService(Db db) : base(db)
        {
        }

        public ServiceBase Create(Class Record)
        {
            if (_db.Class.Any(c => c.Name.ToUpper() == Record.Name.ToUpper().Trim()))
                return Error("Classes with the same exist!");
            Record.Name = Record.Name?.Trim();
            _db.Class.Add(Record);
            _db.SaveChanges();
            return Success("Speices Created.");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Class.Include(c => c.Students).SingleOrDefault(c => c.Id == id);
            if (entity is null)
                return Error("Classes cant be found.");
            if (entity.Students.Any())   // >0
                return Error("classes have relational students.");
             _db.Class.Remove(entity);
            _db.SaveChanges();
            return Success("Classes Deleted Succesfully");
        }

        public IQueryable<ClassModel> Query()
        {
            return _db.Class.OrderBy(c => c.Name).Select(c => new ClassModel() { Record = c });
        }

        public ServiceBase Update(Class Record)
        {
            if (_db.Class.Any(c => c.Id != Record.Id && c.Name.ToUpper() == Record.Name.ToUpper().Trim()))
                return Error("Classes with the same exist!");
            var entity =_db.Class.SingleOrDefault(c  => c.Id == Record.Id);
            if (entity is null)
                return Error("Classes cant be found.");
            entity.Name = Record.Name?.Trim();
            _db.Class.Update(entity);
            _db.SaveChanges();
            return Success("Classes Updated Succesfully");
        }
    }
}
