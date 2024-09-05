using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilitarios.Classes;
using Utilitarios.Componentes;
using Utilitarios.LayoutModels;

namespace Utilitarios.Extencions
{
    public static class Extencions
    {
        /// <summary>
        /// Retorna o Atributo Description de um Enumerator.
        /// </summary>
        /// <param name="currentEnum">Este Enumerator.</param>
        /// <returns></returns>
        public static string Descricao(this Enum currentEnum)
        {
            if (currentEnum.Equals(null))
                return "";
            string description;

            DescriptionAttribute da;
            FieldInfo fi = currentEnum.GetType().GetField(currentEnum.ToString());

            da = (DescriptionAttribute)Attribute.GetCustomAttribute
                (fi, typeof(DescriptionAttribute));

            if (da != null)
                description = da.Description;
            else
                description = currentEnum.ToString();

            return description;
        }
        public static string DescricaoDireta(Enum currentEnum)
        {
            if (currentEnum.Equals(null))
                return "";
            string description;

            DescriptionAttribute da;
            FieldInfo fi = currentEnum.GetType().GetField(currentEnum.ToString());

            da = (DescriptionAttribute)Attribute.GetCustomAttribute
                (fi, typeof(DescriptionAttribute));

            if (da != null)
                description = da.Description;
            else
                description = currentEnum.ToString();

            return description;
        }
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        public static bool IsNotNull(this object obj)
        {
            return !obj.IsNull();
        }
       
        public static bool ValidarEmail(this String email)
        {
            if (email.Contains("@gmail.com")) return true;
            if (email.Contains("@outlook.com")) return true;
            if (email.Contains("@hotmail.com")) return true;
            return false;
        }

        public static Int32 ToInt32(this String str)
        {
            try
            {
                return Convert.ToInt32(str);
            }
            catch
            {
                return -1;
            }
        }

        public static String OcultarParteEmail(this String Email)
        {
            if (Email.ValidarEmail())
            {
                int Indice = Email.IndexOf("@");
                string Provedor = Email.Substring(Indice);
                string EmailSemProvedor = Email.Substring(0, Indice);
                string PrimeiraParteEmail = Email.Substring(0, 3);
                string SegundaParteEmail = EmailSemProvedor.Substring(EmailSemProvedor.Length - 4);
                string EmailFormatado = PrimeiraParteEmail + "******" + SegundaParteEmail + Provedor;
                return EmailFormatado;
            }
            else
                return string.Empty;
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return String.IsNullOrEmpty(str);
        }

        public static string SimNao(this bool Boolean)
        {
            return Boolean ? "Sim" : "Não";
        }

        public static void LimparCampos(this Control controlAtual)
        {
            foreach (Control ctr in controlAtual.Controls)
            {
               

                if (ctr is MyTextBox)
                    ctr.Text = string.Empty;
                    
                if (ctr is MyComboBox)
                    ((MyComboBox)ctr).SelectedValue = -1;

                if (ctr is DateTimePicker)
                    ((DateTimePicker)ctr).Value = DateTime.Now;

                if (ctr is CheckBox)
                    ((CheckBox)ctr).Checked = false;

                if(ctr is PictureEdit)
                    ((PictureEdit)ctr).Image = null;

                if (ctr is GridControl)
                {
                    ((GridControl)ctr).DataSource = null;
                    ((GridControl)ctr).RefreshDataSource();
                }
                if (ctr.HasChildren)
                    LimparCampos(ctr);
            }
        }

        public static void ValidarCamposObrigatorios(this Control controlAtual)
        {
            foreach (Control ctr in controlAtual.Controls)
            {

                if (ctr.HasChildren) ctr.ValidarCamposObrigatorios();

                if (ctr is MyTextBox)
                    ((MyTextBox)ctr).Validar();

                if (ctr is MyComboBox)
                    ((MyComboBox)ctr).ValidarComMsg();
            }
        }

        public static decimal ToDecimal(this String str)
        {
            return Convert.ToDecimal(str);
        }
        public static double ToDouble(this String str)
        {
            return Convert.ToDouble(str);
        }
            
        public static List<Generico> ToGenerica(this List<object> lista)
        {
            List<Generico> listaConvertida = new List<Generico>();
            foreach(var i in lista)
            {
                Generico generico = new Generico()
                {
                    Id = (long)i.GetType().GetProperty("Id").GetValue(i),
                    Descricao = i.GetType().GetProperty("Descricao").IsNull() 
                    ? (string)i.GetType().GetProperty("Nome").GetValue(i) : (string)i.GetType().GetProperty("Descricao").GetValue(i)
                };
                listaConvertida.Add(generico);
            }
            return listaConvertida;
        }

        public static void AlterVisible(this Control ctr)
        {
            ctr.Visible = !ctr.Visible;
        }
        
        public static void Show(this XtraReport rel)
        {
            ReportPrintTool report = new ReportPrintTool(rel);
            report.PreviewForm.WindowState = FormWindowState.Maximized;
            report.ShowPreview();
        }

        public static void AddItemResumo(this Control ctr, LayoutItemResumo layout)
        {

            PanelControl pc = new PanelControl();

            pc.Dock = DockStyle.Left;
            pc.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pc.BackColor = layout.Color;

            LabelControl lb = new LabelControl();
            lb.Text = layout.Text;
            lb.Location = new Point(5,  (pc.Height / 2) - 10);
            lb.Font = new Font(lb.Font.FontFamily, (float)14);
            lb.Name = layout.NameLabel;

            LabelControl lb2 = new LabelControl();
            lb2.Text = layout.Title;
            lb2.Location = new Point(5, 5);
            lb2.Font = new Font(lb.Font.FontFamily, (float)14);

            pc.Controls.Add(lb);
            pc.Controls.Add(lb2);
            ctr.Controls.Add(pc);

        }

        public static void SetLabelValue(this Control ctr,string name,string text)
        {
            foreach(Control ctr2 in ctr.Controls)
            {
                if (ctr2.HasChildren)
                {
                    ctr2.SetLabelValue(name, text);
                }
                else
                {
                    if(ctr2 is LabelControl)
                    {
                        if(((LabelControl)ctr2).Name == name)
                        {
                            ((LabelControl)ctr2).Text = text;
                        }
                    }
                }
            }
        }

        public static Tipe GetControlForName<Tipe>(this Control ctr, string name)
        {
            object ctrRetorno = Util.CriarInstancia<Tipe>();
            foreach (Control ctr2 in ctr.Controls)
            {
                if (ctr2.HasChildren)
                {
                    ctrRetorno = ctr2.GetControlForName<Tipe>(name);
                }
                else
                {
                    if (ctr2 is Tipe)
                    {
                        if (ctr2.Name ==  name)
                        {
                            ctrRetorno = ctr2;
                        }
                    }
                }
            }
            return (Tipe)ctrRetorno;
        }

    }
}
