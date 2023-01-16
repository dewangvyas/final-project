using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_CW_K2221328_ABCBankingGroup
{
    public partial class Deposit : System.Web.UI.Page
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
                getAccountNumber();
                statusOk.Visible= false;
                statusError.Visible = false;
            }

        }

        void getAccountNumber()
        {
            int isDeleted = 1;
            int isBlocked = 3;
            try
            {
                conn = new SqlConnection(Common_Function.GetDBConnectionString());
                cmd = new SqlCommand(@"SELECT account_id, account_number FROM Account WHERE account_id != @account_id and delStatus != @delStatus and retryStatus <= @retryStatus and user_type=@user_type", conn);

                cmd.Parameters.AddWithValue("@account_id", Convert.ToInt32(ddlPayeeAccountNumber.SelectedValue));
                cmd.Parameters.AddWithValue("@delStatus", isDeleted);
                cmd.Parameters.AddWithValue("@retryStatus", isBlocked);
                cmd.Parameters.AddWithValue("@user_type", "user");
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                ddlPayeeAccountNumber.DataSource = dt;
                ddlPayeeAccountNumber.DataTextField = "account_number";
                ddlPayeeAccountNumber.DataValueField = "account_id";
                ddlPayeeAccountNumber.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error - " + ex.Message + "')</script>");
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (Session["userId"] != null)
            {
                conn = new SqlConnection(Common_Function.GetDBConnectionString());
                try
                {
                    conn.Open();
                    int transactionStatus = 0;
                    Utils utils = new Utils();
                    int userBalance = utils.accountBalance(Convert.ToInt32(ddlPayeeAccountNumber.SelectedValue));
                    
                    transaction = conn.BeginTransaction();
                    cmd = new SqlCommand(@"INSERT INTO [Transaction](sender_account_id,receiver_account_id,mobile,amount,transaction_type,remarks) VALUES(@sender_account_id,@receiver_account_id,@mobile,@amount,@transaction_type,@remarks)", conn, transaction);

                    cmd.Parameters.AddWithValue("@sender_account_id", ddlPayeeAccountNumber.SelectedValue);
                    cmd.Parameters.AddWithValue("@receiver_account_id", ddlPayeeAccountNumber.SelectedValue);
                    cmd.Parameters.AddWithValue("@mobile", txtMobileNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@amount", txtAmount.Text.Trim());
                    cmd.Parameters.AddWithValue("@transaction_type", "BANK");
                    cmd.Parameters.AddWithValue("@remarks", "DEPOSIT");
                    transactionStatus = cmd.ExecuteNonQuery();

                    UpdateReceiverBalance(Convert.ToInt32(ddlPayeeAccountNumber.SelectedValue), Convert.ToInt32(txtAmount.Text.Trim()), conn, transaction);

                    transaction.Commit();
                    Session["checkBalance"] = Convert.ToInt32(ddlPayeeAccountNumber.SelectedValue);
                    transactionStatus = 1;
                    if (transactionStatus > 0)
                    {
                        Response.Redirect("Deposit.aspx");
                        statusOk.Visible = true;
                        
                    }
                    else
                    {
                        statusError.Visible = true;
                        error.InnerText = "Invalid Input provided";
                    }

                    
                }
                catch (Exception)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('Error - " + ex.Message + "')</script>");
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        void UpdateReceiverBalance(int receiver_id, int amount, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int receiverBalance = 0;
            cmd = new SqlCommand("SELECT user_balance FROM Account WHERE account_id = @account_id", sqlConnection, sqlTransaction);
            cmd.Parameters.AddWithValue("@account_id", receiver_id);
            try
            {
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    receiverBalance = (int)dataReader["user_balance"];
                    receiverBalance += amount;
                    cmd = new SqlCommand("UPDATE Account SET user_balance = @Amount WHERE account_id = @account_id", sqlConnection, sqlTransaction);
                    cmd.Parameters.AddWithValue("@Amount", receiverBalance);
                    cmd.Parameters.AddWithValue("@account_id", receiver_id);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error - " + ex.Message + "')</script>");
            }
            finally
            {
                dataReader.Close();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Transaction.aspx");
        }
    }
}