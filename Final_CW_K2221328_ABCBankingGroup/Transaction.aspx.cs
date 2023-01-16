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
    public partial class Transaction : System.Web.UI.Page
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
            if(!IsPostBack)
            {
                if (Session["userId"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                getAccountNumber();
            }
            
        }

        void getAccountNumber()
        {
            int isDeleted = 1;
            int isBlocked = 3;
            try
            {
                conn = new SqlConnection(Common_Function.GetDBConnectionString());
                cmd = new SqlCommand(@"SELECT account_id, account_number FROM Account WHERE account_id != @account_id and delStatus != @delStatus and retryStatus <= @retryStatus", conn);

                cmd.Parameters.AddWithValue("@account_id", Session["userId"]);
                cmd.Parameters.AddWithValue("@delStatus", isDeleted);
                cmd.Parameters.AddWithValue("@retryStatus", isBlocked);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                ddlPayeeAccountNumber.DataSource = dt;
                ddlPayeeAccountNumber.DataTextField = "account_number";
                ddlPayeeAccountNumber.DataValueField= "account_id";
                ddlPayeeAccountNumber.DataBind();
            }
            catch(Exception ex)
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
                    int userBalance = utils.accountBalance(Convert.ToInt32(Session["userId"]));
                    if(Convert.ToInt32(txtAmount.Text.Trim()) <= userBalance)
                    {
                        transaction = conn.BeginTransaction();
                        cmd = new SqlCommand(@"INSERT INTO [Transaction](sender_account_id,receiver_account_id,mobile,amount,transaction_type,remarks) VALUES(@sender_account_id,@receiver_account_id,@mobile,@amount,@transaction_type,@remarks)", conn, transaction);

                        cmd.Parameters.AddWithValue("@sender_account_id", Session["userId"]);
                        cmd.Parameters.AddWithValue("@receiver_account_id", ddlPayeeAccountNumber.SelectedValue);
                        cmd.Parameters.AddWithValue("@mobile", txtMobileNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("@amount", txtAmount.Text.Trim());
                        cmd.Parameters.AddWithValue("@transaction_type", "DR");
                        cmd.Parameters.AddWithValue("@remarks", txtRemarks.Text.Trim());
                        transactionStatus = cmd.ExecuteNonQuery();
                        
                        UpdateSenderBalance(Convert.ToInt32(Session["userId"]), userBalance, Convert.ToInt32(txtAmount.Text.Trim()), conn, transaction);
                        UpdateReceiverBalance(Convert.ToInt32(ddlPayeeAccountNumber.SelectedValue), Convert.ToInt32(txtAmount.Text.Trim()), conn, transaction);

                        transaction.Commit();

                        transactionStatus = 1;
                        if(transactionStatus > 0)
                        {
                            Response.Redirect("DebitTransaction.aspx", false);
                        }
                        else
                        {
                            error.InnerText = "Invalid Input provided";
                        }

                    }
                    else
                    {
                        error.InnerText = "Insufficient Balance.";
                    }
                }
                catch(Exception)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch(Exception ex)
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

        void UpdateSenderBalance(int sender_id, int userBalance, int amount, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            try
            {
                if(userBalance >= amount)
                {
                    userBalance -= amount;
                    cmd = new SqlCommand("UPDATE Account SET user_balance = @Amount WHERE account_id = @account_id", sqlConnection, sqlTransaction);
                    cmd.Parameters.AddWithValue("@Amount", userBalance);
                    cmd.Parameters.AddWithValue("@account_id", sender_id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex )
            {
                Response.Write("<script>alert('Error - " + ex.Message + "')</script>");
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
                while(dataReader.Read())
                {
                    receiverBalance = (int)dataReader["user_balance"];
                    receiverBalance += amount;
                    cmd = new SqlCommand("UPDATE Account SET user_balance = @Amount WHERE account_id = @account_id", sqlConnection, sqlTransaction);
                    cmd.Parameters.AddWithValue("@Amount", receiverBalance);
                    cmd.Parameters.AddWithValue("@account_id", receiver_id);
                    cmd.ExecuteNonQuery();
                }
                
            }
            catch(Exception ex)
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