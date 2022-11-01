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
    public partial class Radicado : System.Web.UI.Page
    {

        readonly NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["postgres"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.lblTitulo.Text = "GENERACION DE RADICADO";
                cargarComboTd();
            }
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            int idTd = Convert.ToInt32(dropTipoDocumental.SelectedValue.ToString());
            
            if (idTd != 0)
            {
                int idM = Convert.ToInt32(dropModo.SelectedValue.ToString());
                if (idM != 0)
                {
                    this.lblInfoRadicado.Text = "Aqui Va El Radicado";
                    this.dropTipoDocumental.Enabled = false;
                    this.dropModo.Enabled = false;
                    msjRadicadoGenerado();
                }
                else
                {
                    msjMVacio();
                }
            }
            else
            {
                msjtdVacio();
            }

        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        public void cargarComboTd()
        {
            try
            {
                string cadena = CdRadicados.cargarDropTd();
                NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion);
                conexion.Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dropTipoDocumental.DataSource = ds;
                dropTipoDocumental.DataTextField = "nombre";
                dropTipoDocumental.DataValueField = "id";
                dropTipoDocumental.DataBind();
                dropTipoDocumental.Items.Insert(0, new ListItem("<Seleciona Tipo Documental>", "0"));
                conexion.Close();
            }
            catch (Exception ex)
            {
                string script = "alert('Error: " + ex + "');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                throw;
            }
        }

        protected void dropTipoDocumental_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idTd = Convert.ToInt32(dropTipoDocumental.SelectedValue.ToString());
            if (idTd != 0)
            {
                cargarComboM(idTd);
            }
            else
            {
                dropModo.Items.Clear();
            }    
        }

        public void cargarComboM(int idTd)
        {
            try
            {
                string cadena = CdRadicados.cargarDropM(idTd);
                NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion);
                conexion.Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dropModo.DataSource = ds;
                dropModo.DataTextField = "nombre";
                dropModo.DataValueField = "id";
                dropModo.DataBind();
                dropModo.Items.Insert(0, new ListItem("<Seleciona Modo>", "0"));
                conexion.Close();
            }
            catch (Exception ex)
            {
                string script = "alert('Error: " + ex + "');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                throw;
            }
        }


        protected void msjtdVacio()
        {
            string script = string.Format("alertaComboTdVacio();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alertaComboTdVacio", script, true);
        }

        protected void msjMVacio()
        {
            string script = string.Format("alertaComboMVacio();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alertaComboMVacio", script, true);
        }
        protected void msjRadicadoGenerado()
        {
            string script = string.Format("alertaRadicadoGenerado();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alertaRadicadoGenerado", script, true);
        }


        


    }
}