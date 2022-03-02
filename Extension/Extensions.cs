using APIArchitecture.Entities;
using APIArchitecture.Extension;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static APIArchitecture.DTOs.CategoryDTOs;

namespace APIArchitecture.Extension
{
    public static class Extensions
    {
        public static CategoryDTO asCategoryDto(this Category category)
        {
            return new CategoryDTO(
                  category.ID,category.Name,category.Description,category.TypeID,category.Status,category.CreateDateTime,category.UpdateDateTime
                );
        }
    }
}
