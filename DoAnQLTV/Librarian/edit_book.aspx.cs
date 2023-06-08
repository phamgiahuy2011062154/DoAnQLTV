using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace DoAnQLTV.Librarian
{
    public partial class edit_book : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\QLTV_database.mdf;Integrated Security=True");
        int id;
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
            id = Convert.ToInt32(Request.QueryString["id"].ToString());
            if (IsPostBack) return;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Books WHERE Id="+id+"";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                booktitle.Text = dr["book_name"].ToString();
                authorname.Text = dr["book_author"].ToString();
                quantity.Text = dr["available_quantity"].ToString();
                booksimage.Text = dr["book_image"].ToString();
                isbn.Text = dr["book_isbn"].ToString();

            }

        }

        protected void buttonAddBook_Click(object sender, EventArgs e)
        {
            string path = "";

            if (bookimage.FileName.ToString() != "")
            {

                bookimage.SaveAs(Request.PhysicalApplicationPath + "/Librarian/book_images/" + bookimage.FileName.ToString());
                path = "book_images/" + bookimage.FileName.ToString();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Books SET book_name='" + booktitle.Text + "', book_image = '" + path.ToString()+ "', book_author='" + authorname.Text + "',book_isbn='"+isbn.Text+"',  available_quantity='"+ quantity.Text +"'";
                cmd.ExecuteNonQuery();
            }

            else if (bookimage.FileName.ToString() == "")
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Books SET book_name='" + booktitle.Text + "', book_author='" + authorname.Text + "',book_isbn='"+isbn.Text+"',  available_quantity='" + quantity.Text + "'";
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("book_display.aspx");
        }
    }
}