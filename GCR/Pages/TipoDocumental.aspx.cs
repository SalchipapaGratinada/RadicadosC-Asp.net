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
    public partial class TipoDocumental : System.Web.UI.Page
    {
        readonly NpgsqlConnection conexion = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["postgres"].ConnectionString);
        private static string urlDrucTD = "~/Pages/DrucTD.aspx?op=C";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDatos();
            }
            
        }

        void cargarDatos()
        {
            try
            {
                conexion.Open();
                string cadena = CdTipoDocumental.mostrarDatos();
                NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvtipodocumental.DataSource = dt;
                gvtipodocumental.DataBind();
                conexion.Close();
            }
            catch (Exception ex)
            {
                string script = "alert('Error: "+ex+"');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                throw;
            }
        }

        protected void btnCrearTD_Click(object sender, EventArgs e)
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
            Response.Redirect("~/Pages/DrucTD.aspx?id="+id+"&op=L");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selecionF = (GridViewRow)btnConsultar.NamingContainer;
            id = selecionF.Cells[1].Text;
            Console.WriteLine(id);
            Response.Redirect("~/Pages/DrucTD.aspx?id=" + id + "&op=A");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string id;
            string nombre;
            Button btnConsultar = (Button)sender;
            GridViewRow selecionF = (GridViewRow)btnConsultar.NamingContainer;
            id = selecionF.Cells[1].Text;
            nombre = selecionF.Cells[3].Text;
            Console.WriteLine(id);
            Response.Redirect("~/Pages/DrucGMT.aspx?id=" + id + "&nombre="+nombre);
        }

        //protected void btnmodo_Click(object sender, EventArgs e)
        //{
        //    string nombreTd;
        //    string id;
        //    int idTD;
        //    Button btnConsultar = (Button)sender;
        //    GridViewRow selecionF = (GridViewRow)btnConsultar.NamingContainer;
        //    string nombreM = dropModo.SelectedItem.Text;
        //    nombreTd = selecionF.Cells[3].Text;
        //    idTD = Int32.Parse(selecionF.Cells[1].Text);
        //    string referencia = "[" + nombreTd + " - " + nombreM + "]";
        //    id = selecionF.Cells[1].Text;
        //    if (validarSelect())
        //    {
        //        if (validarDuplicadoRelaciones(nombreTd))
        //        {
        //            int idConsec = Convert.ToInt32(dropConsec.SelectedValue.ToString());
        //            if (idConsec == 0)
        //            {
        //                idConsec = crearConsecutivoAutomatico(referencia, idTD);
        //            }
        //            int idTd = Convert.ToInt32(id);
        //            int idM = Convert.ToInt32(dropModo.SelectedValue.ToString());
        //            DateTime dt = DateTime.Now;
        //            string fecha = dt.ToString("dd-MM-yyyy");
        //            string cadena = CdRelaciones.insertar(idTd, idM, idConsec, fecha);
        //            NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion);
        //            conexion.Open();
        //            cmd.ExecuteNonQuery();
        //            conexion.Close();
        //            msjModoAgregado();
        //            cargarDropConsecutivo();
        //            cargarDropModo();
        //        }
        //        else
        //        {
        //            dropModo.SelectedIndex = 0;
        //        }

        //    }
        //}

        //protected void btnmodoe_Click(object sender, EventArgs e)
        //{
        //    string id;
        //    Button btnConsultar = (Button)sender;
        //    GridViewRow selecionF = (GridViewRow)btnConsultar.NamingContainer;
        //    id = selecionF.Cells[1].Text;
        //    if (validarSelect())
        //    {
        //        int idTd = Convert.ToInt32(id);
        //        int idM = Convert.ToInt32(dropModo.SelectedValue.ToString());
        //        string cadena = CdRelaciones.eliminar(idTd, idM);
        //        NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion);
        //        conexion.Open();
        //        cmd.ExecuteNonQuery();
        //        conexion.Close();
        //        msjModoretirado();

        //    }
        //}
        protected void btnConsec_Click(object sender, EventArgs e)
        {

        }

        protected void btnGestionModos_Click(object sender, EventArgs e)
        {
            string id;
            string nombre;
            Button btnConsultar = (Button)sender;
            GridViewRow selecionF = (GridViewRow)btnConsultar.NamingContainer;
            id = selecionF.Cells[1].Text;
            nombre = selecionF.Cells[3].Text;
            Console.WriteLine(id);
            Response.Redirect("~/Pages/DrucGMT.aspx?id=" + id + "&nombre=" + nombre);
        }


        //protected void cargarDropModo()
        //{

        //    try
        //    {
        //        string cadena = CdRelaciones.cargarDropM();
        //        NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion);
        //        conexion.Open();
        //        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
        //        DataSet ds = new DataSet();
        //        da.Fill(ds);
        //        dropModo.DataSource = ds;
        //        dropModo.DataTextField = "nombre";
        //        dropModo.DataValueField = "id";
        //        dropModo.DataBind();
        //        dropModo.Items.Insert(0, new ListItem("Modos", "0"));
        //        conexion.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        string script = "alert('Error: " + ex + "');";
        //        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
        //        throw;
        //    }


        //}

        //protected void cargarDropConsecutivo()
        //{

        //    try
        //    {
        //        string cadena = CdConsecutivo.cargarDropConsec();
        //        NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion);
        //        conexion.Open();
        //        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
        //        DataSet ds = new DataSet();
        //        da.Fill(ds);
        //        dropConsec.DataSource = ds;
        //        dropConsec.DataTextField = "nombre";
        //        dropConsec.DataValueField = "id";
        //        dropConsec.DataBind();
        //        dropConsec.Items.Insert(0, new ListItem("Consec Nuevo", "0"));
        //        conexion.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        string script = "alert('Error: " + ex + "');";
        //        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
        //        throw;
        //    }


        //}



        //protected Boolean validarSelect()
        //{
        //    if (dropModo.SelectedIndex == 0)
        //    {
        //        msjComboModoVacio();
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }

        //}

        //protected Boolean validarDuplicadoRelaciones(string idTipoDocumental)
        //{
        //    string td = idTipoDocumental;
        //    string modo = dropModo.SelectedItem.Text;
        //    try
        //    {
        //        conexion.Open();
        //        string cadena = CdRelaciones.validarDuplicadosRelaciones(td, modo);
        //        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cadena, conexion);
        //        DataSet ds = new DataSet();
        //        ds.Clear();
        //        da.Fill(ds);
        //        DataTable dt = ds.Tables[0];
        //        DataRow row = dt.Rows[0];
        //        string boo = row[0].ToString();
        //        if (boo.Equals("False"))
        //        {
        //            conexion.Close();
        //            return true;
        //        }
        //        else
        //        {
        //            msjRelacionExiste();
        //            conexion.Close();
        //            return false;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        string script = "alert('Error: " + ex + "');";
        //        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
        //        throw;
        //    }
        //}


        protected void dropModo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected int crearConsecutivoAutomatico(string referencia, int idTD)
        {
            string consec = consecutivoBase(idTD);
            DateTime dt = DateTime.Now;
            string anio = dt.ToString("yyyy");
            string fechaHora = dt.ToString("MM-dd-yyyy-HH:mm:ss");
            string nombre = "";
            try
            {
                string cadena = CdConsecutivo.insertar(consec, anio, referencia, fechaHora, nombre);
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
                        if (i+1 <= limite)
                        {
                            char act1 = formato[i + 1];
                            if (act1.Equals('O'))
                            {
                                if (i+2 <= limite)
                                {
                                    char act2 = formato[i + 2];
                                    if (act2.Equals('N'))
                                    {
                                        posicion = (i+2);
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
        protected void msjRelacionExiste()
        {
            string script = string.Format("alertaRelacionExiste();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alertaRelacionExiste", script, true);
        }
        protected void msjConsecutivoCreado()
        {
            string script = string.Format("alertaConsecutivoCreado();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alertaConsecutivoCreado", script, true);
        }
        protected void msjComboModoVacio()
        {
            string script = string.Format("alertaComboModoVacio();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alertaComboModoVacio", script, true);
        }

        protected void gvtipodocumental_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

    }
}