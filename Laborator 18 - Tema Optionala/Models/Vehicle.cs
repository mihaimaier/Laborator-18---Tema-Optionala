using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator_18___Tema_Optionala.Models
{
    internal class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturers { get; set; }

        public int ManualId { get; set; }
        public Manual Manuals { get; set; }

        public int KeyId { get; set; }
        public Key Keys { get; set; }
        public int KeyNumber { get; set; }
    }
}
