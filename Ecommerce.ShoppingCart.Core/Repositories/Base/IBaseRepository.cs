using Ecommerce.ShoppingCart.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ShoppingCart.Core.Repositories.Base
{
    public interface IBaseRepository<T> where T : class, IBaseClass, new()
    {
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
    }
}
