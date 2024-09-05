namespace GestorFinanceiro.Formularios
{
    partial class FrmTitulo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTitulo));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSalvar = new DevExpress.XtraEditors.SimpleButton();
            this.chkFixo = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dtDataTitulo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboTipoTitulo = new Utilitarios.Componentes.MyComboBox();
            this.txtConteudoView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtValorTitulo = new Utilitarios.Componentes.MyTextBox();
            this.txtDescricaoTitulo = new Utilitarios.Componentes.MyTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkFixo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDataTitulo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDataTitulo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoTitulo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConteudoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorTitulo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescricaoTitulo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.panelControl1);
            this.groupControl1.Controls.Add(this.chkFixo);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.cboTipoTitulo);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.dtDataTitulo);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtValorTitulo);
            this.groupControl1.Controls.Add(this.txtDescricaoTitulo);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(620, 203);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Titulo";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnSalvar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(2, 161);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(616, 40);
            this.panelControl1.TabIndex = 9;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Location = new System.Drawing.Point(512, 6);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(94, 29);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Salvar";
            // 
            // chkFixo
            // 
            this.chkFixo.Location = new System.Drawing.Point(34, 42);
            this.chkFixo.Name = "chkFixo";
            this.chkFixo.Properties.Caption = "Titulo recorrente ?";
            this.chkFixo.Size = new System.Drawing.Size(158, 24);
            this.chkFixo.TabIndex = 8;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(476, 75);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(25, 16);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Tipo";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(335, 72);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(26, 16);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Data";
            // 
            // dtDataTitulo
            // 
            this.dtDataTitulo.EditValue = new System.DateTime(2024, 8, 28, 18, 8, 30, 0);
            this.dtDataTitulo.Location = new System.Drawing.Point(335, 94);
            this.dtDataTitulo.Name = "dtDataTitulo";
            this.dtDataTitulo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDataTitulo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDataTitulo.Size = new System.Drawing.Size(125, 22);
            this.dtDataTitulo.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(191, 72);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(30, 16);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Valor";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(34, 72);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 16);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Descrição";
            // 
            // cboTipoTitulo
            // 
            this.cboTipoTitulo.DataSource = null;
            this.cboTipoTitulo.DisplayMember = "";
            this.cboTipoTitulo.IdObjetoRetorno = null;
            this.cboTipoTitulo.Location = new System.Drawing.Point(476, 94);
            this.cboTipoTitulo.Margin = new System.Windows.Forms.Padding(0);
            this.cboTipoTitulo.Name = "cboTipoTitulo";
            this.cboTipoTitulo.NaoMudarFocoTeclaEnter = false;
            this.cboTipoTitulo.NaoMudarReadOnly = false;
            this.cboTipoTitulo.PermitirTextoDigitadoQueNaoEstaNaLista = false;
            this.cboTipoTitulo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoTitulo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cboTipoTitulo.Properties.ImmediatePopup = true;
            this.cboTipoTitulo.Properties.NullText = "";
            this.cboTipoTitulo.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cboTipoTitulo.Properties.PopupSizeable = false;
            this.cboTipoTitulo.Properties.PopupView = this.txtConteudoView;
            this.cboTipoTitulo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboTipoTitulo.Required = true;
            this.cboTipoTitulo.RequiredMessage = "Informe o tipo do titulo.";
            this.cboTipoTitulo.SelectedIndex = -1;
            this.cboTipoTitulo.SelectedItem = null;
            this.cboTipoTitulo.SelectedValue = null;
            this.cboTipoTitulo.Size = new System.Drawing.Size(120, 22);
            this.cboTipoTitulo.TabIndex = 6;
            // 
            // txtConteudoView
            // 
            this.txtConteudoView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.txtConteudoView.Name = "txtConteudoView";
            this.txtConteudoView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.txtConteudoView.OptionsView.ShowGroupPanel = false;
            // 
            // txtValorTitulo
            // 
            this.txtValorTitulo.Location = new System.Drawing.Point(191, 94);
            this.txtValorTitulo.Name = "txtValorTitulo";
            this.txtValorTitulo.Required = true;
            this.txtValorTitulo.RequiredMessege = "Informe o valor.";
            this.txtValorTitulo.Size = new System.Drawing.Size(125, 22);
            this.txtValorTitulo.TabIndex = 1;
            this.txtValorTitulo.Tipo = Utilitarios.Enumerators.ETipoTextBox.Monetario;
            // 
            // txtDescricaoTitulo
            // 
            this.txtDescricaoTitulo.Location = new System.Drawing.Point(34, 94);
            this.txtDescricaoTitulo.Name = "txtDescricaoTitulo";
            this.txtDescricaoTitulo.Required = true;
            this.txtDescricaoTitulo.RequiredMessege = "Informe a descrição.";
            this.txtDescricaoTitulo.Size = new System.Drawing.Size(125, 22);
            this.txtDescricaoTitulo.TabIndex = 0;
            this.txtDescricaoTitulo.Tipo = Utilitarios.Enumerators.ETipoTextBox.Padrao;
            // 
            // FrmTitulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 203);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FrmTitulo.IconOptions.Image")));
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.Name = "FrmTitulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmTitulo";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkFixo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDataTitulo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDataTitulo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoTitulo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConteudoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorTitulo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescricaoTitulo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private Utilitarios.Componentes.MyTextBox txtDescricaoTitulo;
        private Utilitarios.Componentes.MyTextBox txtValorTitulo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit dtDataTitulo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private Utilitarios.Componentes.MyComboBox cboTipoTitulo;
        private DevExpress.XtraGrid.Views.Grid.GridView txtConteudoView;
        private DevExpress.XtraEditors.CheckEdit chkFixo;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSalvar;
    }
}