using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utilitarios.Enumerators;
using Utilitarios.Extencions;
using Utilitarios.MyMsg;

namespace Utilitarios
{
    public class MyExeption : Exception
    {

        public string Mensagem { get; set; }
        public string Detalhes { get; set; }
        public string Title { get; set; }
        private ETipoException TipoException { get; set; }
        private ETamanhoMsgBox TamanhoMsg{ get; set; }

        public MyExeption() { }

        public MyExeption(string Mensagem, ETipoException Tipo = ETipoException.Erro, string Titulo = "Gestor Financeiro", ETamanhoMsgBox Tamanho = ETamanhoMsgBox.Medio)
        {
            this.Mensagem = Mensagem;
            this.Title = Titulo;
            this.TipoException = Tipo;
            this.TamanhoMsg = Tamanho;
        }

        public void OnMyException(object sender, ThreadExceptionEventArgs e)
        {
            if (e.Exception.Message.Contains("Exceção do tipo 'Utilitarios.MyExeption' foi acionada."))
            {
                MyExeption ex = (MyExeption)e.Exception;

                if (ex.TipoException == ETipoException.Aviso)
                    MyMsgBox.Exibir(ex.Mensagem, ex.Title, EBotoesMyMsgBox.Ok, EIconeMyMsgBox.Aviso, TamanhoMsg);

                if (ex.TipoException == ETipoException.Erro)
                    MyMsgBox.Exibir("Ocorreu um erro inesperado.", ex.Title, EBotoesMyMsgBox.Ok, EIconeMyMsgBox.Erro,TamanhoMsg , ex);
            }
            else if (e.Exception.Message.Contains("O método ou a operação não está implementada."))
            {
                MyMsgBox.Exibir(e.Exception.Message, "Gestor Financeiro", EBotoesMyMsgBox.Ok, EIconeMyMsgBox.Aviso, ETamanhoMsgBox.Pequeno);
            }
            else
            {
                MyExeption ex = new MyExeption();
                ex.Detalhes = this.VerificarInnerException(e.Exception);
                ex.Title = e.Exception.TargetSite.IsNull() ? "Gestor Financeiro" : e.Exception.TargetSite.Name;

                MyMsgBox.Exibir("Ocorreu um erro inesperado.", "Gestor Financeiro", EBotoesMyMsgBox.Ok, EIconeMyMsgBox.Erro, TamanhoMsg, ex);
            }
        }

        private String VerificarInnerException(Exception ex)
        {
            String Detalhes = "Source: " + ex.Source;
            Detalhes += "\n\nNome Metodo: " + ex.TargetSite.Name;
            Detalhes += "\n\n  Modulo: " + ex.TargetSite.Module.Name;
            Detalhes += "\n\n  Parametros Metodo:\n ";
            foreach (var item in ex.TargetSite.GetParameters())
            {
                Detalhes += String.Format("\n    Nome: {0}, Valor padrão: {1}, Tipo: {2} ", item.Name, item.DefaultValue, item.ParameterType);
            }

            if (ex.InnerException != null)
            {
                Detalhes += "\n\n\nMessage: " + ex.Message;
                Detalhes += "\n\n\n Inner Message: \n" + ex.InnerException.Message;
                if (ex.InnerException.InnerException != null)
                {
                    Detalhes += "\n\n\n Inner Inner Message: \n" + ex.InnerException.InnerException.Message;
                    if (ex.InnerException.InnerException.InnerException != null)
                        Detalhes += "\n\n\n Inner Inner Inner Message: \n" + ex.InnerException.InnerException.InnerException.Message;
                }
            }
            else
                Detalhes += "\n\n\nMessage:  " + ex.Message;

            Detalhes += "\n\n\n Rastreio de pilha: \n\n" + ex.StackTrace;

            Detalhes += "\n\n\n Tipo exeção: " + ex.GetType().ToString();

            if (Detalhes.Contains("Referência de objeto não definida para uma instância de um objeto."))
                Detalhes += "\n\n\n\n Tentativa de utilizar o valor de um objeto que esta nulo.";

            return Detalhes;
        }


    }
}
