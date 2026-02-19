namespace Gestor_de_Horarios_de_Maestros
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Principal());
        }
    }
}