using System;

namespace SZEventy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AgendaManager amgr = new AgendaManager();
            SMSSender sms = new SMSSender();
            amgr.AddedAgenda += sms.OnAddedAgenda;
            amgr.AddedAgendaShorter += sms.OnAddedAgendaShorter;
            
            amgr.AddAgenda(new Agenda()
            {
                AgendaDate = DateTime.Now.AddDays(2),
                AgendaName = "Kubuś puchatek i złote gadki"
            });
                Console.ReadKey();

        }
    }
}
