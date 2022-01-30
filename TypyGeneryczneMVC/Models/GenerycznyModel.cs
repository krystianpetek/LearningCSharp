using System.Collections.Generic;

namespace TypyGeneryczneMVC.Models
{
    public class GenerycznyModel<T>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<T> lista { get; set; }
    }
}
