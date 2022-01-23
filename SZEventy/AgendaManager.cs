using System;
using System.Threading;

namespace SZEventy
{
    internal class AgendaManager
    {
        public delegate void AddedAgendaEventHandler(object o, AgendaEventArgs e);
        public event AddedAgendaEventHandler AddedAgenda;

        //EventHandler
        //EventHandler<TEventArgs>
        public event EventHandler<AgendaEventArgs> AddedAgendaShorter;

        /// <summary>
        /// event published powinien być
        /// 1. protected
        /// 2. virtual
        /// 3. void
        /// 4. nazwa powinna zaczynać się na On
        /// </summary>
        protected virtual void OnAddedAgenda(Agenda newAgenda)
        {
            if (AddedAgenda != null)
            {
                AddedAgenda(this, new AgendaEventArgs() { Agenda = newAgenda });
            }
        }

        protected virtual void OnAddedAgendaShorter(Agenda newAgenda)
        {
            if (AddedAgendaShorter != null)
            {
                AddedAgendaShorter(this, new AgendaEventArgs() { Agenda = newAgenda });
            }
        }
        public void AddAgenda(Agenda newAgenda)
        {
            Console.WriteLine("AddAgenda: Zaczynam dodawać ...");
            OnAddedAgenda(newAgenda); // TU musi być poinformowany SMS Sender
            Thread.Sleep(3000);
            OnAddedAgendaShorter(newAgenda);
            Console.WriteLine("AddAgenda: Skończyłem dodawać ...");
        }
    }
}
