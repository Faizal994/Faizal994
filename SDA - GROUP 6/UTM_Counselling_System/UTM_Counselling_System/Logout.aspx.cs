using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UTM_Counselling_System
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["StudentInfo"] = null;
                Session["LecturerInfo"] = null;
                Response.Redirect("Default.aspx", false);
            }
        }
    }
}