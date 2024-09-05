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
using Utilitarios;
using Utilitarios.Extencions;
using Utilitarios.Enumerators;

namespace Utilitarios.MyMsg
{
    public partial class frmMyMsgBox : DevExpress.XtraEditors.XtraForm
    {

        private DialogResult Result = DialogResult.Cancel;

        private frmDetalhesExeption detalhesException = new frmDetalhesExeption();

        public frmMyMsgBox()
        {
            InitializeComponent();
            DelegarEventos();
        }

        private void DelegarEventos()
        {
            this.btnCancelar.Click += EventoCancelar;
            this.btnOk.Click += EventoOk;
            this.btnSim.Click += EventoSim;
            this.btnNao.Click += EventoNao;
            this.lblMaisDetalhesErro.Click += EventoExibirDetalhes;
        }

        public DialogResult Exibir(string Mensagem, string Titulo, EBotoesMyMsgBox Botoes = EBotoesMyMsgBox.Ok, EIconeMyMsgBox Icon = EIconeMyMsgBox.Informacao,ETamanhoMsgBox Tamanho = ETamanhoMsgBox.Medio, MyExeption Ex = null)
        {
            this.txtMenssagem.Text = Mensagem;
            this.lblTitulo.Text = Titulo;
            this.ConfigurarMessageBox(Botoes, Icon);

            if (!Ex.IsNull())
                this.ConfigurarDetalhes(Ex);

            this.ConfigurarTamanho(Tamanho);
            this.ShowDialog();

            this.Dispose();
            this.detalhesException.Dispose();
            return Result;
        }

        private void ConfigurarDetalhes(MyExeption ex)
        {
            this.detalhesException.txtDetalhes.Text = ex.Detalhes;
            this.detalhesException.lblTitulo.Text = ex.Title;
        }

        private void ConfigurarMessageBox(EBotoesMyMsgBox Botoes, EIconeMyMsgBox Icon)
        {
            switch (Botoes)
            {
                case EBotoesMyMsgBox.Ok:
                    {
                        this.pnlBtnOk.Visible = true;
                        break;
                    }
                case EBotoesMyMsgBox.SimNao:
                    {
                        this.pnlBtnSim.Visible = true;
                        this.pnlBtnNao.Visible = true;
                        break;
                    }
                case EBotoesMyMsgBox.OkCancelar:
                    {
                        this.pnlBtnOk.Visible = true;
                        this.pnlBtnCancelar.Visible = true;
                        break;
                    }
                case EBotoesMyMsgBox.SimNaoCancelar:
                    {
                        this.pnlBtnSim.Visible = true;
                        this.pnlBtnNao.Visible = true;
                        this.pnlBtnCancelar.Visible = true;
                        break;
                    }
            }

            switch (Icon)
            {
                case EIconeMyMsgBox.Erro:
                    {
                        this.iconErro.Visible = true;
                        this.pnlCabecalho.Appearance.BackColor = Color.White;
                        this.pnlCabecalho.Appearance.BackColor2 = Color.FromArgb(255, 192, 192);
                        this.pnlDetalhesErro.Visible = true;
                        break;
                    }
                case EIconeMyMsgBox.Aviso:
                    {
                        this.iconAviso.Visible = true;
                        this.pnlCabecalho.Appearance.BackColor = Color.White;
                        this.pnlCabecalho.Appearance.BackColor2 = Color.FromArgb(255, 224, 192);
                        break;
                    }
                case EIconeMyMsgBox.Informacao:
                    {
                        this.iconInformacao.Visible = true;
                        this.pnlCabecalho.Appearance.BackColor = Color.White;
                        this.pnlCabecalho.Appearance.BackColor2 = Color.LightBlue;
                        break;
                    }
                case EIconeMyMsgBox.Sucesso:
                    {
                        this.iconSucesso.Visible = true;
                        this.pnlCabecalho.Appearance.BackColor = Color.White;
                        this.pnlCabecalho.Appearance.BackColor2 = Color.FromArgb(192, 255, 192);
                        break;
                    }
                case EIconeMyMsgBox.Pergunta:
                    {
                        this.iconPergunta.Visible = true;
                        this.pnlCabecalho.Appearance.BackColor = Color.White;
                        this.pnlCabecalho.Appearance.BackColor2 = Color.LightBlue;
                        break;
                    }
            }

        }

        private void ConfigurarTamanho(ETamanhoMsgBox Tamanho)
        {
            //W595
            //H295
            Size size = new Size();
            if(Tamanho.Equals(ETamanhoMsgBox.Pequeno) || Tamanho.Equals(ETamanhoMsgBox.PequenoFixo))
                size = new Size(440, 265);
            else if(Tamanho.Equals(ETamanhoMsgBox.Medio) || Tamanho.Equals(ETamanhoMsgBox.MedioFixo))
                size = new Size(595, 295);
            else if (Tamanho.Equals(ETamanhoMsgBox.Grande) || Tamanho.Equals(ETamanhoMsgBox.GrandeFixo))
                size = new Size(795, 395);
            
            this.Size = size;

            if (Tamanho.Equals(ETamanhoMsgBox.PequenoFixo) || Tamanho.Equals(ETamanhoMsgBox.MedioFixo) || Tamanho.Equals(ETamanhoMsgBox.GrandeFixo))
            {
                this.MaximumSize = size;
                this.MinimumSize = size;
                this.MaximizeBox = false;
            }

        }

        private void EventoCancelar(object sender, EventArgs e)
        {
            this.Result = DialogResult.Cancel;
            this.Close();
        }

        private void EventoOk(object sender, EventArgs e)
        {
            this.Result = DialogResult.OK;
            this.Close();
        }

        private void EventoSim(object sender, EventArgs e)
        {
            this.Result = DialogResult.Yes;
            this.Close();
        }

        private void EventoNao(object sender, EventArgs e)
        {
            this.Result = DialogResult.No;
            this.Close();
        }

        private void EventoExibirDetalhes(object sender, EventArgs e)
        {
            this.detalhesException.Show();
        }
    }
}