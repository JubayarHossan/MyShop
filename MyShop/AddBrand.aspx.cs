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
    public partial class AddBrand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindBrandRepeater();
        }

        private void BindBrandRepeater()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyShopDB"].ConnectionString))
            {
                using(SqlCommand cmd= new SqlCommand("select * from tblBrands",con))
                {
                    using(SqlDataAdapter sqlDataAdapter=new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        rptrBrands.DataSource = dataTable;
                        rptrBrands.DataBind();
                    }
                }
            }
        }

        protected void btnAddBrand_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyShopDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into tblBrands(Name)Values('" + textBrandName.Text + "')", con);
                cmd.ExecuteNonQuery();

                Response.Write("<script>alert('Brand Added Successfully.');</script>");
                textBrandName.Text = string.Empty;
                con.Close();
                //lblMsg.Text = "Registration Successfully Done.";
                //lblMsg.ForeColor = System.Drawing.Color.Green;
                textBrandName.Focus();
            }
            BindBrandRepeater();
        }
    }
}