using ControlEscolar.View;
using NLog;
using ControlEscolar.Utilities;

namespace ControlEscolar
{
    internal static class Program
    {
        private static Logger? _logger;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {

            _logger = LoggingManager.GetLogger("Control Escolar");
            _logger.Info("Aplicacion iniciada");
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new View.frmLogin());

            frmLogin login_form = new frmLogin();
            if (login_form.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MDI_Control_escolar());
            }
        }
    }
}