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
    public partial class AddCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCategoryReapter();
        }

        private void BindCategoryReapter()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyShopDB"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select * from tblCategory", con))
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        rptrCategory.DataSource = dataTable;
                        rptrCategory.DataBind();
                    }
                }
            }
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyShopDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into tblCategory(CatName)Values('" + textCategory.Text + "')", con);
                cmd.ExecuteNonQuery();

                Response.Write("<script>alert('Category Added Successfully.');</script>");
                textCategory.Text = string.Empty;
                con.Close();
                //lblMsg.Text = "Registration Successfully Done.";
                //lblMsg.ForeColor = System.Drawing.Color.Green;
                textCategory.Focus();
            }
            BindCategoryReapter();
        }
    }
}