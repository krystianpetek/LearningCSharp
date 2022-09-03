using System;

namespace SZEventy
{
    internal class SMSSender
    {
        public void OnAddedAgenda(object o, AgendaEventArgs e)
        {
            Console.WriteLine("SMS Sender: SMS was send !!! Data: " + e.Agenda.AgendaDate + " Tytuł: " + e.Agenda.AgendaName);
        }
        public void OnAddedAgendaShorter(object o, AgendaEventArgs e)
        {
            Console.WriteLine("SMS Sender Short: SMS was send !!! Data: " + e.Agenda.AgendaDate + " Tytuł: " + e.Agenda.AgendaName);
        }
    }
}
