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
    public class AyarlarYonetimi : IAyarlarYonetimi
    {
        private REHBEREntities _db = new REHBEREntities();
        public void Add(tblAyarlar entity)
        {
            _db.tblAyarlar.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(tblAyarlar entity)
        {
            _db.tblAyarlar.Remove(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.tblAyarlar.Remove(GetById(id));
            _db.SaveChanges();
        }

        public tblAyarlar Get(Expression<Func<tblAyarlar, bool>> predicate)
        {
            return _db.tblAyarlar.FirstOrDefault(predicate);
        }

        public IQueryable<tblAyarlar> GetAll()
        {
            return _db.tblAyarlar.AsQueryable();

        }

        public IQueryable<tblAyarlar> GetAll(Expression<Func<tblAyarlar, bool>> predicate)
        {
            return _db.tblAyarlar.Where(predicate);
        }

        public tblAyarlar GetById(int id)
        {
            return _db.tblAyarlar.FirstOrDefault(d => d.ID == id);
        }

        public void Update(tblAyarlar entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public tblAyarlar AddOrUpdate(tblAyarlar entity)
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

