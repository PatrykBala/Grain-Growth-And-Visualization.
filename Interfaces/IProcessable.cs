using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Directives using.
// Dyrektywy using.

namespace MultiscaleModelling.Interfaces
{
    interface IProcessable
    // The interface defines the contract.Any class or struct that implements this contract must ensure the implementation of the members defined in the interface.
    // Interfejs definiuje kontrakt. Wszystkie class lub struct , które implementują ten kontrakt, muszą zapewnić implementację elementów członkowskich zdefiniowanych w interfejsie.
    {
        void NextStep();
        void InitializeStep();
        /* The void return type is mainly used to define event handlers where the void return type is required. 
         * An async method that returns a void type cannot be expected, and the object calling the void method 
         * cannot catch the exceptions that the method throws.
         * Typ zwracany void jest używany głównie do definiowania programów obsługi zdarzeń, gdzie wymagany 
         * jest zwracany typ void. Metoda asynchroniczna zwracająca typ void nie może być oczekiwana, a obiekt 
         * wywołujący metodę void nie może przechwytywać wyjątków, które metoda zgłasza.
         */
    }
}
