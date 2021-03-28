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
    public partial class AddSize : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBrand();
                BindMainCategory();
                BindGender();
                BindSizeRptr();
            }
        }

        private void BindSizeRptr()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyShopDB"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Select A.*, B.*,C.*,D.*,E.* from tblSizes A inner join tblCategory B on B.CatID=A.CategoryID  inner join tblBrands C on C.BrandID=A.BrandID inner join tblSubCategory D on D.SubCatID=A.SubCategoryID inner join tblGender E on E.GenderID=A.GenderID", con))
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        rptrSizes.DataSource = dataTable;
                        rptrSizes.DataBind();
                    }
                }
            }
        }

        private void BindMainCategory()
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyShopDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblCategory", con);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count != 0)
                {
                    ddlCategory.DataSource = dataTable;
                    ddlCategory.DataTextField = "CatName";
                    ddlCategory.DataValueField = "CatID";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                }

            }
        }

        private void BindBrand()
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyShopDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblBrands", con);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count != 0)
                {
                    ddlBrand.DataSource = dataTable;
                    ddlBrand.DataTextField = "Name";
                    ddlBrand.DataValueField = "BrandID";
                    ddlBrand.DataBind();
                    ddlBrand.Items.Insert(0, new ListItem("--Select--", "0"));
                }

            }
        }


        private void BindGender()
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyShopDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblGender with(nolock)", con);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count != 0)
                {
                    ddlGender.DataSource = dataTable;
                    ddlGender.DataTextField = "GenderName";
                    ddlGender.DataValueField = "GenderID";
                    ddlGender.DataBind();
                    ddlGender.Items.Insert(0, new ListItem("--Select--", "0"));
                }

            }
        }



        protected void btnAddSize_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyShopDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into tblSizes(SizeName,BrandID,CategoryID,SubCategoryID,GenderID)Values('" + textSize.Text + "', '" + ddlBrand.SelectedItem.Value + "', '" + ddlCategory.SelectedItem.Value + "', '" + ddlSubCategory.SelectedItem.Value + "', '" + ddlGender.SelectedItem.Value + "')", con);
                cmd.ExecuteNonQuery();

                Response.Write("<script>alert('Size Added Successfully.');</script>");
                textSize.Text = string.Empty;
                con.Close();
                ddlBrand.ClearSelection();
                ddlBrand.Items.FindByValue("0").Selected = true;

                ddlCategory.ClearSelection();
                ddlCategory.Items.FindByValue("0").Selected = true;

                ddlSubCategory.ClearSelection();
                ddlSubCategory.Items.FindByValue("0").Selected = true;

                ddlGender.ClearSelection();
                ddlGender.Items.FindByValue("0").Selected = true;

            }
            BindSizeRptr();
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int MainCategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);


            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyShopDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblSubCategory where MainCatID='"+ddlCategory.SelectedItem.Value+"'", con);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count != 0)
                {
                    ddlSubCategory.DataSource = dataTable;
                    ddlSubCategory.DataTextField = "SubCatName";
                    ddlSubCategory.DataValueField = "SubCatID";
                    ddlSubCategory.DataBind();
                    ddlSubCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                }

            }
        }
    }
}