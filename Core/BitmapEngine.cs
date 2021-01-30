using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Directives using.
// Dyrektywy using.

namespace MultiscaleModelling.Core
{
    class BitmapEngine
    {

        private SimulationEngine _simulationEngine;

        public BitmapEngine( SimulationEngine simulationEngine)
        {
            _simulationEngine = simulationEngine;
        }


        public Bitmap GetBitmap()
        {
            return _simulationEngine.MapController.GetBitmap();
        }

        public Bitmap GetBitmapGrainsSelection(bool visibility)
        {
            if (visibility)
                return GetBitmap();
            else
            {
                var colorList = new List<int>();
                foreach (var grain in _simulationEngine.SelectedGrains)
                // foreach - statement executes a statement or a block of statements for each element in an instance of the type it implements.
                // foreach - instrukcja wykonuje instrukcję lub blok instrukcji dla każdego elementu w wystąpieniu typu, który implementuje.
                {
                    colorList.Add(grain.Id);
                }

                return _simulationEngine.MapController.GetBitmapWithHiddenColors(colorList);
            }
        }

        public Bitmap GetEnergyBitmap()
        {
            return _simulationEngine.MapController.GetBitmapWithEnergyColors();
        }

    }
}
