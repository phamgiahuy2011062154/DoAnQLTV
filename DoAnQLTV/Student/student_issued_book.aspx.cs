using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace DoAnQLTV.Student
{
    public partial class student_issued_book : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\QLTV_database.mdf;Integrated Security=True");
        string penalty = "0";
        double songay = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(con.State == ConnectionState.Open)
            {
                con.Close();

            }
            con.Open();

            if (Session["Student"] == null)
            {
                Response.Redirect("student_login.aspx");
            }

            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "SELECT * FROM Penalty";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                penalty = dr2["penalty"].ToString();             
            }


            DataTable dt_temp = new DataTable();
            dt_temp.Clear();
            dt_temp.Columns.Add("user_muon");
            dt_temp.Columns.Add("mssv_muon");
            dt_temp.Columns.Add("isbn_muon");
            dt_temp.Columns.Add("ngay_muon");
            dt_temp.Columns.Add("ngay_tra");
            dt_temp.Columns.Add("sach_da_tra");
            dt_temp.Columns.Add("ngay_tra_sach");
            dt_temp.Columns.Add("so_ngay_tre");
            dt_temp.Columns.Add("penalty");


            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Issue WHERE user_muon='" + Session["Student"].ToString() +"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                DataRow dr1 = dt_temp.NewRow();
                dr1["user_muon"] = dr["user_muon"].ToString();
                dr1["mssv_muon"] = dr["mssv_muon"].ToString();
                dr1["isbn_muon"] = dr["isbn_muon"].ToString();
                dr1["ngay_muon"] = dr["ngay_muon"].ToString();
                dr1["ngay_tra"] = dr["ngay_tra"].ToString();
                dr1["sach_da_tra"] = dr["sach_da_tra"].ToString();
                dr1["ngay_tra_sach"] = dr["ngay_tra_sach"].ToString();

                DateTime d1 = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyy"));
                DateTime d2 = Convert.ToDateTime(dr["ngay_tra"].ToString());

                if (d1> d2)
                {
                    TimeSpan t = d1 - d2;
                    double so_ngay = t.TotalDays;
                    dr1["so_ngay_tre"] = so_ngay.ToString();
                }
                else
                {
                    dr1["so_ngay_tre"] = "0";

                }
                dr1["penalty"] = Convert.ToString(Convert.ToDouble(songay) * Convert.ToDouble(penalty));
                dt_temp.Rows.Add(dr1);

            }
            isData.DataSource = dt_temp;
            isData.DataBind();
        }
    }
}