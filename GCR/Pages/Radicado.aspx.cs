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
                    int idConsec = traerIdConsecutivo(idTd, idM);
                    string sConsecutivo = traerConsecutivo(idConsec);
                    string sConsecAumentado = formateandoConsecutivo(sConsecutivo);
                    try
                    {
                        string cadena = CdRadicados.actualizarConsecutivo(sConsecAumentado, idConsec);
                        NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion);
                        conexion.Open();
                        cmd.ExecuteNonQuery();
                        conexion.Close();
                        //aqui necesitamos mostrar el radicado con el formato
                        string formato = sacarFormatoParaRadicado(idTd);
                        string cadenaConsecutivo = formateandoFormatoTd(formato);
                        string tipoDoc = dropTipoDocumental.SelectedItem.Text;
                        string modo = dropModo.SelectedItem.Text;
                        //Aqui se trae el codigo del modo
                        string codigoModo = traerCodigoModo(modo);

                        formato = formato.Replace("[TP]", tipoDoc);
                        formato = formato.Replace("[M]", codigoModo);
                        formato = formato.Replace("[CON,"+cadenaConsecutivo+"]", sConsecAumentado);
                        string radicado = formato;
                        msjRadicadoGenerado();
                        this.lblInfoRadicado.Text = "Numero De Radicado: "+radicado; 
                        this.dropTipoDocumental.Enabled = false;
                        this.dropModo.Enabled = false;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
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

        public int traerIdConsecutivo(int idTd, int idM)
        {
            try
            {
                conexion.Open();
                string cadena = CdRadicados.traerIdConsecutivoRelacion(idTd, idM);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cadena, conexion);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                int idC = Int32.Parse(row[0].ToString());
                conexion.Close();
                return idC;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public string traerConsecutivo (int idConsec)
        {
            try
            {
                conexion.Open();
                string cadena = CdRadicados.traerConsecutivo(idConsec);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cadena, conexion);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                string cadenaConsec = row[0].ToString();
                conexion.Close();
                return cadenaConsec;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string formateandoConsecutivo(string cadenaConsec)
        {
            int consec = Int32.Parse(cadenaConsec);
            consec = consec + 1;
            int aux = cadenaConsec.Length - consec.ToString().Length;
            string cadenaConsecNueva;
            if (aux > 0)
            {
                cadenaConsecNueva = cadenaConsec.Substring(0,aux);
                cadenaConsecNueva = cadenaConsecNueva + consec.ToString();
            }
            else
            {
                cadenaConsecNueva = consec.ToString();
            }
            return cadenaConsecNueva;
        }


        public string traerCodigoModo(string nombre)
        {
            try
            {
                conexion.Open();
                string cadena = CdModo.traerCodigoModo(nombre);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cadena, conexion);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                string codigoModo = row[0].ToString();
                conexion.Close();
                return codigoModo;
            }
            catch (Exception)
            {
                throw;
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

        public string sacarFormatoParaRadicado(int idTd)
        {
            try
            {
                conexion.Open();
                string cadena = CdTipoDocumental.traerFormato(idTd);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cadena, conexion);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                string formato = row[0].ToString();
                conexion.Close();
                return formato;

            }
            catch (Exception ex)
            {
                string script = "alert('Error: " + ex + "');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                throw;
            }
        }

        public string formateandoFormatoTd(string formato)
        {
            formato = formato.ToUpper();
            int limite = formato.Length - 1;
            int posicion = -1;
            int numeroDeCeros = 0;
            if (formato.Contains("CON"))
            {
                for (int i = 0; i < formato.Length; i++)
                {
                    char act = formato[i];
                    if (act.Equals('C'))
                    {
                        if (i + 1 <= limite)
                        {
                            char act1 = formato[i + 1];
                            if (act1.Equals('O'))
                            {
                                if (i + 2 <= limite)
                                {
                                    char act2 = formato[i + 2];
                                    if (act2.Equals('N'))
                                    {
                                        posicion = (i + 2);
                                    }
                                }
                            }
                        }
                    }
                }
                for (int i = posicion; i < formato.Length; i++)
                {
                    char act = formato[i];
                    if (act.Equals('0'))
                    {
                        numeroDeCeros = numeroDeCeros + 1;
                    }
                }
                if (numeroDeCeros != 0)
                {
                    string cadenaDeCeros = formato.Substring((posicion + 2), numeroDeCeros);
                    return cadenaDeCeros;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
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
        protected void msjPrueba(string mensaje)
        {
            string script = "alert('Error: " + mensaje + "');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
        }




    }
}