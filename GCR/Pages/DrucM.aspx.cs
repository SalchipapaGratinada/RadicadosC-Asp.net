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
    public partial class DrucM : System.Web.UI.Page
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
                        case "C":
                            this.lblTitulo.Text = "Ingresar Modo";
                            this.btnCrear.Visible = true;
                            break;
                        case "L":
                            this.lblTitulo.Text = "Consulta De Modo";
                            bloquearCampos();
                            break;
                        case "A":
                            this.lblTitulo.Text = "Actualizacion De Modo";
                            this.btnAcualizar.Visible = true;
                            break;
                        case "E":
                            this.lblTitulo.Text = "Eliminar Modo";
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
            if (validarCampos(codigo) || validarCampos(nombre))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Hay Campos Vacios');", true);
            }
            else
            {
                try
                {
                    string cadena = "INSERT INTO modo(codigo, nombre ) values('" + codigo + "', '" + nombre +"');";
                    NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    Response.Redirect("Modo.aspx");
                }
                catch (Exception ex)
                {
                    string script = "alert('Error: " + ex + "');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                    throw;
                }

            }
        }

        protected void btnAcualizar_Click(object sender, EventArgs e)
        {
            string codigo = tbCodigo.Text;
            string nombre = tbNombre.Text;
            if (validarCampos(codigo) || validarCampos(nombre) )
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Hay Campos Vacios');", true);
            }
            else
            {
                try
                {
                    string cadena = "UPDATE modo SET codigo = '" + codigo + "',nombre = '" + nombre + "' WHERE id = " + auxId + ";";
                    NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    Response.Redirect("Modo.aspx");
                }
                catch (Exception ex)
                {
                    string script = "alert('Error: " + ex + "');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                    throw;
                }

            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string cadena = "DELETE FROM modo WHERE id = " + auxId + ";";
                NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion);
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                Response.Redirect("Modo.aspx");
            }
            catch (Exception ex)
            {
                string script = "alert('Error: " + ex + "');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                throw;
            }
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("Modo.aspx");
        }

        void cargarDatos()
        {
            try
            {
                conexion.Open();
                string cadena = "SELECT * FROM public.modo WHERE id=" + auxId + ";";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cadena, conexion);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                tbCodigo.Text = row[1].ToString();
                tbNombre.Text = row[2].ToString();
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
            tbCodigo.Enabled = false;
            tbNombre.Enabled = false;
        }



    }
}