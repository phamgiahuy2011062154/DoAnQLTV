using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnQLTV.Librarian
{
    public partial class delete_book : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\QLTV_database.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            if (Session["Librarian"] == null)
            {
                Response.Redirect("login.aspx");
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE Books WHERE Id='" + Request.QueryString["id"].ToString() +"'";
            cmd.ExecuteNonQuery();
            Response.Redirect("book_display.aspx");

        }
    }
}