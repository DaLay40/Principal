namespace GestorFinanceiro.Formularios
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.navigationPane1 = new DevExpress.XtraBars.Navigation.NavigationPane();
            this.pageInicio = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.gridControlTitulos = new DevExpress.XtraGrid.GridControl();
            this.gridViewTitulos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSituacao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnTipoTitulos = new DevExpress.XtraEditors.SimpleButton();
            this.bntTitulo = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtFinal = new DevExpress.XtraEditors.DateEdit();
            this.dtInicio = new DevExpress.XtraEditors.DateEdit();
            this.panelResumo = new DevExpress.XtraEditors.XtraScrollableControl();
            this.myComboBox1 = new Utilitarios.Componentes.MyComboBox();
            this.txtConteudoView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.navigationPane1)).BeginInit();
            this.navigationPane1.SuspendLayout();
            this.pageInicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTitulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTitulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.xtraScrollableControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFinal.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFinal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myComboBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConteudoView)).BeginInit();
            this.SuspendLayout();
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 25;
            // 
            // navigationPane1
            // 
            this.navigationPane1.AllowHtmlDraw = true;
            this.navigationPane1.Controls.Add(this.pageInicio);
            this.navigationPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPane1.Location = new System.Drawing.Point(0, 0);
            this.navigationPane1.Name = "navigationPane1";
            this.navigationPane1.PageProperties.AllowCustomHeaderButtonsGlyphSkinning = true;
            this.navigationPane1.PageProperties.ShowCollapseButton = false;
            this.navigationPane1.PageProperties.ShowExpandButton = false;
            this.navigationPane1.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.navigationPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.pageInicio});
            this.navigationPane1.RegularSize = new System.Drawing.Size(1653, 708);
            this.navigationPane1.SelectedPage = this.pageInicio;
            this.navigationPane1.Size = new System.Drawing.Size(1653, 708);
            this.navigationPane1.TabIndex = 0;
            this.navigationPane1.Text = "Inicio";
            // 
            // pageInicio
            // 
            this.pageInicio.Caption = "Inicio";
            this.pageInicio.Controls.Add(this.groupControl5);
            this.pageInicio.Controls.Add(this.panelControl2);
            this.pageInicio.Controls.Add(this.panelControl1);
            this.pageInicio.Name = "pageInicio";
            this.pageInicio.Properties.AllowCustomHeaderButtonsGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.pageInicio.Properties.ShowCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.pageInicio.Size = new System.Drawing.Size(1556, 628);
            // 
            // groupControl5
            // 
            this.groupControl5.AppearanceCaption.BorderColor = System.Drawing.Color.Gray;
            this.groupControl5.AppearanceCaption.Options.UseBorderColor = true;
            this.groupControl5.Controls.Add(this.gridControlTitulos);
            this.groupControl5.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl5.Location = new System.Drawing.Point(0, 122);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(854, 458);
            this.groupControl5.TabIndex = 2;
            this.groupControl5.Text = "Titulos";
            // 
            // gridControlTitulos
            // 
            this.gridControlTitulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlTitulos.Location = new System.Drawing.Point(2, 28);
            this.gridControlTitulos.MainView = this.gridViewTitulos;
            this.gridControlTitulos.Name = "gridControlTitulos";
            this.gridControlTitulos.Size = new System.Drawing.Size(850, 428);
            this.gridControlTitulos.TabIndex = 0;
            this.gridControlTitulos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTitulos});
            // 
            // gridViewTitulos
            // 
            this.gridViewTitulos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumnSituacao,
            this.gridColumn7});
            this.gridViewTitulos.GridControl = this.gridControlTitulos;
            this.gridViewTitulos.Name = "gridViewTitulos";
            this.gridViewTitulos.OptionsBehavior.Editable = false;
            this.gridViewTitulos.OptionsView.ShowAutoFilterRow = true;
            this.gridViewTitulos.OptionsView.ShowGroupPanel = false;
            this.gridViewTitulos.OptionsView.ShowIndicator = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Descrição";
            this.gridColumn2.FieldName = "Descricao";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 517;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Data";
            this.gridColumn3.FieldName = "Data";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 76;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Valor";
            this.gridColumn4.FieldName = "Valor";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 53;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Tipo";
            this.gridColumn5.FieldName = "ETipo";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 49;
            // 
            // gridColumnSituacao
            // 
            this.gridColumnSituacao.Caption = "Situação";
            this.gridColumnSituacao.FieldName = "ESituacao";
            this.gridColumnSituacao.MinWidth = 25;
            this.gridColumnSituacao.Name = "gridColumnSituacao";
            this.gridColumnSituacao.Visible = true;
            this.gridColumnSituacao.VisibleIndex = 5;
            this.gridColumnSituacao.Width = 63;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Recorente";
            this.gridColumn7.FieldName = "StringFixo";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 67;
            // 
            // panelControl2
            // 
            this.panelControl2.AllowTouchScroll = true;
            this.panelControl2.Controls.Add(this.btnTipoTitulos);
            this.panelControl2.Controls.Add(this.bntTitulo);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 580);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1556, 48);
            this.panelControl2.TabIndex = 3;
            // 
            // btnTipoTitulos
            // 
            this.btnTipoTitulos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTipoTitulos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTipoTitulos.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnTipoTitulos.ImageOptions.SvgImageSize = new System.Drawing.Size(15, 15);
            this.btnTipoTitulos.Location = new System.Drawing.Point(1327, 5);
            this.btnTipoTitulos.Name = "btnTipoTitulos";
            this.btnTipoTitulos.Size = new System.Drawing.Size(109, 38);
            this.btnTipoTitulos.TabIndex = 6;
            this.btnTipoTitulos.Text = "Tipos titulos";
            // 
            // bntTitulo
            // 
            this.bntTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bntTitulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntTitulo.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.bntTitulo.ImageOptions.SvgImageSize = new System.Drawing.Size(15, 15);
            this.bntTitulo.Location = new System.Drawing.Point(1442, 4);
            this.bntTitulo.Name = "bntTitulo";
            this.bntTitulo.Size = new System.Drawing.Size(109, 38);
            this.bntTitulo.TabIndex = 5;
            this.bntTitulo.Text = "Novo Titulo";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.xtraScrollableControl1);
            this.panelControl1.Controls.Add(this.panelResumo);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1556, 122);
            this.panelControl1.TabIndex = 0;
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Controls.Add(this.myComboBox1);
            this.xtraScrollableControl1.Controls.Add(this.labelControl2);
            this.xtraScrollableControl1.Controls.Add(this.labelControl1);
            this.xtraScrollableControl1.Controls.Add(this.dtFinal);
            this.xtraScrollableControl1.Controls.Add(this.dtInicio);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(2, 2);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(553, 118);
            this.xtraScrollableControl1.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(23, 59);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 16);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Data final";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 16);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Data inicial";
            // 
            // dtFinal
            // 
            this.dtFinal.EditValue = null;
            this.dtFinal.Location = new System.Drawing.Point(23, 83);
            this.dtFinal.Name = "dtFinal";
            this.dtFinal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFinal.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFinal.Size = new System.Drawing.Size(141, 22);
            this.dtFinal.TabIndex = 1;
            // 
            // dtInicio
            // 
            this.dtInicio.EditValue = null;
            this.dtInicio.Location = new System.Drawing.Point(23, 31);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtInicio.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtInicio.Size = new System.Drawing.Size(141, 22);
            this.dtInicio.TabIndex = 0;
            // 
            // panelResumo
            // 
            this.panelResumo.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelResumo.Location = new System.Drawing.Point(555, 2);
            this.panelResumo.Name = "panelResumo";
            this.panelResumo.Size = new System.Drawing.Size(999, 118);
            this.panelResumo.TabIndex = 1;
            // 
            // myComboBox1
            // 
            this.myComboBox1.DataSource = null;
            this.myComboBox1.DisplayMember = "";
            this.myComboBox1.IdObjetoRetorno = null;
            this.myComboBox1.Location = new System.Drawing.Point(264, 34);
            this.myComboBox1.Margin = new System.Windows.Forms.Padding(0);
            this.myComboBox1.Name = "myComboBox1";
            this.myComboBox1.NaoMudarFocoTeclaEnter = false;
            this.myComboBox1.NaoMudarReadOnly = false;
            this.myComboBox1.PermitirTextoDigitadoQueNaoEstaNaLista = false;
            this.myComboBox1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.myComboBox1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.myComboBox1.Properties.ImmediatePopup = true;
            this.myComboBox1.Properties.NullText = "";
            this.myComboBox1.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.myComboBox1.Properties.PopupSizeable = false;
            this.myComboBox1.Properties.PopupView = this.txtConteudoView;
            this.myComboBox1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.myComboBox1.Required = false;
            this.myComboBox1.RequiredMessage = null;
            this.myComboBox1.SelectedIndex = -1;
            this.myComboBox1.SelectedItem = null;
            this.myComboBox1.SelectedValue = null;
            this.myComboBox1.Size = new System.Drawing.Size(120, 22);
            this.myComboBox1.TabIndex = 4;
            // 
            // txtConteudoView
            // 
            this.txtConteudoView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.txtConteudoView.Name = "txtConteudoView";
            this.txtConteudoView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.txtConteudoView.OptionsView.ShowGroupPanel = false;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1653, 708);
            this.Controls.Add(this.navigationPane1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FrmPrincipal.IconOptions.Image")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPrincipal";
            ((System.ComponentModel.ISupportInitialize)(this.navigationPane1)).EndInit();
            this.navigationPane1.ResumeLayout(false);
            this.pageInicio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTitulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTitulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.xtraScrollableControl1.ResumeLayout(false);
            this.xtraScrollableControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFinal.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFinal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myComboBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConteudoView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.NavigationPane navigationPane1;
        private DevExpress.XtraBars.Navigation.NavigationPage pageInicio;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraGrid.GridControl gridControlTitulos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTitulos;
        private DevExpress.XtraEditors.XtraScrollableControl panelResumo;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraEditors.DateEdit dtInicio;
        private DevExpress.XtraEditors.DateEdit dtFinal;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton bntTitulo;
        private DevExpress.XtraEditors.SimpleButton btnTipoTitulos;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSituacao;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private Utilitarios.Componentes.MyComboBox myComboBox1;
        private DevExpress.XtraGrid.Views.Grid.GridView txtConteudoView;
    }
}