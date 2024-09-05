using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios.Classes;
using Utilitarios.Modelo;

namespace Utilitarios.Entidades
{
    public class Computador : TableBase
    {

        public string Nome { get; set; }
        public string NumeroSerie { get; set; }
        public DateTime UltimoAcesso { get; set; }

    }
}
