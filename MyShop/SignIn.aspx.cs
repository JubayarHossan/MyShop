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
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Request.Cookies["UNAME"]!=null && Request.Cookies["UPWD"] != null)
                {
                    textUsername.Text= Request.Cookies["UNAME"].Value;
                    textPass.Text= Request.Cookies["UPWD"].Value;
                    CheckBox1.Checked = true;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyShopDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblusers where Username=@username and Password=@pwd", con);
                cmd.Parameters.AddWithValue("@username", textUsername.Text);

                cmd.Parameters.AddWithValue("@pwd", textPass.Text);
                SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                sqlData.Fill(dataTable);
                if(dataTable.Rows.Count !=0)
                {
                    if (CheckBox1.Checked)
                    {
                        Response.Cookies["UNAME"].Value = textUsername.Text;
                        Response.Cookies["UPWD"].Value = textPass.Text;
                        
                        Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(10);
                        Response.Cookies["UPWD"].Expires = DateTime.Now.AddDays(10);
                    }
                    else
                    {
                        Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["UPWD"].Expires = DateTime.Now.AddDays(-1);
                    }

                    string Utype=dataTable.Rows[0][5].ToString().Trim();
                    if (Utype == "User")
                    {
                        Session["Username"] = textUsername.Text;
                        Response.Redirect("~/UserHome.aspx");
                    }

                    if (Utype == "Admin")
                    {
                        Session["Username"] = textUsername.Text;
                        Response.Redirect("~/AdminHome.aspx");
                    }
                }
                else
                {
                    lblError.Text = "Invalid Username and password";
                }

                //Response.Write("<script>alert('Login Successfully Done.');</script>");
                clr();
                con.Close();
                //lblMsg.Text = "Registration Successfully Done.";
               // lblMsg.ForeColor = System.Drawing.Color.Green;
                //Response.Redirect("~/SignIn.aspx");
            }
        }

        private void clr()
        {
            textUsername.Text = string.Empty;
            textPass.Text = string.Empty;
            textUsername.Focus();
        }
    }
}