using DevExpress.XtraEditors;
using Utilitarios.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios.Enumerators;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Windows.Forms;
using Utilitarios.Extencions;
using System.Collections;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Utilitarios.Componentes
{
    public class MyComboBox : GridLookUpEdit, IDisposable
    {
        public GridLookUpEdit componente;
        private GridView gridView = new GridView();
        public GridColumn coluna1 = new GridColumn();
        private GridColumn coluna2 = new GridColumn();
        private GridColumn coluna3 = new GridColumn();
        private BindingSource binCorrente;
        public bool NaoMudarReadOnly { get; set; }
        public bool NaoMudarFocoTeclaEnter { get; set; }

        public MyComboBox()
        {
            ConfigureComponente();
        }

        #region Propriedades

        public object DataSource
        {
            get { return this.Properties.DataSource; }
            set { this.Properties.DataSource = value; }
        }

        public object DisplayMember
        {
            get { return this.Properties.DisplayMember; }
            set { this.Properties.DisplayMember = value.ToString(); }
        }

        public bool PopupOpen
        {
            get { return this.IsPopupOpen; }
        }

        /// <summary>
        /// Retorna o 'value' do item selecionado no GridLookUpEdit - Sempre quando é um Enumerator.
        /// </summary>
        public object SelectedValue
        {
            get
            {
                return this.EditValue;
            }
            set
            {
                this.EditValue = value;
            }
        }

        /// <summary>
        /// Retorna o 'object' do item selecionado no GridLookUpEdit - Pode ser Enumerator ou Objeto.
        /// </summary>
        public object SelectedItem
        {
            get
            {

                if (this.GetSelectedDataRow().IsNotNull())
                    return this.GetSelectedDataRow();
                else
                    return this.EditValue;
            }
            set
            {
                this.EditValue = value;
            }
        }

        /// <summary>
        /// Retorna o 'index' do item selecionado no GridLookUpEdit.
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                object key = this.EditValue;
                return this.Properties.GetIndexByKeyValue(key);
            }
            set
            {
                //int currentIndex = this.Properties.GetIndexByKeyValue(value);
                //object keyValue = this.Properties.GetKeyValue(currentIndex);
                object keyValue = this.Properties.GetKeyValue(value);
                this.EditValue = keyValue;
            }
        }

        public bool Required { get; set; }

        public String RequiredMessage { get; set; }
        #endregion

        #region Métodos Utilitários


        public void ValidarComMsg()
        {
            if (this.Required && (this.SelectedValue.IsNull() || this.Text == ""))
                throw new MyExeption(this.RequiredMessage,ETipoException.Aviso);

        }

        public bool Validar()
        {
            if (this.Required && (this.SelectedValue.IsNull() || this.Text == ""))
                return false;
            else
                return true;
        }

        /// <summary>
        /// Método para atribuir o datasource (Coleção), ValueMember e DisplayMember no GridLookUpEdit.
        /// </summary>
        /// <param name="datasource">Uma Coleção de objetos.</param>
        /// <param name="valueMember">Nome do propriedade que será associado 'value'.</param>
        /// <param name="displayMember">Nome da propriedade que será mostrado no FlatComboBox.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Caption"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Field")]
        public void SetDataSource(object dataSource, string valueMember, string displayMember, string FieldName, string Caption, Boolean inserirValorNulo = false, Boolean CriarOrdenacao = true, Boolean SetarIndex = true)
        {
            if (dataSource.IsNull()) return;

            this.Properties.BeginUpdate();
            IEnumerable listaEnumerable = dataSource as IEnumerable;
            IList listaConvertida = listaEnumerable.Cast<Object>().ToList();

            if (this.binCorrente.IsNull())
                this.binCorrente = new BindingSource();

            if (listaConvertida.IsNotNull() && listaConvertida.Count > 0)
            {
                if (inserirValorNulo)
                    listaConvertida.Add(null);

                this.binCorrente.DataSource = null;
                this.binCorrente.DataSource = listaConvertida;

                this.Properties.BeginUpdate();
                this.Properties.DataSource = binCorrente;
            }
            else
                this.binCorrente.DataSource = null;

            this.Properties.ValueMember = valueMember;
            this.Properties.DisplayMember = displayMember;
            this.Properties.PopupFormSize = new System.Drawing.Size(this.Size.Width, this.Size.Height);
            this.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;

            ConfigurarColunasGridLookUpEdit(FieldName, Caption, CriarOrdenacao);
            this.Properties.View = this.gridView;
            this.Properties.EndUpdate();

            RepositoryItemMemoEdit memoEdit = new RepositoryItemMemoEdit();
            this.gridView.Columns[0].ColumnEdit = memoEdit;

            if (SetarIndex)
                this.SelectedIndex = -1;
        }

        public void SetDataSource(object dataSource, string valueMember, string displayMember, string FieldName1, string Caption1, string FieldName2, string Caption2, Boolean OcultarSegundaColuna = false, Boolean inserirValorNulo = false, Boolean CriarOrdenacao = true)
        {
            this.Properties.BeginUpdate();
            IEnumerable listaEnumerable = dataSource as IEnumerable;
            IList listaConvertida = listaEnumerable.Cast<Object>().ToList();

            if (this.binCorrente.IsNull())
                this.binCorrente = new BindingSource();

            if (listaConvertida.IsNotNull() && listaConvertida.Count > 0)
            {
                if (inserirValorNulo)
                    listaConvertida.Add(null);

                this.binCorrente.DataSource = null;
                this.binCorrente.DataSource = listaConvertida;

                this.Properties.BeginUpdate();
                this.Properties.DataSource = binCorrente;
            }
            else
                this.binCorrente.DataSource = null;


            this.Properties.ValueMember = valueMember;
            this.Properties.DisplayMember = displayMember;
            this.Properties.PopupFormSize = new System.Drawing.Size(this.Size.Width, this.Size.Height);
            this.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;

            ConfigurarColunasGridLookUpEdit(FieldName1, Caption1, FieldName2, Caption2, OcultarSegundaColuna, CriarOrdenacao);
            this.Properties.View = this.gridView;
            this.Properties.View.Columns[1].Visible = !OcultarSegundaColuna;
            this.Properties.EndUpdate();

            RepositoryItemMemoEdit memoEdit = new RepositoryItemMemoEdit();
            this.gridView.Columns[0].ColumnEdit = memoEdit;
            this.gridView.Columns[1].ColumnEdit = memoEdit;

            this.SelectedIndex = -1;
        }

        public void SetDataSource(object dataSource, string valueMember, string displayMember, string FieldName1, string Caption1, string FieldName2, string Caption2, string FieldName3, string Caption3, Boolean OcultarSegundaColuna = false, Boolean inserirValorNulo = false, Boolean CriarOrdenacao = true)
        {
            this.Properties.BeginUpdate();
            IEnumerable listaEnumerable = dataSource as IEnumerable;
            IList listaConvertida = listaEnumerable.Cast<Object>().ToList();

            if (this.binCorrente.IsNull())
                this.binCorrente = new BindingSource();

            if (listaConvertida.IsNotNull() && listaConvertida.Count > 0)
            {
                if (inserirValorNulo)
                    listaConvertida.Add(null);

                this.binCorrente.DataSource = null;
                this.binCorrente.DataSource = listaConvertida;

                this.Properties.BeginUpdate();
                this.Properties.DataSource = binCorrente;
            }
            else
                this.binCorrente.DataSource = null;


            this.Properties.ValueMember = valueMember;
            this.Properties.DisplayMember = displayMember;
            this.Properties.PopupFormSize = new System.Drawing.Size(this.Size.Width, this.Size.Height);
            this.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;

            ConfigurarColunasGridLookUpEdit(FieldName1, Caption1, FieldName2, Caption2, FieldName3, Caption3, OcultarSegundaColuna, CriarOrdenacao);
            this.Properties.View = this.gridView;
            this.Properties.View.Columns[1].Visible = !OcultarSegundaColuna;
            this.Properties.EndUpdate();

            RepositoryItemMemoEdit memoEdit = new RepositoryItemMemoEdit();
            this.gridView.Columns[0].ColumnEdit = memoEdit;
            this.gridView.Columns[1].ColumnEdit = memoEdit;
            this.gridView.Columns[2].ColumnEdit = memoEdit;

            this.SelectedIndex = -1;
        }

        private void ConfigurarColunasGridLookUpEdit(string FieldName1, string Caption1, Boolean CriarOrdenacao)
        {
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.coluna1,
            this.coluna2});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView.OptionsFind.FindDelay = 100;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsSelection.InvertSelection = true;
            this.gridView.OptionsView.ShowAutoFilterRow = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.RowAutoHeight = true;

            this.coluna1.Caption = Caption1;
            this.coluna1.Name = "coluna1";
            this.coluna1.FieldName = FieldName1;
            this.coluna1.Visible = true;
            this.coluna1.VisibleIndex = 0;
            this.coluna1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.coluna1.AppearanceCell.Options.UseFont = true;
            this.coluna1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
            this.coluna1.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Like;
            if (CriarOrdenacao)
                this.coluna1.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
        }

        private void ConfigurarColunasGridLookUpEdit(string FieldName1, string Caption1, string FieldName2, string Caption2, Boolean ocultarSegundaColuna, Boolean CriarOrdenacao)
        {
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.coluna1,
            this.coluna2});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView.OptionsFind.FindDelay = 100;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsSelection.InvertSelection = true;
            this.gridView.OptionsView.ShowAutoFilterRow = false;
            this.gridView.OptionsView.ShowGroupPanel = false;

            this.coluna1.Caption = Caption1;
            this.coluna1.Name = "coluna1";
            this.coluna1.FieldName = FieldName1;
            this.coluna1.VisibleIndex = 0;
            this.coluna1.Visible = true;
            this.coluna1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.coluna1.AppearanceCell.Options.UseFont = true;
            this.coluna1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
            this.coluna1.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            //if (CriarOrdenacao)
            //    this.coluna1.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            //this.coluna1.BestFit();

            this.coluna2.Caption = Caption2;
            this.coluna2.Name = "coluna2";
            this.coluna2.FieldName = FieldName2;
            this.coluna2.VisibleIndex = 1;
            this.coluna2.Visible = !ocultarSegundaColuna;
            this.coluna2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.coluna2.AppearanceCell.Options.UseFont = true;
            this.coluna2.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
            this.coluna2.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            this.coluna2.MinWidth = 70;
            if (CriarOrdenacao)
                this.coluna2.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            this.coluna2.BestFit();
        }

        private void ConfigurarColunasGridLookUpEdit(string FieldName1, string Caption1, string FieldName2, string Caption2, string FieldName3, string Caption3, Boolean ocultarSegundaColuna, Boolean CriarOrdenacao)
        {
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.coluna1,
            this.coluna2,
            this.coluna3});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView.OptionsFind.FindDelay = 100;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsSelection.InvertSelection = true;
            this.gridView.OptionsView.ShowAutoFilterRow = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.RowAutoHeight = true;

            this.coluna1.Caption = Caption1;
            this.coluna1.Name = "coluna1";
            this.coluna1.FieldName = FieldName1;
            this.coluna1.VisibleIndex = 0;
            this.coluna1.Visible = true;
            this.coluna1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.coluna1.AppearanceCell.Options.UseFont = true;
            this.coluna1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
            this.coluna1.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            //if (CriarOrdenacao)
            //    this.coluna1.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            this.coluna1.BestFit();

            this.coluna2.Caption = Caption2;
            this.coluna2.Name = "coluna2";
            this.coluna2.FieldName = FieldName2;
            this.coluna2.VisibleIndex = 1;
            this.coluna2.Visible = !ocultarSegundaColuna;
            this.coluna2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.coluna2.AppearanceCell.Options.UseFont = true;
            this.coluna2.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
            this.coluna2.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            //if (CriarOrdenacao)
            //    this.coluna2.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            //this.coluna2.BestFit();

            this.coluna3.Caption = Caption3;
            this.coluna3.Name = "coluna3";
            this.coluna3.FieldName = FieldName3;
            this.coluna3.VisibleIndex = 2;
            this.coluna3.Visible = !ocultarSegundaColuna;
            this.coluna3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.coluna3.AppearanceCell.Options.UseFont = true;
            this.coluna3.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
            this.coluna3.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            if (CriarOrdenacao)
                this.coluna3.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            //this.coluna3.BestFit();
        }

        public void SetarPrimeiroElemento()
        {
            if (!this.IsDesignMode)
            {
                int currentIndex = this.Properties.GetIndexByKeyValue(this.EditValue);
                //if (currentIndex.Equals(-1) && this.Properties.DataSource.IsNotNull())
                if (this.Properties.DataSource.IsNotNull())
                {
                    //object keyValue = this.Properties.GetKeyValue(++currentIndex);
                    object keyValue = this.Properties.GetKeyValue(0);
                    this.EditValue = keyValue;
                }
            }
        }

        /// <summary>
        /// Habilita ou Desabilita todos os componentes.
        /// </summary>
        /// <param name="enable">Se for true, habilita todos os componentes. Caso contrário
        ///                      desabilita.
        /// </param>
        public void EnableComponents(bool enable)
        {
            this.Enabled = enable;
        }

        /// <summary>
        /// Limpa a lista do FlatComboBox.
        /// </summary>
        public void ClearConteudo()
        {
            this.Properties.DataSource = null;
            this.EditValue = "";
        }

        /// <summary>
        /// Coloca o focu no 'FlatComboBox' de Conteúdo.
        /// </summary>
        public void FocusConteudo()
        {
            this.Focus();
        }

        /// <summary>
        /// Método que agrupa os componentes da SUPERCLASSE (Panel + TableLayoutPanel + Label) e
        /// 'FlatComboBox' de Conteúdo.
        /// </summary>
        protected void ConfigureComponente()
        {
            //this = new GridLookUpEdit();
            //this.AddComponente(this, new ColumnStyle(SizeType.Percent, 100F));

            this.Properties.ImmediatePopup = true;
            this.Properties.PopupFilterMode = PopupFilterMode.Contains;
            this.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.Properties.NullText = "";
            this.Name = "txtConteudo";
            this.Size = new System.Drawing.Size(120, 21);
            this.Properties.PopupSizeable = false;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Enter += new EventHandler(ComboBoxCEOEnter);
            this.KeyUp += new KeyEventHandler(ComboCeoKeyUpKeyDown);
            this.Leave += new EventHandler(ComboLeave);
            this.Popup += new EventHandler(RedimencionarConteudoAbrirPopUp);
            this.Properties.CharacterCasing = CharacterCasing.Upper;
            this.Text = "";
            this.Properties.NullText = "";
        }

        public bool PermitirTextoDigitadoQueNaoEstaNaLista { get; set; }
        public Int16? IdObjetoRetorno { get; set; }

        public void RemoverBinding()
        {
            if (this.DataBindings.Count > 0)
                this.DataBindings.Clear();
        }

        public void AtualizarComponente()
        {

            if (this.DataBindings.Count > 0)
                this.DataBindings[0].ReadValue();
        }

        public void AtualizarObjeto()
        {

            if (this.DataBindings.Count > 0)
                this.DataBindings[0].WriteValue();
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Método utilizado para adicionar o evento SelectedIndexChanged no compoente ComboBoxCEO. 
        /// </summary>
        /// <param name="evento">EventHandler para ser delegado</param>
        public void AddEventoSelectedIndexChanged(EventHandler evento)
        {
            this.EditValueChanged += new EventHandler(evento);
        }

        /// <summary>
        /// Método utilizado para remover o evento SelectedIndexChanged no compoente ComboBoxCEO. 
        /// </summary>
        /// <param name="evento">EventHandler para ser delegado</param>
        public void RemoveEventoSelectedIndexChanged(EventHandler evento)
        {
            this.EditValueChanged -= new EventHandler(evento);
        }

        private void ComboBoxCEOEnter(object sender, EventArgs e)
        {
            if (!this.IsDesignMode)
            {
                GridLookUpEdit comboCorrente = (GridLookUpEdit)sender;
                int currentIndex = comboCorrente.Properties.GetIndexByKeyValue(comboCorrente.EditValue);
                if (currentIndex.Equals(-1))
                {
                    object keyValue = comboCorrente.Properties.GetKeyValue(++currentIndex);
                    this.EditValue = keyValue;
                }
            }
        }

        private void RedimencionarConteudoAbrirPopUp(object sender, EventArgs e)
        {
            GridLookUpEdit view = sender as GridLookUpEdit;
            view.Properties.View.BestFitColumns();

            GridViewInfo vinfo = view.Properties.View.GetViewInfo() as GridViewInfo;
            System.Drawing.Size clientSize = view.Properties.View.GridControl.FindForm().ClientSize;
            clientSize.Width =
                Math.Min(SystemInformation.WorkingArea.Width - 10, vinfo.ViewRects.ColumnTotalWidth + vinfo.ViewRects.IndicatorWidth + SystemInformation.VerticalScrollBarWidth + 10);
            view.Properties.View.GridControl.FindForm().ClientSize = clientSize;
        }

        /// <summary>
        /// Evento que ocorre ao sair do combobox.
        /// </summary>
        /// <param name="sender">Objeto em que ocorreu o evento</param>
        /// <param name="e">Informações adicionais</param>
        private void ComboLeave(object sender, EventArgs e)
        {
            //this.AtualizarComponente();

            if (!this.IsDesignMode && !this.PermitirTextoDigitadoQueNaoEstaNaLista)
            {
                GridLookUpEdit combo = (GridLookUpEdit)sender;
                int currentIndex = combo.Properties.GetIndexByKeyValue(combo.EditValue);
                if (currentIndex < 0 && combo.DataBindings.Count > 0)
                {
                    object keyValue = combo.Properties.GetKeyValue(++currentIndex);
                    combo.EditValue = keyValue;
                }
            }
        }

        /// <summary>
        /// Evento que ocorre quando está sendo pressionada
        /// </summary>
        /// <param name="sender">Objeto em que ocorreu o evento</param>
        /// <param name="e">Informações adicionais</param>        
        private void ComboCeoKeyUpKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Down && e.KeyCode != Keys.Up)
                return;

            GridLookUpEdit comboCorrente = (GridLookUpEdit)sender;

            if (comboCorrente.Properties.DataSource.IsNull())
                return;

            int rowCount = (comboCorrente.Properties.DataSource as IList).Count;
            int currentIndex = comboCorrente.Properties.GetIndexByKeyValue(comboCorrente.EditValue);

            comboCorrente.ShowPopup();

            if (e.KeyCode.Equals(Keys.Down))
            {
                if (currentIndex == rowCount)
                    currentIndex = 0;

                object keyValue = comboCorrente.Properties.GetKeyValue(++currentIndex);
                comboCorrente.EditValue = keyValue;

                //if (comboCorrente.DataBindings.IsNotNull() && comboCorrente.DataBindings[0].IsNotNull())
                //    comboCorrente.DataBindings[0].WriteValue();
            }

            if (e.KeyCode.Equals(Keys.Up))
            {
                if (currentIndex <= 0)
                    currentIndex = rowCount;

                object keyValue = comboCorrente.Properties.GetKeyValue(--currentIndex);
                comboCorrente.EditValue = keyValue;

                //if (comboCorrente.DataBindings.IsNotNull() && comboCorrente.DataBindings[0].IsNotNull())
                //    comboCorrente.DataBindings[0].WriteValue();
            }

            e.SuppressKeyPress = true;
        }


        #endregion

    }
}


