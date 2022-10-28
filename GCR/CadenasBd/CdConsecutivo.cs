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
            string cd = "SELECT id as ID, consec as Consecutivo, anio as Año  FROM public.consecutivo";
            return cd;
        }

        public static string cargarDatos(string id)
        {
            string cd = "SELECT * FROM public.consecutivo WHERE id=" + id + ";";
            return cd;
        }

        public static string actualizar(string consec, string anio, string id)
        {
            string cd = "UPDATE consecutivo SET consec = '" + consec + "',anio = '" + anio + "' WHERE id = " + id + ";";
            return cd;
        }

    }
}