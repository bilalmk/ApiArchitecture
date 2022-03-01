using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Del
{
    public interface IDataAccess
    {
        string connectionString { get; set; }
        Hashtable CurrentSqlParameters { get; set; }
        object GetSingle(string sqlQuery);
        bool ExecuteNonQuery(string sqlQuery);
        bool InsertNewRecord(string sqlQuery);
        
        string GetLastInsertedID();

        DataTable GetData(string sqlQuery);
        DataTable GetDataSP(string sqlQuery);
        DataTable SelectRecords(string sqlQuery);
        IDataReader ExecuteReader(string sqlQuery);


    }
}
