using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios.CustomAttributes;

namespace Utilitarios.Enumerators
{
    public enum ESituacaoTitulo
    {
        [SituacaoTituloAttibute("250, 210, 120")]
        Pendente = 0,
        [SituacaoTituloAttibute("255,150,150")]
        Vencida = 1,
        [SituacaoTituloAttibute("140,221,211")]
        Paga = 2

    }
}
