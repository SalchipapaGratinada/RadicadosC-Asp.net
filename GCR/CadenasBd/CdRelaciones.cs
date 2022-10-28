using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCR.CadenasBd
{
    public class CdRelaciones
    {

        public static string mostrarRelaciones()
        {
            string cd = "SELECT dtdm.id, td.nombre AS TipoDocumental, md.nombre AS Modo,  cons.consec AS NuConsec , " +
                    "cons.anio AS Año, dtdm.fecha AS Fecha " +
                    "FROM detalletdm AS dtdm JOIN tipodocumental AS td " +
                    "ON td.id = dtdm.id_tipodocumental " +
                    "JOIN modo AS md ON md.id = dtdm.id_modo " +
                    "JOIN consecutivo AS cons ON cons.id = dtdm.id_consecutivo ";
            return cd; 
        }

        public static string cargarDropTd()
        {
            string cd = "SELECT id, nombre FROM tipodocumental ORDER BY id";
            return cd;
        }

        public static string cargarDropM ()
        {
            string cd = "SELECT id,  nombre FROM modo ORDER BY id";
            return cd;
        }

    }
}