using CloudCart.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CloudCart.Services
{
    public class SellService
    {
        public static string cs = @"Data Source=USHYDSSAISHAN2\SQLEXPRESS; database=CloudCart; Trusted_Connection=True; MultipleActiveResultSets=True;";

        public static List<SellOrder> GetRecentOrders()
        {
            List<SellOrder> ordersList = new();
            SqlConnection con = new SqlConnection(cs);
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Get_Recent_Sell_Orders";
            sc.CommandType = CommandType.StoredProcedure;
            sc.Connection = con;
            try
            {                
                Console.WriteLine($"PurchaseService : Executing Getting Recent Orders from DB");
                SqlDataAdapter da = new SqlDataAdapter(sc);
                DataSet ds = new DataSet();
                da.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Console.WriteLine(ds.Tables[0].Rows.Count);
                    SellOrder so = new SellOrder(){
                        SellOrderID = Convert.ToInt32(dr["SellOrderID"]),
                        CustomerName = dr["CustomerName"].ToString(),
                        CustomerEmail = dr["CustomerEmail"].ToString(),
                        CustomerPhone = Convert.ToInt64(dr["CustomerPhone"]),
                        SellCourierCharge = Convert.ToDouble(dr["SellCourierCharge"]),
                        SellInvoiceNumber = dr["SellInvoiceNumber"].ToString(),
                        SellDate = Convert.ToDateTime(dr["SellDate"]),
                        SellTotalPrice = Convert.ToDouble(dr["SellTotalPrice"]),
                        SellTransactionID = dr["SellTransactionID"].ToString()
                    };
                    ordersList.Add(so);
                }
                Console.WriteLine($"PurchaseService : Done Executing Getting Recent Orders from DB");
            }
            catch (Exception e)
            {
                Console.WriteLine("PurchaseService : Error Occurred While Getting Recent Orders from DB");
                Console.WriteLine(e.Message);
            }
            return ordersList;
        }

        public static int Process_Sell_Order(SellOrder sellOrder)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlTransaction sqlTran = connection.BeginTransaction();

                // For PurchaseOrder Table
                SqlCommand sc1 = connection.CreateCommand();
                sc1.Transaction = sqlTran;
                // For PurchasedItems Table
                SqlCommand sc2 = connection.CreateCommand();
                sc2.Transaction = sqlTran;
               
                try
                {
                    // For PurchaseOrder Table
                    sc1.CommandText = "Add_Sell_Order";
                    sc1.CommandType = CommandType.StoredProcedure;
                    sc1.Connection = connection;

                    sc1.Parameters.AddWithValue("@SellInvoiceNumber", sellOrder.SellInvoiceNumber);
                    sc1.Parameters.AddWithValue("@SellTransactionID", sellOrder.SellTransactionID);
                    sc1.Parameters.AddWithValue("@CustomerName", sellOrder.CustomerName);
                    sc1.Parameters.AddWithValue("@CustomerPhone", sellOrder.CustomerPhone);
                    sc1.Parameters.AddWithValue("@CustomerEmail", sellOrder.CustomerEmail);
                    sc1.Parameters.AddWithValue("@SellCourierCharge", sellOrder.SellCourierCharge);
                    sc1.Parameters.AddWithValue("@SellTotalPrice", sellOrder.SellTotalPrice);
                    sc1.Parameters.AddWithValue("@SellDate", sellOrder.SellDate);

                    SqlParameter SellOrderID = new SqlParameter();
                    SellOrderID.ParameterName = "@SellOrderID";
                    SellOrderID.DbType = System.Data.DbType.Int16;
                    SellOrderID.Direction = System.Data.ParameterDirection.Output;
                    sc1.Parameters.Add(SellOrderID);

                    
                    int rows_effected = sc1.ExecuteNonQuery();
                    int SellOrderIDValue = Convert.ToInt32(SellOrderID.Value);


                    // For PurchasedItems Table
                    sc2.CommandText = "Add_Multiple_Sold_Items";
                    sc2.CommandType = CommandType.StoredProcedure;
                    sc2.Connection = connection;

                    dynamic items = JsonConvert.DeserializeObject(sellOrder.SellItems);

                    DataTable dt = new DataTable();
                    dt.Columns.Add(new DataColumn("SellInvoiceNumber", typeof(string)));  
                    dt.Columns.Add(new DataColumn("ItemName", typeof(string)));  
                    dt.Columns.Add(new DataColumn("ItemPrice", typeof(double)));  
                    dt.Columns.Add(new DataColumn("ItemQuantity", typeof(int)));  
                    dt.Columns.Add(new DataColumn("SellOrderID", typeof(int)));                                    
                    foreach(var item in items){
                        dt.Rows.Add(sellOrder.SellInvoiceNumber, item.ItemName, item.ItemPrice, item.ItemQuantity, SellOrderIDValue); 
                    }
                    sc2.Parameters.AddWithValue("@tableproducts", dt);                    
                    int rowsEffected = sc2.ExecuteNonQuery();


                    if(rowsEffected == items.Count)
                    {
                        
                        Console.WriteLine("All records were written to database.");
                        

                        
                        
                        foreach(var item in items){
                           Console.WriteLine(item);
                            // Updating Quantity
                            SqlCommand sc3 = connection.CreateCommand();
                            sc3.Transaction = sqlTran;
                            // For Updating Quantities
                            sc3.CommandText = "Update_Item_Quantity";
                            sc3.CommandType = CommandType.StoredProcedure;
                            sc3.Connection = connection;
                            // For Getting Old Quantity
                            SqlCommand sc4 = connection.CreateCommand();
                            sc4.Connection = connection;
                            sc4.Transaction = sqlTran;
                            sc4.CommandText = "select ItemQuantity from Items where ItemId = "+item.ItemId;                            
                            int oldQuantity = (Int32)sc4.ExecuteScalar();
                            sc4.Dispose();
                            int updatedQuantity = oldQuantity - Convert.ToInt32(item.ItemQuantity);
                            // For Updating Quantity
                            sc3.Parameters.AddWithValue("@ItemId", Convert.ToInt32(item.ItemId));
                            sc3.Parameters.AddWithValue("@ItemQuantity", updatedQuantity);
                            sc3.Parameters.AddWithValue("@ItemLastUpdate", DateTime.Now);

                            int rowsUpdate = sc3.ExecuteNonQuery();
                            sc3.Dispose();
                            if(rowsUpdate != 1){
                                throw new Exception("Error Occured while Updating Quantities of item with id = "+item.ItemId);
                            }

                            
                        }

                        sqlTran.Commit();






                        return SellOrderIDValue;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                    
                    try
                    {
                        sqlTran.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        Console.WriteLine(exRollback.Message);
                    }
                }
            }
        return -1;
    }
    }
}
