using System;

namespace Zdarzenia
{
    internal partial class Program
    {
        public class TestowanieZdarzen {
            public int value;
            public delegate void NumberManipulationHandler();
            public event NumberManipulationHandler ChangeNumber;

            // aktywacja zdarzenia
            protected virtual void OnChangeNumber()
            {
                if (ChangeNumber != null)
                {
                    ChangeNumber();
                }
                else
                {
                    Console.WriteLine("Zdarzenie!");
                }
            }
            public TestowanieZdarzen(int i)
            {
                SetValue(i);
            }

            public void SetValue(int i)
            {
                if (value != i)
                {
                    value = i;
                    OnChangeNumber();
                }
            }
        }
    }
}

