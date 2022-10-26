using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GCR.Pages
{
    public partial class index : System.Web.UI.Page
    {
        private const string UrlTipoDocumental = "~/Pages/TipoDocumental.aspx";
        private const string UrlModo = "~/Pages/Modo.aspx";
        private const string UrlConsecutivo = "~/Pages/Consecutivo.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGestionDocumental_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Pages/TipoDocumental.aspx");
        }

        protected void btnModo_Click(object sender, EventArgs e)
        {
            Response.Redirect(UrlModo);
        }

        protected void btnTipoDocumental_Click(object sender, EventArgs e)
        {
            Response.Redirect(UrlTipoDocumental);
        }

        protected void btnConsecutivo_Click(object sender, EventArgs e)
        {
            Response.Redirect(UrlConsecutivo);
        }
    }
}