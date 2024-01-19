using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8
{
    public interface IPart
    {
        public void BuildThis();
    }
    public interface IWorker
    {
        public void Work();
    }
    public class Basemante:IPart
    {
        public bool Built { get; set; }
        public Basemante(bool built)
        {
            Built = built;
        }
        public Basemante() { Built = false; }
        public void BuildThis()
        {
            Built = true;
        }
    }
}
