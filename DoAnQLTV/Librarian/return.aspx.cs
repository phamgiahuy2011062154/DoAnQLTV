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
    public partial class _return : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\QLTV_database.mdf;Integrated Security=True");
        int id;
        string isbn = "";
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

            id = Convert.ToInt32(Request.QueryString["id"].ToString());
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Issue SET sach_da_tra='yes', ngay_tra_sach='"+DateTime.Now.ToString("dd/MM/yyyy")+"' WHERE Id='"+id+"'";
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "SELECT * FROM Issue WHERE Id='"+id+"'";
            cmd1.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                isbn = dr["isbn_muon"].ToString();
            }

            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "UPDATE Books SET available_quantity=available_quantity+1 WHERE book_isbn='"+isbn.ToString()+"'";
            cmd2.ExecuteNonQuery();

            Response.Redirect("return_book.aspx");

        }
    }
}