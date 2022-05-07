using System;
using System.IO;

namespace AppMVVM_WFAiIS.Model
{
    public static class FileHelper
    {
        private const string fileName = "../../../saveProgress.txt";
        public static void Save(this ModelMPAM model)
        {
            string val = model.ValueOfMySlider.ToString();
            File.WriteAllText(fileName, val);
        }
        public static ModelMPAM Read()
        {
            string val = "";
            try
            {
                val = File.ReadAllText(fileName);
            }
            catch (Exception ex)
            {
                val = "0";
            }
            double valueToRead = double.Parse(val);
            if (double.IsNaN(valueToRead))
                valueToRead = 0;
            return new ModelMPAM() { ValueOfMySlider = valueToRead };
        }
    }
}
