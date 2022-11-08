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
    public partial class DrucGMT : System.Web.UI.Page
    {
        readonly NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["postgres"].ConnectionString);
        public static string auxId = "-1";
        public static string auxNombre = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    auxId = Request.QueryString["id"].ToString();
                }
                if (Request.QueryString["nombre"] != null)
                {
                    auxNombre = Request.QueryString["nombre"].ToString();
                    tbTD.Text = auxNombre.ToString();
                    tbTD.Enabled = false;
                    cargarDropConsecutivo();
                    cargarDropModosDisponibles();
                    cargarDropModosAgregados();
                }
            }
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("TipoDocumental.aspx");
        }


        protected void dropConsec_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idConsec = Convert.ToInt32(dropConsec.SelectedValue.ToString());
            if (idConsec != 0)
            {
                tbNombreConsec.Text = "";
                tbNombreConsec.Enabled = false;
            }
            else
            {
                tbNombreConsec.Enabled = true;

            }
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int idConsec = Convert.ToInt32(dropConsec.SelectedValue.ToString());
            int idModo = Convert.ToInt32(dropModos.SelectedValue.ToString());
            if (idConsec != 0 || !tbNombreConsec.Text.Equals(""))
            {
                if (idModo != 0)
                {
                    string nombreTd = auxNombre;
                    int idTD = Convert.ToInt32(auxId);
                    string nombreM = dropModos.SelectedItem.Text;
                    string referencia = "[" + nombreTd + " - " + nombreM + "]";
                    string nombreConsecutivo = tbNombreConsec.Text;
                    if (validarSelect())
                    {
                        if (validarDuplicadoRelaciones(nombreTd))
                        {
                            if (idConsec == 0)
                            {
                                idConsec = crearConsecutivoAutomatico(referencia, idTD, nombreConsecutivo);
                            }
                            int idM = Convert.ToInt32(dropModos.SelectedValue.ToString());
                            DateTime dt = DateTime.Now;
                            string fecha = dt.ToString("dd-MM-yyyy");
                            string cadena = CdRelaciones.insertar(idTD, idM, idConsec, fecha);
                            NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion);
                            conexion.Open();
                            cmd.ExecuteNonQuery();
                            conexion.Close();
                            msjModoAgregado();
                            tbNombreConsec.Text = "";
                            cargarDropConsecutivo();
                            cargarDropModosAgregados();
                            cargarDropModosDisponibles();
                        }
                        else
                        {
                            dropModos.SelectedIndex = 0;
                        }

                    }
                }
                else
                {
                    msjSeleccioneModo();
                }
            }
            else
            {
                msjFaltaNombreConsec();
            }   
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (validarSelectModosAgregados())
            {
                int idTd = Convert.ToInt32(auxId);
                int idM = Convert.ToInt32(dropModosAgregados.SelectedValue.ToString());
                string cadena = CdRelaciones.eliminar(idTd, idM);
                NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion);
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                msjModoretirado();
                cargarDropModosAgregados();
                cargarDropModosDisponibles();

            }
        }

        protected int crearConsecutivoAutomatico(string referencia, int idTD, string nombreConsecutivo)
        {
            string consec = consecutivoBase(idTD);
            DateTime dt = DateTime.Now;
            string anio = dt.ToString("yyyy");
            string fechaHora = dt.ToString("MM-dd-yyyy-HH:mm:ss");
            try
            {
                string cadena = CdConsecutivo.insertar(consec, anio, referencia, fechaHora, nombreConsecutivo);
                NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion);
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                msjConsecutivoCreado();
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

        public string consecutivoBase(int idTd)
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
                string cadenaConsecutivo = formateandoFormatoTd(formato);
                conexion.Close();
                return cadenaConsecutivo;

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
        protected Boolean validarSelect()
        {
            if (dropModos.SelectedIndex == 0)
            {
                msjSeleccioneModo();
                return false;
            }
            else
            {
                return true;
            }

        }
        protected Boolean validarSelectModosAgregados()
        {
            if (dropModosAgregados.SelectedIndex == 0)
            {
                msjSeleccioneModo();
                return false;
            }
            else
            {
                return true;
            }

        }

        protected Boolean validarDuplicadoRelaciones(string idTipoDocumental)
        {
            string td = idTipoDocumental;
            string modo = dropModos.SelectedItem.Text;
            try
            {
                conexion.Open();
                string cadena = CdRelaciones.validarDuplicadosRelaciones(td, modo);
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
                    msjRelacionExiste();
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

        protected void cargarDropConsecutivo()
        {
            try
            {
                string cadena = CdConsecutivo.cargarDropConsec();
                NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion);
                conexion.Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dropConsec.DataSource = ds;
                dropConsec.DataTextField = "nombre";
                dropConsec.DataValueField = "id";
                dropConsec.DataBind();
                dropConsec.Items.Insert(0, new ListItem("Consec Nuevo", "0"));
                conexion.Close();
            }
            catch (Exception ex)
            {
                string script = "alert('Error: " + ex + "');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                throw;
            }


        }

        protected void cargarDropModosDisponibles()
        {
            int idTD = Convert.ToInt32(auxId);
            try
            {
                string cadena = CdModo.cargarDropModoSoloDisponibles(idTD);
                NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion);
                conexion.Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dropModos.DataSource = ds;
                dropModos.DataTextField = "nombre";
                dropModos.DataValueField = "id";
                dropModos.DataBind();
                dropModos.Items.Insert(0, new ListItem("Modos Disponibles", "0"));
                conexion.Close();
            }
            catch (Exception ex)
            {
                string script = "alert('Error: " + ex + "');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                throw;
            }


        }


        protected void cargarDropModosAgregados()
        {
            int idTD = Convert.ToInt32(auxId);
            try
            {
                string cadena = CdModo.cargarDropModoSoloAgregados(idTD);
                NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion);
                conexion.Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dropModosAgregados.DataSource = ds;
                dropModosAgregados.DataTextField = "nombre";
                dropModosAgregados.DataValueField = "id";
                dropModosAgregados.DataBind();
                dropModosAgregados.Items.Insert(0, new ListItem("Modos Agregados", "0"));
                conexion.Close();
            }
            catch (Exception ex)
            {
                string script = "alert('Error: " + ex + "');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                throw;
            }


        }

        protected void msjRelacionExiste()
        {
            string script = string.Format("alertaRelacionExiste();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alertaRelacionExiste", script, true);
        }
        protected void msjFaltaNombreConsec()
        {
            string script = string.Format("alertaFaltaNombreConsec();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alertaFaltaNombreConsec", script, true);
        }
        protected void msjSeleccioneModo()
        {
            string script = string.Format("alertaSeleccioneModo();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alertaSeleccioneModo", script, true);
        }

        protected void msjConsecutivoCreado()
        {
            string script = string.Format("alertaConsecutivoCreado();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alertaConsecutivoCreado", script, true);
        }

        protected void msjModoAgregado()
        {
            string script = string.Format("alertaModoAgregado();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alertaModoAgregado", script, true);
        }

        protected void msjModoretirado()
        {
            string script = string.Format("alertaModoRetirado();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alertaModoRetirado", script, true);
        }

    }
}