using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_CW_K2221328_ABCBankingGroup
{
    public partial class Dashboard : System.Web.UI.Page
    {

        //Sql Connection Command
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getDashboardDetails();
                
            }
        }

        void getDashboardDetails()
        {
            string totalTransaction = string.Empty;
            string totalAmount = string.Empty;
            string NoOfUsers = string.Empty;
            string NoOfEmployee = string.Empty;
            bool queryStatus = false;


            //totalTransaction
            conn = new SqlConnection(Common_Function.GetDBConnectionString());
            cmd = new SqlCommand("SELECT count(transactionId) AS totalTransaction FROM [Transaction]", conn);
            try
            {
                conn.Open();
                reader= cmd.ExecuteReader();
                while (reader.Read())
                {
                    queryStatus = true;
                    totalTransaction = reader["totalTransaction"].ToString();
                    lblTotalTransaction.Text = totalTransaction;
                }


                //totalAmount
                cmd = new SqlCommand(@"SELECT sum(amount) as Amount FROM [Transaction]", conn);
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    totalAmount = reader["Amount"].ToString();
                    lblTotalAmount.Text = totalAmount;
                }

                int flagStatus = 0;
                //NoOfUsers
                cmd = new SqlCommand("SELECT count(account_id) AS totalUsers FROM Account where delStatus =@delStatus and isBlocked=@isBlocked", conn);
                cmd.Parameters.AddWithValue("@delStatus", flagStatus);
                cmd.Parameters.AddWithValue("@isBlocked", flagStatus);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    NoOfUsers = reader["totalUsers"].ToString();
                    TotalUser.Text = NoOfUsers;
                }
                //
                //
                //CONTINUE FROM HERE
                //
                //
                cmd = new SqlCommand("SELECT count(emp_id) AS totalEmployees FROM Employee where emp_isDeleted =@delStatus and emp_isBlocked=@isBlocked", conn);
                cmd.Parameters.AddWithValue("@delStatus", flagStatus);
                cmd.Parameters.AddWithValue("@isBlocked", flagStatus);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    NoOfEmployee = reader["totalEmployees"].ToString();
                    TotalEmployee.Text = NoOfEmployee;
                }
                

            }
            catch (Exception ex)
            {

            }
            finally
            {
                reader.Close();
                conn.Close();
            }
        }
    }
}