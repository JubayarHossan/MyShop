using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MyShop
{
    public partial class RecoverPassword : System.Web.UI.Page
    {
        string GUIDValue;
        DataTable dataTable = new DataTable();
        int Uid;
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyShopDB"].ConnectionString))
            {
                con.Open();
                GUIDValue = Request.QueryString["id"];
                if (GUIDValue != null)
                {
                    SqlCommand cmd = new SqlCommand("select * from ForgotPass where Id=@Id",con);

                    cmd.Parameters.AddWithValue("@Id", GUIDValue);
                    SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
                   
                    sqlData.Fill(dataTable);
                    if (dataTable.Rows.Count!=0)
                    {
                        Uid = Convert.ToInt32(dataTable.Rows[0][1]);
                    }
                    else
                    {

                        lblmsg.Text = "Your Password Reset Link is Expired or invalid... try again. ";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            if (!IsPostBack)
            {
                if (dataTable.Rows.Count != 0)
                {
                    textNewPass.Visible = true;
                    textConfirmPass.Visible = true;
                    lblNewPass.Visible = true;
                    lblConfirmPass.Visible = true;
                    btnResetPass.Visible = true;
                }
                else
                {
                    lblmsg.Text = "Your Password Reset Link is Expired or invalid... try again. ";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void btnResetPass_Click(object sender, EventArgs e)
        {
            if (textNewPass.Text !="" && textConfirmPass.Text!=""&& textNewPass.Text==textConfirmPass.Text)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyShopDB"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update tblusers set Password=@p where Uid=@Uid", con);
                    cmd.Parameters.AddWithValue("@p", textNewPass.Text);
                    cmd.Parameters.AddWithValue("@Uid", Uid);
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("delete form ForgotPass where Uid='" + Uid + "'", con);
                    cmd2.ExecuteNonQuery();
                    Response.Write("<script> alert('Password Reset Successfully done.') <script/>");
                    Response.Redirect("~/SignIn.aspx");
                }
            }
        }
    }
}