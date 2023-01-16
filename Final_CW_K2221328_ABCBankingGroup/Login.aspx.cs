using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_CW_K2221328_ABCBankingGroup
{
    public partial class Login : System.Web.UI.Page
    {
        //Sql Connection Command
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;
        //RijndaelManaged rijndaelCipher;
        //ICryptoTransform encryptor;
        protected void Page_Load(object sender, EventArgs e)
        {
            string userIP = HttpContext.Current.Request.UserHostAddress;
            Session["IP"] = userIP;
            Session["userRetry"] = 0;
            try
            {
                if (Session["logged_in"] != null)
                {
                    Response.Redirect("Userdetails.aspx");
                }
                //if (Session["register"] != null)
                //{
                //    string username = Session["user_name"].ToString();
                //    txtUsername.Text = username;
                //    txtPassword.Focus();
                //}
                
            }
            catch(Exception ex)
            {
                error.InnerText = "Error" + ex.Message;
            }
        }

        protected void btnregister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void lbForgotPassword_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == string.Empty)
            {
                error.InnerText = "Please Provide a valid User Name";
                txtUsername.Focus();
            }
            else
            {
                conn = new SqlConnection(Common_Function.GetDBConnectionString());
                cmd = new SqlCommand(@"SELECT * FROM Account WHERE user_name = @user_name", conn);
                cmd.Parameters.AddWithValue("@user_name", txtUsername.Text.Trim());
                try
                {
                    conn.Open();
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Session["forgotpassword"] = reader["user_name"].ToString();
                        Response.Redirect("ForgotPassword.aspx");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error FP - " + ex.Message + "')</script>");
                    
                }
                finally
                {
                    reader.Close();
                    conn.Close();
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string loginUserName = string.Empty;
            string loginUserType = ddlUserType.SelectedValue.ToLower();
            //if (Session["register"].ToString() != txtUsername.Text.Trim())
            //{
            //    txtUsername.Text = txtUsername.Text.Trim();
            //}


            conn = new SqlConnection(Common_Function.GetDBConnectionString());
            cmd = new SqlCommand(@"SELECT * FROM Account WHERE user_name = @username and user_password=@user_password and user_type=@user_type", conn);
            cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
            cmd.Parameters.AddWithValue("@user_password", txtPassword.Text.Trim());
            cmd.Parameters.AddWithValue("@user_type", loginUserType);
            

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                loginUserName = txtUsername.Text.Trim();
                bool isTrue = false;
                int retryStatus = 0;
                while(reader.Read())
                {
                    if (Convert.ToInt32(reader["isBlocked"]) != 1)
                    {
                        isTrue = true;
                        Session["userId"] = reader["account_id"].ToString();
                        Session["account_number"] = reader["account_number"].ToString();
                        Session["username"] = reader["user_name"].ToString();
                        Session["logged_in"] = true;
                        Session["user_type"] = reader["user_type"].ToString();
                        cmd = new SqlCommand(@"UPDATE Account SET retryStatus = @retryStatus where account_id=@account_id", conn);
                        cmd.Parameters.AddWithValue("@retryStatus", retryStatus);
                        cmd.Parameters.AddWithValue("@account_id", reader["account_id"].ToString());
                        retryStatus = cmd.ExecuteNonQuery();
                        if (retryStatus > 0)
                        {
                            //logger Retry reset successfull
                        }
                    }
                    else
                    {
                        error.InnerText = "USERNAME: " + loginUserName + " IS BLOCKED.";
                        
                        if(btnLogin.Text == "UNBLOCK REQUEST")
                        {
                            int unblockUser = 0;
                            error.InnerText = "Request has been Sent to the bank.";
                            cmd = new SqlCommand(@"UPDATE Account SET isBlocked = @isBlocked,retryStatus=@retryStatus WHERE account_id=@account_id", conn);
                            cmd.Parameters.AddWithValue("@retryStatus", retryStatus);
                            cmd.Parameters.AddWithValue("@isBlocked", unblockUser);
                            cmd.Parameters.AddWithValue("@account_id", reader["account_id"].ToString());
                            retryStatus = cmd.ExecuteNonQuery();
                            if (retryStatus > 0)
                            {
                                //Logger
                            }
                            btnLogin.Text = "LOGIN";
                        }
                        else
                        {
                            btnLogin.Text = "UNBLOCK REQUEST";
                        }
                        
                    }
                    
                }
                if (isTrue)
                {
                    if(Session["user_type"].ToString() == "admin")
                    {
                        Response.Redirect("Dashboard.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("UserDetails.aspx", false);
                    }
                    
                }
                else
                {
                    retryLogic(loginUserName);
                }
            }
            catch (Exception ex)
            {                
                Response.Write("<script>alert('Error LC - " + ex.Message + "')</script>");
            }
            finally
            {
                reader.Close();
                conn.Close();
            }
        }


        void retryLogic(string loginName)
        {
            int dbRetry = 0;
            int userId = 0;
            string password = string.Empty;

            conn = new SqlConnection(Common_Function.GetDBConnectionString());
            cmd = new SqlCommand(@"SELECT account_id, user_password, retryStatus FROM Account WHERE user_name = @user_name", conn);
            cmd.Parameters.AddWithValue("@user_name", loginName);

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();

                bool userExist = false;

                while (reader.Read())
                {
                    userExist = true;
                    userId = Convert.ToInt32(reader["account_id"]);
                    password = reader["user_password"].ToString();

                    
                    if (Convert.ToInt32(reader["retryStatus"]) <= 3)
                    {
                        dbRetry = Convert.ToInt32(reader["retryStatus"]) + 1;
                    }

                }
                if (userExist)
                {
                    int retryLeft = 3;
                    if (dbRetry < 3)
                    {
                        
                        Session["userRetry"] = dbRetry;

                        cmd = new SqlCommand(@"UPDATE Account SET retryStatus = @retryStatus WHERE account_id = @account_id", conn);
                        cmd.Parameters.AddWithValue("@retryStatus", dbRetry);
                        cmd.Parameters.AddWithValue("@account_id", userId);
                        int updateRetry = cmd.ExecuteNonQuery();
                        if (updateRetry > 0)
                        {
                            //Logger Function
                        }

                        retryLeft =  retryLeft - dbRetry;
                        error.InnerText = "INVALID PASSWORD PROVIDED. RETRY LEFT: " + retryLeft;
                        
                    }
                    else
                    {
                        bool block_status = blockUser(userId);
                        if(block_status)
                        {
                            error.InnerText = "USERNAME: " + loginName + " IS BLOCKED.";
                        }
                        
                    }

                }
                else
                {
                    error.InnerText = "INVALID CREDENTIALS PROVIDED. RETRY LEFT: " + dbRetry;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error RL - " + ex.Message + "')</script>");
            }
            finally
            {
                reader.Close();
                conn.Close();
            }

            
        }


        bool blockUser(int checkUserId)
        {
            int verify_user = 2;
            int isBlocked = 1;
            bool blockedUser = false;
            conn = new SqlConnection(Common_Function.GetDBConnectionString());
            cmd = new SqlCommand("UPDATE Account SET isBlocked = @isBlocked where account_id = @account_id", conn);
            cmd.Parameters.AddWithValue("@isBlocked", isBlocked);
            cmd.Parameters.AddWithValue("@account_id", checkUserId);
            
            
            try
            {
                conn.Open();
                int updateRetry = cmd.ExecuteNonQuery();
                if (updateRetry > 0)
                {
                    blockedUser = true;
                }
                cmd = new SqlCommand("UPDATE ValidateAccount SET verify_account = @verify_account where accId = @account_id", conn);
                cmd.Parameters.AddWithValue("@verify_account", verify_user);
                cmd.Parameters.AddWithValue("@account_id", checkUserId);
                updateRetry = cmd.ExecuteNonQuery();
                if (updateRetry > 0)
                {
                    //logger
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error CRL - " + ex.Message + "')</script>");
            }
            finally
            {
                conn.Close();
            }
            return blockedUser;
        }

        protected void btnRegisterEmp_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterEmployee.aspx");
        }
    }
}