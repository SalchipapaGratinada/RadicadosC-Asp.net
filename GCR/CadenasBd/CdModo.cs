using GCR.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCR.CadenasBd
{
    public class CdModo
    {
        public static string mostrarDatos()
        {
            string cd = "SELECT * FROM public.modo";
            return cd;
        }

        public static string cargarDatos(string id)
        {
            string cd = "SELECT * FROM public.modo WHERE id=" + id + ";";
            return cd;
        }

        public static string insertar(string codigo, string nombre)
        {
            string cd = "INSERT INTO modo(codigo, nombre ) values('" + codigo + "', '" + nombre + "');";
            return cd;
        }

        public static string actualizar(string codigo, string nombre, string id)
        {
            string cd = "UPDATE modo SET codigo = '" + codigo + "',nombre = '" + nombre + "' WHERE id = " + id + ";";
            return cd;
        }

        public static string eliminar(string id)
        {
            string cd = "DELETE FROM modo WHERE id = " + id + ";";
            return cd;
        }

        public static string traerCodigoModo(string nombre)
        {
            string cd = "SELECT codigo FROM modo WHERE nombre = '"+nombre+"'";
            return cd;
        }

        public static string buscar(string cadena)
        {
            string cd = "SELECT* FROM modo WHERE nombre LIKE '%"+cadena+"%'";
            return cd;
            
        }
        public static string cargarDropModoSoloDisponibles(int id)
        {
            string cd = "SELECT md.id AS id, md.nombre As nombre FROM modo AS md " +
                " WHERE NOT EXISTS(SELECT NULL FROM detalletdm AS dtdm" +
                " WHERE dtdm.id_modo = md.id AND dtdm.id_tipodocumental = "+id+")";
            return cd;

        }

        public static string cargarDropModoSoloAgregados(int id)
        {
            string cd = "SELECT md.id AS id, md.nombre As nombre FROM modo AS md" +
                " LEFT JOIN detalletdm AS dtdm ON md.id = dtdm.id_modo WHERE dtdm.id_tipodocumental = "+id+"" +
                " AND md.id = dtdm.id_modo ORDER BY md.id; ";
            return cd;
        }

       


    }
}