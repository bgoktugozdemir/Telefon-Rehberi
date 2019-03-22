using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Rehber.Bl.Interface;
using Rehber.Model.DataModel;

namespace Rehber.Bl.Repository
{
    public class DepartmanYonetimi : IDepartmanYonetimi
    {
        private REHBEREntities _db = new REHBEREntities();
        public void Add(tblDepartman entity)
        {
            _db.tblDepartman.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(tblDepartman entity)
        {
            _db.tblDepartman.Remove(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.tblDepartman.Remove(GetById(id));
            _db.SaveChanges();
        }

        public tblDepartman Get(Expression<Func<tblDepartman, bool>> predicate)
        {
            return _db.tblDepartman.FirstOrDefault(predicate);
        }

        public IQueryable<tblDepartman> GetAll()
        {
            return _db.tblDepartman.AsQueryable();

        }

        public IQueryable<tblDepartman> GetAll(Expression<Func<tblDepartman, bool>> predicate)
        {
            return _db.tblDepartman.Where(predicate);
        }

        public tblDepartman GetById(int id)
        {
            return _db.tblDepartman.FirstOrDefault(d => d.ID == id);
        }

        public void Update(tblDepartman entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public tblDepartman AddOrUpdate(tblDepartman entity)
        {
            try
            {
                _db.Entry(entity).State = entity.ID == 0 ?
                    EntityState.Added :
                    EntityState.Modified;
                _db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }


            return entity;
        }
    }
}
