using Dapper;
using ReviewGameAzure.DAL.Entities;
using ReviewGameAzure.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            _Connection.Open();
            CategoryEntity category = _Connection.QuerySingleOrDefault<CategoryEntity>(
                "SELECT * FROM Category WHERE Id = @Id",
                new { Id = id });
            _Connection.Close();

            return category;
        }

        public IEnumerable<CategoryEntity> GetByName(string name)
        {
            _Connection.Open();

            // Gestion des caracteres '%', '_', '[' et ']'
            string pattern = Regex.Replace(name, @"[%_\[\]]", "_$0");
            Console.WriteLine($"GetByName : Avant {name} / Après {pattern}");


            IEnumerable<CategoryEntity> categories = _Connection.Query<CategoryEntity>(
               "SELECT * FROM Category WHERE Name LIKE @Pattern ESCAPE '_'",
                new { Pattern = "%" + pattern + "%" }
            );
            _Connection.Close();

            return categories;
        }

        public CategoryEntity Insert(CategoryEntity entity)
        {
            _Connection.Open();
            CategoryEntity category = _Connection.QuerySingle<CategoryEntity>(
                "INSERT INTO [Category]([Name], [Description])" + 
                " OUTPUT Inserted.*" + 
                " VALUES (@Name, @Description)",
                entity
            );
            _Connection.Close();

            return category;
        }

        public bool Remove(long id)
        {
            _Connection.Open();
            int nbRow = _Connection.Execute(
                "DELETE FROM Category WHERE Id = @Id",
                new { Id = id }
            );
            _Connection.Close();

            return nbRow == 1;
        }

        public CategoryEntity Update(long id, CategoryEntity entity)
        {
            _Connection.Open();
            CategoryEntity category = _Connection.QuerySingle<CategoryEntity>(
                "UPDATE Category" +
                " SET Name = @Name, Description = @Desc" +
                " OUTPUT inserted.*" +
                " WHERE Id = @Id",
                new { Id = id, Name = entity.Name, Desc = entity.Description }
            );
            _Connection.Close();

            return category;
        }
    }
}
