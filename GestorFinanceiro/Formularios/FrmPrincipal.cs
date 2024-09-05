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
using Utilitarios.Extencions;
using Utilitarios.LayoutModels;
using Utilitarios.Classes;
using Utilitarios.Entidades;
using System.Collections;
using DevExpress.Utils;
using DevExpress.LookAndFeel;
using MaterialSkin.Controls;
using System.Reflection;

namespace GestorFinanceiro.Formularios
{
    public partial class FrmPrincipal : FrmBase
    {

        private List<Titulo> listaTitulos = new List<Titulo>();
        private BindingSource bindingTitulos = new BindingSource();

        public FrmPrincipal() 
        {
            InitializeComponent();
            this.Configure();
            this.DelegarEventos();
            this.AtualizarTela();
        }
        

        public override void DelegarEventos()
        {
            base.DelegarEventos();
            this.bntTitulo.Click += EventoTelaTitulos;
            this.btnTema.Click += EventoTema;
            this.materialFlatButton1.Click += EventoNovoForm;
        }

        private void EventoNovoForm(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }

        private void EventoTema(object sender, EventArgs e)
        {
            string teste = SkinStyle.Office2010Blue;
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(SkinStyle.Blue);
            DevExpress.LookAndFeel.LookAndFeelHelper.ForceDefaultLookAndFeelChanged();

            
        }

        private void EventoTelaTitulos(object sender, EventArgs e)
        {
            new FrmTitulo().ShowDialog();
            AtualizarTela();
        }

        private void Teste()
        {
            this.panelResumo.Controls.Clear();
            for (int i = 0; i< 10;i++)
            {
                LayoutItemResumo lt = new LayoutItemResumo()
                {
                    Title = "Teste" + i.ToString(),
                    Color = Util.GetColor("SkyBlue"),
                    Text = "R$ 200 "
                };

                this.panelResumo.AddItemResumo(lt);
            }

            //myComboBox1.SetDataSource(Util.GetThems(),)

        }
        
        private void AtualizarTela()
        {
            this.listaTitulos = DbHelper.Select<Titulo>();
            this.bindingTitulos.DataSource = this.listaTitulos;
            this.gridControlTitulos.DataSource = this.bindingTitulos;
            this.gridViewTitulos.SetFormatRulesSituacoes();
            this.gridViewTitulos.BestFitColumns();
            Teste();
        }

    }
}