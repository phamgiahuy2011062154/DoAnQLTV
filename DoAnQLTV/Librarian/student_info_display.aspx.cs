using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace DoAnQLTV.Librarian
{
    public partial class student_info_display : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\QLTV_database.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State ==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            if (Session["Librarian"] == null)
            {
                Response.Redirect("login.aspx");
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM RegisterStudent";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            stdDisplay.DataSource = dt;
            stdDisplay.DataBind();

        }
    }
}