using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CloudCart.Models;
using Newtonsoft.Json;

namespace CloudCart.Services
{
    public class PurchaseService
    {
        public static string cs = @"Data Source=USHYDSSAISHAN2\SQLEXPRESS; database=CloudCart; Trusted_Connection=True; MultipleActiveResultSets=True;";

        
        public static List<PurchaseOrder> GetRecentOrders()
        {
            List<PurchaseOrder> ordersList = new();
            SqlConnection con = new SqlConnection(cs);
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Get_Recent_Purchase_Orders";
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
                    PurchaseOrder po = new PurchaseOrder(){
                        PurchaseCourierCharge = Convert.ToDouble(dr["PurchaseCourierCharge"]),
                        PurchaseInvoiceNumber = dr["PurchaseInvoiceNumber"].ToString(),
                        PurchaseOrderID = Convert.ToInt32(dr["PurchaseOrderID"]),
                        PurchaseTotalPrice = Convert.ToDouble(dr["PurchaseTotalPrice"]),
                        PurchaseDate = Convert.ToDateTime(dr["PurchaseDate"]),
                        PurchaseTransactionID = dr["PurchaseTransactionID"].ToString()
                    };
                    ordersList.Add(po);
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


    public static int Add_Purchased_Order(PurchaseOrder purchaseOrder){
            SqlConnection con = new SqlConnection(cs);
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Add_Purchase_Order";
            sc.CommandType = CommandType.StoredProcedure;
            sc.Connection = con;

            sc.Parameters.AddWithValue("@PurchaseInvoiceNumber", purchaseOrder.PurchaseInvoiceNumber);
            sc.Parameters.AddWithValue("@PurchaseTransactionID", purchaseOrder.PurchaseTransactionID);
            sc.Parameters.AddWithValue("@PurchaseCourierCharge", purchaseOrder.PurchaseCourierCharge);
            sc.Parameters.AddWithValue("@PurchaseTotalPrice", purchaseOrder.PurchaseTotalPrice);
            sc.Parameters.AddWithValue("@PurchaseDate", purchaseOrder.PurchaseDate);
            try
            {                
                Console.WriteLine("PurchaseService : Executing insert Order to DB");
                con.Open();
                int rowsEffected = sc.ExecuteNonQuery();
                Console.WriteLine("Rows Effected : " + rowsEffected);
                if (rowsEffected == 1)
                {
                    return 1;
                }
                Console.WriteLine("PurchaseService : Done Executing insert Order to DB");
            }
            catch (Exception e)
            {
                Console.WriteLine("PurchaseService : Error Occurred While inserting Order to DB");
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return -1;
        }


    public static int Add_Purchased_Item(PurchasedItem purchasedItem){
            SqlConnection con = new SqlConnection(cs);
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Add_Purchased_Items";
            sc.CommandType = CommandType.StoredProcedure;
            sc.Connection = con;

            sc.Parameters.AddWithValue("@PurchaseInvoiceNumber", purchasedItem.PurchaseInvoiceNumber);
            sc.Parameters.AddWithValue("@ItemName", purchasedItem.ItemName);
            sc.Parameters.AddWithValue("@Itemprice", purchasedItem.ItemPrice);
            sc.Parameters.AddWithValue("@ItemQuantity", purchasedItem.ItemQuantity);
            sc.Parameters.AddWithValue("@ItemSupplierId", purchasedItem.ItemSupplierId);
            sc.Parameters.AddWithValue("@PurchaseOrderID", purchasedItem.PurchaseOrderID);
            try
            {                
                Console.WriteLine("PurchaseService : Executing insert purchased Items to DB");
                con.Open();
                int rowsEffected = sc.ExecuteNonQuery();
                Console.WriteLine("Rows Effected : " + rowsEffected);
                if (rowsEffected == 1)
                {
                    return 1;
                }
                Console.WriteLine("PurchaseService : Done Executing insert purchased Items to DB");
            }
            catch (Exception e)
            {
                Console.WriteLine("PurchaseService : Error Occurred While inserting purchased Items to DB");
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return -1;
        }



    public static int Process_Purchase_Order(PurchaseOrder purchaseOrder){

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
                    sc1.CommandText = "Add_Purchase_Order";
                    sc1.CommandType = CommandType.StoredProcedure;
                    sc1.Connection = connection;

                    sc1.Parameters.AddWithValue("@PurchaseInvoiceNumber", purchaseOrder.PurchaseInvoiceNumber);
                    sc1.Parameters.AddWithValue("@PurchaseTransactionID", purchaseOrder.PurchaseTransactionID);
                    sc1.Parameters.AddWithValue("@PurchaseCourierCharge", purchaseOrder.PurchaseCourierCharge);
                    sc1.Parameters.AddWithValue("@PurchaseTotalPrice", purchaseOrder.PurchaseTotalPrice);
                    sc1.Parameters.AddWithValue("@PurchaseDate", purchaseOrder.PurchaseDate);

                    SqlParameter PurchaseOrderID = new SqlParameter();
                    PurchaseOrderID.ParameterName = "@PurchaseOrderID";
                    PurchaseOrderID.DbType = System.Data.DbType.Int16;
                    PurchaseOrderID.Direction = System.Data.ParameterDirection.Output;
                    sc1.Parameters.Add(PurchaseOrderID);

                    
                    int rows_effected = sc1.ExecuteNonQuery();
                    int PurchaseOrderIDValue = Convert.ToInt32(PurchaseOrderID.Value);


                    // For PurchasedItems Table
                    sc2.CommandText = "Add_Multiple_Purchased_Items";
                    sc2.CommandType = CommandType.StoredProcedure;
                    sc2.Connection = connection;

                    dynamic items = JsonConvert.DeserializeObject(purchaseOrder.PurchaseItems);

                    DataTable dt = new DataTable();
                    dt.Columns.Add(new DataColumn("PurchaseInvoiceNumber", typeof(string)));  
                    dt.Columns.Add(new DataColumn("ItemName", typeof(string)));  
                    dt.Columns.Add(new DataColumn("Itemprice", typeof(double)));  
                    dt.Columns.Add(new DataColumn("ItemQuantity", typeof(int)));  
                    dt.Columns.Add(new DataColumn("ItemSupplierId", typeof(int))); 
                    dt.Columns.Add(new DataColumn("PurchaseOrderID", typeof(int)));                                    
                    foreach(var item in items){
                        dt.Rows.Add(purchaseOrder.PurchaseInvoiceNumber, item.ItemName, item.ItemPrice, item.ItemQuantity, item.ItemSupplierId, PurchaseOrderIDValue); 
                    }
                    sc2.Parameters.AddWithValue("@tableproducts", dt);                    
                    int rowsEffected = sc2.ExecuteNonQuery();


                    if(rowsEffected == items.Count)
                    {
                        
                        Console.WriteLine("All records were written to database.");
                        

                        
                        
                        foreach(var item in items){
                            // dt.Rows.Add(purchaseOrder.PurchaseInvoiceNumber, item.ItemName, item.ItemPrice, item.ItemQuantity, item.ItemSupplierId, PurchaseOrderIDValue); 
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
                            int updatedQuantity = oldQuantity + Convert.ToInt32(item.ItemQuantity);
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






                        return PurchaseOrderIDValue;
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
