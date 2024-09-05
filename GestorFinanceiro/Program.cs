using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilitarios;
using DevExpress.LookAndFeel;
using Utilitarios.Classes;

namespace GestorFinanceiro
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MyExeption MyException = new MyExeption();
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(MyException.OnMyException);

            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(SkinStyle.Office2019White);
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Skins.SkinManager.EnableMdiFormSkins();
            DevExpress.LookAndFeel.LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
            Util.RegistrarComputador();
            Application.Run(new Formularios.FrmPrincipal());
        }
    }
}
