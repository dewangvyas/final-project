using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_CW_K2221328_ABCBankingGroup
{
    public partial class DebitTransaction : System.Web.UI.Page
    {

        //Sql Connection Command
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader dataReader;
        SqlTransaction transaction = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userId"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                getDebitTransaction();
            }
        }

        void getDebitTransaction()
        {
            try
            {
                conn = new SqlConnection(Common_Function.GetDBConnectionString());
                cmd = new SqlCommand(@"SELECT acc.account_number, acc.user_name, tr.amount, tr.remarks , tr.timestamp FROM [Transaction] tr INNER JOIN  Account acc ON tr.receiver_account_id = acc.account_id WHERE tr.sender_account_id = @sender_account_id", conn);

                cmd.Parameters.AddWithValue("@sender_account_id", Session["userId"]);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                gvMyDebits.DataSource = dt;
                gvMyDebits.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error - " + ex.Message + "')</script>");
            }
        }
    }
}