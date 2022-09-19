using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator_18___Tema_Optionala.Models
{
    internal class Key
    {
        public int Id { get; set; }
        public Guid Barcode { get; set; }
        public Vehicle Vehicles { get; set; }
    }
}
