using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_CW_K2221328_ABCBankingGroup
{
    public partial class EditUser : System.Web.UI.Page
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
                    lblAccountNumber.Text = reader["account_number"].ToString();
                    lblAccountType.Text = reader["account_type"].ToString();

                    txtFirstName.Text = reader["first_name"].ToString();
                    txtLastName.Text = reader["last_name"].ToString();
                    txtEmail.Text = reader["email"].ToString();
                    txtMobileNumber.Text = reader["mobile"].ToString();
                    txtAddress.Text = reader["address"].ToString();
                    txtPassport.Text = reader["passport"].ToString();

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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(Common_Function.GetDBConnectionString());
            cmd = new SqlCommand(@"SELECT * FROM Account WHERE account_id = @account_id", conn);
            cmd.Parameters.AddWithValue("@account_id", Session["userId"]);

            string firstName, lastName, email, mobileNumber, address, passport = string.Empty;
            try
            {
                firstName = txtFirstName.Text.Trim();
                lastName = txtLastName.Text.Trim();
                email = txtEmail.Text.Trim();
                mobileNumber = txtMobileNumber.Text.Trim();
                address = txtAddress.Text.Trim();
                passport = txtPassport.Text.Trim();

                int updateStatus = 0;

                conn.Open();
                reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    if(firstName != reader["first_name"].ToString())
                    {
                        updateStatus = updateTable("first_name" , txtFirstName.Text.Trim(), Session["userId"].ToString());
                    }
                    if(lastName != reader["last_name"].ToString())
                    {
                        updateStatus = updateTable("last_name", txtLastName.Text.Trim(), Session["userId"].ToString());
                    }
                    if(email != reader["email"].ToString())
                    {
                        updateStatus = updateTable("email", txtEmail.Text.Trim(), Session["userId"].ToString());
                    }
                    if(mobileNumber != reader["mobile"].ToString())
                    {
                        updateStatus = updateTable("mobile", txtMobileNumber.Text.Trim(), Session["userId"].ToString());
                    }
                    if(address != reader["address"].ToString())
                    {
                        updateStatus = updateTable("address", txtAddress.Text.Trim(), Session["userId"].ToString());
                    }
                    if(passport != reader["passport"].ToString())
                    {
                        updateStatus = updateTable("passport", txtPassport.Text.Trim(), Session["userId"].ToString());
                    }
                    
                }
                if(updateStatus > 0)
                {
                    Response.Redirect("UserDetails.aspx", false);
                }
                else
                {
                    error.InnerText = "No Change Found";
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
        }

        int updateTable(string ColumnName, string Value, string userId)
        {
            conn = new SqlConnection(Common_Function.GetDBConnectionString());
            cmd = new SqlCommand(@"UPDATE Account SET "+ ColumnName + "=@columnValue WHERE account_id =@account_id", conn);
            cmd.Parameters.AddWithValue("@account_id", Session["userId"]);
            cmd.Parameters.AddWithValue("@columnValue", Value);
            int statusQuery = 0;
            try
            {
                conn.Open();
                statusQuery = cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Error - " + ex.Message + "')</script>");
            }
            finally
            {
                conn.Close();
            }
            
            return statusQuery;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserDetails.aspx", false);
        }
    }
}