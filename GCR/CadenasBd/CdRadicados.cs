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


    }
}