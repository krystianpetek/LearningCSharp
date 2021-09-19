using System;

namespace Rozdzial8_3
{
    // dziedziczenie interfejsów
    interface IReadableSettingsProvider
    {
        string GetSetting(string name, string defaultValue);
    }
    interface IWriteableSettingsProvider
    {
        void SetSetting(string name, string value);
    }

    // dziedziczenie po wielu interfejsach
    interface ISettingsProvider : IReadableSettingsProvider, IWriteableSettingsProvider
    {

    }
    class FileSettingsProvider : ISettingsProvider
    {
        #region Składowe z interfejsu ISettingsProvider
        public void SetSetting(string name, string value)
        {

        }
        #endregion

        #region Składowe z interfejsu IReadableSettingsProvider
        public string GetSetting(string name, string defaultValue)
        {
            return "";
        }
        #endregion
    }

    // tworzenie interfejsu pochodnego od innego interfejsu, ponieważ nie zaleca się dodawania nowych składowych do udostępnionego już interfejsu
    interface IDistributedSettingsProvider : ISettingsProvider
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
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
