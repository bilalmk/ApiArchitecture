using APIArchitecture.Entities;
using System.Collections.Generic;

namespace APIArchitecture.DB.MYSQL
{
    public interface IDBCategory
    {
        IEnumerable<Category> GetAll();
    }
}