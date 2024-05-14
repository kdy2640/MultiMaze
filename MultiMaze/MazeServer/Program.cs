using System.Net.Sockets;
using System.Net;
using System.Text;

namespace MazeServer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ServerGameManager serverGameManager = ServerGameManager.Instance;
            ApplicationConfiguration.Initialize();
            Application.Run(new ServerScene());
        }

    }
}