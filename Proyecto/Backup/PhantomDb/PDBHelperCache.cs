using System;
using System.Collections.Generic;
using System.Text;
using PhantomDb;
using PhantomDb.Armadores;
using System.Collections;
using System.Data;

namespace PhantomDb
{
    public class PDBHelperCache : PDBHelperAbstract
    {
        #region Singleton
        public static PDBHelperCache Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly PDBHelperCache instance = new PDBHelperCache();
        }

        PDBHelperCache()
        {
        }
        #endregion

        Dictionary<Type, Armador> cache = new Dictionary<Type, Armador>();
        public Dictionary<Type, Armador> Cache
        {
            get { return cache; }
            set { cache = value; }
        }

        public static ArmadorFactory Factory = new ArmadorFactory(null);

        protected override Armador GetArmador(Type t)
        {
            Armador armador;

            try
            {
                armador = (Armador)Cache[t];
            }
            catch (KeyNotFoundException)
            {
                armador = Factory.CreateFromClass(t);
                Cache[t] = armador;
            }

            return armador;
        }

    }
}
