using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilitarios.Enumerators;

namespace Utilitarios.MyMsg
{
    public static class MyMsgBox
    {
        public static frmMyMsgBox form { get { return new frmMyMsgBox(); } }

        public static DialogResult Exibir(string Mensagem, string Titulo, EBotoesMyMsgBox Botoes = EBotoesMyMsgBox.Ok, EIconeMyMsgBox Icon = EIconeMyMsgBox.Informacao, ETamanhoMsgBox Tamanho = ETamanhoMsgBox.Medio,MyExeption Ex = null)
        {
            return form.Exibir(Mensagem, Titulo, Botoes, Icon,Tamanho, Ex);
        }
       
    }
}
