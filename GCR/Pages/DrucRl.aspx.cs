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
    public partial class DrucRl : System.Web.UI.Page
    {
        readonly NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["postgres"].ConnectionString);
        public static string auxId = "-1";
        public static string auxOpc = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                            this.lblTitulo.Text = "Ingresar Relacion";
                            this.lbldroptd.Visible = true;
                            this.lbldropm.Visible = true;
                            this.dropTipoDocumental.Visible = true;
                            this.dropModo.Visible = true;
                            this.btnCrear.Visible = true;
                            cargarDropTd();
                            cargarDropM();
                            break;
                        case "L":
                            this.lblTitulo.Text = "Consulta De Relaciones";
                            activarCampos();
                            bloquearCampos();
                            break;
                        case "A":
                            this.lblTitulo.Text = "Actualizacion De Relaciones";
                            activarCampos();
                            this.btnAcualizar.Visible = true;
                            break;
                        case "E":
                            this.lblTitulo.Text = "Eliminar Relacion";
                            activarCampos();
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
            if (validarComboxRelaciones())
            {
                if (validarDuplicadoRelaciones())
                {
                    string nombreTd = dropTipoDocumental.SelectedItem.Text;
                    string nombreM = dropModo.SelectedItem.Text;
                    string referencia = "[" + nombreTd + " - " + nombreM + "]";
                    int idConsec = crearConsecutivoAutomatico(referencia);
                    int idTd = Convert.ToInt32(dropTipoDocumental.SelectedValue.ToString());
                    int idM = Convert.ToInt32(dropModo.SelectedValue.ToString());
                    DateTime dt = DateTime.Now;
                    string fecha = dt.ToString("dd-MM-yyyy");
                    string cadena = CdRelaciones.insertar(idTd, idM, idConsec, fecha);
                    NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    Response.Redirect("Relaciones.aspx");
                }
            }
             
        }

        protected void btnAcualizar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("Relaciones.aspx");
        }


        protected void cargarDropTd()
        {
            try
            {
                string cadena = CdRelaciones.cargarDropTd();
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
        protected void cargarDropM()
        {
            try
            {
                string cadena = CdRelaciones.cargarDropM();
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

        protected void bloquearCampos()
        {
            tbtipod.Enabled = false;
            tbmodo.Enabled = false;
            tbconsecu.Enabled = false;
            tbanio.Enabled = false;
            tbfecha.Enabled = false;
        }
        
        protected void activarCampos()
        {
            this.lbltd.Visible = true;
            this.tbtipod.Visible = true;
            this.lblmodo.Visible = true;
            this.tbmodo.Visible = true;
            this.lblconsec.Visible = true;
            this.tbconsecu.Visible = true;
            this.lblanio.Visible = true;
            this.tbanio.Visible = true;
            this.lblfecha.Visible = true;
            this.tbfecha.Visible = true;
        }

        protected void cargarDatos()
        {
            try
            {
                conexion.Open();
                string cadena = CdRelaciones.cargarDatos(auxId);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cadena, conexion);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                tbtipod.Text = row[1].ToString();
                tbmodo.Text = row[2].ToString();
                tbconsecu.Text = row[3].ToString();
                tbanio.Text = row[4].ToString();
                tbfecha.Text = row[5].ToString();
                conexion.Close();
            }
            catch (Exception ex)
            {
                string script = "alert('Error: " + ex + "');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                throw;
            }

        }

        protected Boolean validarComboxRelaciones()
        {
            if (dropTipoDocumental.SelectedIndex == 0)
            {
                string ex = "Seleccione Un Tipo Documental";
                string script = "alert('Warning: " + ex + "');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                return false;
            }
            else
            {
                if (dropModo.SelectedIndex == 0)
                {
                    string ex = "Seleccione Un Modo";
                    string script = "alert('Warning: " + ex + "');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }

        protected Boolean validarDuplicadoRelaciones()
        {
            string td = dropTipoDocumental.SelectedItem.Text;
            string modo = dropModo.SelectedItem.Text;
            try
            {
                conexion.Open();
                string cadena = CdRelaciones.validarDuplicadosRelaciones(td,modo);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cadena, conexion);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                string boo = row[0].ToString();
                if (boo.Equals("False"))
                {
                    conexion.Close();
                    return true;
                }
                else
                {
                    string ex = "Esta Relacion Ya Existe...";
                    string script = "alert('Error: " + ex + "');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                    conexion.Close();
                    return false;
                }

            }
            catch (Exception ex)
            {
                string script = "alert('Error: " + ex + "');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                throw;
            }
        }


        protected int crearConsecutivoAutomatico(string referencia)
        {
            string consec = "0001";
            DateTime dt = DateTime.Now;
            string anio = dt.ToString("yyyy");
            try
            {
                string cadena = CdConsecutivo.insertar(consec, anio, referencia);
                NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion);
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                int ultConsec = ultimoConsec();
                return ultConsec;
            }
            catch (Exception ex)
            {
                string script = "alert('Error: " + ex + "');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                throw;
            }
        }

        protected int ultimoConsec()
        {
            try
            {
                conexion.Open();
                string cadena = CdRelaciones.ultimoConsec();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cadena, conexion);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                string boo = row[0].ToString();
                conexion.Close();
                return Convert.ToInt32(boo);
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