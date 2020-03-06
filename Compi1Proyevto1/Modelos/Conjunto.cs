using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi1Proyevto1.Modelos
{
    class Conjunto
    {
        private String id;
        private List<char> conjuntoo;

        public string Id { get => id; set => id = value; }
        public List<char> Conjuntoo { get => conjuntoo; set => conjuntoo = value; }

        public Conjunto(string id, List<char> conjunto)
        {
            this.id = id;
            this.conjuntoo = conjunto;
        }

        public Conjunto()
        {
        }

    }
}
