using System;
using System.Reflection;
using PhantomDb.Entidades;
using PhantomDb.Armadores;
using System.Collections.Generic;

namespace PhantomDb
{
    internal class PropertyIterator
    {
        Type t;
        object o;

        public delegate void Void_Atributo(ref Armador arm, Atributo a, PropertyInfo pi, object val);
        public delegate void Void_Columna(ref Armador arm, Entidades.Columna c, PropertyInfo pi, object val);
        public delegate void Void_Relacion(ref Armador arm, Entidades.Relacion r, PropertyInfo pi, object val);
        public delegate void Void_Identificador(ref Armador arm, Identificador i, PropertyInfo pi, object val);

        public event Void_Atributo AlEncontrarAtributo = null;
        public event Void_Columna AlEncontrarColumna = null;
        public event Void_Identificador AlEncontrarIdentificador = null;
        public event Void_Relacion AlEncontrarRelacion = null;

        public PropertyIterator(Type t)
            : this(t, null)
        {
        }

        public PropertyIterator(Type t, object o)
        {
            this.t = t;
            this.o = o;
        }

        private void CallEventAtributo(ref Armador arm, Atributo a, PropertyInfo pi, object val)
        {
            if (this.AlEncontrarAtributo != null)
                this.AlEncontrarAtributo(ref arm, a, pi, val);
        }
        private void CallEventColumna(ref Armador arm, Entidades.Columna a, PropertyInfo pi, object val)
        {
            if (this.AlEncontrarColumna != null)
                this.AlEncontrarColumna(ref arm, a, pi, val);
        }

        private void CallEventIdentificador(ref Armador arm, Identificador i, PropertyInfo pi, object val)
        {
            if (this.AlEncontrarIdentificador != null)
                this.AlEncontrarIdentificador(ref arm, i, pi, val);
        }

        private void CallEventRelacion(ref Armador arm, Entidades.Relacion r, PropertyInfo pi, object val)
        {
            if (this.AlEncontrarRelacion != null)
                this.AlEncontrarRelacion(ref arm, r, pi, val);
        }
        
        protected void Process(ref Armador arm, Type tipo)
        {
            //Recorre los atributos declarados sobre la clase
            foreach (object classAtri in tipo.GetCustomAttributes(false))
            {
                if (classAtri.GetType().Equals(typeof(Heredar)))
                {
                    this.Process(ref arm, ((Heredar)classAtri).Padre);
                }
            }

            bool atributo; // Bugfix Columna-Atributo

            //Recorre las properties del objeto
            foreach (PropertyInfo p in tipo.GetProperties())
            {
                atributo = false; // Bugfix
                //Si tiene atributos personalizados...
                //if (p.GetCustomAttributes(true).Length > 0)
                //{
                    //Se recorren los atributos personalizados...
                    foreach (object atri in p.GetCustomAttributes(true))
                    {
                        //Si se debe ignorar el atributo, fin.
                        if (atri.GetType().Equals(typeof(IgnorarAtributo)))
                        {
                            atributo = true;
                            break;
                        }
                        //Si el atributo es identificador, se agrega como identificador.
                        else if (atri.GetType().Equals(typeof(Identificador)))
                        {
                            Identificador i = (Identificador)atri;
                            if (i.Nombre.Equals(""))
                            {
                                i.Nombre = p.Name;
                            }
                            atributo = true;

                            this.CallEventIdentificador(ref arm, i, p, o);
                        }
                        //Si el atributo es atributo, se agrega como atributo.
                        else if (atri.GetType().Equals(typeof(Atributo)))
                        {
                            Atributo at = (Atributo)atri;
                            if (at.Nombre.Equals(""))
                            {
                                at.Nombre = p.Name;
                            }

                            atributo = true;
                            this.CallEventAtributo(ref arm, at, p, o);
                        }
                        else if (atri.GetType().Equals(typeof(Entidades.Columna)))
                        {
                            Entidades.Columna c = (Entidades.Columna)atri;
                            if (c.Titulo.Equals(""))
                            {
                                c.Titulo = p.Name;
                            }

                            this.CallEventColumna(ref arm, c, p, o);
                        }
                        else if (atri.GetType().Equals(typeof(Entidades.Relacion)))
                        {
                            Entidades.Relacion r = (Entidades.Relacion)atri;
                            this.CallEventRelacion(ref arm, r, p, o);
                        }
                    }

                    if (!atributo)
                    {
                        this.CallEventAtributo(ref arm, new Atributo(p.Name, false), p, o);
                    }
                //}
                //else //Si no tiene atributos personalizados, se toma como que fuera un atributo.
                //{
                //    this.CallEventAtributo(ref arm, new Atributo(p.Name, false), p, o);
                //}
            }
        }

        public void Process(ref Armador arm)
        {
            this.Process(ref arm, this.t);
        }
    }
}
