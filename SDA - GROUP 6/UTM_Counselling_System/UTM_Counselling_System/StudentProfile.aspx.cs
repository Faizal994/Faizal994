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
    public partial class StudentProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["StudentInfo"] != null)
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)Session["StudentInfo"];

                    unmae.Value = dt.Rows[0]["StudentName"].ToString();
                    email.Value = dt.Rows[0]["StudentEmail"].ToString();

                    if (dt.Rows[0]["StudentPhone"].ToString() != String.Empty)
                    {
                        phone.Value = dt.Rows[0]["StudentPhone"].ToString();
                        selectgender.Value = dt.Rows[0]["StudentGender"].ToString();
                        matricnumber.Value = dt.Rows[0]["StudentMatricNumber"].ToString();
                        age.Value = dt.Rows[0]["StudentAge"].ToString();
                        selectdepartment.Value = dt.Rows[0]["StudentDepartment"].ToString();
                        taOtherDetails.Value = dt.Rows[0]["StudentProfileDescription"].ToString();
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)Session["StudentInfo"];

                try
                {
                    string sql = "";

                    string cnString = ConfigurationManager.ConnectionStrings["UTMCounsellingConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(cnString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand();

                    sql = "Update Student Set StudentName = @StudentName, StudentEmail = @StudentEmail, StudentPhone = @StudentPhone, StudentGender = @StudentGender, StudentMatricNumber = @StudentMatricNumber, " +
                                           " StudentAge = @StudentAge, StudentDepartment = @StudentDepartment, StudentProfileDescription = @StudentProfileDescription WHERE StudentID = @StudentID";

                    cmd.Connection = con;
                    cmd.CommandText = sql;

                    cmd.Parameters.AddWithValue("@StudentName", (unmae.Value.Trim()));
                    cmd.Parameters.AddWithValue("@StudentEmail", email.Value.Trim());
                    cmd.Parameters.AddWithValue("@StudentPhone", phone.Value.Trim());
                    cmd.Parameters.AddWithValue("@StudentGender", (selectgender.Value.Trim()));
                    cmd.Parameters.AddWithValue("@StudentMatricNumber", matricnumber.Value.Trim());
                    cmd.Parameters.AddWithValue("@StudentAge", age.Value.Trim());
                    cmd.Parameters.AddWithValue("@StudentDepartment", (selectdepartment.Value.Trim()));
                    cmd.Parameters.AddWithValue("@StudentProfileDescription", taOtherDetails.Value.Trim());
                    cmd.Parameters.AddWithValue("@StudentID", dt.Rows[0]["StudentID"]);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();



                    
                    SqlDataAdapter sqlAdp = new SqlDataAdapter("Select * from Student Where StudentEmail = '" + email.Value.Trim() + "'", con);
                    SqlCommandBuilder bui = new SqlCommandBuilder(sqlAdp);
                    DataTable dtStudent = new DataTable();
                    sqlAdp.Fill(dtStudent);
                    Session["StudentInfo"] = dtStudent;

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