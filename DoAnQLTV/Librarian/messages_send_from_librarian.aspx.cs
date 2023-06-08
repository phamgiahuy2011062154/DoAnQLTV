using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace DoAnQLTV.Librarian
{
    public partial class messages_send_from_librarian : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\QLTV_database.mdf;Integrated Security=True");
        string username = "";
        string msg = "";
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

            username = Request.QueryString["username"].ToString();
            msg = Request.QueryString["msg"].ToString();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Message VALUES('Librarian','"+username.ToString()+"','"+msg.ToString()+"','no')";
            cmd.ExecuteNonQuery();

        }
    }
}