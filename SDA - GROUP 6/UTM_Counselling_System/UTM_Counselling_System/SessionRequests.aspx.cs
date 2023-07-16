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
    public partial class SessionRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LecturerInfo"] == null)
                {
                    Response.Redirect("LecturerLogin.aspx", false);
                    return;
                }
                // Call FillGridView Method
                FillGridView();
            }
        }


        public void FillGridView()
        {
            try
            {
                DataTable dt = new DataTable(); //part of data layer
                if (Session["LecturerInfo"] != null)
                {
                    dt = (DataTable)Session["LecturerInfo"];
                }

                string cnString = ConfigurationManager.ConnectionStrings["UTMCounsellingConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cnString);
                SqlDataAdapter sqlAdp = new SqlDataAdapter("Select CounsellingSession.SessionID, Student.StudentName, CounsellingSession.SessionReason, CounsellingSession.SessionDateTime, CounsellingSession.SessionStatus From CounsellingSession " +
                                                           " INNER JOIN Lecturer ON CounsellingSession.LecturerID = Lecturer.LecturerID " +
                                                           " INNER JOIN Student ON CounsellingSession.StudentID = Student.StudentID " +
                                                           "  WHERE CounsellingSession.LecturerID = '" + dt.Rows[0]["LecturerID"] + "' Order By CounsellingSession.SessionID Desc  ", con);

                SqlCommandBuilder bui = new SqlCommandBuilder(sqlAdp);
                DataTable dtSession = new DataTable(); //part of data layer
                sqlAdp.Fill(dtSession);


                GridViewSession.DataSource = dtSession;
                GridViewSession.DataBind();
            }
            catch
            {
                Response.Write("<script> alert('Connection String Error...') </script>");
            }
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Confirm") // appliation relate code
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = GridViewSession.Rows[rowIndex];

                //Fetch value of Name.
                string SessionID = (row.FindControl("lblId") as Label).Text;



                string sql = "";

                string cnString = ConfigurationManager.ConnectionStrings["UTMCounsellingConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cnString);
                con.Open();
                SqlCommand cmd = new SqlCommand();

                sql = "Update CounsellingSession set SessionStatus = @Status Where SessionID = @SessionID";
                cmd.Parameters.AddWithValue("@SessionID", SessionID);


                cmd.Connection = con;
                cmd.CommandText = sql;


                cmd.Parameters.AddWithValue("@Status", "Confirmed");
                cmd.ExecuteNonQuery();
                cmd.Dispose();



                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Session Confirmed');", true);//application relted code
                GridViewSession.DataSource = null;
                GridViewSession.DataBind();
                FillGridView();
            }
        }



    }
}