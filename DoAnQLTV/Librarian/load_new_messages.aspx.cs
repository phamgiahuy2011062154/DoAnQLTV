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
    public partial class load_new_messages : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\QLTV_database.mdf;Integrated Security=True");
        string username = "";
        string msg = "";
        int dem = 0;
        
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

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Message WHERE dusername='Librarian' AND placed='no'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                dem = dem + 1;
                if (dem == 1)
                {
                    msg = dr["susername"].ToString() + ":" + dr["msg"].ToString();
                }
                else
                {
                    msg = msg + "||abcd||" + dr["susername"].ToString() + ":" + dr["msg"].ToString();

                }

                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "UPDATE Message SET placed='yes' WHERE Id='"+dr["Id"].ToString()+"'";
                cmd1.ExecuteNonQuery();


            }
            if (dem == 0)
            {
                Response.Write("0");
            }
            else
            {
                Response.Write(msg.ToString());
            }



        }
    }
}