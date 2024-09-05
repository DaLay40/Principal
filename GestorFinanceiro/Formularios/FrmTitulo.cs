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
using Utilitarios.Entidades;
using Utilitarios.Classes;
using Utilitarios.Enumerators;
using Utilitarios.MyMsg;
using Utilitarios.Extencions;

namespace GestorFinanceiro.Formularios
{
    public partial class FrmTitulo : FrmBase
    {

        public Titulo oTitulo;


        public FrmTitulo()
        {
            InitializeComponent();
            oTitulo = new Titulo();
            this.Configure();
            this.DelegarEventos();
            this.ConfigBinding();
        }

        public FrmTitulo(Titulo T)
        {
            InitializeComponent();
            this.oTitulo = T;
            this.Configure();
            this.DelegarEventos();
            this.ConfigBinding();
        }

        public override void DelegarEventos()
        {
            this.btnSalvar.Click += EventoSalvarTitulo;
        }

        private void EventoSalvarTitulo(object sender, EventArgs e)
        {
            this.ValidarCamposObrigatorios();
            if(oTitulo.Id == null)
            {
                oTitulo.Insert();
                MyMsgBox.Exibir("Titulo cadastrado com sucesso.", "Sucesso", EBotoesMyMsgBox.Ok, EIconeMyMsgBox.Sucesso);
            }
            else
            {
                oTitulo.Update();
                MyMsgBox.Exibir("Titulo atualizado com sucesso.", "Sucesso", EBotoesMyMsgBox.Ok, EIconeMyMsgBox.Sucesso);
            }
            this.LimparCampos();
            this.Close();
        }


        private void ConfigBinding()
        {
            CarregarCombo();
            this.txtDescricaoTitulo.DataBindings.Add("Text", oTitulo, "Descricao");
            this.txtValorTitulo.DataBindings.Add("Text", oTitulo, "Valor");
            this.cboTipoTitulo.DataBindings.Add("SelectedValue", oTitulo, "ETipo");
            this.chkFixo.DataBindings.Add("Checked", oTitulo, "Fixo");
            this.dtDataTitulo.DataBindings.Add("DateTime", oTitulo, "Data");
        }

        private void CarregarCombo()
        {
            this.cboTipoTitulo.SetDataSource(Util.GetDataSource(typeof(ETipoTitulo)), "Value", "Key", "Key", "Tipo Titulo");
        }

    }
}