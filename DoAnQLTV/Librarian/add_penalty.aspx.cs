using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace DoAnQLTV.Librarian
{
    public partial class add_penalty : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\QLTV_database.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            if (IsPostBack) return;

            if (Session["Librarian"] == null)
            {
                Response.Redirect("login.aspx");
            }

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Penalty";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                penalty.Text = dr["penalty"].ToString();
            }


        }

        protected void buttonPen_Click(object sender, EventArgs e)
        {
            int dem = 0;
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "SELECT * FROM Penalty";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            dem = Convert.ToInt32(dt1.Rows.Count.ToString());
            if (dem == 0)
            {
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "INSERT INTO Penalty VALUES('"+penalty.Text+"')";
                cmd2.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "INSERT INTO Penalty VALUES('" + penalty.Text + "')";
                cmd2.ExecuteNonQuery();
            }
            Response.Redirect("add_penalty.aspx");
        }
    }
}