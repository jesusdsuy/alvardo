using ServiceReference1;

namespace SRGA_GUIAS
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //
            //MessageBox.Show("el nro pasado es "+args[0]);
            //convengamos que lo que viene es el cargaid
                        
           Form1 formulario = new Form1();
            //formulario.Nueva(int.Parse(args[0]));
           
            //formulario.Nueva(6951);
            

            Application.Run(new Form1());

        }
    }
}