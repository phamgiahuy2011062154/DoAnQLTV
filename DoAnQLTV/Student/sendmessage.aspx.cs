using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAnQLTV.Student
{
    public partial class std_send_msg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Student"] == null)
            {
                Response.Redirect("student_login.aspx");
            }
        }
    }
}