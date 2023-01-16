using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_CW_K2221328_ABCBankingGroup
{
    public partial class MainMenu : System.Web.UI.MasterPage
    {

        //Sql Connection Command
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["userId"] != null)
                {
                    Utils utils = new Utils();
                    lblBalance.Text = "BALANCE " + utils.accountBalance(Convert.ToInt32(Session["userId"])).ToString();
                }
                if (Session["user_type"] != null)
                {
                    if (Session["user_type"].ToString() == "admin")
                    {
                        hlUser.Visible = false;
                        hlEmployee.Visible = false ;
                        hlDeposit.Visible = false ;
                        hlWithdrawl.Visible = false ;
                        hlStatement.Visible = false ;
                    }
                    if(Session["user_type"].ToString() == "emp")
                    {
                        adminDashboard.Visible = false;
                        hlAdmin.Visible = false;
                        hlUser.Visible = false;
                        hlTransaction.Visible = false;
                        hlCredits.Visible = false;
                        hlDebits.Visible = false;
                        lblBalance.Visible = false;
                    }
                    if (Session["user_type"].ToString() == "user")
                    {
                        adminDashboard.Visible = false;
                        hlAdminData.Visible = false;
                        hlAdmin.Visible = false;
                        hlEmployee.Visible = false;
                        hlDeposit.Visible = false;
                        hlWithdrawl.Visible = false;
                        hlStatement.Visible = false;
                    }

                }
                else
                {
                    hlAdminData.Visible = false;
                    hlAdmin.Visible = false;
                    hlEmployee.Visible = false;
                }
            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}