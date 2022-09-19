using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypyGeneryczne
{

    internal class RepozytoriumGen<T> where T : class //new(), IEncja
    {
        private List<T> lista = new();
        public void DodajElement(T element)
        {
            if (element != null)
            {
                lista.Add(element);
            }
        }
        public IEnumerable<T> ZwrocElementy()
        {
            foreach(var item in lista)
            {
                yield return item;
            }
        }
        public T ZwrocElementOId(int id)
        {
            if(id < lista.Count)
            {
                return lista[id];
            }
            else
            {
                return default;
            }
        }
    }
    internal class RepozytoriumGen<TKey, TValue> 
        where TKey : class 
        where TValue : new()
    {
        private Dictionary<TKey, TValue> lista = new();
        public void DodajElement(TKey key, TValue value)
        {
            if (value != null)
            {
                lista.Add(key,value);
            }
        }
        public TValue ZwrocElementOKluczu(TKey key)
        {
            if(lista.TryGetValue(key, out TValue wynik))
            {
                return wynik;
            }
            else
            {
                return default;
            }
        }
    }
    public class RepozytoriumOgraniczenia<T> where T : IEncja , new()
    {
        private List<T> lista = new();
        public void DodajElement(T element)
        {
            if (element != null)
            {
                var klient = new T()
                { Id = element.Id};
                lista.Add(klient);
            }
                    
        }
        public T ZwrocElementOId(int id)
        {
            if (id < lista.Count)
            {
                return lista[id];
            }
            else
            {
                return default;
            }
        }
    }
}
