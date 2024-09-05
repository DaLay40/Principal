using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios.Enumerators;
using Utilitarios.Extencions;

namespace Utilitarios.Entidades
{
    public class Titulo : TableBase
    {

        public Titulo()
        {
            this.Data = DateTime.Now;
        }

        public string Descricao {get;set;}
        public DateTime Data {get;set;}
        public Decimal Valor {get;set;}
        public int Tipo {get;set;}
        public int Situacao {get;set;}
        public bool Fixo { get; set; }

        public virtual ETipoTitulo ETipo
        { get { return (ETipoTitulo)this.Tipo; } set { this.Tipo = (int)value; } }

        public virtual ESituacaoTitulo ESituacao
        { get { return (ESituacaoTitulo)this.Situacao; } set { this.Situacao = (int)value; } }

        public virtual string StringFixo
        { get { return this.Fixo.SimNao(); } }
    }
}
