using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Data.Common;
using System.Web.Util;

namespace Final_CW_K2221328_ABCBankingGroup
{
    public partial class Statement : System.Web.UI.Page
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
            string csvDelimiter = ddlCsvDelimiter.SelectedValue == "COMMA DELIMITER" ? "," : "|";
            conn = new SqlConnection(Common_Function.GetDBConnectionString());
            try
            {
                bool cTable = createTable();
                bool isInserted = updateStatement();

                conn.Open();
                cmd = new SqlCommand("SELECT timestamp,account_number,account_type, debit, credit, remarks from Statement ORDER BY id", conn);
                sda = new SqlDataAdapter(cmd);
                StringBuilder sb = new StringBuilder();
                
                DataSet ds = new DataSet();
                sda.Fill(ds);

                sb.Append("TIMESTAMP" + csvDelimiter);
                sb.Append("ACCOUNT NUMBER" + csvDelimiter);
                sb.Append("ACCOUNT TYPE" + csvDelimiter);
                sb.Append("DEBIT" + csvDelimiter);
                sb.Append("CREDIT" + csvDelimiter);
                sb.Append("REMARKS" + csvDelimiter);
                sb.Append("\r\n");
                foreach (DataRow statementRow in ds.Tables[0].Rows)
                {
                    string timestamp = statementRow["timestamp"].ToString();
                    sb.Append(timestamp + csvDelimiter);

                    string account_number = statementRow["account_number"].ToString();
                    sb.Append(account_number + csvDelimiter);

                    string account_type = statementRow["account_type"].ToString();
                    sb.Append(account_type + csvDelimiter);

                    string debit = statementRow["debit"].ToString();
                    sb.Append(debit + csvDelimiter);

                    string credit = statementRow["credit"].ToString();
                    sb.Append(credit + csvDelimiter);

                    string remark = statementRow["remarks"].ToString();
                    sb.Append(remark);
                    sb.Append("\r\n");

                }

                DateTime tempDate = DateTime.Today;
                string today = tempDate.ToString("yyyyMMdd");
                string filename = Session["statement_acc_number"].ToString() + "_Statement_" + today + ".csv";

                StreamWriter fileCSV = new StreamWriter(@"C:\\Users\\dewan\\source\\repos\\Final_CW_K2221328_ABCBankingGroup\\"+ filename);
                fileCSV.WriteLine(sb.ToString());
                fileCSV.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error - " + ex.Message + "')</script>");
            }
            finally
            {
                
                //dropTable();
                //dataReader.Close();
                conn.Close();
                
            }

            Response.Redirect("Statement.aspx", false);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Statement.aspx", false);
        }

        bool createTable()
        {
            conn = new SqlConnection(Common_Function.GetDBConnectionString());
            bool isCreated = false;

            cmd = new SqlCommand("SELECT TABLE_NAME FROM information_schema.TABLES WHERE TABLE_NAME like 'Statement'",conn);

            try
            {
                conn.Open();
                dataReader = cmd.ExecuteReader();

                while(dataReader.Read())
                {
                    if (dataReader["TABLE_NAME"].ToString() == "Statement")
                        dropTable();
                }


                cmd = new SqlCommand("CREATE TABLE Statement(id int PRIMARY KEY IDENTITY(1,1),trId  int FOREIGN KEY REFERENCES  [Transaction](transactionId), account_id int FOREIGN KEY REFERENCES Account(account_id),account_number VARCHAR(50),account_type VARCHAR(20),username VARCHAR(30),debit VARCHAR(20) DEFAULT '-',credit VARCHAR(20) DEFAULT '-',remarks VARCHAR(50),timestamp datetime default CURRENT_TIMESTAMP)", conn);

                int created = cmd.ExecuteNonQuery();
                if(created > 0)
                {
                    isCreated = true;
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

            return isCreated;
        }

        bool updateStatement()
        {
            conn = new SqlConnection(Common_Function.GetDBConnectionString());
            bool isReady = false;
            try
            {
                int isInserted = 0;
                conn.Open();

                //THIS WILL ADD ALL THE DEBITS FROM TRANSACTION TABLE IN A TEMPORARY TABLE STATEMENT
                cmd = new SqlCommand(@"SELECT tr.transactionId AS id,acc.account_id as account_id, acc.account_number as account_number,acc.account_type as account_type, acc.user_name as user_name, tr.amount as amount, tr.remarks as remarks, tr.timestamp as timestamp FROM [Transaction] tr INNER JOIN  Account acc ON (tr.sender_account_id = acc.account_id) WHERE tr.sender_account_id = @accountId and tr.receiver_account_id != @accountId", conn);

                cmd.Parameters.AddWithValue("@accountId", Convert.ToInt32(ddlPayeeAccountNumber.SelectedValue));
                dataReader = cmd.ExecuteReader();

                
                while (dataReader.Read())
                {  
                    cmd = new SqlCommand(@"INSERT INTO Statement(trId,account_id,account_number, account_type, username, debit, remarks, timestamp) VALUES(@id,@account_id,@account_number, @account_type, @username, @debit, @remarks, @timestamp)", conn);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dataReader["id"]));
                    cmd.Parameters.AddWithValue("@account_id", Convert.ToInt32(dataReader["account_id"]));
                    cmd.Parameters.AddWithValue("@account_number", dataReader["account_number"].ToString());
                    cmd.Parameters.AddWithValue("@account_type", dataReader["account_type"].ToString());
                    cmd.Parameters.AddWithValue("@username", dataReader["user_name"].ToString());
                    cmd.Parameters.AddWithValue("@debit", dataReader["amount"].ToString());
                    cmd.Parameters.AddWithValue("@remarks", dataReader["remarks"].ToString());
                    cmd.Parameters.AddWithValue("@timestamp", dataReader["timestamp"].ToString());
                    isInserted = cmd.ExecuteNonQuery();
                    if (isInserted > 0)
                    {
                        isReady = true;
                        error.InnerText = "ROW INSERTED";
                        Session["statement_acc_number"] = dataReader["account_number"].ToString();
                    }
                }




                //THIS WILL ADD ALL THE CREDITS FROM TRANSACTION TABLE IN A TEMPORARY TABLE STATEMENT
                cmd = new SqlCommand(@"SELECT tr.transactionId AS id,acc.account_id as account_id, acc.account_number as account_number,acc.account_type as account_type, acc.user_name as user_name, tr.amount as amount, tr.remarks as remarks, tr.timestamp as timestamp FROM [Transaction] tr INNER JOIN  Account acc ON (tr.receiver_account_id = acc.account_id) WHERE tr.receiver_account_id = @accountId", conn);

                cmd.Parameters.AddWithValue("@accountId", Convert.ToInt32(ddlPayeeAccountNumber.SelectedValue));
                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    cmd = new SqlCommand(@"INSERT INTO Statement(trId,account_id,account_number, account_type, username, credit, remarks, timestamp) VALUES
(@id,@account_id,@account_number, @account_type, @username, @credit, @remarks, @timestamp)", conn);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dataReader["id"]));
                    cmd.Parameters.AddWithValue("@account_id", Convert.ToInt32(dataReader["account_id"]));
                    cmd.Parameters.AddWithValue("@account_number", dataReader["account_number"].ToString());
                    cmd.Parameters.AddWithValue("@account_type", dataReader["account_type"].ToString());
                    cmd.Parameters.AddWithValue("@username", dataReader["user_name"].ToString());
                    cmd.Parameters.AddWithValue("@credit", dataReader["amount"].ToString());
                    cmd.Parameters.AddWithValue("@remarks", dataReader["remarks"].ToString());
                    cmd.Parameters.AddWithValue("@timestamp", dataReader["timestamp"].ToString());
                    isInserted = cmd.ExecuteNonQuery();
                    if (isInserted > 0)
                    {
                        isReady = true;
                        error.InnerText = "ROW INSERTED";
                    }
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
            

            return isReady;
        }

        void dropTable()
        {
            conn = new SqlConnection(Common_Function.GetDBConnectionString());

            try
            {
                conn.Open();
                cmd = new SqlCommand("DROP TABLE Statement", conn);
                int dTable = cmd.ExecuteNonQuery();

                if (dTable > 0)
                {
                    //logger
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
    }
}