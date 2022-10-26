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
    public partial class DrucC : System.Web.UI.Page
    {
        readonly NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["postgres"].ConnectionString);
        public static string auxId = "-1";
        public static string auxOpc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    auxId = Request.QueryString["id"].ToString();
                    cargarDatos();
                }
                if (Request.QueryString["op"] != null)
                {
                    auxOpc = Request.QueryString["op"].ToString();
                    switch (auxOpc)
                    {
                        case "L":
                            this.lblTitulo.Text = "Consulta De Consecutivo";
                            bloquearCampos();
                            break;
                        case "A":
                            this.lblTitulo.Text = "Actualizacion De Consecutivo";
                            this.btnAcualizar.Visible = true;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        protected void btnAcualizar_Click(object sender, EventArgs e)
        {
            string consec = tbConsecutivo.Text;
            string anio = tbAnio.Text;
            if (validarCampos(consec) || validarCampos(anio))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Hay Campos Vacios');", true);
            }
            else
            {
                try
                {
                    string cadena = "UPDATE consecutivo SET consec = '" + consec + "',anio = '" + anio + "' WHERE id = " + auxId + ";";
                    NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    Response.Redirect("Consecutivo.aspx");
                }
                catch (Exception ex)
                {
                    string script = "alert('Error: " + ex + "');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                    throw;
                }

            }
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("Consecutivo.aspx");
        }
        void cargarDatos()
        {
            try
            {
                conexion.Open();
                string cadena = "SELECT * FROM public.consecutivo WHERE id=" + auxId + ";";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cadena, conexion);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                tbConsecutivo.Text = row[1].ToString();
                tbAnio.Text = row[2].ToString();
                conexion.Close();
            }
            catch (Exception ex)
            {
                string script = "alert('Error: " + ex + "');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                throw;
            }
        }

        Boolean validarCampos(string dato)
        {
            if (dato.Equals(""))
            {
                return true;
            }
            return false;
        }
        void bloquearCampos()
        {
            tbConsecutivo.Enabled = false;
            tbAnio.Enabled = false;
        }


    }
}