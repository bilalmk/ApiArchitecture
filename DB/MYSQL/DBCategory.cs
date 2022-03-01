using APIArchitecture.Extension;
using APIArchitecture.Entities;
using Del;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

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
            List<Category> categoryList = new List<Category>();
            string sql = "select id,categoryTypeId,categoryName,categoryDescription,createDateTime,updateDateTime,status from rb_category";
            var data = dataAccess.GetData(sql);
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

            return categoryList;

        }
    }
}
