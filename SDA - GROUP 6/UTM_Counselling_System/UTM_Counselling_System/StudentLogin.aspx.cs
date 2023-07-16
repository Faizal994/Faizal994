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
    public partial class StudentLogin : System.Web.UI.Page
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
                    string cnString = ConfigurationManager.ConnectionStrings["UTMCounsellingConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(cnString);
                    SqlDataAdapter sqlAdp = new SqlDataAdapter("Select * from Student Where StudentEmail = '" + email.Value.Trim() + "' And StudentPassword = '" + pwd.Value.Trim() + "' " , con);
                    SqlCommandBuilder bui = new SqlCommandBuilder(sqlAdp);
                    DataTable dt = new DataTable();
                    sqlAdp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        Session["StudentInfo"] = dt;

                        

                        if (dt.Rows[0]["StudentPhone"].ToString() == String.Empty)
                        {
                            Response.Redirect("StudentProfile.aspx", false);
                        }
                        else
                        {
                            Response.Redirect("StudentSessions.aspx", false);
                        }
                    }
                    else
                    {
                        String Message;
                        Message = "<script>alert('Login UnSuccessful...')</script>";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "temp", Message, false);
                        email.Focus();
                    }

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message + "<script> alert('Record not added...') </script>");
                }
            }
        }


    }
}