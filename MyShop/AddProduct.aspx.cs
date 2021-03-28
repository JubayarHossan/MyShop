using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace MyShop
{
    public partial class AddProduct : System.Web.UI.Page
    {
        public static String CS = ConfigurationManager.ConnectionStrings["MyShopDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBrand();
                BindCategory();
                BindGender();
                ddlSubCategory.Enabled = false;
                ddlGender.Enabled = false;
            }
        }
        private void BindCategory()
        {

            using (SqlConnection con = new SqlConnection(CS))
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

            using (SqlConnection con = new SqlConnection(CS))
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

            using (SqlConnection con = new SqlConnection(CS))
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertProducts", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PName",textProductName.Text);
                cmd.Parameters.AddWithValue("@PPrice",textPrice.Text);
                cmd.Parameters.AddWithValue("@PSelPrice", textSellPrice.Text);
                cmd.Parameters.AddWithValue("@PBrandID", ddlBrand.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@PCategoryID", ddlCategory.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@PSubCatID", ddlSubCategory.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@PGenderID", ddlGender.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@PDescription", textDescription.Text);
                cmd.Parameters.AddWithValue("@PProductDetails", textPDetails.Text);
                cmd.Parameters.AddWithValue("@PMaterialCare", txtMatCare.Text);
                if (chFD.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@FreeDelivery", 1.ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@FreeDelivery", 0.ToString());
                }

                if (ch30Ret.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@30DayRet", 1.ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@30DayRet", 0.ToString());
                }

                if (chbCOD.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@COD", 1.ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@COD", 0.ToString());
                }
                con.Open();
                Int64 PID = Convert.ToInt64(cmd.ExecuteScalar());

                //Isert Size Quantity
                for (int i = 0; i < cblSize.Items.Count; i++)
                {
                    if (cblSize.Items[i].Selected == true)
                    {
                        Int64 SizeID = Convert.ToInt64(cblSize.Items[i].Value);
                        int Quantity = Convert.ToInt32(textQuantity.Text);
                        SqlCommand cmd2 = new SqlCommand("Insert into tblProductSizeQuantity Values('" + PID + "','" + SizeID + "','" + Quantity + "')", con);
                        cmd2.ExecuteNonQuery();
                    }
                    
                }
                //insert and uploaded images
                if (fileUploadImg01.HasFile)
                {
                    string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
                    if (!Directory.Exists(SavePath))
                    {
                        Directory.CreateDirectory(SavePath);
                    }
                    string Extention = Path.GetExtension(fileUploadImg01.PostedFile.FileName);
                    fileUploadImg01.SaveAs(SavePath + "//" + textProductName.Text.ToString().Trim() + "01");

                    SqlCommand cmd3 = new SqlCommand("Insert into tblProductImages Values('" + PID + "','" + textProductName.Text.ToString().Trim() +"01"+ "','" + Extention + "')", con);
                    cmd3.ExecuteNonQuery();
                }

                //2nd file upload
                if (fileUploadImg02.HasFile)
                {
                    string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
                    if (!Directory.Exists(SavePath))
                    {
                        Directory.CreateDirectory(SavePath);
                    }
                    string Extention = Path.GetExtension(fileUploadImg02.PostedFile.FileName);
                    fileUploadImg02.SaveAs(SavePath + "//" + textProductName.Text.ToString().Trim() + "02");

                    SqlCommand cmd4 = new SqlCommand("Insert into tblProductImages Values('" + PID + "','" + textProductName.Text.ToString().Trim() + "02" + "','" + Extention + "')", con);
                    cmd4.ExecuteNonQuery();
                }

                //3rd file upload
                if (fileUploadImg03.HasFile)
                {
                    string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
                    if (!Directory.Exists(SavePath))
                    {
                        Directory.CreateDirectory(SavePath);
                    }
                    string Extention = Path.GetExtension(fileUploadImg03.PostedFile.FileName);
                    fileUploadImg03.SaveAs(SavePath + "//" + textProductName.Text.ToString().Trim() + "03");

                    SqlCommand cmd5 = new SqlCommand("Insert into tblProductImages Values('" + PID + "','" + textProductName.Text.ToString().Trim() + "03" + "','" + Extention + "')", con);
                    cmd5.ExecuteNonQuery();
                }

                //4th file upload
                if (fileUploadImg04.HasFile)
                {
                    string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
                    if (!Directory.Exists(SavePath))
                    {
                        Directory.CreateDirectory(SavePath);
                    }
                    string Extention = Path.GetExtension(fileUploadImg04.PostedFile.FileName);
                    fileUploadImg04.SaveAs(SavePath + "//" + textProductName.Text.ToString().Trim() + "04");

                    SqlCommand cmd6 = new SqlCommand("Insert into tblProductImages Values('" + PID + "','" + textProductName.Text.ToString().Trim() + "04" + "','" + Extention + "')", con);
                    cmd6.ExecuteNonQuery();
                }

                //5th file upload
                if (fileUploadImg05.HasFile)
                {
                    string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
                    if (!Directory.Exists(SavePath))
                    {
                        Directory.CreateDirectory(SavePath);
                    }
                    string Extention = Path.GetExtension(fileUploadImg05.PostedFile.FileName);
                    fileUploadImg05.SaveAs(SavePath + "//" + textProductName.Text.ToString().Trim() + "05");

                    SqlCommand cmd7 = new SqlCommand("Insert into tblProductImages Values('" + PID + "','" + textProductName.Text.ToString().Trim() + "05" + "','" + Extention + "')", con);
                    cmd7.ExecuteNonQuery();
                }
            }
            clr();


        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSubCategory.Enabled = true;
            int MainCategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);


            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblSubCategory where MainCatID='" + ddlCategory.SelectedItem.Value + "'", con);

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

        protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblSizes where BrandID='" + ddlBrand.SelectedItem.Value + "' and CategoryID='" + ddlCategory.SelectedItem.Value + "' and SubCategoryID='" + ddlSubCategory.SelectedItem.Value + "' and GenderID='" + ddlGender.SelectedItem.Value + "'", con);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count != 0)
                {
                    cblSize.DataSource = dataTable;
                    cblSize.DataTextField = "SizeName";
                    cblSize.DataValueField = "SizeID";
                    cblSize.DataBind();
                   
                }

            }
        }

        protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlSubCategory.SelectedIndex != 0)
            {
                ddlGender.Enabled = true;
            }
            else
            {
                ddlGender.Enabled = false;
            }
        }
         private void clr()
        {
            textProductName.Text = string.Empty;
            textPrice.Text = string.Empty;
            textSellPrice.Text = string.Empty;
            ddlBrand.Items.Clear();
            ddlCategory.Items.Clear();
            ddlSubCategory.Items.Clear();
            ddlGender.Items.Clear();
            cblSize.Items.Clear();
            textQuantity.Text = string.Empty;
            textDescription.Text = string.Empty;
            textPDetails.Text = string.Empty;
            txtMatCare.Text = string.Empty;
            ch30Ret.Checked = false;
            chFD.Checked = false;
            chbCOD.Checked = false;
           

        }
    }
}