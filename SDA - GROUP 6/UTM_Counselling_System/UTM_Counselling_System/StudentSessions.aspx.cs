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
    public partial class StudentSessions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["StudentInfo"] == null)
                {
                    Response.Redirect("StudentLogin.aspx", false);
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
                DataTable dt = new DataTable();
                if (Session["StudentInfo"] != null)
                {                   
                    dt = (DataTable)Session["StudentInfo"];
                }

                string cnString = ConfigurationManager.ConnectionStrings["UTMCounsellingConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cnString);
                SqlDataAdapter sqlAdp = new SqlDataAdapter("Select * From CounsellingSession " +
                                                           " INNER JOIN Lecturer ON CounsellingSession.LecturerID = Lecturer.LecturerID " +
                                                           " INNER JOIN Student ON CounsellingSession.StudentID = Student.StudentID " +
                                                           "  WHERE CounsellingSession.StudentID = '" + dt.Rows[0]["StudentID"] + "' Order By CounsellingSession.SessionID Desc  ", con);

                SqlCommandBuilder bui = new SqlCommandBuilder(sqlAdp);
                DataTable dtSession = new DataTable();
                sqlAdp.Fill(dtSession);


                GridViewSession.DataSource = dtSession;
                GridViewSession.DataBind();
            }
            catch
            {
                Response.Write("<script> alert('Connection String Error...') </script>");
            }
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookCounsellingSession.aspx", false);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "CancelSession")
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
                cmd.Parameters.AddWithValue("@SessionID", SessionID); // virtual delete/ not physical delet from the database


                cmd.Connection = con;
                cmd.CommandText = sql;


                cmd.Parameters.AddWithValue("@Status", "Cancelled");
                cmd.ExecuteNonQuery();
                cmd.Dispose();



                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Session Cancelled');", true);
                GridViewSession.DataSource = null;
                GridViewSession.DataBind();
                FillGridView();
            }
        }

        protected void grd_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridViewSession_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}