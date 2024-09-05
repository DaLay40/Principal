using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Utilitarios.Modelo;
using Utilitarios.Classes;
using System.Drawing.Drawing2D;

namespace GestorFinanceiro.Formularios
{
    public partial class FrmBase : DevExpress.XtraEditors.XtraForm
    {

        public int TipoFormulario { get; set; }
        public FrmBase()
        {
            InitializeComponent();
            Configure();
        }

        public virtual void DelegarEventos()
        {

        }

        public virtual void Configure()
        {
            Text = "Gestor Financeiro";
          
        }

        

    }
  
    
}