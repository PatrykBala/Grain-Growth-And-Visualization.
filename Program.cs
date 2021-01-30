using System; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
// Directives using.
// Dyrektywy using.

namespace MultiscaleModelling
// Namespace declaration.
// Deklaracja przestrzeni nazw.
{
    static class Program
    // A static class containing methods.
    // Klasa statyczna zawierające metody.
    {
        [STAThread]
        // Indicates that the COM threading model for the application is a single-threaded apartment (STA).
        // Wskazuje, że model wątkowości COM dla aplikacji jest apartamentem jednowątkowym (STA).
        
        static void Main()
        // The main entry point for the application.
        // Główny punkt wejścia do aplikacji.
        {
            Application.EnableVisualStyles();
            // Enables visual styles for the application.
            // Włącza style wizualne dla aplikacji.
            Application.SetCompatibleTextRenderingDefault(false);
            // Sets the application-wide default for the UseCompatibleTextRendering property defined in some controls.
            // Ustawia wartość domyślną dla całej aplikacji dla właściwości UseCompatibleTextRendering zdefiniowanej w niektórych kontrolkach.
            Application.Run(new Form1());
            // Begins running the standard application message loop on the current thread.
            // Rozpoczyna uruchamianie standardowej pętli komunikatów aplikacji w bieżącym wątku.
        }
    }
}
