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
    public partial class AllUsers : System.Web.UI.Page
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
                getUserData();
            }
        }


        void getUserData()
        {
            try
            {
                int statusCheck = 1;
                conn = new SqlConnection(Common_Function.GetDBConnectionString());
                
                if (Session["user_type"].ToString() != "admin")
                {
                    cmd = new SqlCommand("SELECT account_id, account_number, user_name, first_name, last_name,user_password,gender,address, email, mobile, passport, user_balance, user_type, timestamp FROM Account WHERE delStatus != @delStatus and retryStatus != @retryStatus and user_type != @user_type and user_type !=@userAdmin", conn);
                    cmd.Parameters.AddWithValue("@userAdmin", "admin");
                }
                else
                {
                    cmd = new SqlCommand("SELECT account_id, account_number, user_name, first_name, last_name,user_password,gender,address, email, mobile, passport, user_balance, user_type, timestamp FROM Account WHERE delStatus != @delStatus and retryStatus != @retryStatus and user_type != @user_type", conn);
                }

                cmd.Parameters.AddWithValue("@delStatus", statusCheck);
                cmd.Parameters.AddWithValue("@retryStatus", statusCheck);
                cmd.Parameters.AddWithValue("@user_type", Session["user_type"].ToString());

                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                gvAllUsers.DataSource = dt;
                gvAllUsers.DataBind();
                
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error - " + ex.Message + "')</script>");
            }
        }

        protected void gvAllUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAllUsers.EditIndex = e.NewEditIndex;
            getUserData();
        }

        protected void gvAllUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int accountId = Convert.ToInt32(gvAllUsers.DataKeys[e.RowIndex].Value.ToString());
            string userName = ((TextBox)gvAllUsers.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string password = ((TextBox)gvAllUsers.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            string firstName = ((TextBox)gvAllUsers.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
            string lastName = ((TextBox)gvAllUsers.Rows[e.RowIndex].Cells[5].Controls[0]).Text;
            string gender = ((TextBox)gvAllUsers.Rows[e.RowIndex].Cells[6].Controls[0]).Text;
            string email = ((TextBox)gvAllUsers.Rows[e.RowIndex].Cells[7].Controls[0]).Text;
            string mobile = ((TextBox)gvAllUsers.Rows[e.RowIndex].Cells[8].Controls[0]).Text;
            string passport = ((TextBox)gvAllUsers.Rows[e.RowIndex].Cells[9].Controls[0]).Text;
            string address = ((TextBox)gvAllUsers.Rows[e.RowIndex].Cells[10].Controls[0]).Text;
            string amount = ((TextBox)gvAllUsers.Rows[e.RowIndex].Cells[12].Controls[0]).Text;

            conn = new SqlConnection(Common_Function.GetDBConnectionString());
            cmd = new SqlCommand("UPDATE Account SET user_name = @user_name, user_password=@user_password, first_name=@first_name, last_name=@last_name, gender=@gender, email=@email,mobile=@mobile,passport=@passport,address=@address,user_balance=@user_balance WHERE account_id = @account_id ", conn);
            cmd.Parameters.AddWithValue("@user_name", userName);
            cmd.Parameters.AddWithValue("@user_password", password);
            cmd.Parameters.AddWithValue("@first_name", firstName);
            cmd.Parameters.AddWithValue("@last_name", lastName);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@mobile", mobile);
            cmd.Parameters.AddWithValue("@passport", passport);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@user_balance", Convert.ToInt32(amount));
            cmd.Parameters.AddWithValue("@account_id", accountId);

            try
            {
                conn.Open();
                int updateUserViaGrid = cmd.ExecuteNonQuery();

                if(updateUserViaGrid > 0)
                {
                    gvAllUsers.EditIndex = -1;
                    getUserData();
                }
                else
                {
                    error.InnerText = "Invalid Input";
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Error - " + ex.Message + "')</script>");
            }
            finally
            {
                conn.Close();
            }
        }

        protected void gvAllUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAllUsers.EditIndex = -1;
            getUserData();
        }

        protected void gvAllUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int account_id = Convert.ToInt32(gvAllUsers.DataKeys[e.RowIndex].Value.ToString());

            //First we will take the backup then we will delete the user
            //This will be the hard delete
            conn = new SqlConnection(Common_Function.GetDBConnectionString());
            cmd = new SqlCommand(@"SELECT * FROM Account WHERE account_id=@account_id",conn);
            cmd.Parameters.AddWithValue("@account_id", account_id);
            try
            {
                int status_flag = 1;
                conn.Open();
                dataReader= cmd.ExecuteReader();
                bool userExist = false;

                while(dataReader.Read())
                {
                    userExist= true;
                    cmd = new SqlCommand(@"INSERT INTO Deleted_Users(account_id, account_number, account_type, user_name, email, mobile, address, passport, has_job, joint_account, joint_account_username_1, joint_account_username_2, joint_account_username_3, question_id, user_value, user_balance, user_password, user_type, gender, timestamp, first_name, last_name, delStatus, retryStatus) VALUES(@account_id, @account_number, @account_type, @user_name, @email, @mobile, @address, @passport, @has_job, @joint_account, @joint_account_username_1,@joint_account_username_2,@joint_account_username_3,@question_id,@user_value,@user_balance,@user_password,@user_type,@gender,@timestamp,@first_name,@last_name,@delStatus,@retryStatus) ", conn);

                    cmd.Parameters.AddWithValue("@account_id", Convert.ToInt32(dataReader["account_id"]));
                    cmd.Parameters.AddWithValue("@account_number", dataReader["account_number"].ToString());
                    cmd.Parameters.AddWithValue("@account_type", dataReader["account_type"].ToString());
                    cmd.Parameters.AddWithValue("@user_name", dataReader["user_name"].ToString());
                    cmd.Parameters.AddWithValue("@email", dataReader["email"].ToString());
                    cmd.Parameters.AddWithValue("@mobile", dataReader["mobile"].ToString());
                    cmd.Parameters.AddWithValue("@address", dataReader["address"].ToString());
                    cmd.Parameters.AddWithValue("@passport", dataReader["passport"].ToString());
                    cmd.Parameters.AddWithValue("@has_job", Convert.ToInt32(dataReader["has_job"]));
                    cmd.Parameters.AddWithValue("@joint_account", Convert.ToInt32(dataReader["joint_account"]));
                    cmd.Parameters.AddWithValue("@joint_account_username_1", dataReader["joint_account_username_1"].ToString());
                    cmd.Parameters.AddWithValue("@joint_account_username_2", dataReader["joint_account_username_2"].ToString());
                    cmd.Parameters.AddWithValue("@joint_account_username_3", dataReader["joint_account_username_3"].ToString());
                    cmd.Parameters.AddWithValue("@question_id", Convert.ToInt32(dataReader["question_id"]));
                    cmd.Parameters.AddWithValue("@user_value", dataReader["user_value"].ToString());
                    cmd.Parameters.AddWithValue("@user_balance", dataReader["user_balance"]);
                    cmd.Parameters.AddWithValue("@user_password", dataReader["user_password"].ToString());
                    cmd.Parameters.AddWithValue("@user_type", dataReader["user_type"].ToString());
                    cmd.Parameters.AddWithValue("@gender", dataReader["gender"].ToString());
                    cmd.Parameters.AddWithValue("@timestamp", dataReader["timestamp"]);
                    cmd.Parameters.AddWithValue("@first_name", dataReader["first_name"].ToString());
                    cmd.Parameters.AddWithValue("@last_name", dataReader["last_name"].ToString());
                    cmd.Parameters.AddWithValue("@delStatus", status_flag);
                    cmd.Parameters.AddWithValue("@retryStatus", Convert.ToInt32(dataReader["retryStatus"]) );

                    int insertDeletedUserStatus = cmd.ExecuteNonQuery();

                    if(insertDeletedUserStatus > 0)
                    {
                        error.InnerText = "VALUE INSERTED";

                        //[HARD DELETE]

                        //UPDATE VALIDATE USER
                        cmd = new SqlCommand(@"UPDATE ValidateAccount SET delete_account = @delete_account, verify_account =@verify_account WHERE accId=@accId", conn);
                        cmd.Parameters.AddWithValue("@delete_account", status_flag);
                        cmd.Parameters.AddWithValue("@verify_account", status_flag);
                        cmd.Parameters.AddWithValue("@accId", Convert.ToInt32(dataReader["account_id"]));

                        int statusUpdate = cmd.ExecuteNonQuery();
                        if (statusUpdate > 0)
                        {
                            //logger updated
                        }


                        cmd = new SqlCommand(@"UPDATE Account SET delStatus = @delStatus WHERE account_id = @account_id ", conn);
                        cmd.Parameters.AddWithValue("@delStatus", statusUpdate);
                        cmd.Parameters.AddWithValue("@account_id", Convert.ToInt32(dataReader["account_id"]));

                        int deleteUserFromAccount = cmd.ExecuteNonQuery();

                        if(deleteUserFromAccount > 0)
                        {
                            //logger User Deleted from the DB [HARD DELETE]
                        }
                        else
                        {
                            error.InnerText = "USER NOT DELETED";
                        }

                        


                    }
                    else
                    {
                        error.InnerText = "Invalid Input";
                    }
                    
                    

                    gvAllUsers.EditIndex = -1;
                    getUserData();

                    
                }
                if (userExist)
                {

                }
                else
                {

                }

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Error - " + ex.Message + "')</script>");
            }
            finally
            {
                dataReader.Close();
                conn.Close();
            }


            
        }

    }
}