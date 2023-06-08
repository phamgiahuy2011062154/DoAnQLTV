﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace DoAnQLTV.Student
{
    public partial class messages_send_from_student : System.Web.UI.Page
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
            if (Session["Student"] == null)
            {
                Response.Redirect("student_login.aspx");
            }
            username = Session["Student"].ToString();
            msg = Request.QueryString["msg"].ToString();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Message VALUES('" + username.ToString() + "','Librarian','" + msg.ToString() + "','no')";
            cmd.ExecuteNonQuery();
        }
    }
}