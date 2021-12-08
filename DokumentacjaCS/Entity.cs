﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokumentacjaCS
{
    internal class Entity
    {
        static int s_nextSerialNo;
        int _serialNo;
        public Entity() => _serialNo = s_nextSerialNo++;
        public int GetSerialNo() => _serialNo;
        public static int GetNextSerialNo() => s_nextSerialNo;
        public static void SetNextSerialNo(int value)=> s_nextSerialNo = value;
    }    
}
