using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace UTM_Counselling_System
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["LecturerInfo"] == null)
                {
                    Response.Redirect("StudentLogin.aspx", false);
                    return;
                }

                LoadChartPendingSessionsCurrentMonth();
                LoadChartConfirmedCurrentMonth();
               // PopulateChart();
            }
        }

        private void LoadChartPendingSessionsCurrentMonth()
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["UTMCounsellingConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Select  FORMAT (CAST(SessionDateTime as DATE), 'dd') as Date, Count(SessionID) as [Total] " +
                                                        " from CounsellingSession Where  datepart(mm, SessionDateTime) = month(getdate()) AND SessionStatus = 'Pending Confirmation' " +
                                                        " Group by CAST(SessionDateTime as DATE) " +
                                                        " Order by Date", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        sda.Fill(dt);
                    }
                }
            }

            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++) // iterator
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
            }
            ChartPendingConfirmationSession.Series[0].Points.DataBindXY(x, y);
            ChartPendingConfirmationSession.Series[0].ChartType = SeriesChartType.Column;
            ChartPendingConfirmationSession.Series[0].Color = Color.FromArgb(20, 159, 181);
            ChartPendingConfirmationSession.ChartAreas["ChartArea2"].Area3DStyle.Enable3D = false;

            dt.Dispose();
            dt = null;
        }


        private void LoadChartConfirmedCurrentMonth()
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["UTMCounsellingConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Select  FORMAT (CAST(SessionDateTime as DATE), 'dd') as Date, Count(SessionID) as [Total] " +
                                                        " from CounsellingSession Where  datepart(mm, SessionDateTime) = month(getdate()) AND SessionStatus = 'Confirmed' " +
                                                        " Group by CAST(SessionDateTime as DATE) " +
                                                        " Order by Date", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        sda.Fill(dt);
                    }
                }
            }

            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++) //iterator
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
            }
            ChartConfirmedSession.Series[0].Points.DataBindXY(x, y);
            ChartConfirmedSession.Series[0].ChartType = SeriesChartType.Column;
            ChartConfirmedSession.Series[0].Color = Color.FromArgb(34, 139, 34);
            ChartConfirmedSession.ChartAreas["ChartArea2"].Area3DStyle.Enable3D = false;

            dt.Dispose();
            dt = null;
        }


        //void PopulateChart()
        //{
        //    this.Chart1.Visible = true;
        //    string query = "SELECT DATENAME(Month,SessionDateTime) AS Month,Count(SessionID) as TotalOrders  FROM CounsellingSession WHERE SessionDateTime BETWEEN '2023-01-01' AND '2023-12-31' GROUP BY DATENAME(Month,SessionDateTime)";
        //    DataTable dt = GetData(query);
        //    string[] x = new string[dt.Rows.Count];
        //    int[] y = new int[dt.Rows.Count];
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        x[i] = dt.Rows[i][0].ToString();
        //        y[i] = Convert.ToInt32(dt.Rows[i][1]);
        //    }
        //    Chart1.Series[0].Points.DataBindXY(x, y);
        //    Chart1.Series[0].ChartType = SeriesChartType.Column;
        //    Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
        //    //Chart1.Legends[0].Enabled = true;
        //}


        private static DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["UTMCounsellingConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}