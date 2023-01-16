using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_CW_K2221328_ABCBankingGroup
{
    public partial class Register : System.Web.UI.Page
    {
        //Sql Connection Command
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string AccountNumber = displayAccountNumber();
                string  tempAccountNumber = AccountNumber.Remove(AccountNumber.Length - 4) + "****";
                lblAccountNumber.Text= tempAccountNumber;
                accountnumber.Value= AccountNumber;
            }

        }

        string displayAccountNumber()
        {
            string accNumber = string.Empty;
            try
            {
                

                //Creating SQL Objects
                conn = new SqlConnection(Common_Function.GetDBConnectionString());

                //We can create a String Variable for a query. However, this will be common and dynamic for every user in the Project for creating new Account Number by incrementing a PreDefined String and typecasting it.
                cmd = new SqlCommand(@"SELECT 'KU222132800' + CAST( MAX( CAST( SUBSTRING (account_number, 12, 50) AS INT)) +1 AS VARCHAR) AS account_number FROM Account" , conn);

                //DB Connection Open Command
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //Better to be precise with the value
                    accNumber = reader["account_number"].ToString();
                }
                //The most important command to avoid excessive RAM consumption is to close all the DB connection and free the resources.
                reader.Close();
                conn.Close();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            
            return accNumber;
        }

        protected void btnregister_Click(object sender, EventArgs e)
        {

            conn = new SqlConnection(Common_Function.GetDBConnectionString());
            cmd = new SqlCommand(@"SELECT accType,min_balance FROM AccountType WHERE account_type_id = @account_type_id", conn);
            cmd.Parameters.AddWithValue("@account_type_id", ddlAccountType.SelectedValue);

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToInt32(txtAmount.Text.Trim()) >= Convert.ToInt32(reader["min_balance"]))
                    {
                        int has_job = 0;
                        int joint_account = 0;
                        string accountHolderName1 = "NA";
                        string accountHolderName2 = "NA";
                        string accountHolderName3 = "NA";

                        
                        if (isSalaried.SelectedValue == "YES")
                        {
                            has_job = 1;
                        }
                        else
                        {
                            has_job = 0;
                        }
                        if (cbJointAccount.Checked)
                        {
                            joint_account = 1;

                            if (txtAccountHolder1.Text.Trim() != string.Empty)
                            {
                                accountHolderName1 = txtAccountHolder1.Text.Trim();
                            }
                            if (txtAccountHolder2.Text.Trim() != string.Empty)
                            {
                                accountHolderName2 = txtAccountHolder2.Text.Trim();
                            }
                            if (txtAccountHolder3.Text.Trim() != string.Empty)
                            {
                                accountHolderName3 = txtAccountHolder3.Text.Trim();
                            }
                        }

                        cmd = new SqlCommand(@"INSERT INTO Account( account_number,account_type,user_name,user_password,mobile,gender,email,address,passport,question_id,user_value,user_balance,first_name,last_name,user_type,has_job,joint_account,joint_account_username_1,joint_account_username_2,joint_account_username_3) VALUES(@account_number,@account_type,@user_name,@user_password,@mobile,@gender,@email,@address,@passport,@question_id,@user_value,@user_balance,@first_name,@last_name, @user_type,@has_job,@joint_account,@joint_account_username_1,@joint_account_username_2,@joint_account_username_3)", conn);
                        cmd.Parameters.AddWithValue("@account_number", accountnumber.Value);
                        cmd.Parameters.AddWithValue("@account_type", reader["accType"].ToString());
                        cmd.Parameters.AddWithValue("@user_name", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@user_password", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@mobile", txtMobileNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("@gender", ddlGender.SelectedValue);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@passport", txtPassport.Text.Trim());
                        cmd.Parameters.AddWithValue("@question_id", ddlSecurityQuestion.SelectedValue);
                        cmd.Parameters.AddWithValue("@user_value", txtAnswer.Text.Trim());
                        cmd.Parameters.AddWithValue("@user_balance", txtAmount.Text.Trim());
                        cmd.Parameters.AddWithValue("@first_name", txtFirstName.Text.Trim());
                        cmd.Parameters.AddWithValue("@last_name", txtLastName.Text.Trim());
                        cmd.Parameters.AddWithValue("@user_type", ddlUserType.SelectedValue.ToLower());
                        cmd.Parameters.AddWithValue("@has_job", has_job);
                        cmd.Parameters.AddWithValue("@joint_account", joint_account);
                        cmd.Parameters.AddWithValue("@joint_account_username_1", accountHolderName1);
                        cmd.Parameters.AddWithValue("@joint_account_username_2", accountHolderName2);
                        cmd.Parameters.AddWithValue("@joint_account_username_3", accountHolderName3);
                        int statusQuery = cmd.ExecuteNonQuery();
                        if (statusQuery > 0)
                        {
                            Response.Redirect("Login.aspx", false);
                            Session["register"] = txtUsername.Text.Trim();
                        }
                        else
                        {
                            error.InnerText = "Invalid Input provided";
                        }

                        updateValidateAccount(txtUsername.Text.Trim());
                        

                    }
                    else
                    {
                        errorAmount.InnerText = "Minimum Amount for "+ reader["accType"] + " is => "+ (int)reader["min_balance"];
                        txtAmount.Focus();
                    }
                }

                
            }
            catch(Exception ex)
            {
                if(ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                {
                    error.InnerText = "Username Already Exist.";
                }
                else
                {
                    Response.Write("<script>alert('Error - " + ex.Message + "')</script>");
                }
            }
            finally
            {
                
                reader.Close();
                conn.Close();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        void updateValidateAccount(string UserName)
        {
            conn = new SqlConnection(Common_Function.GetDBConnectionString());

            //TAKE THE ACCOUNT ID WHICH WAS JUST GENERATED AND INSERT THE ROW IN VALIDATEACCOUNT TABLE
            cmd = new SqlCommand(@"SELECT account_id FROM Account WHERE user_name = @user_name", conn);
            cmd.Parameters.AddWithValue("@user_name", txtUsername.Text.Trim());
            try
            {
                bool userCreated = false;
                conn.Open();
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    userCreated = true;
                    cmd = new SqlCommand(@"INSERT INTO ValidateAccount(accId) VALUES(@accId)", conn);
                    cmd.Parameters.AddWithValue("@accId", reader["account_id"].ToString());

                    int updateTable = cmd.ExecuteNonQuery();
                    if(updateTable > 0)
                    {
                        //logger
                    }
                }

                
            }
            catch(Exception ex)
            {

            }
            finally
            {
                reader.Close();
                conn.Close();
            }
        }

        protected void cbJointAccount_CheckedChanged(object sender, EventArgs e)
        {
            if(cbJointAccount.Checked)
            {
                txtAccountHolder1.Visible = true;
                txtAccountHolder2.Visible = true;
                txtAccountHolder3.Visible = true;
            }
            else
            {
                txtAccountHolder1.Visible = false;
                txtAccountHolder2.Visible = false;
                txtAccountHolder3.Visible = false;
            }
            
        }

        
    }
}