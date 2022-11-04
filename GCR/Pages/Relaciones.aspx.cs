using GCR.CadenasBd;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GCR.Pages
{
    public partial class Relaciones : System.Web.UI.Page
    {
        readonly NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["postgres"].ConnectionString);
        private static string urlDrucTD = "~/Pages/DrucRl.aspx?op=C";

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        void cargarDatos()
        {
            try
            {
                conexion.Open();
                string cadena = CdRelaciones.mostrarRelaciones();
                NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvrelaciones.DataSource = dt;
                gvrelaciones.DataBind();
                conexion.Close();
            }
            catch (Exception ex)
            {
                string script = "alert('Error: " + ex + "');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                throw;
            }
        }


        protected void btnCrearRl_Click(object sender, EventArgs e)
        {
            Response.Redirect(urlDrucTD);
        }

        protected void btnLeer_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selecionF = (GridViewRow)btnConsultar.NamingContainer;
            id = selecionF.Cells[1].Text;
            Console.WriteLine(id);
            Response.Redirect("~/Pages/DrucRl.aspx?id=" + id + "&op=L");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selecionF = (GridViewRow)btnConsultar.NamingContainer;
            id = selecionF.Cells[1].Text;
            Console.WriteLine(id);
            Response.Redirect("~/Pages/DrucRl.aspx?id=" + id + "&op=A");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selecionF = (GridViewRow)btnConsultar.NamingContainer;
            id = selecionF.Cells[1].Text;
            Console.WriteLine(id);
            Response.Redirect("~/Pages/DrucRl.aspx?id=" + id + "&op=E");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                string cadena = CdRelaciones.buscar(tbbuscar.Text);
                NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvrelaciones.DataSource = dt;
                gvrelaciones.DataBind();
                conexion.Close();
            }
            catch (Exception ex)
            {
                string script = "alert('Error: " + ex + "');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                throw;
            }
        }
    }
}