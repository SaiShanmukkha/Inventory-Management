using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Data;

namespace CloudCart.Services
{
    public class DemoService
    {

        public void getDataFromDBPart1(){
            string cs =  @"Data Source=USHYDSSAISHAN2\SQLEXPRESS; database=demoDBFun;integrated security=SSPI";
            SqlConnection con = new SqlConnection(cs);
            string command = "Select * from products";

            // Method - 1 for making SQL Command
            // SqlCommand cmd = new SqlCommand(command, con);

            // method-2 for making SQL Command
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = command;
            cmd.Connection = con;


            // To tell that command is Stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            // Adding values to parameters in stored Procedure
            cmd.Parameters.AddWithValue("@ParameterName", "ParameterValue");
            // For getting the out parameter
            SqlParameter outputParameter = new SqlParameter();
            outputParameter.ParameterName = "@ParameterName";
            // For Adding datatype of output parameter
            outputParameter.DbType = System.Data.DbType.Int16;
            outputParameter.Direction = System.Data.ParameterDirection.Output;
            // for adding this output parameter
            cmd.Parameters.Add(outputParameter);


            // Opening Connection
            con.Open();

            // We use this when we get multiple records at at time
            SqlDataReader rdr = cmd.ExecuteReader();

            // When we get value back i.e, generally from Aggregate Functions
            var value = cmd.ExecuteScalar();


            // For updating, inserting, deleting queries, returns Number of Rows effected
            int rows_effected =  cmd.ExecuteNonQuery();
            // for getting output parameter from DB
            string outputParameterValue = outputParameter.Value.ToString();


            // Closing Connection
            con.Close();
        }

        public void getDataFromDBPart2(){
            string cs =  @"Data Source=USHYDSSAISHAN2\SQLEXPRESS; database=demoDBFun;integrated security=SSPI";
            SqlConnection con = new SqlConnection(cs);
            string command = "Select * from products";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = command;
            cmd.Connection = con;

            // SqlDataReader is connection orientated (Requires Active connection while reading datasource), ReadOnly and forward only (no way to access previous read record again)
            // SqlDataReader Instance cannot be created using new operator
            // The forward only nature of SQLDataReader makes it more efficient choice to read data
            // The SQLCommand object's Executereader() method creates and returns instance of SqlDataReader
            // To create SqlDatareader instance connection must be opened by open() method, otherwise it throws runtime exception
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            // SqlDataReader Read() method is used to Loop through the rows
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductId");
            dt.Columns.Add("ProductName");
            dt.Columns.Add("ProductQuantity");
            while (rdr.Read()){
                DataRow dr = dt.NewRow();
                dr["ProductId"] = rdr["ProductId"];
                dr["ProductName"] = rdr["ProductName"];
                dr["ProductQuantity"] = rdr["ProductIdQuantity"];
                dt.Rows.Add(dr);
            }

            

            // SqlDataReder instance must be closed after reading data
            rdr.Close();


            // Closing connection
            con.Close();

        }


        public void getDataFromDBPart3(){
            string cs =  @"Data Source=USHYDSSAISHAN2\SQLEXPRESS; database=demoDBFun;integrated security=SSPI";
            SqlConnection con = new SqlConnection(cs);
            // Adding multiple SQL Commands in one command
            string commands = "Select * from products;select * from producttypes;";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = commands;
            cmd.Connection = con;

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            // If your statement / proc is returning multiple result sets, For example, if you have two select statements in single Command object, then you will get back two result sets.
            // NextResult is used to move between result sets.
            // Read is used to move forward in records of a single result set.
            while (rdr.NextResult())
            {
                // assign rdr to usability

            }

            // Always close the reader 
            rdr.Close();
            // Closing connection
            con.Close();
        }


        public void getDataFromDBPart4(){
            string cs =  @"Data Source=USHYDSSAISHAN2\SQLEXPRESS; database=demoDBFun;integrated security=SSPI";
            SqlConnection con = new SqlConnection(cs);
            string command = "Select * from products";
            
            // SqlDataAdapter & DataSet provides disconnected data access model
            SqlDataAdapter da = new SqlDataAdapter(command, con);
            DataSet ds = new DataSet();
            
            // SqlDataAdapter will open connections, fills dataset with data and closes the connection.
            da.Fill(ds);

            // Using the DataRow to access data
            foreach(DataRow dr in ds.Tables[0].Rows){                
                Console.WriteLine(dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            }

            // To release resources, we use dispose
            con.Dispose();            
        }

        // Cache Data Obtained from Database
        public void cacheDataReceivedFromDB()
        {
            string cs =  @"Data Source=USHYDSSAISHAN2\SQLEXPRESS; database=demoDBFun;integrated security=SSPI";
            SqlConnection con = new SqlConnection(cs);
            string command = "Select * from products";
            
            // SqlDataAdapter & DataSet provides disconnected data access model
            SqlDataAdapter da = new SqlDataAdapter(command, con);
            DataSet ds = new DataSet();
            da.Fill(ds);          


            // pending implementation ... 
        }

        public void getDataFromDBPart5(){
            string cs =  @"Data Source=USHYDSSAISHAN2\SQLEXPRESS; database=demoDBFun;integrated security=SSPI";
            SqlConnection con = new SqlConnection(cs);
            string command = "Select * from products";
            
            // SqlDataAdapter & DataSet provides disconnected data access model
            SqlDataAdapter da = new SqlDataAdapter(command, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Products");
            
            con.Dispose();
        }

    }
}


// Don't concatenate dynamic queries, it increases risk of SQL injeection.
// Always better to use Parameterized Values.

// you can directly use sql queries or stored procedure to execute a query.

// If the connection is open before the Fill() method is called, then no, the connection will not be closed by the DataAdapter.

// However, if you do not explicitly open the connection, and instead let the DataAdapter open and close the connection within the Fill() command, then the connection will be closed on error.

// If you use connection object one time, use Dispose. A using block will ensure this is called even in the event of an exception.
// If connection object must be reused, use Close method.
