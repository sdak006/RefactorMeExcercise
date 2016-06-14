using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.DontRefactor.Data.Implementation
{
    public abstract class BaseReadOnlyRepository<T> : IReadOnlyRepository<T> where T : class
    {
        protected abstract T[] Data { get; }

        public IQueryable<T> GetAll() {
            return Data.AsQueryable();
        }

        public IQueryable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate) {
            return Data.AsQueryable().Where(predicate);
        }
    }
}
