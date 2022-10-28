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
    public partial class Consecutivo : System.Web.UI.Page
    {
        readonly NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["postgres"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarConsecutivo();
        }

        protected void btnLeer_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selecionF = (GridViewRow)btnConsultar.NamingContainer;
            id = selecionF.Cells[1].Text;
            Console.WriteLine(id);
            Response.Redirect("~/Pages/DrucC.aspx?id=" + id + "&op=L");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (campoVacio())
            {
                if (validarPassword())
                {
                    string id;
                    Button btnConsultar = (Button)sender;
                    GridViewRow selecionF = (GridViewRow)btnConsultar.NamingContainer;
                    id = selecionF.Cells[1].Text;
                    Console.WriteLine(id);
                    Response.Redirect("~/Pages/DrucC.aspx?id=" + id + "&op=A");
                }
                else
                {
                    string script = "alert('Error: PassWord Incorrecta ');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                }
                             
            }
            else
            {
                string script = "alert('Error: Campo PassWord Vacio ');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
            }
           
        }

        void cargarConsecutivo()
        {
            try
            {
                conexion.Open();
                string cadena = CdConsecutivo.mostrarDatos();
                NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvconsecutivo.DataSource = dt;
                gvconsecutivo.DataBind();
                conexion.Close();
            }
            catch (Exception ex)
            {
                string script = "alert('Error: " + ex + "');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                throw;
            }
        }

        Boolean validarPassword()
        {
            string ps = tbkey.Text;
            if (ps.Equals("123"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        Boolean campoVacio()
        {
            string ps = tbkey.Text;
            if (ps.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}