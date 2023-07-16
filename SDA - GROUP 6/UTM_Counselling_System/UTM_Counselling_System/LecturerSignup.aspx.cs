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
    public partial class LecturerSignup : System.Web.UI.Page
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

                    sql = "Insert into Lecturer (LecturerName, LecturerEmail, LecturerPassword) " +
                                           " values(@LecturerName, @LecturerEmail, @LecturerPassword)"; //create


                    cmd.Connection = con;
                    cmd.CommandText = sql;


                    cmd.Parameters.AddWithValue("@LecturerName", (unmae.Value.Trim()));
                    cmd.Parameters.AddWithValue("@LecturerEmail", email.Value.Trim());
                    cmd.Parameters.AddWithValue("@LecturerPassword", pwd.Value.Trim());
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();


                    // clear controls
                    unmae.Value = "";
                    email.Value = "";
                    pwd.Value = "";

                    Response.Write("Message" + "<script> alert('Sign up completed, please login...') </script>");

                    Response.Redirect("LecturerLogin.aspx", false);



                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message + "<script> alert('Record not added...') </script>");
                }
            }
        }
    }
}