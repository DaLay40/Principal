using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.CustomAttributes
{
    class SituacaoTituloAttibute : Attribute
    {

        public string Color { get; }
        public SituacaoTituloAttibute(string color)
        {
            Color = color;
        }
    }
}
