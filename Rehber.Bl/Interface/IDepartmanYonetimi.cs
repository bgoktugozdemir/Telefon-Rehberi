using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Rehber.Model.DataModel;

namespace Rehber.Bl.Interface
{
    public interface IDepartmanYonetimi
    {
        IQueryable<tblDepartman> GetAll();
        IQueryable<tblDepartman> GetAll(Expression<Func<tblDepartman, bool>> predicate);
        tblDepartman Get(Expression<Func<tblDepartman, bool>> predicate);
        void Add(tblDepartman entity);
        void Update(tblDepartman entity);
        void Delete(tblDepartman entity);
        void Delete(int id);
        tblDepartman AddOrUpdate(tblDepartman entity);
    }
}
