namespace Rozdzial8_3
{
    // dziedziczenie interfejsów
    internal interface IReadableSettingsProvider
    {
        string GetSetting(string name, string defaultValue);
    }

    internal interface IWriteableSettingsProvider
    {
        void SetSetting(string name, string value);
    }

    // dziedziczenie po wielu interfejsach
    internal interface ISettingsProvider : IReadableSettingsProvider, IWriteableSettingsProvider
    {
    }

    internal class FileSettingsProvider : ISettingsProvider
    {
        #region Składowe z interfejsu ISettingsProvider

        public void SetSetting(string name, string value)
        {
            Name = name;
        }

        #endregion Składowe z interfejsu ISettingsProvider

        #region Składowe z interfejsu IReadableSettingsProvider

        public string GetSetting(string name, string defaultValue)
        {
            return Name;
        }

        #endregion Składowe z interfejsu IReadableSettingsProvider

        public string Name { get; set; }
    }

    // tworzenie interfejsu pochodnego od innego interfejsu, ponieważ nie zaleca się dodawania nowych składowych do udostępnionego już interfejsu
    internal interface IDistributedSettingsProvider : ISettingsProvider
    {
        /// <summary>
        /// Pobieranie ustawień dla konkretnego identyfikatora URI.
        /// </summary>
        /// <param name="machineName">Identyfikator uri, którego dotyczą ustawienia</param>
        /// <param name="name">NAzwa ustawienia.</param>
        /// <param name="defaultValue">Wartość zwracana, gdy nie mozna znaleźć danego ustawienia</param>
        /// <returns>Określone ustawienie</returns>
        string GetSetting(string machineName, string name, string defaultValue);

        /// <summary>
        /// Określenie ustawienia dla konkretnego identyfikatora URI
        /// </summary>
        /// <param name="machineName">Identyfikator uri, którego dotyczy ustawienie</param>
        /// <param name="name">Nazwa ustawienia</param>
        /// <param name="value">Zapisywana wartość</param>
        void SetSetting(string machineName, string name, string value);
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
        }
    }
}