using System;
using System.Collections.Generic;
using System.Linq;
using Application.Model;
using Domain.Persistence;
using Infrastructure.Initialization;
using SQLite;
using AutoMapper;
namespace Infrastructure.Persistence
{
    public class CategoryRepository : ICategoryRepository 
    {
        public IEnumerable<Category> GetCategories()
        {
            Mapper.CreateMap<Model.Category, Category>();

            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                var c = db.Table<Model.Category>().ToList();

                return Mapper.Map<IEnumerable<Model.Category>, IEnumerable<Category>>(c).ToList();
            }
        }

        public Boolean DoCustomQuestionsExist()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                var c = db.Table<Model.Questions>().Where(cat => cat.CategoryId == 6).Count();

                return c > 0;
            }
        }
    }
}