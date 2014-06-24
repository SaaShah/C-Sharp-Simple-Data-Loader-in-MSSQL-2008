using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
/// <summary>
/// Developed by Saad Bin Shahid connection
/// </summary>
public class connection
{
    protected connection() { }

	public static SqlConnection _getcon()
    {
        String _string = @"
Data Source=Server_Address;
Initial Catalog=DB_NAME;
Integrated Security=SSPI;
User ID=YOUR_ID;
Password=YOUR_PASSWORD;";


        try
        {
            SqlConnection con = new SqlConnection(_string);
            con.Open(); //open the connection
            return con;
        }
        catch (SqlException er) 
        {
            return null;
        }

	}
}