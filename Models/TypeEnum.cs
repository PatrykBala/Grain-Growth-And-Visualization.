using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Directives using.
// Dyrektywy using.

namespace MultiscaleModelling.Models
{
    public enum TypeEnum
    /* An enumeration type (or an enumeration type) is a value type defined by a set of named constants of 
     * the base numeric type. To define an enumeration type, use the enum keyword and specify the names of 
     * the enumeration members.
     * Typ wyliczenia (lub Typ wyliczeniowy) jest typem wartości zdefiniowanym przez zestaw nazwanych 
     * stałych podstawowego typu liczbowego . Aby zdefiniować typ wyliczeniowy, użyj enum słowa kluczowego 
     * i określ nazwy elementów członkowskich wyliczenia.
     */
    {
        Empty =0,
        Border = 1,
        Grain = 2,
        Inclusion = 3,
        OldGrain = 4,
        GrainBorder = 5,
        Recrystallization = 6
        /* By default, the associated enumeration member constants are of type int; they start at zero and 
         * increase by one in the order of the definition text. You can explicitly specify any other integral 
         * numeric type as the underlying type of an enumeration type. You can also explicitly specify associated 
         * constant values.
         * Domyślnie skojarzone wartości stałe elementów członkowskich wyliczenia są typu int ; zaczynają się od 
         * zera i zwiększają się o jeden po kolejności tekstu definicji. Można jawnie określić dowolny inny 
         * typ liczbowy całkowity jako typ podstawowy typu wyliczenia. Można również jawnie określić skojarzone 
         * wartości stałe.
        */
    }
}
