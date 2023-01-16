using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_CW_K2221328_ABCBankingGroup
{
    public partial class ForgotPassword : System.Web.UI.Page
    {

        //Sql Connection Command
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getUserSecurityAnswer();
            }
        }

        void getUserSecurityAnswer()
        {
            if (Session["forgotpassword"] != null)
            {
                conn = new SqlConnection(Common_Function.GetDBConnectionString());
                cmd = new SqlCommand(@"SELECT sq.question_value AS Security_Question, a.user_value AS Answer FROM Account a INNER JOIN security_question sq ON a.question_id = sq.question_id WHERE user_name = @username", conn);

                cmd.Parameters.AddWithValue("@username",Session["forgotpassword"].ToString() );
                try
                {
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    bool isTrue = false;

                    //goto DB and fetch the data for the Username
                    while (reader.Read())
                    {
                        isTrue = true;
                        lblUsername.Text = Session["forgotpassword"].ToString();
                        lblSecurityQuestion.Text = reader["Security_Question"].ToString();

                        hdnAnswer.Value = reader["Answer"].ToString();
                    }

                    //No Data found
                    if (!isTrue)
                    {
                        error.InnerText = "Invalid User Name provided";
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
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if(txtAnswer.Text.Trim() == hdnAnswer.Value)
            {
                Response.Redirect("ChangePassword.aspx");
            }
            else
            {
                error.InnerText = "Invalid Input provided";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}