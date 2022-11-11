using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Drawing;
using System.Xml.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Rectangle = iTextSharp.text.Rectangle;
using GCR.JavaScript;
using System.Web.Services.Description;

namespace GCR.Pages
{
    public partial class Pdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            

        }

        protected void btnSubirArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                string radicado = "DPDJDU958928";
                string nombre = String.Format("{0}_{1}_{2}", Path.GetFileNameWithoutExtension(fileUPdf.FileName), radicado, Path.GetExtension(fileUPdf.FileName));
                fileUPdf.SaveAs(Server.MapPath("~/Archivos/") + nombre);
                Label1.Text = "El archivo " + fileUPdf.FileName + " ha sido subido correctamente";
            }
            catch
            {
                Label1.Text = "Ha ocurrido un error al intentar subir el archivo al servidor";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


        }


        protected void btnPrueba_Click(object sender, EventArgs e)
        {
            string viejoArchvio = Server.MapPath("~/Archivos/Prueba.pdf");
            string viejoArchvio2 = Server.MapPath("~/Archivos/con_texto.pdf");

            PdfReader objetoReader = new PdfReader(viejoArchvio);
            Rectangle objetoTamanio = objetoReader.GetPageSize(1);

            string script = string.Format("alert('Bienvenido:{0}');", objetoTamanio);
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);

            Document objetoDocumento = new Document(objetoTamanio);

            FileStream objetoFileS = new FileStream(viejoArchvio2, FileMode.Create, FileAccess.Write);
            PdfWriter objetoWriter = PdfWriter.GetInstance(objetoDocumento, objetoFileS);

            objetoDocumento.Open();

            PdfContentByte objetoPdf = objetoWriter.DirectContent;

            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            objetoPdf.SetColorFill(BaseColor.BLACK);
            objetoPdf.SetFontAndSize(bf, 20);

            objetoPdf.BeginText();

            string texto = "RADICADO # TP[000]MCONSE";
            objetoPdf.ShowTextAligned(20, texto, 40, objetoTamanio.Height-50, 0);
            objetoPdf.EndText();

            PdfImportedPage page = objetoWriter.GetImportedPage(objetoReader, 1);
            objetoPdf.AddTemplate(page, 0, 0);

            objetoDocumento.Close();
            objetoFileS.Close();
            objetoWriter.Close();
            objetoReader.Close();
        }
    }
}