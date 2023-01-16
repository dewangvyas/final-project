using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Final_CW_K2221328_ABCBankingGroup
{
    public class Common_Function
    {
        public static string GetDBConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["abc_bankConnectionString"].ConnectionString;
        }
    }

    public class Utils
    {
        //Sql Connection Command
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        public int accountBalance(int userId)
        {
            int userBalance = 0;
            try
            {
                conn = new SqlConnection(Common_Function.GetDBConnectionString());
                cmd = new SqlCommand(@"SELECT user_balance FROM Account WHERE account_id = @account_id", conn);

                cmd.Parameters.AddWithValue("@account_id", userId);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                userBalance = Convert.ToInt32(dt.Rows[0]["user_balance"]) == 0 ? 0 : Convert.ToInt32(dt.Rows[0]["user_balance"]);

            }
            catch(Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('Error - '" + ex.Message + ");</script>");
            }

            return userBalance;
        }

    }

}