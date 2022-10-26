using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GCR
{
    public partial class MP : System.Web.UI.MasterPage
    {
        private static string urlinicio = "~/Pages/index.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            
        }

        void pagina()
        {
            Response.Redirect(urlinicio);
        }


    }
}