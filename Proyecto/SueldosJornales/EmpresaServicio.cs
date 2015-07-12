using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SueldosJornales
{
    /*Este punto se refiere exclusivamente a aquellas empresas que proveen de
    personal eventual o temporario y cuyos datos deben componer el libro de la
    Ley 20744 (art. 52).*/
    public class EmpresaServicio
    {
        private string codigo;
        private string razonSocial;
        private bool habilitado;

        public EmpresaServicio(string codigo, string razonSocial) 
        {
            this.codigo = codigo;
            this.razonSocial = razonSocial;
            this.habilitado = true;
        }
    }
}
