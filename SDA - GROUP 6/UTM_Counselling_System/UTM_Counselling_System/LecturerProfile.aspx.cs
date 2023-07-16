using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UTM_Counselling_System
{
    public partial class LecturerProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Session["LecturerInfo"] == null)
                {
                    Response.Redirect("LecturerLogin.aspx", false);
                    return;
                }
                    
                


                if (Session["LecturerInfo"] != null)
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)Session["LecturerInfo"];

                    unmae.Value = dt.Rows[0]["LecturerName"].ToString();
                    email.Value = dt.Rows[0]["LecturerEmail"].ToString();

                    if (dt.Rows[0]["LecturerPhone"].ToString() != String.Empty)
                    {
                        phone.Value = dt.Rows[0]["LecturerPhone"].ToString();
                        selectgender.Value = dt.Rows[0]["LecturerGender"].ToString();
                        role.Value = dt.Rows[0]["LecturerRole"].ToString();                        
                        selectdepartment.Value = dt.Rows[0]["LecturerDepartment"].ToString();
                        taOtherDetails.Value = dt.Rows[0]["LecturerProfileDescirption"].ToString();
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)Session["LecturerInfo"];

                try
                {
                    string sql = "";

                    string cnString = ConfigurationManager.ConnectionStrings["UTMCounsellingConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(cnString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand();

                    sql = "Update Lecturer Set LecturerName = @LecturerName, LecturerEmail = @LecturerEmail, LecturerPhone = @LecturerPhone, LecturerGender = @LecturerGender, LecturerRole = @LecturerRole, " +
                                           " LecturerDepartment = @LecturerDepartment, LecturerProfileDescirption = @LecturerProfileDescirption WHERE LecturerID = @LecturerID"; //update

                    cmd.Connection = con;
                    cmd.CommandText = sql;

                    cmd.Parameters.AddWithValue("@LecturerName", (unmae.Value.Trim()));
                    cmd.Parameters.AddWithValue("@LecturerEmail", email.Value.Trim());
                    cmd.Parameters.AddWithValue("@LecturerPhone", phone.Value.Trim());
                    cmd.Parameters.AddWithValue("@LecturerGender", (selectgender.Value.Trim()));
                    cmd.Parameters.AddWithValue("@LecturerRole", role.Value.Trim());                    
                    cmd.Parameters.AddWithValue("@LecturerDepartment", (selectdepartment.Value.Trim()));
                    cmd.Parameters.AddWithValue("@LecturerProfileDescirption", taOtherDetails.Value.Trim());
                    cmd.Parameters.AddWithValue("@LecturerID", dt.Rows[0]["LecturerID"]);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();




                    SqlDataAdapter sqlAdp = new SqlDataAdapter("Select * from Lecturer Where LecturerEmail = '" + email.Value.Trim()  + "'", con); //read
                    SqlCommandBuilder bui = new SqlCommandBuilder(sqlAdp);
                    DataTable dtLecturer = new DataTable();
                    sqlAdp.Fill(dtLecturer);
                    Session["LecturerInfo"] = dtLecturer;

                    // clear controls                   

                    Response.Write("Message" + "<script> alert('Profile Updated Successfully...') </script>");
                    dt = null;


                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message + "<script> alert('Record not added...') </script>");
                }
            }
        }
    }
}