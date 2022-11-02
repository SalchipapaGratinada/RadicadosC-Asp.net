using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCR.CadenasBd
{
    public class CdRadicados
    {

        public static string cargarDropTd()
        {
            string cd = "SELECT id, nombre FROM tipodocumental ORDER BY id";
            return cd;
        }

        public static string cargarDropM(int idTd)
        {
            string cd = "SELECT md.id AS id, md.nombre As nombre FROM detalletdm AS dtdm JOIN tipodocumental AS td " +
                " ON td.id = dtdm.id_tipodocumental JOIN modo AS md ON md.id = dtdm.id_modo " +
                " JOIN consecutivo AS cons ON cons.id = dtdm.id_consecutivo WHERE td.id ="+ idTd +" ORDER BY id";
            return cd;
        }

        public static string traerIdConsecutivoRelacion(int idTd, int idM)
        {
            string cd = "SELECT dtm.id_consecutivo FROM detalletdm AS dtm WHERE dtm.id_tipodocumental = "+idTd+" AND dtm.id_modo = "+idM+"; ";
            return cd;
        }
        public static string traerConsecutivo(int idConsec)
        {
            string cd = "SELECT consec FROM consecutivo WHERE id = "+idConsec+";";
            return cd;
        }

        public static string actualizarConsecutivo(string nuevoConsec, int idConsec)
        {
            string cd = "UPDATE consecutivo set consec = '"+nuevoConsec+"' WHERE id = "+idConsec+";";
            return cd;
        }


        


    }
}