using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SZEventy
{
    internal class AgendaManager
    {
        public delegate void AddedAgendaEventHandler(object o, AgendaEventArgs e);
        public event AddedAgendaEventHandler AddedAgenda;
        
        /// <summary>
        /// event published powinien być
        /// 1. protected
        /// 2. virtual
        /// 3. void
        /// 4. nazwa powinna zaczynać się na On
        /// </summary>
        protected virtual void OnAddedAgenda(Agenda newAgenda)
        {
            if(AddedAgenda != null)
            {
                AddedAgenda(this, new AgendaEventArgs() {  Agenda = newAgenda } );
            }
        }
        public void AddAgenda(Agenda newAgenda)
        {
            Console.WriteLine("AddAgenda: Zaczynam dodawać ...");
            Thread.Sleep(3000);
            OnAddedAgenda(newAgenda); // TU musi być poinformowany SMS Sender
            Console.WriteLine("AddAgenda: Skończyłem dodawać ...");
        }
    }
}
