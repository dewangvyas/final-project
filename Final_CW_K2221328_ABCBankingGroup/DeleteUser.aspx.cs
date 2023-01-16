using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_CW_K2221328_ABCBankingGroup
{
    public partial class DeleteUser : System.Web.UI.Page
    {

        //Sql Connection Command
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userId"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                string UserName = getUserName();
                lblUsername.Text = UserName;
            }
        }

        string getUserName()
        {
            string username = string.Empty;
            conn = new SqlConnection(Common_Function.GetDBConnectionString());
            cmd = new SqlCommand(@"SELECT user_name FROM Account where account_id = @account_id", conn);

            cmd.Parameters.AddWithValue("@account_id", Session["userId"]);

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    username = reader["user_name"].ToString();
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Error - " + ex.Message + "')</script>");
            }
            finally
            {
                reader.Close();
                conn.Close();
            }

            return username;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int deleteStatus = 1;
            conn = new SqlConnection(Common_Function.GetDBConnectionString());
            cmd = new SqlCommand(@"UPDATE Account SET delStatus = @delStatus WHERE account_id = @account_id", conn);

            cmd.Parameters.AddWithValue("@account_id", Session["userId"]);
            cmd.Parameters.AddWithValue("@delStatus", deleteStatus);
            try
            {
                conn.Open();
                int statusQuery = cmd.ExecuteNonQuery();
                if (statusQuery > 0)
                {
                    Response.Redirect("Userdetails.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error - " + ex.Message + "')</script>");
            }
            finally
            {
                conn.Close();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserDetails.aspx");
        }
    }
}