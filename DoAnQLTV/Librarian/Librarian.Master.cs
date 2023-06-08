using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DoAnQLTV.Librarian
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\QLTV_database.mdf;Integrated Security=True");
        int dem = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Message WHERE dusername='Librarian' AND placed='no'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dem = Convert.ToInt32(dt.Rows.Count.ToString());
            notification1.Text = dem.ToString();
            notification2.Text = dem.ToString();
            r1.DataSource = dt;
            r1.DataBind();
        }
        public string gettwentycharacters (object myvalues) {
            string a;
            a = Convert.ToString(myvalues.ToString());
            string b = "";
            if (a.Length >= 20)
            {
                b = a.Substring(0, 20);
                return b.ToString() + "..";
            }
            else
            {
                b = a.ToString();
                return b.ToString();
            }
        }
    }

}