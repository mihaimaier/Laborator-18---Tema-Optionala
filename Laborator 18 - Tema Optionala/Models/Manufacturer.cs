using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator_18___Tema_Optionala.Models
{
    internal class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public List<Manual> Manuals  { get; set; } = new List<Manual>();
        public List<Key> Keys { get; set; } = new List<Key>();
    }
}
