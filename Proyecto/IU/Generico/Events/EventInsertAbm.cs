using System;
using Ext.Net;

namespace IU.Generico.Events
{
    /// <summary>
    /// Evento ejecutado antes de insertar un registro dentro de la base de datos.
    /// </summary>
    public class EventInsertAbm : EventArgs
    {
        private object tag;
        /// <summary>
        /// Objeto a insertar.
        /// </summary>
        public object Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        private BeforeRecordInsertedEventArgs parentEventArgs;
        public BeforeRecordInsertedEventArgs ParentEventArgs
        {
            get { return parentEventArgs; }
            set { parentEventArgs = value; }
        }

        public EventInsertAbm(object tag, ref BeforeRecordInsertedEventArgs parentEventArgs)
            : base()
        {
            Tag = tag;
            ParentEventArgs = parentEventArgs;
        }
    }
}
