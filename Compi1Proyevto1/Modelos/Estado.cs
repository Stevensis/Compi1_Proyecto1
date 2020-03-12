using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi1Proyevto1.Modelos
{
    class Estado
    {
        private List<int> cerradura;
        private String name;
        private List<TransicionEstado> transicion;

        public Estado(List<int> cerradura, string name, List<TransicionEstado> transicion)
        {
            this.cerradura = cerradura;
            this.name = name;
            this.transicion = transicion;
        }

        public Estado(List<int> cerradura, string name)
        {
            this.cerradura = cerradura;
            this.name = name;
            this.transicion = new List<TransicionEstado>();
        }

        public List<int> Cerradura { get => cerradura; set => cerradura = value; }
        public string Name { get => name; set => name = value; }
        public List<TransicionEstado> Transicion { get => transicion; set => transicion = value; }
    }
}
