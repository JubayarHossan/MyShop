using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace MyShop
{
    public partial class AddGender : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGenderRptr();
        }

        private void BindGenderRptr()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyShopDB"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select * from tblGender", con))
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        rptrGender.DataSource = dataTable;
                        rptrGender.DataBind();
                    }
                }
            }
        }
        protected void btnAddGender_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyShopDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into tblGender(GenderName)Values('" + textGender.Text + "')", con);
                cmd.ExecuteNonQuery();

                Response.Write("<script>alert('Gender Added Successfully.');</script>");
                textGender.Text = string.Empty;
                con.Close();
                textGender.Focus();

            }
            BindGenderRptr();
        }
    }
}