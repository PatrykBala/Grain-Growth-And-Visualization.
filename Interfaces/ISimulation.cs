using MultiscaleModelling.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Directives using.
// Dyrektywy using.

namespace MultiscaleModelling.Interfaces
{
    public interface ISimulation
    /* The interface contains definitions for a group of related functions that a non-abstract class or struct 
     * must implement. An interface can define the static methods that must be implemented.
     * Interfejs zawiera definicje dla grupy powiązanych funkcji, które muszą implementować Klasa nieabstrakcyjna 
     * lub Struktura . Interfejs może definiować static metody, które muszą mieć implementację.
    */
    {
        void Initialize(Configuration config);
        void NextStep();
        void Restart();
        // We use void as the return type of the method (or local function) to specify that the method does not return a value.
        // Używamy void jako zwracanego typu metody (lub funkcji lokalnej), aby określić, że metoda nie zwraca wartości.
        Bitmap GetBitmap();
        Bitmap GetBitmapGrainsSelection(bool visibility);
        Bitmap GetEnergyBitmap();
        // Encapsulates a GDI + bitmap that consists of the pixel data of a graphic image and its attributes.A Bitmap is an object used to work with images defined by pixel data.
        // Hermetyzuje mapę bitową GDI+, która składa się z danych pikseli obrazu graficznego i jego atrybutów. A Bitmap jest obiektem używanym do pracy z obrazami zdefiniowanymi przez dane pikseli.

        void ExportToFile(FileTypeEnum type, string fileName);
        void ImportFromFile(FileTypeEnum type, string fileName);
        void AddInclusions(ConfigurationInclusions config);
        Configuration GetConfiguration();
        // Represents a configuration file that applies to a specific computer, application, or resource. This class cannot be inherited.
        // Reprezentuje plik konfiguracji, który ma zastosowanie do określonego komputera, aplikacji lub zasobu. Klasa ta nie może być dziedziczona.
        bool IsMapEmpty();

        bool IsEndSimulation();

        void AddOrRemoveGrainsToSelectLis(int x, int y);
        void RestartSelectedList();
        void StartGenerateSubstructure(Configuration config);
        void AddBoundariesForGrains(Configuration config);
        void RemoveGrainsColors();
        float GetGBPercent();
        void CalculateEnergy();

        void InitializeStep();

    }
}
