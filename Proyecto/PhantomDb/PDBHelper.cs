using System;
using PhantomDb.Armadores;

namespace PhantomDb
{
    public class PDBHelper : PDBHelperAbstract
    {
        #region Singleton
        public static PDBHelper Instance
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

            internal static readonly PDBHelper instance = new PDBHelper();
        }

        PDBHelper()
        {
        }
        #endregion

        public static ArmadorFactory Factory = new ArmadorFactory(null);

        protected override Armador GetArmador(Type t)
        {
            return Factory.CreateFromClass(t);
        }

    }
}
