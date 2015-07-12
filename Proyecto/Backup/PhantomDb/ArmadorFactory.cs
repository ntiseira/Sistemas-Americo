using System;
using System.Reflection;
using PhantomDb.Armadores;
using PhantomDb.Entidades;

namespace PhantomDb
{
    /// <summary>
    /// Fábrica de armadores. 
    /// Utiliza objetos InstanciadorDeArmador para fabricar armadores.
    /// Ver también <seealso cref="InstanciadorDeArmador"/>, <seealso cref="ArmadorFisico"/>
    /// </summary>
    public class ArmadorFactory
    {
        DataSet_String consultar;

        public DataSet_String Consultar
        {
            get { return consultar; }
            set { consultar = value; }
        }

        public ArmadorFactory(DataSet_String consultar)
        {
            this.Consultar = consultar;
        }

        public Armador CreateFromClass(Type t)
        {
            Armador arm = new Armador(t);
            arm.Consultar = this.Consultar;
            PropertyIterator it = new PropertyIterator(t);
            it.AlEncontrarAtributo += new PropertyIterator.Void_Atributo(Class_AlEncontrarAtributo);
            it.AlEncontrarIdentificador += new PropertyIterator.Void_Identificador(Class_AlEncontrarIdentificador);
            it.AlEncontrarColumna += new PropertyIterator.Void_Columna(it_AlEncontrarColumna);
            it.AlEncontrarRelacion += new PropertyIterator.Void_Relacion(it_AlEncontrarRelacion);
            it.Process(ref arm);

            arm.AsociarColumnas();
            arm.AsociarRelaciones();

            return arm;
        }

        public Armador CreateFromInstance(object o)
        {
            Type t = o.GetType();
            Armador arm = new Armador(t, o);
            arm.Consultar = this.Consultar;
            PropertyIterator it = new PropertyIterator(t, o);
            it.AlEncontrarAtributo += new PropertyIterator.Void_Atributo(Class_AlEncontrarAtributo);
            it.AlEncontrarIdentificador += new PropertyIterator.Void_Identificador(Class_AlEncontrarAtributo);
            it.AlEncontrarColumna += new PropertyIterator.Void_Columna(it_AlEncontrarColumna);
            it.AlEncontrarRelacion += new PropertyIterator.Void_Relacion(it_AlEncontrarRelacion);
            it.Process(ref arm);

            arm.AsociarColumnas();
            arm.AsociarRelaciones();

            return arm;
        }

        void it_AlEncontrarRelacion(ref Armador arm, Relacion r, PropertyInfo pi, object val)
        {
            Relacionado rc = new Relacionado
            {
                CampoId = r.CampoId,
                CampoSecundario = r.CampoSecundario,
                Destino = r.Destino,
                Where = r.Where,
                Nombre = pi.Name,
                PermitirNull = r.PermitirNull
            };
            arm.AgregarRelacion(rc);
        }

        void it_AlEncontrarColumna(ref Armador arm, Columna c, PropertyInfo pi, object val)
        {
            Columnas ac = new Columnas(c.Titulo, c.Visible);
            ac.Nombre = pi.Name;
            ac.Valores = c.Valores;
            ac.Formato = Formato.GetFormat(c.Formato);
            arm.AgregarColumna(ac);
        }

        void Class_AlEncontrarIdentificador(ref Armador arm, Identificador i, PropertyInfo pi, object val)
        {
            Atributos at;
            if (val != null)
            {
                at = new Atributos(i.Nombre, pi.GetValue(arm.InstanciaAsociada, null), pi, val);
            }
            else
            {
                at = new Atributos(i.Nombre, null, pi);
            }
            at.Atributo = pi.Name;
            at.Autogenerado = i.Autogenerado;
            at.SoloLectura = !i.Modificable;
            arm.AgregarIdentificador(at);
        }

        void Class_AlEncontrarAtributo(ref Armador arm, Atributo a, PropertyInfo pi, object val)
        {
            Atributos at;
            if (val != null)
            {
                at = new Atributos(a.Nombre, pi.GetValue(arm.InstanciaAsociada, null), pi, val);
            }
            else
            {
                at = new Atributos(a.Nombre, null, pi);
            }
            at.Atributo = pi.Name;
            at.Autogenerado = a.Autogenerado;
            at.SoloLectura = !a.Modificable;
            arm.Agregar(at);
        }
    }
}
