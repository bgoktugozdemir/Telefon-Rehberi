using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Rehber.Model.DataModel;

namespace Rehber.Bl.Interface
{
    public interface IAyarlarYonetimi
    {
        IQueryable<tblAyarlar> GetAll();
        IQueryable<tblAyarlar> GetAll(Expression<Func<tblAyarlar, bool>> predicate);
        tblAyarlar Get(Expression<Func<tblAyarlar, bool>> predicate);
        void Add(tblAyarlar entity);
        void Update(tblAyarlar entity);
        void Delete(tblAyarlar entity);
        void Delete(int id);
        tblAyarlar AddOrUpdate(tblAyarlar entity);
    }
}
