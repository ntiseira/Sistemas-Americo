using System;
using System.Collections.Generic;
using System.Text;

namespace AdministradorGeneral.Seguridad
{
    public class Permisos
    {
        int permisos;
        public int Grado
        {
            get { return permisos; }
            set { permisos = value; }
        }

        public bool Alta
        {
            get { return this.GetBit(0); }
            set { this.SetBit(0, value); }
        }

        public bool Baja
        {
            get { return this.GetBit(1); }
            set { this.SetBit(1, value); }
        }

        public bool Modif
        {
            get { return this.GetBit(2); }
            set { this.SetBit(2, value); }
        }

        public Permisos()
        {
            Grado = 0;
        }

        /// <summary>
        /// Crea un objeto con permisos totales.
        /// </summary>
        public static Permisos PermisosAdmin
        {
            get { return new Permisos { Modif = true, Baja = true, Alta = true }; }
        }

        /// <summary>
        /// Crea un objeto sin permisos.
        /// </summary>
        public static Permisos PermisosGuest
        {
            get { return new Permisos { Grado = 0 }; }
        }

        public static bool operator >=(Permisos d1, Permisos d2)
        {
            return d1.Grado >= d2.Grado;
        }
        public static bool operator >(Permisos d1, Permisos d2)
        {
            return d1.Grado > d2.Grado;
        }
        public static bool operator <=(Permisos d1, Permisos d2)
        {
            return d1.Grado <= d2.Grado;
        }
        public static bool operator <(Permisos d1, Permisos d2)
        {
            return d1.Grado < d2.Grado;
        }

        private bool GetBit(int bit)
        {
            return (Grado & (int)Math.Pow(2d, (double)bit))>0;
        }

        private void SetBit(int bit, bool value)
        {
            int pos = (int)Math.Pow(2d, (double)bit);

            if (value)
            {
                Grado = Grado | pos;
            }
            else
            {
                Grado = Grado & (~pos);
            }
        }
    }
}
