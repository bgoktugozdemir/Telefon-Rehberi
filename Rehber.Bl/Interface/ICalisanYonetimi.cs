using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Rehber.Model.DataModel;

namespace Rehber.Bl.Interface
{
    public interface ICalisanYonetimi
    {
        IQueryable<tblCalisan> GetAll();
        IQueryable<tblCalisan> GetAll(Expression<Func<tblCalisan, bool>> predicate);
        tblCalisan Get(Expression<Func<tblCalisan, bool>> predicate);
        void Add(tblCalisan entity);
        void Update(tblCalisan entity);
        void Delete(tblCalisan entity);
        void Delete(int id);
        tblCalisan AddOrUpdate(tblCalisan entity);
    }
}
