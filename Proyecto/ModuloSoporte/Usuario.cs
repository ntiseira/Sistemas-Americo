using System;

namespace ModuloSoporte
{
    public class Usuarios
    {
        string usuario;
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        string clave;
        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }

        string tipo;
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public Usuarios(string usuario, string clave, string tipo)
        {
            Usuario = usuario;
            Clave = clave;
            Tipo = tipo;
        }
    }
}
