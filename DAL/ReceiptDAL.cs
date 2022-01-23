using Newtonsoft.Json;
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
    public class ReceiptDAL: IDisposable
    {
        Database dbInstance;
        public ReceiptDAL()
        {
            dbInstance = Database.getDbInstance();
        }        

        public string AddReceiptDetails(ReceiptVM receipt)
        {
            SqlConnection connection = dbInstance.GetDBConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            cmd = new SqlCommand("Insert_Receipt", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ReceiptData", JsonConvert.SerializeObject(receipt));
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds.Tables[0].Rows[0]["Id"].ToString();
        }

        public IEnumerable<BusinessPartnerContactDetails> GetContact(string phoneNumber)
        {
            SqlConnection connection = dbInstance.GetDBConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            cmd = new SqlCommand("Select_PhoneNumbers", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            DataTable contactTable = ds.Tables[0];
            return this.GetContactList(contactTable);
        }

        public IEnumerable<ReceiptVM> GetReceiptHistory(int bspId)
        {
            SqlConnection connection = dbInstance.GetDBConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            cmd = new SqlCommand("Select_ReceiptHistoryDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BusinessPartnerId", bspId);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return this.GetBSPHistoryList(ds);
        }

        public BusinessPartnerVM GetBusinessPartnerByBSPId(int bspId)
        {
            SqlConnection connection = dbInstance.GetDBConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            cmd = new SqlCommand("Select_BusinessPartnerByBSPId", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BusinessPartnerId", bspId);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            DataTable bspTable      = ds.Tables[0];
            DataTable contactTable  = ds.Tables[1];
            DataTable addressTable  = ds.Tables[2];
            return this.MapBapVM(bspTable, contactTable, addressTable);
        }

        public BusinessPartnerResponse ManageBusinessPartner(BusinessPartnerVM businessPartner)
        {
            SqlConnection connection = dbInstance.GetDBConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            cmd = new SqlCommand("Manage_BusinessPartner", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BusinessPartnerData", JsonConvert.SerializeObject(businessPartner));
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            DataTable contactTable = ds.Tables[0];
            return this.GetBusinessPartnerResponse(contactTable);
        }

        private List<BusinessPartnerContactDetails> GetContactList(DataTable contact)
        {

            var convertedContactList = (from rw in contact.AsEnumerable()
                                        select new BusinessPartnerContactDetails()
                                        {
                                            Id = Convert.ToInt32(rw["Id"]),
                                            BusinessPartnerId = Convert.ToInt32(rw["BusinessPartnerId"]),
                                            PhoneNumber = Convert.ToString(rw["PhoneNumber"]),                                       
                                            Email = Convert.ToString(rw["Email"])
                                        }).ToList();

            return convertedContactList;
        }

        private List<ReceiptVM> GetBSPHistoryList(DataSet bspDetails)
        {
            DataTable receiptHeader = bspDetails.Tables[0];
            DataTable productReceiptMap = bspDetails.Tables[1];
            DataTable productDetails = bspDetails.Tables[2];
            List<ReceiptVM> receiptHeaderList = new List<ReceiptVM>();
            if (receiptHeader != null && receiptHeader.Rows.Count > 0 &&
                productReceiptMap != null && productReceiptMap.Rows.Count > 0 &&
                productDetails != null && productDetails.Rows.Count > 0)
            {

                receiptHeaderList = (from rw in receiptHeader.AsEnumerable()
                                         select new ReceiptVM()
                                         {
                                             Id = Convert.ToInt32(rw["Id"]),
                                             TotalAmount = Convert.ToDecimal(rw["TotalAmount"]),
                                             GivenAmount = Convert.ToDecimal(rw["CustomerGivenAmount"]),
                                             SpecialDiscount = Convert.ToDecimal(rw["SpecialDiscount"]),
                                             Remark = Convert.ToString(rw["Remark"]),
                                             CreatedDateTime = Convert.ToDateTime(rw["CreatedDateTime"])
                                         }).ToList();

                var productReceiptMapList = (from rw in productReceiptMap.AsEnumerable()
                                             select new ProductReceiptMapVM()
                                             {
                                                 ProductId = Convert.ToInt32(rw["Id"]),
                                                 ReceiptId = Convert.ToInt32(rw["ReceiptId"]),
                                                 Quantity = Convert.ToInt32(rw["Quantity"]),
                                                 ItemPrice = Convert.ToDecimal(rw["Price"]),
                                                 ItemDiscountedPrice = Convert.ToDecimal(rw["Discount"]),
                                                 mpt_SizeEnum = Convert.ToInt32(rw["mpt_SizeEnum"]),
                                                 Size = Convert.ToString(rw["Size"])
                                             }).ToList();

                var productDetailsList = (from rw in productDetails.AsEnumerable()
                                          select new ProductVM()
                                          {
                                              Id = Convert.ToInt32(rw["Id"]),
                                              Name = Convert.ToString(rw["Name"]),
                                              Code = Convert.ToString(rw["Code"]),
                                              mpt_CategoryEnum = Convert.ToInt32(rw["mpt_CategoryEnum"]),
                                              CategoryName = Convert.ToString(rw["CategoryName"]),
                                              mpt_StatusEnum = Convert.ToInt32(rw["mpt_StatusEnum"]),
                                              mpt_SizeEnum = Convert.ToInt32(rw["mpt_SizeEnum"]),
                                              Status = Convert.ToString(rw["Status"])
                                          }).ToList();

                // Map Details
                for (int i = 0; i < productReceiptMapList.Count(); i++)
                {
                    int activeProductId = productReceiptMapList[i].ProductId;
                    int sizeEnum = productReceiptMapList[i].mpt_SizeEnum.Value;
                    productReceiptMapList[i].product = productDetailsList.Find(x => (x.Id == activeProductId && x.mpt_SizeEnum == sizeEnum));
                }

                for (int i = 0; i < receiptHeaderList.Count(); i++)
                {
                    int activeReceiptId = receiptHeaderList[i].Id;
                    receiptHeaderList[i].Products = productReceiptMapList.FindAll(x => x.ReceiptId == activeReceiptId);
                }
            }
            return receiptHeaderList;
        }

        private BusinessPartnerResponse GetBusinessPartnerResponse(DataTable bsp)
        {

            var bspResponse = (from rw in bsp.AsEnumerable()
                                        select new BusinessPartnerResponse()
                                        {
                                            BusinessPartnerId = Convert.ToInt32(rw["BusinessPartnerId"]),
                                            AddressId = Convert.ToInt32(rw["AddressId"]),
                                            ContactId = Convert.ToInt32(rw["ContactId"])
                                        }).FirstOrDefault();

            return bspResponse;
        }

        private BusinessPartnerVM MapBapVM(DataTable bsp, DataTable contact, DataTable address)
        {
            var bspList = (from rw in bsp.AsEnumerable()
                                        select new BusinessPartnerVM()
                                        {
                                            Id = Convert.ToInt32(rw["Id"]),
                                            Name = Convert.ToString(rw["Name"]),
                                            mpt_StatusEnum = Convert.ToInt32(rw["mpt_StatusEnum"]),
                                            contacts = (from row in contact.AsEnumerable()
                                                         where Convert.ToInt32(row["BusinessPartnerId"]) == Convert.ToInt32(rw["Id"])
                                                         select new BusinessPartnerContactDetails()
                                                         {
                                                             Id = Convert.ToInt32(row["Id"]),
                                                             BusinessPartnerId = Convert.ToInt32(rw["Id"]),
                                                             PhoneNumber = Convert.ToString(row["PhoneNumber"]),
                                                             Email = Convert.ToString(row["Email"])
                                                         }).ToList(),
                                            addresses = (from row in address.AsEnumerable()
                                                        where Convert.ToInt32(row["BusinessPartnerId"]) == Convert.ToInt32(rw["Id"])
                                                        select new BusinessPartnerAddressDetails()
                                                        {
                                                            Id = Convert.ToInt32(row["Id"]),
                                                            BusinessPartnerId = Convert.ToInt32(rw["Id"]),
                                                            Address = Convert.ToString(row["Address"])
                                                        }).ToList()
                                        }).ToList();
            return bspList.FirstOrDefault();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
