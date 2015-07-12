using System;
using Ext.Net;

namespace IU.Generico.Events
{
    /// <summary>
    /// Evento ejecutado antes de insertar un registro dentro de la base de datos.
    /// </summary>
    public class EventUpdateAbm : EventArgs
    {
        private object tag;
        /// <summary>
        /// Objeto a modificar.
        /// </summary>
        public object Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        private BeforeRecordUpdatedEventArgs parentEventArgs;
        public BeforeRecordUpdatedEventArgs ParentEventArgs
        {
            get { return parentEventArgs; }
            set { parentEventArgs = value; }
        }

        public EventUpdateAbm(object tag, ref BeforeRecordUpdatedEventArgs parentEventArgs)
            : base()
        {
            Tag = tag;
            ParentEventArgs = parentEventArgs;
        }
    }
}
