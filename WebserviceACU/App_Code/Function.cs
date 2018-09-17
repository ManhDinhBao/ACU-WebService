using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Function
/// </summary>
public class Function
{
    //public static string conString = "Data Source=10.173.24.199,1433;Initial Catalog = IBSACU; User ID = ibs; Password=ibs;";
    public static string conString = "Data Source=192.168.1.51,1433;Initial Catalog = IBSACU; User ID = ibs; Password=ibs;";
    public Function()
    {
        //
        // TODO: Add constructor logic here
        //
        
    }
    public static DataSet Query(string spName, List<Tuple<string,string>> paramater)
    {
        SqlConnection con = new SqlConnection(conString);
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        for (int i = 0; i < paramater.Count; i++)
        {
            cmd.Parameters.AddWithValue(paramater[i].Item1, paramater[i].Item2);
        }

        cmd.CommandText = spName;
        DataSet ds = new DataSet();
        cmd.Connection = con;
        con.Open();
        da.SelectCommand = cmd;
        da.Fill(ds);
        con.Close();
        return ds;
    }   

    public static DataSet Save(string spName,string type, List<Tuple<string, string>> paramater)
    {
        SqlConnection con = new SqlConnection(conString);
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        for (int i = 0; i < paramater.Count; i++)
        {
            cmd.Parameters.AddWithValue(paramater[i].Item1, paramater[i].Item2);
        }

        cmd.CommandText = spName;
        DataSet ds = new DataSet();
        cmd.Connection = con;
        con.Open();
        //if (type == "A")
        //{
        //    da.InsertCommand = cmd;
        //}
        //else if (type == "U")
        //{
        //    da.UpdateCommand = cmd;
        //}
        //else if (type == "D")
        //{
        //    da.DeleteCommand = cmd;
        //} 
        da.SelectCommand = cmd;
        da.Fill(ds);
        con.Close();
        return ds;
    }

    public static DataSet UserSave(string spName, string workingTag, string userId, string optLevel, string userName, string password, string personName, byte[] avatar, string email, string phoneNo, bool status, DateTime startDate, DateTime experiedDate, string person, DateTime mDate)
    {
        SqlConnection con = new SqlConnection(conString);
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@workingTag", workingTag);
        cmd.Parameters.AddWithValue("@userId", userId);
        cmd.Parameters.AddWithValue("@optLevel", optLevel);
        cmd.Parameters.AddWithValue("@userName", userName);
        cmd.Parameters.AddWithValue("@password", password);
        cmd.Parameters.AddWithValue("@personName", personName);
        cmd.Parameters.AddWithValue("@avatar", avatar);
        cmd.Parameters.AddWithValue("@email", email);
        cmd.Parameters.AddWithValue("@phoneNo", phoneNo);
        cmd.Parameters.AddWithValue("@status", status);
        cmd.Parameters.AddWithValue("@startDate", startDate);
        cmd.Parameters.AddWithValue("@experiedDate", experiedDate);
        cmd.Parameters.AddWithValue("@person", person);
        cmd.Parameters.AddWithValue("@mDate", mDate);

        cmd.CommandText = spName;
        DataSet ds = new DataSet();
        cmd.Connection = con;
        con.Open();
        
        da.SelectCommand = cmd;
        da.Fill(ds);
        con.Close();
        return ds;
    }

}