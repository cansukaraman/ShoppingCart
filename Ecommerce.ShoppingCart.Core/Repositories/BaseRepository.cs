using Ecommerce.ShoppingCart.Core.Model;
using Ecommerce.ShoppingCart.Core.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ShoppingCart.Core.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseClass, new()
    {
        public ShoppingCartContext context;
        public BaseRepository(ShoppingCartContext context)
        {
            this.context = context;
        }

        public void Add(T entity)
        {
            EntityEntry dbEntityEntry = context.Entry<T>(entity);
            context.Set<T>().Add(entity);
        }
        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().AsEnumerable();
        }

        public T GetSingle(int id)
        {
            return context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public void Update(T entity)
        {
            EntityEntry dbEntityEntry = context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }
    }
}
