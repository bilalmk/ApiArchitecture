using APIArchitecture.Extension;
using APIArchitecture.Entities;
using Del;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace APIArchitecture.DB.MYSQL
{
    public class DBCategory : IDBCategory
    {
        public IDataAccess dataAccess;
        public DBCategory(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        public IEnumerable<Category> GetAll()
        {
            IEnumerable<Category> categoryList = new List<Category>();
            string sql = "select id ID,categoryTypeId as TypeID,categoryName as Name,categoryDescription as Description,createDateTime,updateDateTime,status from rb_category";
            var data = dataAccess.GetData(sql);

            categoryList = ConvertDataTable<Category>(data);
            return categoryList;

            /* categoryList = data.AsEnumerable().Select(row => new Category()
             {
                 ID              = row["id"].Int32(),
                 TypeID          = row["categoryTypeId"].Int32(),
                 Name            = row["categoryName"].ToString(),
                 Description     = row["categoryDescription"].ToString(),
                 CreateDateTime  = row["createDateTime"].ToDateTime(),
                 UpdateDateTime  = row["updateDateTime"].ToDateTime(),
                 Status          = row["status"].Int32()
             });

             return categoryList;*/


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

        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name.ToUpper() == column.ColumnName.ToUpper())
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}
