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
    public partial class issue : System.Web.UI.Page
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

            username.Items.Clear();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT username FROM RegisterStudent";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                username.Items.Add(dr["username"].ToString());
            }

            isbn.Items.Clear();
            isbn.Items.Add("Select");
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "SELECT book_isbn FROM Books";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                isbn.Items.Add(dr1["book_isbn"].ToString());
            }
        }

        protected void buttonIssueBook_Click(object sender, EventArgs e)
        {

            if (isbn.SelectedItem.ToString() == "Select")
            {
                Response.Write("<script>alert('Vui lòng chọn sách')</script>");

            }
            else
            {

                int tim = 0;
                SqlCommand cmd6 = con.CreateCommand();
                cmd6.CommandType = CommandType.Text;
                cmd6.CommandText = "SELECT * FROM Issue WHERE user_muon='" + username.SelectedItem.ToString() + "' AND isbn_muon='" + isbn.SelectedItem.ToString() + "' AND sach_da_tra='no'";
                cmd6.ExecuteNonQuery();
                DataTable dt5 = new DataTable();
                SqlDataAdapter da5 = new SqlDataAdapter(cmd6);
                da5.Fill(dt5);
                tim = Convert.ToInt32(dt5.Rows.Count.ToString());
                if (tim > 0)
                {
                    Response.Write("<script>alert('Sách đã mượn ở tài khoản này')</script>");
                }
                else
                {

                    if (qty.Text == "0")
                    {
                        Response.Write("<script>alert('Đã hết sách') </script>");
                    }
                    else
                    {
                        string is_ngay_muon = DateTime.Now.ToString("dd/MM/yyyy");
                        string is_ngay_tra = DateTime.Now.AddDays(30).ToString("dd/MM/yyyy");
                        string mssv = "";
                        SqlCommand cmd_ms = con.CreateCommand();
                        cmd_ms.CommandType = CommandType.Text;
                        cmd_ms.CommandText = "SELECT * FROM RegisterStudent WHERE username='"+username.SelectedItem.ToString()+"'";
                        cmd_ms.ExecuteNonQuery();
                        DataTable dt_ms = new DataTable();
                        SqlDataAdapter da_ms = new SqlDataAdapter(cmd_ms);
                        da_ms.Fill(dt_ms);
                        foreach(DataRow dr_ms in dt_ms.Rows)
                        {
                            mssv = dr_ms["mssv"].ToString();
                        }


                        SqlCommand cmd4 = con.CreateCommand();
                        cmd4.CommandType = CommandType.Text;
                        cmd4.CommandText = "INSERT INTO Issue VALUES('" + username.SelectedItem.ToString() + "','" + mssv.ToString() + "','" + isbn.SelectedItem.ToString() + "','" + is_ngay_muon.ToString() + "','" + is_ngay_tra.ToString() + "','no','no','0','0')";
                        cmd4.ExecuteNonQuery();

                        SqlCommand cmd5 = con.CreateCommand();
                        cmd5.CommandType = CommandType.Text;
                        cmd5.CommandText = "UPDATE Books SET available_quantity=available_quantity-1 WHERE book_isbn='" + isbn.SelectedItem.ToString() + "'";
                        cmd5.ExecuteNonQuery();

                        Response.Write("<script>alert('Đã mượn sách thành công') </script>");
                    }
                }
            }
        }

        protected void isbn_SelectedIndexChanged(object sender, EventArgs e)
        {
            img.ImageUrl = "";
            bookname.Text = "";
            qty.Text = "";
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "SELECT * FROM Books WHERE book_isbn='"+isbn.SelectedItem.ToString() +"'";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                img.ImageUrl=dr2["book_image"].ToString();
                bookname.Text = dr2["book_name"].ToString();
                qty.Text = dr2["available_quantity"].ToString();
            }
        }
    }
}