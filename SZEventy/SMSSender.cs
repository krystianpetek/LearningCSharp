﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZEventy
{
    internal class SMSSender
    {
        public void OnAddedAgenda(object o, AgendaEventArgs e)
        {
            Console.WriteLine("SMS Sender: SMS was send !!! Data: " + e.Agenda.AgendaDate + " Tytuł: "+e.Agenda.AgendaName );
        }
    }
}
