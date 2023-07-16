using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UTM_Counselling_System
{
    public partial class StudentSignup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string sql = "";

                   

                    string cnString = ConfigurationManager.ConnectionStrings["UTMCounsellingConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(cnString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand();

                    sql = "Insert into Student (StudentName, StudentEmail, StudentPassword) " +
                                           " values(@StudentName, @StudentEmail, @StudentPassword)";


                    cmd.Connection = con;
                    cmd.CommandText = sql;


                    cmd.Parameters.AddWithValue("@StudentName", (unmae.Value.Trim()));
                    cmd.Parameters.AddWithValue("@StudentEmail", email.Value.Trim());
                    cmd.Parameters.AddWithValue("@StudentPassword", pwd.Value.Trim());                                        
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();





                    // clear controls
                    unmae.Value = "";
                    email.Value = "";
                    pwd.Value = "";

                    Response.Write("Message" + "<script> alert('Sign up completed, please login...') </script>");

                    Response.Redirect("StudentLogin.aspx", false);



                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message + "<script> alert('Record not added...') </script>");
                }
            }
        }
    }
}