using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpresaDCMS
{
    public partial class inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Session.Count; i++)
            {
                Session.Clear();
                Session.Abandon();
            }
            Response.Redirect("~/comun/login.aspx");
        }
    }
}