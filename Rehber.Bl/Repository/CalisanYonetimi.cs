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
    public class CalisanYonetimi : ICalisanYonetimi
    {
        private REHBEREntities _db = new REHBEREntities();
        public void Add(tblCalisan entity)
        {
            _db.tblCalisan.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(tblCalisan entity)
        {
            _db.tblCalisan.Remove(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.tblCalisan.Remove(GetById(id));
            _db.SaveChanges();
        }

        public tblCalisan Get(Expression<Func<tblCalisan, bool>> predicate)
        {
            return _db.tblCalisan.FirstOrDefault(predicate);
        }

        public IQueryable<tblCalisan> GetAll()
        {
            return _db.tblCalisan.AsQueryable();

        }

        public IQueryable<tblCalisan> GetAll(Expression<Func<tblCalisan, bool>> predicate)
        {
            return _db.tblCalisan.Where(predicate);
        }

        public tblCalisan GetById(int id)
        {
            return _db.tblCalisan.FirstOrDefault(d => d.ID == id);
        }

        public void Update(tblCalisan entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public tblCalisan AddOrUpdate(tblCalisan entity)
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

