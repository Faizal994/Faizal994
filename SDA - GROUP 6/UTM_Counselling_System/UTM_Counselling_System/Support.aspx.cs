using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UTM_Counselling_System
{
    public partial class Support : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["StudentInfo"] == null)
                {
                    Response.Redirect("StudentLogin.aspx", false);
                    return;
                }


                LoadLecturer();
            }
        }
    


        void LoadLecturer()
        {
            //return DataTable havinf MenuCategory data
            string cnString = ConfigurationManager.ConnectionStrings["UTMCounsellingConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cnString);
            SqlDataAdapter adap = new SqlDataAdapter("Select * from Lecturer", con);
            SqlCommandBuilder bui = new SqlCommandBuilder(adap);
            DataTable dt = new DataTable();
            adap.Fill(dt);



            ddl_CounsellingLecturer.DataSource = dt;
            ddl_CounsellingLecturer.DataTextField = "LecturerName";
            ddl_CounsellingLecturer.DataValueField = "LecturerEmail";
            ddl_CounsellingLecturer.DataBind();

            ListItem lst = new ListItem("--Select Counselling Lecturer--", "0");
            ddl_CounsellingLecturer.Items.Insert(0, lst);

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)Session["StudentInfo"];


                string to = ddl_CounsellingLecturer.SelectedValue; //To address    
                string from = dt.Rows[0]["StudentEmail"].ToString(); //From address    
                MailMessage message = new MailMessage(from, to);

                string mailbody = tasupportreason.Value;
                message.Subject = "Support Request";
                message.Body = mailbody;
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
                System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential("km.assignment.services@gmail.com", "bwjsmmiqmsykytoc");
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential1;
                try
                {
                    client.Send(message);
                    Response.Write("Message" + "<script> alert('Support Email Sent...') </script>");
                    dt = null;
                    tasupportreason.Value = "";
                    ddl_CounsellingLecturer.SelectedIndex = 0;
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message + "<script> alert('Error sending email...') </script>");
                    
                }


               
            }
        }
    }
}
