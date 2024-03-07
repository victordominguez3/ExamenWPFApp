using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExamenWPFApp.Models
{
    public class Artista
    {

        private string name;

        public string Name { get => name; set => name = value; }

        public override string ToString()
        {
            return name;
        }

    }
}
