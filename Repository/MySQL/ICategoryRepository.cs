using APIArchitecture.Entities;
using System.Collections.Generic;

namespace APIArchitecture.Repository.MySQL
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
    }
}