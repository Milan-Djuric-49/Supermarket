using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    public class proizvod
    {
        public int id;
        public string naziv;
        public int cena;

        public proizvod(int _id, string _naziv, int _cena)
        {
            this.id = _id;
            this.naziv = _naziv;
            this.cena = _cena;
        }
    }
}
