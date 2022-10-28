using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace GCR.CadenasBd
{
    public class CdTipoDocumental
    {
        public static string mostrarDatos()
        {
            string cd = "SELECT * FROM public.tipodocumental";
            return cd;
        }

        public static string cargarDatos(string id)
        {
            string cd = "SELECT * FROM public.tipodocumental WHERE id=" + id + ";";
            return cd;
        }

        public static string insertar(string codigo, string nombre, string formato)
        {
            string cd = "INSERT INTO tipodocumental(codigo, nombre, formato ) values('" + codigo + "', '" + nombre + "', '" + formato + "');";
            return cd;
        }

        public static string actualizar(string codigo, string nombre, string formato, string id)
        {
            string cd = "UPDATE tipodocumental SET codigo = '" + codigo + "',nombre = '" + nombre + "', formato = '" + formato + "' WHERE id = " + id + ";";
            return cd;
        }

        public static string eliminar(string id)
        {
            string cd = "DELETE FROM tipodocumental WHERE id = " + id + ";";
            return cd;
        }

    }
}