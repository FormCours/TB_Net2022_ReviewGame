using Dapper;
using ReviewGameAzure.DAL.Entities;
using ReviewGameAzure.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewGameAzure.DAL.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbConnection _Connection;

        public CategoryRepository(IDbConnection connection)
        {
            _Connection = connection;
        }

        public IEnumerable<CategoryEntity> GetAll()
        {
            _Connection.Open();
            IEnumerable<CategoryEntity> categories = _Connection.Query<CategoryEntity>("SELECT * FROM Category");
            _Connection.Close();

            return categories;
        }

        public CategoryEntity? GetById(long id)
        {
            throw new NotImplementedException();
        }

        public CategoryEntity Insert(CategoryEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Remove(long id)
        {
            throw new NotImplementedException();
        }

        public CategoryEntity Update(long id, CategoryEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
