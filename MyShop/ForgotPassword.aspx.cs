using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;

namespace MyShop
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResetPass_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyShopDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblusers where Email=@Email", con);
                cmd.Parameters.AddWithValue("@Email", textEmailID.Text);

                
                SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                sqlData.Fill(dataTable);

                if (dataTable.Rows.Count != 0)
                {
                    string myGUID = Guid.NewGuid().ToString();
                    int Uid = Convert.ToInt32(dataTable.Rows[0][0]);
                    SqlCommand cmd1 = new SqlCommand("Insert into ForgotPass(Id,Uid,RequestDateTime)Values('"+myGUID+"','"+Uid+"',GETDATE())", con);
                    cmd1.ExecuteNonQuery();


                    //Send Reset link via Email

                    string ToEmailAddress =dataTable.Rows[0][3].ToString();
                    string Username = dataTable.Rows[0][1].ToString();
                    string EmailBody ="Hi ,"+Username+ ", <br/><br/>Click the link below to reset password<br/><br/>https://localhost:44331/RecoverPassword.aspx?id="+myGUID;

                    MailMessage PassRecMail = new MailMessage("juwelvai6@gmail.com", ToEmailAddress);
                    PassRecMail.Body = EmailBody;
                    PassRecMail.IsBodyHtml = true;
                    PassRecMail.Subject = "Reset Password";
                    PassRecMail.Priority = MailPriority.High;


                    using (SmtpClient client = new SmtpClient())
                    {
                        client.EnableSsl = true;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential("juwelvai6@gmail.com", "018373940");
                        client.Host = "smtp.gmail.com";
                        client.Port = 587;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;

                        client.Send(PassRecMail);
                    }

                    //SmtpClient SMTP = new SmtpClient("smtp.gmail.com", 587);
                    //SMTP.Credentials = new NetworkCredential()
                    //{
                    //    UserName = "jubayarvaigmail.com",
                    //    Password = "018373940@j"
                    //};
                    //SMTP.EnableSsl = true;
                    //SMTP.Send(PassRecMail);
                    //--------------



                    lblResetPassMsg.Text = "Reset Link send! Check Your Email For Reset Password ";
                    lblResetPassMsg.ForeColor = System.Drawing.Color.Green;
                    textEmailID.Text = string.Empty;
                }
                else
                {
                    lblResetPassMsg.Text = "OOps! This Email Does not Exist... Try again";
                    lblResetPassMsg.ForeColor = System.Drawing.Color.Red;
                    textEmailID.Text = string.Empty;
                    textEmailID.Focus();
                }
            }
        }
    }
}