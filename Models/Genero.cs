using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenWPFApp.Models
{
    public  class Genero
    {

        private string name;

        public Genero(string name)
        {
            this.name = name;
        }

        public string Name { get => name; set => name = value; }

    }
}
