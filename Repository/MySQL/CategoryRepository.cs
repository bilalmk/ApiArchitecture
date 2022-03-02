using APIArchitecture.Entities;
using APIArchitecture.Extension;
using Del;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace APIArchitecture.Repository.MySQL
{
    public class CategoryRepository : ICategoryRepository
    {

        //public IDBCategory DB;

        /*public CategoryRepository(IDBCategory DB)
        {
            this.DB = DB;
        }
        public IEnumerable<Category> GetAll()
        {
            var catList = DB.GetAll();
            return catList;
        }*/

        public IDataAccess dataAccess;
        public CategoryRepository(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            IEnumerable<Category> categoryList = new List<Category>();
            string sql = "select id as ID,categoryTypeId as TypeID,categoryName as Name,categoryDescription as Description,createDateTime,updateDateTime,status from rb_category";
            var data = dataAccess.GetData(sql);

            //categoryList = Helpers.HelperFunctions.ConvertDataTable<Category>(data);
            //return await Task.FromResult(categoryList.ToList());

             categoryList = data.AsEnumerable().Select(row => new Category()
             {
                 ID              = row["ID"].UInt32(),  
                 TypeID          = row["TypeID"].Int32(),
                 Name            = row["Name"].ToString(),
                 Description     = row["Description"].ToString(),
                 CreateDateTime  = row["createDateTime"].ToDateTime(),
                 UpdateDateTime  = row["updateDateTime"].ToDateTime(),
                 Status          = row["status"].Int32()
             });

             return categoryList;


            /*            categoryList = data.Select(item => item.asCategoryDto());

                        foreach (DataRow row in data.Rows)
                        {
                            categoryList.Add(new Category()
                            {
                                ID = row["id"].Int32(),
                                TypeID = row["categoryTypeId"].Int32(),
                                Name = row["categoryName"].ToString(),
                                Description = row["categoryDescription"].ToString(),
                                CreateDateTime = row["createDateTime"].ToDateTime(),
                                UpdateDateTime = row["updateDateTime"].ToDateTime(),
                                Status = row["status"].Int32()
                            });
                        }

                        return categoryList;*/

        }

        
    }
}
