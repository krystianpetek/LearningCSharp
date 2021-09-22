using System;

namespace Rozdzial9_4
{
    // WYLICZENIA
    class Program
    {
        enum ConnectionState
        {
            Disconnected, Connecting, Connected, Disconnecting
        }
        enum ConnectionStateJawne :short
        {
            Disconnected, // 0
            Connecting = 10, // 10
            Connected, // 11
            Joined = Connected, // 11 
            Disconnecting // 12
        }

        static void Main(string[] args)
        {
            int? connectionState = null;
            switch (connectionState)
            {
                case 0: break;
                case 1: break;
                case 2: break;
                case 3: break;
            }

            ConnectionState connectionState2 = ConnectionState.Disconnected;
            switch(connectionState2)
            {
                case ConnectionState.Disconnected: break;
                case ConnectionState.Connected: break;
                case ConnectionState.Disconnecting: break;
                case ConnectionState.Connecting: break;
            }
        }
    }
    // 398
}
