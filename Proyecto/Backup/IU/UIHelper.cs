using System;
using Ext.Net;
using System.Web.SessionState;
using System.Web.UI;

namespace IU
{
    public class UIHelper
    {
        public static void PaginaMensaje(Page p, string titulo, string mensaje)
        {
            p.Session["Mensaje"] = mensaje;
            p.Session["Titulo"] = titulo;
            p.Response.Redirect("../../Mensaje.aspx");
        }

        public static void FuncionalidadNoImplementada(Page p)
        {
            p.Session["Mensaje"] = "Lo sentimos, pero no se ha implementado la funcionalidad para esta versión.";
            p.Session["Titulo"] = "Funcionalidad no implementada";
            p.Response.Redirect("../../Mensaje.aspx");
        }
        public static void AccesoDenegado(Page p)
        {
            p.Session["Mensaje"] = "Usted no tiene los permisos para acceder a esta sección.";
            p.Session["Titulo"] = "Acceso denegado";
            p.Response.Redirect("../../Mensaje.aspx");
        }

        public static void MostrarExcepcion(Exception ex, string titulo)
        {
            MostrarError(ex.Message + "\n" + ex.StackTrace, titulo);
        }

        public static void MostrarExcepcionSimple(Exception ex, string titulo)
        {
            MostrarError(ex.Message, titulo);
        }

        public static void MostrarError(string mensaje, string titulo)
        {
            MostrarError(mensaje, titulo, null);
        }

        public static void MostrarError(string mensaje, string titulo, JFunction fn)
        {
            X.Msg.Show(new MessageBoxConfig
            {
                Title = titulo,
                Message = mensaje,
                Buttons = MessageBox.Button.OK,
                Icon = MessageBox.Icon.ERROR,
                Fn = fn
            });
        }
    }
}
