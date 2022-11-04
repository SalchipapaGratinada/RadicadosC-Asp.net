using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCR.CadenasBd
{
    public class CdConsecutivo
    {

        public static string mostrarDatos()
        {
            string cd = "SELECT id as ID, consec as Consecutivo, anio as Año, referencia, fechahora as Fecha FROM public.consecutivo";
            return cd;
        }

        public static string cargarDatos(string id)
        {
            string cd = "SELECT * FROM public.consecutivo WHERE id=" + id + ";";
            return cd;
        }

        public static string actualizar(string consec, string anio, string refer, string id)
        {
            string cd = "UPDATE consecutivo SET consec = '" + consec + "',anio = '" + anio + "' , referencia = '"+ refer + "'  WHERE id = " + id + ";";
            return cd;
        }

        public static string insertar(string consec, string anio, string refer, string fechaHora)
        {
            string cd = "INSERT INTO consecutivo(consec, anio, referencia, fechahora) values('" + consec + "', '" + anio + "', '" + refer + "', '"+fechaHora+"');";
            return cd;
        }
        public static string cargarDropConsec()
        {
            string cd = "SELECT id, consec FROM consecutivo ORDER BY id;";
            return cd;
        }


    }
}