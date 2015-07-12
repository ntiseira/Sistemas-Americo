using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos.ModuloSoporte
{
    public class DatosSoporte
    {
        public static bool validarUsuario(string usuario, string contraseña)
        {
            string consulta = "SELECT usuario FROM usuarios WHERE usuario = '" + usuario + "' and contraseña = '" + contraseña + "';";

            DataSet ds = Datos.ConsultarEx(consulta);

            return !Datos.EstaVacio(ds);
        }

        public static DataSet LoguearUsuario(string usuario, string contraseña)
        {
            string consulta = "SELECT usuario, tipoUsuario FROM usuarios WHERE usuario = '" + usuario + "' and password = '" + contraseña + "';";

            return Datos.ConsultarEx(consulta);
        }

        public static void CreateId(long idRelation, string tabla)
        {
            Datos.ConsultarEx(String.Format(
                "INSERT INTO idSolution (id, idRelacion, tabla) VALUES (0, {0}, \"{1}\");"
                , idRelation, tabla));
        }

        public static DataSet GetId(long idRelation, string tabla)
        {
            return Datos.Consultar(String.Format(
                "INSERT INTO idSolution (id, idRelacion, tabla) VALUES (0, {0}, \"{1}\");"
                , idRelation, tabla));
        }

        public static DataSet NextId(long idRelation, string tabla)
        {
            return Datos.Consultar(String.Format(
                "UPDATE idSolution SET id = id+1;"
                , idRelation, tabla));
        }
    }
}
