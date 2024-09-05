using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Entidades
{
    public class SituacaoTitulos : TableBase
    {

        public string Descricao { get; set; }
        public string BackColor1 { get; set; }
        public string BackColor2 { get; set; }
        public string ForeColor { get; set; }
        public string BorderColor { get; set; }
        public Int64? IdComputador { get; set; }
        public int Enumerator { get; set; }

    }
}
