using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_CW_K2221328_ABCBankingGroup
{
    public partial class ChangePassword : System.Web.UI.Page
    {

        //Sql Connection Command
        SqlConnection conn;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (Session["forgotpassword"] != null)
            {
                conn = new SqlConnection(Common_Function.GetDBConnectionString());
                cmd = new SqlCommand(@"UPDATE Account SET user_password = @user_password WHERE user_name = @user_name", conn);

                cmd.Parameters.AddWithValue("@user_password", txtNewPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@user_name", Session["forgotpassword"].ToString());
                try
                {
                    conn.Open();
                    int statusQuery = cmd.ExecuteNonQuery();

                    if (statusQuery > 0)
                    {
                        Response.Redirect("Login.aspx", false);
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
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");
        }
    }
}