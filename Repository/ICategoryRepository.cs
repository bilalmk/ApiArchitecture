using APIArchitecture.Entities;
using System.Collections.Generic;

namespace APIArchitecture.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
    }
}