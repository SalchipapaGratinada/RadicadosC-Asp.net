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
                    //cargarDatos();
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
                            bloquearCampos();
                            break;
                        case "A":
                            this.lblTitulo.Text = "Actualizacion De Relaciones";
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
                            this.btnAcualizar.Visible = true;
                            break;
                        case "E":
                            this.lblTitulo.Text = "Eliminar Relacion";
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
        protected void cargarDropM()
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

        void bloquearCampos()
        {
            tbtipod.Enabled = false;
            tbmodo.Enabled = false;
            tbconsecu.Enabled = false;
            tbanio.Enabled = false;
            tbfecha.Enabled = false;
        }


        //void cargarDatos()
        //{
        //    try
        //    {
        //        conexion.Open();
        //        string cadena = CdTipoDocumental.cargarDatos(auxId);
        //        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cadena, conexion);
        //        DataSet ds = new DataSet();
        //        ds.Clear();
        //        da.Fill(ds);
        //        DataTable dt = ds.Tables[0];
        //        DataRow row = dt.Rows[0];
        //        tbCodigo.Text = row[1].ToString();
        //        tbNombre.Text = row[2].ToString();
        //        tbFormato.Text = row[3].ToString();
        //        conexion.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        string script = "alert('Error: " + ex + "');";
        //        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
        //        throw;
        //    }

        //}


    }
}