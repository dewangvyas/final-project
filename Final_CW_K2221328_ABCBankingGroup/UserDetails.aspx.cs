using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Remoting.Messaging;
using System.Collections;

namespace Final_CW_K2221328_ABCBankingGroup
{
    public partial class UserDetails : System.Web.UI.Page
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
                getUserDetails();
            }
        }

        void getUserDetails()
        {
            
            try
            {
                string account_number, account_type, user_name, email, mobile, address, gender, passport = string.Empty;
                conn = new SqlConnection(Common_Function.GetDBConnectionString());
                cmd = new SqlCommand(@"SELECT * FROM Account WHERE account_id = @account_id", conn);
                cmd.Parameters.AddWithValue("@account_id", Session["userId"]);

                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lblUserName.Text = reader["user_name"].ToString();
                    string suffix = string.Empty;

                    if(reader["gender"].ToString() == "Male")
                    {
                        suffix = "Mr. ";
                    }
                    else if(reader["gender"].ToString() == "Female")
                    {
                        suffix = "Ms. ";
                    }
                    lblAccountHolderName.Text = suffix+reader["first_name"].ToString().ToUpper() + " " + reader["last_name"].ToString().ToUpper();

                    lblAccountNumber.Text = reader["account_number"].ToString();
                    lblAccountType.Text = reader["account_type"].ToString();

                    
                    lblEmail.Text = reader["email"].ToString();
                    lblMobileNumber.Text = reader["mobile"].ToString();
                    lblAddress.Text = reader["address"].ToString();
                    lblPassport.Text = reader["passport"].ToString();
                    if (reader["delStatus"].ToString() == "1")
                    {
                        error.InnerText = "DELETE REQUEST IS SENT";
                    }
                    
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error - " + ex.Message + "')</script>");
            }
            finally
            {
                reader.Close();
                conn.Close();
            }

        }

        protected void btneditAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditUser.aspx");
        }

        protected void btndeleteAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteUser.aspx");
        }
    }
}