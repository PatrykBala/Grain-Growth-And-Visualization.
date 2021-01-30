namespace MultiscaleModelling.Properties
{
    /* Settings that are in the scope of the application are read-only and can only be changed at design time 
     * or by changing a file. config between application sessions. However, settings that are in the scope of 
     * the user can be saved at runtime, just like changing any property value.
     * Ustawienia, które są objęte zakresem aplikacji, są tylko do odczytu i mogą być zmieniane tylko w czasie 
     * projektowania lub przez zmianę pliku. config między sesjami aplikacji. Ustawienia, które są objęte zakresem 
     * użytkownika, można jednak zapisywać w czasie wykonywania tak samo jak w przypadku zmiany dowolnej wartości 
     * właściwości.
     */

    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase
    {

        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));

        public static Settings Default
        {
            get
            {
                return defaultInstance;
            }
        }
    }
}
