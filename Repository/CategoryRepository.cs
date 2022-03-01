using APIArchitecture.DB.MYSQL;
using APIArchitecture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIArchitecture.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        public IDBCategory DB;

        public CategoryRepository(IDBCategory DB)
        {
            this.DB = DB;
        }
        public IEnumerable<Category> GetAll()
        {
            var catList = DB.GetAll();
            return catList;
        }
    }
}
