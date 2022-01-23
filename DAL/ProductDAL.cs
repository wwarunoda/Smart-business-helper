using PizzaBox_Receipt_Management.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PizzaBox_Receipt_Management.Models;

namespace PizzaBox_Receipt_Management.DML
{
    public class ProductDAL : IDisposable
    {
        Database dbInstance;
        public ProductDAL()
        {
            dbInstance = Database.getDbInstance();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public int ManageProduct(ProductVM product)
        {
            SqlConnection connection = dbInstance.GetDBConnection();
            SqlCommand cmd = new SqlCommand("Manage_ProductData", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductData", JsonConvert.SerializeObject(product));
            SqlParameter RuturnValue = new SqlParameter("@Id", SqlDbType.Int);
            RuturnValue.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(RuturnValue);
            cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Id"].Value;
        }

        public int ManageProductPriceMap(ProductPriceVM priceInformations)
        {
            SqlConnection connection = dbInstance.GetDBConnection();
            SqlCommand cmd = new SqlCommand("Manage_ProductPriceMappingData", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductPriceMappingData", JsonConvert.SerializeObject(priceInformations));
            SqlParameter RuturnValue = new SqlParameter("@Id", SqlDbType.Int);
            RuturnValue.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(RuturnValue);
            cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Id"].Value;
        }

        public List<ProductVM> GetProducts()
        {
            SqlConnection connection = dbInstance.GetDBConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            cmd = new SqlCommand("Select_Products", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@parm1", id);//if you have parameters.
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            DataTable productTable = ds.Tables[0];
            DataTable price = ds.Tables[1];
            return this.GetProductList(productTable, price);
        }

        public void DeleteProductPriceMapping(int productPriceMappingId)
        {
            SqlConnection connection = dbInstance.GetDBConnection();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("Delete_ProductPriceMapping", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductPriceMappingId", productPriceMappingId);//if you have parameters.
            cmd.ExecuteNonQuery();
        }

        private List<ProductVM> GetProductList(DataTable product, DataTable price)
        {

            var convertedProductList = (from rw in product.AsEnumerable()
                                        select new ProductVM()
                                        {
                                            Id = Convert.ToInt32(rw["Id"]),
                                            Name = Convert.ToString(rw["Name"]),
                                            Code = Convert.ToString(rw["Code"]),
                                            mpt_CategoryEnum = Convert.ToInt32(rw["mpt_CategoryEnum"]),
                                            CategoryName = Convert.ToString(rw["CategoryName"]),
                                            mpt_StatusEnum = Convert.ToInt32(rw["mpt_StatusEnum"]),
                                            Status = Convert.ToString(rw["Status"]),
                                            PriceList = (from row in price.AsEnumerable()
                                                         where Convert.ToInt32(row["ProductId"]) == Convert.ToInt32(rw["Id"])
                                                         select new ProductPriceVM()
                                                         {
                                                             Id = Convert.ToInt32(row["Id"]),
                                                             ProductId = Convert.ToInt32(rw["Id"]),
                                                             mpt_SizeEnum = Convert.ToInt32(row["mpt_SizeEnum"]),
                                                             SizeName = Convert.ToString(row["SizeName"]),
                                                             Discount = Convert.ToDecimal((row["Discount"])),
                                                             Price = Convert.ToDecimal((row["Price"]))
                                                         }).ToList()
                                        }).ToList();

            return convertedProductList;
        }

        public List<DialyReportVM> ViewDialyReport(DateTime fromDate, DateTime toDate)
        {
            SqlConnection connection = dbInstance.GetDBConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            cmd = new SqlCommand("Select_DailyBillReport", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StartDate", fromDate);
            cmd.Parameters.AddWithValue("@EndDate", toDate);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            DataTable contactTable = ds.Tables[0];
            return this.GetDialyBillList(contactTable);
        }

        private List<DialyReportVM> GetDialyBillList(DataTable contact)
        {

            var convertedBillList = (from rw in contact.AsEnumerable()
                                     select new DialyReportVM()
                                     {
                                         Name = Convert.ToString(rw["Name"]),
                                         PhoneNumber = Convert.ToString(rw["PhoneNumber"]),
                                         Address = Convert.ToString(rw["Address"]),
                                         TotalAmount = Convert.ToDecimal(rw["TotalAmount"]),
                                         SpecialDiscount = Convert.ToDecimal(rw["SpecialDiscount"]),
                                         CustomerGivenAmount = Convert.ToDecimal(rw["CustomerGivenAmount"]),
                                         Remark = Convert.ToString(rw["Remark"]),
                                         CreatedDateTime = Convert.ToDateTime(rw["CreatedDateTime"])
                                     }).ToList();

            return convertedBillList;
        }

        public ReceiptAdvanceDetailsResponse GetReceiptAdvancedDetails(ReceiptAdvanceDetailsRequest request)
        {
            SqlConnection connection = dbInstance.GetDBConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            cmd = new SqlCommand("Select_ReceiptAdvanceDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DateFrom", request.ReceiptDetails.FromDate);
            cmd.Parameters.AddWithValue("@DateTo", request.ReceiptDetails.ToDate);
            cmd.Parameters.AddWithValue("@TP", request.ReceiptDetails.CustomerTP);
            cmd.Parameters.AddWithValue("@Name", request.ReceiptDetails.CustomerName);
            cmd.Parameters.AddWithValue("@ReceiptNo", request.ReceiptDetails.ReceiptNumber);
            cmd.Parameters.AddWithValue("@Email", request.ReceiptDetails.CustomerEmail);
            cmd.Parameters.AddWithValue("@Address", request.ReceiptDetails.CustomerAddress);
            cmd.Parameters.AddWithValue("@ProductName", request.ReceiptDetails.Products);
            cmd.Parameters.AddWithValue("@ProductCode", request.ReceiptDetails.ProductCodes);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            DataTable contactTable = ds.Tables[0];
            return this.GetReceiptAdvancedDetailList(contactTable);
        }

        private ReceiptAdvanceDetailsResponse GetReceiptAdvancedDetailList(DataTable contact)
        {
            ReceiptAdvanceDetailsResponse receiptAdvanceDetailsResponse = new ReceiptAdvanceDetailsResponse();
            var convertedBillList = (from rw in contact.AsEnumerable()
                                     select new ReceiptAdvancedDetailsVM()
                                     {
                                         ReceiptNumber = Convert.ToString(rw["ReceiptNumber"]),
                                         BillAmount = Convert.ToDecimal(rw["BillAmount"]),
                                         CustomerGivenAmount = Convert.ToDecimal(rw["CustomerGivenAmount"]),
                                         SpecialDiscount = Convert.ToDecimal(rw["SpecialDiscount"]),
                                         ProductCodes = Convert.ToString(rw["ProductCodes"]),
                                         Products = Convert.ToString(rw["Products"]),
                                         ProductsUnitPrices = Convert.ToString(rw["ProductsUnitPrices"]),
                                         ProductsUnitDiscounts = Convert.ToString(rw["ProductsUnitDiscounts"]),
                                         CustomerName = Convert.ToString(rw["CustomerName"]),
                                         CustomerAddress = Convert.ToString(rw["CustomerAddress"]),
                                         CustomerTP = Convert.ToString(rw["CustomerTP"]),
                                         ReceiptDate = Convert.ToDateTime(rw["ReceiptDate"])
                                     }).ToList();

            receiptAdvanceDetailsResponse.ReceiptDetailsList = convertedBillList;
            return receiptAdvanceDetailsResponse;
        }
    }
    }
