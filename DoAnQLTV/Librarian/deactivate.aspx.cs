using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnQLTV.Librarian
{
    public partial class deactivate : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\QLTV_database.mdf;Integrated Security=True");
        int Id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open(); 
            if (Session["Librarian"] == null)
            {
                Response.Redirect("login.aspx");
            }
            Id = Convert.ToInt32(Request.QueryString["Id"].ToString());
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE RegisterStudent SET approved='no' WHERE Id='" + Id + "'";
            cmd.ExecuteNonQuery();

            Response.Redirect("student_info_display.aspx");
        }
    }
}