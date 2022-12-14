using GCR.CadenasBd;
using Microsoft.SqlServer.Server;
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
    public partial class DrucTD : System.Web.UI.Page
    {
        readonly NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["postgres"].ConnectionString);
        public static string auxId = "-1";
        public static string auxOpc = "";

        void cargarDatos()
        {
            try
            {
                conexion.Open();
                string cadena = CdTipoDocumental.cargarDatos(auxId);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cadena, conexion);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                tbCodigo.Text = row[1].ToString();
                tbNombre.Text = row[2].ToString();
                tbFormato.Text = row[3].ToString();
                conexion.Close();
            }
            catch (Exception ex )
            {
                string script = "alert('Error: " + ex + "');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                throw;
            }
           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"]!=null)
                {
                    auxId = Request.QueryString["id"].ToString();
                    cargarDatos();
                }
                if (Request.QueryString["op"] != null)
                {
                    auxOpc = Request.QueryString["op"].ToString();
                    switch (auxOpc)
                    {
                        case "C":
                            this.lblTitulo.Text = "Ingresar Tipo Documental";
                            this.btnCrear.Visible = true;
                            break;
                        case "L":
                            this.lblTitulo.Text = "Consulta De Tipo Documental";
                            bloquearCampos();
                            break;
                        case "A":
                            this.lblTitulo.Text = "Actualizacion De Tipo Documental";
                            this.btnAcualizar.Visible = true;
                            break;
                        case "E":
                            this.lblTitulo.Text = "Eliminar Tipo Documental";
                            bloquearCampos();
                            this.btnEliminar.Visible = true;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            string codigo = tbCodigo.Text;
            string nombre = tbNombre.Text;
            string formato = tbFormato.Text;
            formato = formato.ToUpper();
            if (corchetesCorrecto(formato))
            {
                if (tbFormato.Text.Contains("[TP]") && tbFormato.Text.Contains("[M]") && tbFormato.Text.Contains("CON"))
                {
                    if (tbFormato.Text.Contains(" "))
                    {
                        msjEspacios();
                    }
                    else
                    {
                        if (validarCampos(codigo) || validarCampos(nombre) || validarCampos(formato))
                        {
                            msjCampoVacio();
                        }
                        else
                        {
                            try
                            {
                                string cadena = CdTipoDocumental.insertar(codigo, nombre, formato);
                                NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion);
                                conexion.Open();
                                cmd.ExecuteNonQuery();
                                conexion.Close();
                                Response.Redirect("TipoDocumental.aspx");
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
                else
                {
                    msjPalabrasReservadas();
                }
            }
            else
            {
                msjCorchetesFaltantes();
            }            
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("TipoDocumental.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string cadena = CdTipoDocumental.eliminar(auxId);
                NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion);
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                Response.Redirect("TipoDocumental.aspx");
            }
            catch (Exception ex)
            {
                string script = "alert('Error: " + ex + "');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                throw;
            }
            
        }

        protected void btnAcualizar_Click(object sender, EventArgs e)
        {
            string codigo = tbCodigo.Text;
            string nombre = tbNombre.Text;
            string formato = tbFormato.Text;
            if (validarCampos(codigo) || validarCampos(nombre) || validarCampos(formato))
            {
                msjCampoVacio();
            }
            else
            {
                try
                {
                    string cadena = CdTipoDocumental.actualizar(codigo, nombre, formato, auxId);
                    NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    Response.Redirect("TipoDocumental.aspx");
                }
                catch (Exception ex )
                {
                    string script = "alert('Error: " + ex + "');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                    throw;
                }
                
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
            tbCodigo.Enabled = false;
            tbNombre.Enabled = false;
            tbFormato.Enabled = false;
        }
        protected Boolean corchetesCorrecto(string formato)
        {
            int corcheteAbre = 0;
            int corcheteCierra = 0;
            for (int i = 0; i < formato.Length; i++)
            {
                char caracter = formato[i];
                if (caracter.Equals('['))
                {
                    corcheteAbre++;
                }
                if (caracter.Equals(']'))
                {
                    corcheteCierra++;
                }

            }
            if (corcheteAbre == corcheteCierra)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void msjCampoVacio()
        {
            string script = string.Format("alertaCampoVacio();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alertaCampoVacio", script, true);
        }
        protected void msjEspacios()
        {
            string script = string.Format("alertaEspacios();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alertaEspacios", script, true);
        }
        protected void msjPalabrasReservadas()
        {
            string script = string.Format("alertaPalabrasReservadas();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alertaPalabrasReservadas", script, true);
        }
        protected void msjCorchetesFaltantes()
        {
            string script = string.Format("alertaCorchetes();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alertaCorchetes", script, true);
        }

        
    }
}