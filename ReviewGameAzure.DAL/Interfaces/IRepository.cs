using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewGameAzure.DAL.Interfaces
{
    public interface IRepository<TId, TEntity>
    {
        TEntity? GetById(TId id);

        IEnumerable<TEntity> GetAll();

        TEntity Insert(TEntity entity);

        TEntity Update(TId id, TEntity entity);

        bool Remove(TId id);
    }
}
