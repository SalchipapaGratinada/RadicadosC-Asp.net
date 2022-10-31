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

        public static string cargarDatos(string id)
        {
            string cd = "SELECT dtdm.id, td.nombre AS TipoDocumental, md.nombre AS Modo,  cons.consec AS NuConsec , " +
                    "cons.anio AS Año, dtdm.fecha AS Fecha " +
                    "FROM detalletdm AS dtdm JOIN tipodocumental AS td " +
                    "ON td.id = dtdm.id_tipodocumental " +
                    "JOIN modo AS md ON md.id = dtdm.id_modo " +
                    "JOIN consecutivo AS cons ON cons.id = dtdm.id_consecutivo WHERE dtdm.id = "+id+"";
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

        public static string validarDuplicadosRelaciones(string td, string modo)
        {
            string cd = "SELECT EXISTS (SELECT  FROM detalletdm AS ps JOIN tipodocumental AS td ON " +
                " td.id = ps.id_tipodocumental JOIN modo AS md ON md.id = ps.id_modo " +
                " JOIN consecutivo AS cons ON cons.id = ps.id_consecutivo " +
                " WHERE td.nombre = '"+td+"' and md.nombre = '"+modo+"' )";
            return cd;
        }

        public static string ultimoConsec()
        {
            string cd = "SELECT MAX(id) FROM consecutivo";
            return cd;
        }

        public static string insertar(int idTd, int idM, int idCons, string fecha)
        {
            string cd = "INSERT INTO detalletdm(id_tipodocumental, id_modo, id_consecutivo, fecha) values("+idTd+", "+idM+", "+idCons+", '"+fecha+"');";
            return cd;
        }
        public static string eliminar(int idTd, int idM)
        {
            string cd = "DELETE FROM detalletdm WHERE id_tipodocumental = "+idTd+" AND id_modo = "+idM+" ";
            return cd;
        }

        


    }
}