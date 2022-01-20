using CloudCart.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CloudCart.Services
{
    public class SuppliersService
    {
        public static string cs = @"Data Source=USHYDSSAISHAN2\SQLEXPRESS; database=CloudCart; Trusted_Connection=True; MultipleActiveResultSets=True;";

        public static List<Supplier> Get_Suppliers()
        {
            List<Supplier> SupplierssList = new();

            SqlConnection con = new SqlConnection(cs);
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Get_Suppliers";
            sc.CommandType = CommandType.StoredProcedure;
            sc.Connection = con;
            try
            {
                Console.WriteLine($"SuppliersService : Executing Getting Suppliers from DB");
                SqlDataAdapter da = new SqlDataAdapter(sc);
                DataSet ds = new DataSet();
                da.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Supplier Supplier = new();
                    Supplier.SupplierId = Convert.ToInt32(dr["SupplierId"]);
                    Supplier.SupplierName = dr["SupplierName"].ToString();
                    Supplier.SupplierIndustry = dr["SupplierIndustry"].ToString();
                    Supplier.SupplierPhone = Convert.ToInt64(dr["SupplierPhone"]);
                    Supplier.SupplierEmail = dr["SupplierEmail"].ToString();
                    Supplier.SupplierAddress = dr["SupplierAddress"].ToString();
                    Supplier.SupplierCity = dr["SupplierCity"].ToString();
                    Supplier.SupplierProvince = dr["SupplierProvince"].ToString();
                    Supplier.SupplierCountry = dr["SupplierCountry"].ToString();
                    Supplier.SupplierPinCode = Convert.ToInt32(dr["SupplierPinCode"]);
                    Supplier.SupplierRating = Convert.ToDouble(dr["SupplierRating"]);
                    Supplier.SupplierJoinDate = Convert.ToDateTime(dr["SupplierJoinDate"]);
                    Supplier.SupplierDataLastUpdate = Convert.ToDateTime(dr["SupplierDataLastUpdate"]);
                    SupplierssList.Add(Supplier);
                }
                Console.WriteLine($"SuppliersService : Done Executing Getting Suppliers from DB");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occurred while feteching Suppliers");
                Console.WriteLine(e.Message);
            }
            return SupplierssList;
        }

        public static Supplier Get_Supplier_By_Id(int? SupplierId)
        {
            Supplier Supplier = new();
            Supplier.SupplierId = -1;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Get_Supplier_By_id";
            sc.CommandType = CommandType.StoredProcedure;
            sc.Connection = con;
            sc.Parameters.AddWithValue("@SupplierId", SupplierId);
            try
            {                
                Console.WriteLine($"SuppliersService : Executing Getting Supplier with id = {SupplierId} from DB");
                SqlDataAdapter da = new SqlDataAdapter(sc);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataRow dr = ds.Tables[0].Rows[0];
                if(dr != null){
                    Supplier.SupplierId = Convert.ToInt32(dr["SupplierId"]);
                    Supplier.SupplierName = dr["SupplierName"].ToString();
                    Supplier.SupplierIndustry = dr["SupplierIndustry"].ToString();
                    Supplier.SupplierPhone = Convert.ToInt64(dr["SupplierPhone"]);
                    Supplier.SupplierEmail = dr["SupplierEmail"].ToString();
                    Supplier.SupplierAddress = dr["SupplierAddress"].ToString();
                    Supplier.SupplierCity = dr["SupplierCity"].ToString();
                    Supplier.SupplierProvince = dr["SupplierProvince"].ToString();
                    Supplier.SupplierCountry = dr["SupplierCountry"].ToString();
                    Supplier.SupplierPinCode = Convert.ToInt32(dr["SupplierPinCode"]);
                    Supplier.SupplierRating = Convert.ToDouble(dr["SupplierRating"]);
                    Supplier.SupplierJoinDate = Convert.ToDateTime(dr["SupplierJoinDate"]);
                    Supplier.SupplierDataLastUpdate = Convert.ToDateTime(dr["SupplierDataLastUpdate"]);
                }               
                Console.WriteLine($"SuppliersService : Done Executing Getting Supplier with id = {SupplierId} from DB"); 
            }
            catch (Exception e)
            {
                Console.WriteLine($"SuppliersService: Error Occured While feteching Supplier with {SupplierId} from DB");
                Console.WriteLine(e.Message);
            }finally{
                con.Close();
                con.Dispose();
            }
            return Supplier;
        }


        public static int Insert_Supplier(Supplier Supplier){
            SqlConnection con = new SqlConnection(cs);
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Add_Supplier";
            sc.CommandType = CommandType.StoredProcedure;
            sc.Connection = con;
            sc.Parameters.AddWithValue("@SupplierName", Supplier.SupplierName);            
            sc.Parameters.AddWithValue("@SupplierIndustry", Supplier.SupplierIndustry);
            sc.Parameters.AddWithValue("@SupplierEmail", Supplier.SupplierEmail);
            sc.Parameters.AddWithValue("@SupplierPhone", Supplier.SupplierPhone);
            sc.Parameters.AddWithValue("@SupplierRating", Supplier.SupplierRating);
            sc.Parameters.AddWithValue("@SupplierAddress", Supplier.SupplierAddress);
            sc.Parameters.AddWithValue("@SupplierCity", Supplier.SupplierCity);
            sc.Parameters.AddWithValue("@SupplierProvince", Supplier.SupplierProvince);
            sc.Parameters.AddWithValue("@SupplierCountry", Supplier.SupplierCountry);
            sc.Parameters.AddWithValue("@SupplierPinCode", Supplier.SupplierPinCode);
            sc.Parameters.AddWithValue("@SupplierDataLastUpdate", Supplier.SupplierDataLastUpdate);
            sc.Parameters.AddWithValue("@SupplierJoinDate", Supplier.SupplierJoinDate);
            try{
                con.Open();
                int rowsEffected = sc.ExecuteNonQuery();
                Console.WriteLine("SuppliersService : Executing Insert Supplier to DB");
                Console.WriteLine("Rows Effected : " + rowsEffected);
                if (rowsEffected == 1)
                {
                    return 1;
                }
                 Console.WriteLine("SuppliersService : Done Executing Insert Supplier to DB");
            }catch(Exception e){
                Console.WriteLine("SuppliersService : Error Occurred While inserting Supplier to DB");
                Console.WriteLine(e.Message);
            }finally{
                con.Close();
                con.Dispose();
            }
            return -1;
        }

    public static int Update_Supplier(Supplier Supplier){
            SqlConnection con = new SqlConnection(cs);
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Update_Supplier";
            sc.CommandType = CommandType.StoredProcedure;
            sc.Connection = con;
            sc.Parameters.AddWithValue("@SupplierId", Supplier.SupplierId);            
            sc.Parameters.AddWithValue("@SupplierName", Supplier.SupplierName);            
            sc.Parameters.AddWithValue("@SupplierIndustry", Supplier.SupplierIndustry);
            sc.Parameters.AddWithValue("@SupplierEmail", Supplier.SupplierEmail);
            sc.Parameters.AddWithValue("@SupplierPhone", Supplier.SupplierPhone);
            sc.Parameters.AddWithValue("@SupplierAddress", Supplier.SupplierAddress);
            sc.Parameters.AddWithValue("@SupplierRating", Supplier.SupplierRating);
            sc.Parameters.AddWithValue("@SupplierCity", Supplier.SupplierCity);
            sc.Parameters.AddWithValue("@SupplierProvince", Supplier.SupplierProvince);
            sc.Parameters.AddWithValue("@SupplierCountry", Supplier.SupplierCountry);
            sc.Parameters.AddWithValue("@SupplierPinCode", Supplier.SupplierPinCode);
            sc.Parameters.AddWithValue("@SupplierDataLastUpdate", Supplier.SupplierDataLastUpdate);
            sc.Parameters.AddWithValue("@SupplierJoinDate", Supplier.SupplierJoinDate);
            try{
                con.Open();
                int rowsEffected = sc.ExecuteNonQuery();
                Console.WriteLine("SuppliersService : Executing Update Supplier to DB");
                Console.WriteLine("Rows Effected : " + rowsEffected);
                if (rowsEffected == 1)
                {
                    return 1;
                }
                Console.WriteLine("SuppliersService : Done Executing Update Supplier to DB");
            }catch(Exception e){
                Console.WriteLine("SuppliersService : Error Occurred While Updating Supplier to DB");
                Console.WriteLine(e.Message);
            }finally{
                con.Close();
                con.Dispose();
            }
            return -1;
        }

    public static int Delete_Supplier(int? SupplierId){
            SqlConnection con = new SqlConnection(cs);
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Delete_Supplier";
            sc.CommandType = CommandType.StoredProcedure;
            sc.Connection = con;
            sc.Parameters.AddWithValue("@SupplierId", SupplierId);
            try{
                con.Open();
                int rowsEffected = sc.ExecuteNonQuery();
                Console.WriteLine($"SuppliersService : Executing Deleting Supplier with id = {SupplierId} from DB");
                Console.WriteLine("Rows Effected : " + rowsEffected);
                if (rowsEffected == 1)
                {
                    return 1;
                }
                Console.WriteLine($"SuppliersService : Done Executing Deleting Supplier with id = {SupplierId} from DB");
            }catch(Exception e){
                Console.WriteLine($"SuppliersService : Error Occurred While Deleting Supplier with id = {SupplierId} from DB");
                Console.WriteLine(e.Message);
            }finally{
                con.Close();
                con.Dispose();
            }
            return -1;
        }



    }
}
