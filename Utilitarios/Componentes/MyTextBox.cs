using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilitarios.Enumerators;
using Utilitarios.Extencions;

namespace Utilitarios.Componentes
{
    public class MyTextBox : TextEdit
    {

        public ETipoTextBox Tipo { get; set; }
        public bool Required { get; set; }
        public String RequiredMessege { get; set; }

        public MyTextBox()
        {
            DelegarEventos();
            
        }

        public void DelegarEventos()
        {
            this.KeyPress += new KeyPressEventHandler(EventoKeyPress);
        }

       
        private void EventoKeyPress(object sender, KeyPressEventArgs e)
        {
            switch (this.Tipo)
            {
                case ETipoTextBox.Numerico:
                {
                    if (!(Char.IsDigit(e.KeyChar) || (char)Keys.Back == e.KeyChar))
                    {
                        e.Handled = true;
                    }
                    break;
                };
                case ETipoTextBox.Monetario:
                {
                        if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
                        {
                            TextEdit textBox = (TextEdit)this;
                            string txt = textBox.Text.Replace(",", "").Replace(".", "");
                            if (char.IsDigit(e.KeyChar))
                                if (txt == string.Empty)
                                    txt = "00";
                                else if (textBox.SelectionLength == textBox.Text.Length)
                                {
                                    txt = "00";
                                    txt += e.KeyChar;
                                }
                                else
                                    txt += e.KeyChar;
                            if (e.KeyChar == (char)Keys.Back)
                            {
                                if (textBox.SelectionLength == textBox.Text.Length)
                                    txt = "00";
                                else
                                    txt = txt.Substring(0, txt.Length - 1);
                            }
                            txt = string.Format("{0:C}", double.Parse(txt) / 100);
                            textBox.Text = txt.Substring(3);
                            textBox.SelectionStart = textBox.Text.Length;
                        }
                        e.Handled = true;
                        break;
                }
                case ETipoTextBox.Padrao:
                {
                    break;
                }
            }
        }

        public void Validar()
        {
            if(this.Tipo == ETipoTextBox.Monetario)
            {
                if (this.Required && (this.Text.IsNullOrEmpty() || this.Text.ToDecimal() == 0))
                    throw new MyExeption(this.RequiredMessege, ETipoException.Aviso);
            }
            else
            {
                if (this.Required && this.Text.IsNullOrEmpty())
                    throw new MyExeption(this.RequiredMessege, ETipoException.Aviso);
            }
            
        }

    }
}
