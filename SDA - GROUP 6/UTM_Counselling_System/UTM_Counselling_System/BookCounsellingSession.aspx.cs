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
    public partial class BookCounsellingSession : System.Web.UI.Page
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
            ddl_CounsellingLecturer.DataValueField = "LecturerID";
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

                try
                {
                    string sql = "";

                    string cnString = ConfigurationManager.ConnectionStrings["UTMCounsellingConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(cnString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand();

                    sql = "Insert into CounsellingSession (SessionDateTime, SessionReason, SessionStatus, LecturerID, StudentID) " +
                                           " values(@SessionDateTime, @SessionReason, @SessionStatus, @LecturerID, @StudentID)";



                    cmd.Connection = con;
                    cmd.CommandText = sql;

                    cmd.Parameters.AddWithValue("@SessionDateTime", Convert.ToDateTime(sessiondate.Value));
                    cmd.Parameters.AddWithValue("@SessionReason", tasessionreason.Value.Trim());
                    cmd.Parameters.AddWithValue("@SessionStatus", "Pending Confirmation");
                    cmd.Parameters.AddWithValue("@LecturerID", Convert.ToInt32(ddl_CounsellingLecturer.SelectedValue));
                    cmd.Parameters.AddWithValue("@StudentID", dt.Rows[0]["StudentID"]);

                    if (checkSameTiming(Convert.ToDateTime(sessiondate.Value), Convert.ToInt32(ddl_CounsellingLecturer.SelectedValue)) == true)
                    {
                        Response.Write("Message" + "<script> alert('Counselling Session Already booked for this time, try another date and time...') </script>");
                        dt = null;
                        return;
                    }
                          
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    
                    // clear controls                   

                    Response.Write("Message" + "<script> alert('Counselling Session Requested...') </script>");
                    dt = null;
                    Response.Redirect("StudentSessions.aspx", false);


                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message + "<script> alert('Record not added...') </script>");
                }
            }
        }


        private bool checkSameTiming(DateTime dtSessionDateTime, int LectureID)
        {

            bool IsSameTime = false;


            string cnString = ConfigurationManager.ConnectionStrings["UTMCounsellingConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cnString);
            SqlDataAdapter sqlAdp = new SqlDataAdapter("Select * from CounsellingSession " +
                                                       " WHERE SessionDateTime > '" + dtSessionDateTime.AddHours(-1).ToString("yyyy-MM-dd HH:mm:ss") + "' and SessionDateTime < '" + dtSessionDateTime.AddHours(+1).ToString("yyyy-MM-dd HH:mm:ss") +  "' " +
                                                        " AND LecturerID = " + LectureID + " ", con);
            SqlCommandBuilder bui = new SqlCommandBuilder(sqlAdp);
            DataTable dt = new DataTable();
            sqlAdp.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                return true;
            }

            return IsSameTime;
        }

       
    }
}