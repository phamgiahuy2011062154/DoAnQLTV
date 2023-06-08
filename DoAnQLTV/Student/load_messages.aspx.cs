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
    public partial class load_message : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\QLTV_database.mdf;Integrated Security=True");
        string username = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            if (Session["Student"] == null)
            {
                Response.Redirect("student_login.aspx");
            }
            username = Session["Student"].ToString();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Message WHERE (susername ='" + username.ToString() + "' AND dusername='Librarian') OR (dusername ='" + username.ToString() + "' AND susername='Librarian')";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Response.Write("<p>");
                Response.Write(dr["susername"].ToString() + ":" + dr["msg"].ToString());
                Response.Write("</p>");
                Response.Write("<hr>");
                if (dr["dusername"].ToString() == username.ToString())
                {
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "UPDATE Message SET placed='yes' WHERE Id='" + dr["Id"].ToString() + "'";
                    cmd1.ExecuteNonQuery();


                }
            }
        }
    }
}