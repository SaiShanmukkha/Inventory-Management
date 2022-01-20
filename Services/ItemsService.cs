using CloudCart.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace CloudCart.Services
{
    public class ItemsService
    {
        public static string cs = @"Data Source=USHYDSSAISHAN2\SQLEXPRESS; database=CloudCart; Trusted_Connection=True; MultipleActiveResultSets=True;";

        public static List<Item> GetItems()
        {
            List<Item> itemList = new();
            SqlConnection con = new SqlConnection(cs);
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Get_Items";
            sc.CommandType = CommandType.StoredProcedure;
            sc.Connection = con;
            try
            {                
                Console.WriteLine($"ItemsService : Executing Getting Items from DB");
                SqlDataAdapter da = new SqlDataAdapter(sc);
                DataSet ds = new DataSet();
                da.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Item item = new Item();
                    item.ItemId = Convert.ToInt32(dr["ItemId"]);
                    item.ItemName = dr["ItemName"].ToString();
                    item.ItemQuantity = Convert.ToInt32(dr["ItemQuantity"]);
                    item.ItemPrice = Convert.ToDouble(dr["ItemPrice"]);
                    item.ItemCreationDate = Convert.ToDateTime(dr["ItemCreationDate"]);
                    item.ItemLastUpdate = Convert.ToDateTime(dr["ItemLastUpdate"]);
                    itemList.Add(item);
                }
                Console.WriteLine($"ItemsService : Done Executing Getting Items from DB");
            }
            catch (Exception e)
            {
                Console.WriteLine("ItemsService : Error Occurred While Getting Items from DB");
                Console.WriteLine(e.Message);
            }
            return itemList;
        }


        public static int UpdateItem(Item item)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Update_Item";
            sc.CommandType = CommandType.StoredProcedure;
            sc.Connection = con;
            sc.Parameters.AddWithValue("@ItemId", item.ItemId);
            sc.Parameters.AddWithValue("@ItemName", item.ItemName);
            sc.Parameters.AddWithValue("@ItemPrice", item.ItemPrice);
            sc.Parameters.AddWithValue("@ItemQuantity", item.ItemQuantity);
            sc.Parameters.AddWithValue("@ItemLastUpdate", item.ItemLastUpdate);
            sc.Parameters.AddWithValue("@ItemCreationDate", item.ItemCreationDate);            
            try
            {
                Console.WriteLine($"ItemsService : Executing Updating Items in DB");                
                con.Open();
                int rowsEffected = sc.ExecuteNonQuery();
                Console.WriteLine("Rows Effected : " + rowsEffected);
                if (rowsEffected == 1)
                {
                    return 1;
                }
                Console.WriteLine($"ItemsService : Done Executing Updating Items in DB");     
            }
            catch (Exception e)
            {
                Console.WriteLine("ItemsService : Error Occurred While Updating Item to DB");
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return -1;
        }

        public static int Deleteitem(int? itemId)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Delete_Item";
            sc.CommandType = CommandType.StoredProcedure;
            sc.Connection = con;
            sc.Parameters.AddWithValue("@ItemId", itemId);

            
            try
            {
                Console.WriteLine($"ItemsService : Executing Delete Item with id = {itemId} from DB");
                con.Open();
                int rowsEffected = sc.ExecuteNonQuery();
                Console.WriteLine("Rows Effected : " + rowsEffected);
                if (rowsEffected == 1)
                {
                    return 1;
                }
                Console.WriteLine($"ItemsService : Done Executing Delete Item with id = {itemId} from DB");
            }
            catch (Exception e)
            {
                Console.WriteLine("ItemsService : Error Occurred While Deleting Item with id = {itemId} from DB");
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return -1;
        }

        public static int InsertItem(Item item)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Add_Item";
            sc.CommandType = CommandType.StoredProcedure;
            sc.Connection = con;

            sc.Parameters.AddWithValue("@ItemName", item.ItemName);
            sc.Parameters.AddWithValue("@ItemPrice", item.ItemPrice);
            sc.Parameters.AddWithValue("@ItemQuantity", item.ItemQuantity);
            sc.Parameters.AddWithValue("@ItemLastUpdate", item.ItemLastUpdate);
            sc.Parameters.AddWithValue("@ItemCreationDate", item.ItemCreationDate);
            try
            {                
                Console.WriteLine("ItemsService : Executing insert Item to DB");
                con.Open();
                int rowsEffected = sc.ExecuteNonQuery();
                Console.WriteLine("Rows Effected : " + rowsEffected);
                if (rowsEffected == 1)
                {
                    return 1;
                }
                Console.WriteLine("ItemsService : Done Executing insert Item to DB");
            }
            catch (Exception e)
            {
                Console.WriteLine("ItemsService : Error Occurred While inserting Item to DB");
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return -1;
        }


        public static Item Get_Item_By_Id(int? itemId)
        {
            Item item = new Item();
            item.ItemId = -1;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Get_Item_By_Id";
            sc.CommandType = CommandType.StoredProcedure;
            sc.Connection = con;
            sc.Parameters.AddWithValue("@ItemId", itemId);
            try
            {                
                Console.WriteLine($"ItemsService : Executing get Item with id = {itemId} from DB");
                SqlDataAdapter da = new SqlDataAdapter(sc);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataRow dr = ds.Tables[0].Rows[0];
                if (dr != null)
                {
                    item.ItemId = Convert.ToInt32(dr["ItemId"]);
                    item.ItemName = dr["ItemName"].ToString();
                    item.ItemQuantity = Convert.ToInt32(dr["ItemQuantity"]);
                    item.ItemPrice = Convert.ToDouble(dr["ItemPrice"]);
                    item.ItemCreationDate = Convert.ToDateTime(dr["ItemCreationDate"]);
                    item.ItemLastUpdate = Convert.ToDateTime(dr["ItemLastUpdate"]);
                }
                Console.WriteLine($"ItemsService : Done Executing get Item with id = {itemId} from DB");
            }
            catch (Exception e)
            {
                Console.WriteLine($"ItemService: Error occurred while fetching data with id = {itemId} from DB");
                Console.WriteLine(e.Message);
            }
            return item;
        }

    }
}
