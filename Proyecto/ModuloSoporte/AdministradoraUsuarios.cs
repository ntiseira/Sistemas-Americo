using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos.ModuloSoporte;
using System.Data;
using CapaDatos;

namespace ModuloSoporte
{
    public static class AdministradoraUsuarios
    {
        public static bool Acceder(string user, string clave)
        {
            DataSet ds = DatosSoporte.LoguearUsuario(user, clave);
            if (Datos.EstaVacio(ds))
                return false;
            else
            {
                object [] valores = Datos.GetValores(ds);
                Usuarios u = new Usuarios(valores[0].ToString(), "", valores[1].ToString());
                ModuloSoporte.Global.TipoUsuario = u.Tipo;
                ModuloSoporte.Global.Usuario = u.Usuario;
                Global.CodEmpresa = 0;
                return true;
            }
        }

        public static bool validarUsuario(string usuario, string contraseña)
        {
            return DatosSoporte.validarUsuario(usuario, contraseña);
        }
    }
}
