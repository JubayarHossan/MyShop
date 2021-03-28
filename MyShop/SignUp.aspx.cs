using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;

namespace MyShop
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void textsignup_Click(object sender, EventArgs e)
        {
            if (isformvalid())
            {
                using(SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["MyShopDB"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into tblusers(Username,Password,Email,Name,Usertype)Values('" + textUname.Text + "','" + textPass.Text + "','" + textEmail.Text + "','" + textName.Text + "','User')", con);
                    cmd.ExecuteNonQuery();

                    Response.Write("<script>alert('Registration Successfully Done.');</script>");
                    clr();
                    con.Close();
                    lblMsg.Text = "Registration Successfully Done.";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    Response.Redirect("~/SignIn.aspx");
                }
                Response.Redirect("~/SignIn.aspx");
            }
            else
            {
                Response.Write("<script>alert('Registration Failed.');</script>");
                lblMsg.Text = "All fields are mandatory.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }

        }

        private bool isformvalid()
        {
            if (textUname.Text == "")
            {
                
                Response.Write("<script>alert('username not valid');</script>");
                textUname.Focus();
                return false;
            }
            else if (textPass.Text == "")
            {
                Response.Write("<script>alert('Password not valid');</script>");
                textPass.Focus();
                return false;
            }
            else if (textPass.Text != textCPass.Text)
            {
                Response.Write("<script>alert('Confirm Password not valid');</script>");
                textCPass.Focus();
                return false;
            }
            else if (textEmail.Text == "")
            {
                Response.Write("<script>alert('Email not valid');</script>");
                textEmail.Focus();
                return false;
            }
            else if (textName.Text == "")
            {
                Response.Write("<script>alert('Name not valid');</script>");
                textName.Focus();
                return false;
            }
            return true;
        }

        private void clr()
        {
            textUname.Text = string.Empty;
            textPass.Text = string.Empty;
            textCPass.Text = string.Empty;
            textName.Text = string.Empty;
            textEmail.Text = string.Empty;
        }
    }
}