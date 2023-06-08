using System;
using System.Data;
using System.Data.SqlClient;

namespace DoAnQLTV.Librarian
{
    public partial class add_book : System.Web.UI.Page
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
        }

        protected void buttonAddBook_Click(object sender, EventArgs e)
        {
            string path = "";
            bookimage.SaveAs(Request.PhysicalApplicationPath + "/Librarian/book_images/" + bookimage.FileName.ToString());
            path = "book_images/" + bookimage.FileName.ToString();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Books VALUES ('" + booktitle.Text + "','" + path.ToString() + "','" + authorname.Text + "','"+isbn.Text+"','" + quantity.Text + "')";
            cmd.ExecuteNonQuery();
            addSuccess.Style.Add("display", "block");

        }
    }
}