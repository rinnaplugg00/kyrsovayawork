using System;
using System.Windows.Forms;
using MovieCatalog.Forms; // ✅ Исправлено

namespace MovieCatalog // ✅ обязательно именно это пространство имён
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm()); // ✅ Теперь MainForm найдётся
        }
    }
}
