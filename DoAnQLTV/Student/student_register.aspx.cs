using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace DoAnQLTV.Student
{
    public partial class student_register : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\QLTV_database.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        protected void buttonReg_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO RegisterStudent VALUES('"+username.Text+"','"+mssv.Text+"','"+fullname.Text+"','"+password.Text+"','"+email.Text+"','"+sdt.Text+"','no')";
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('oke');</script>");
            Response.Redirect("student_login.aspx");

            int i = 0;
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = System.Data.CommandType.Text;
            cmd1.CommandText = "SELECT * FROM RegisterStudent WHERE username='" + username.Text + "' AND password='" + password.Text + "'";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            i = Convert.ToInt32(dt1.Rows.Count.ToString());
            if (i > 0)
            {
                Session["Student"] = username.Text;
                Response.Redirect("student_book_display.aspx");
            }
            
        }
    }
}