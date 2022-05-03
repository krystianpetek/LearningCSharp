using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMVVM_2_WFAiIS.Model
{
    public class TextModel
    {
        public string? Text { get; set; } = string.Empty;
        public void CleanText()
        {
            Text = string.Empty;
        }
    }
}
