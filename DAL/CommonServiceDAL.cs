using PizzaBox_Receipt_Management.Models;
using PizzaBox_Receipt_Management.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox_Receipt_Management.DML
{
    public class CommonServiceDAL : IDisposable
    {
        Database dbInstance;
        public CommonServiceDAL()
        {
            dbInstance = Database.getDbInstance();
        }

        public CommonDataResponse GetMasterData()
        {
            SqlConnection connection = dbInstance.GetDBConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            cmd = new SqlCommand("Select_MasterData", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@parm1", id);//if you have parameters.
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            DataTable sizesTable = ds.Tables[0];
            DataTable categoryTable = ds.Tables[1];
            DataTable statusTable = ds.Tables[2];
            DataTable protionsTable = ds.Tables[3];
            return new CommonDataResponse()
            {
                Sizes = this.GetMasterDataList(sizesTable),
                Categories = this.GetMasterDataList(categoryTable),
                Status = this.GetMasterDataList(statusTable),
                Portions = this.GetMasterDataList(protionsTable)
            };
        }

        private List<MultiPurposeTagVM> GetMasterDataList(DataTable dt)
        {

            var convertedList = (from rw in dt.AsEnumerable()
                                 select new MultiPurposeTagVM()
                                 {
                                     Id = Convert.ToInt32(rw["Id"]),
                                     Name = Convert.ToString(rw["Name"]),
                                     Data = Convert.ToInt32(rw["Data"]),
                                     TypeEnum = Convert.ToInt32(rw["TypeEnum"]),
                                     Description = Convert.ToString(rw["Description"])
                                 }).ToList();

            return convertedList;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
