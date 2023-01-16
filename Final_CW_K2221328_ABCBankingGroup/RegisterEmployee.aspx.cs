using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_CW_K2221328_ABCBankingGroup
{
    public partial class RegisterEmployee : System.Web.UI.Page
    {

        //Sql Connection Command
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnregister_Click(object sender, EventArgs e)
        {
            string user_type = ddlUserType.SelectedValue.ToLower();
            string id = getId(user_type);
            bool insertUser = addUser(user_type, id);

            if(insertUser)
            {
                Session["user_type"] = ddlUserType.SelectedValue.ToLower();
                Response.Redirect("Login.aspx", false);
            }


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }

        string getId(string userType)
        {

            conn = new SqlConnection(Common_Function.GetDBConnectionString());

            string id = string.Empty;
            if (userType == "admin")
            {
                //ABC2221328000
                cmd = new SqlCommand(@"SELECT 'ABC22213280' + CAST( MAX( CAST( SUBSTRING (admin_id, 12, 50) AS INT)) +1 AS VARCHAR) AS admin_id FROM ABC_Admin", conn);

                try
                {
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        id = reader["admin_id"].ToString();
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
            else if (userType == "emp")
            {
                cmd = new SqlCommand(@"SELECT 'EMP22213280' + CAST( MAX( CAST( SUBSTRING (emp_id, 12, 50) AS INT)) +1 AS VARCHAR) AS emp_id FROM Employee", conn);

                try
                {
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        id = reader["emp_id"].ToString();
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
            else
            {
                error.InnerText = "WRONG USER TYPE PROVIDED";
            }
            return id;
        }
        bool addUser(string userType, string id)
        {
            int statusQuery = 0;
            bool rowInserted = false;

            conn = new SqlConnection(Common_Function.GetDBConnectionString());

            try
            {
                conn.Open();

                if(userType == "admin" || userType == "emp")
                {
                    int user_balance = 0;
                    int has_job = 0;
                    int joint_account = 0;
                    string accountHolderName1 = "NA";
                    string accountHolderName2 = "NA";
                    string accountHolderName3 = "NA";

                    cmd = new SqlCommand(@"INSERT INTO Account( account_number,account_type,user_name,user_password,mobile,gender,email,address,passport,question_id,user_value,user_balance,first_name,last_name,user_type,has_job,joint_account,joint_account_username_1,joint_account_username_2,joint_account_username_3) VALUES(@account_number,@account_type,@user_name,@user_password,@mobile,@gender,@email,@address,@passport,@question_id,@user_value,@user_balance,@first_name,@last_name, @user_type,@has_job,@joint_account,@joint_account_username_1,@joint_account_username_2,@joint_account_username_3)", conn);

                    cmd.Parameters.AddWithValue("@account_number", id);
                    cmd.Parameters.AddWithValue("@account_type", "NA");
                    cmd.Parameters.AddWithValue("@user_name", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@user_password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@mobile", txtMobileNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@gender", ddlGender.SelectedValue);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@passport", txtPassport.Text.Trim());
                    cmd.Parameters.AddWithValue("@question_id", ddlSecurityQuestion.SelectedValue);
                    cmd.Parameters.AddWithValue("@user_value", txtAnswer.Text.Trim());
                    cmd.Parameters.AddWithValue("@user_balance", user_balance);
                    cmd.Parameters.AddWithValue("@first_name", txtFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@last_name", txtLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@user_type", ddlUserType.SelectedValue.ToLower());
                    cmd.Parameters.AddWithValue("@has_job", has_job);
                    cmd.Parameters.AddWithValue("@joint_account", joint_account);
                    cmd.Parameters.AddWithValue("@joint_account_username_1", accountHolderName1);
                    cmd.Parameters.AddWithValue("@joint_account_username_2", accountHolderName2);
                    cmd.Parameters.AddWithValue("@joint_account_username_3", accountHolderName3);

                    statusQuery = cmd.ExecuteNonQuery();
                    if (statusQuery > 0)
                    {
                        rowInserted = true;
                        //logger
                    }
                }

                if (userType == "admin")
                {
                    cmd = new SqlCommand(@"INSERT INTO ABC_Admin( id ,admin_userName  ,admin_firstName ,admin_lastName ,admin_password ,admin_mobile ,admin_gender ,admin_email  ,admin_address ,admin_passport  ,admin_questionId ,admin_value) VALUES(@id ,@admin_userName  ,@admin_firstName ,@admin_lastName ,@admin_password ,@admin_mobile ,@admin_gender ,@admin_email  ,@admin_address ,@admin_passport  ,@admin_questionId ,@admin_value)", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@admin_userName", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@admin_firstName", txtFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@admin_lastName", txtLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@admin_password", txtPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@admin_mobile", txtMobileNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@admin_gender", ddlGender.SelectedValue);
                    cmd.Parameters.AddWithValue("@admin_email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@admin_address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@admin_passport ", txtPassport.Text.Trim());
                    cmd.Parameters.AddWithValue("@admin_questionId", ddlSecurityQuestion.SelectedValue);
                    cmd.Parameters.AddWithValue("@admin_value", txtAnswer.Text.Trim());

                    statusQuery = cmd.ExecuteNonQuery();
                    if (statusQuery > 0)
                    {
                        rowInserted = true;
                        //logger
                    }
                }

                if (userType == "emp")
                {
                    cmd = new SqlCommand(@"INSERT INTO Employee(emp_id  ,emp_userName  ,emp_firstName ,emp_lastName ,emp_password ,emp_mobile ,emp_gender ,emp_email  ,emp_address ,emp_passport  ,emp_questionId ,emp_value ) VALUES(@emp_id  ,@emp_userName  ,@emp_firstName ,@emp_lastName ,@emp_password ,@emp_mobile ,@emp_gender ,@emp_email  ,@emp_address, @emp_passport  ,@emp_questionId ,@emp_value)", conn);
                    cmd.Parameters.AddWithValue("@emp_id", id);
                    cmd.Parameters.AddWithValue("@emp_userName", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@emp_firstName", txtFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@emp_lastName", txtLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@emp_password", txtPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@emp_mobile", txtMobileNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@emp_gender", ddlGender.SelectedValue);
                    cmd.Parameters.AddWithValue("@emp_email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@emp_address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@emp_passport ", txtPassport.Text.Trim());
                    cmd.Parameters.AddWithValue("@emp_questionId", ddlSecurityQuestion.SelectedValue);
                    cmd.Parameters.AddWithValue("@emp_value", txtAnswer.Text.Trim());


                    statusQuery = cmd.ExecuteNonQuery();
                    if (statusQuery > 0)
                    {
                        rowInserted = true;
                        //logger
                    }
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

            

            return rowInserted;
        }

    }
}