using PizzaBox_Receipt_Management.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox_Receipt_Management.DML
{
    public class PromotionalMessageDAL : IDisposable
    {
        Database dbInstance;
        public PromotionalMessageDAL()
        {
            dbInstance = Database.getDbInstance();
        }

        public List<Contact> GetContacts()
        {
            SqlConnection connection = dbInstance.GetDBConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            cmd = new SqlCommand("Select_PromotionalContact", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@parm1", id);//if you have parameters.
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return GetBSPContact(ds.Tables[0]);
        }

        public void UpdateContacts(Contact contact)
        {
            SqlConnection connection = dbInstance.GetDBConnection();
            SqlCommand cmd = new SqlCommand("UPDATE_PromotionalContact", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IsMessageEnable", contact.IsPromotionalMessageEnable);
            cmd.Parameters.AddWithValue("@Id", contact.ID);
            cmd.ExecuteNonQuery();
        }

        private List<Contact> GetBSPContact(DataTable dt)
        {

            var convertedList = (from rw in dt.AsEnumerable()
                                 select new Contact()
                                 {
                                     BusinessPartnerId = Convert.ToInt32(rw["BusinessPartnerId"]),
                                     PhoneNumber = Convert.ToString(rw["PhoneNumber"]),
                                     Email = Convert.ToString(rw["Email"]),
                                     ID = Convert.ToInt32(rw["ID"]),
                                     IsPromotionalMessageEnable = Convert.ToBoolean(rw["IsPromotionalMessageEnable"]),
                                     Name = Convert.ToString(rw["Name"])
                                 }).ToList();

            return convertedList;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
