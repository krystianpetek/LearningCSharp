using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodOther
{
    public abstract class DialogBox
    {
        public abstract Button CreateButton();
    }
}
