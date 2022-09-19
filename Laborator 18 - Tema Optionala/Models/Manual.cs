using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator_18___Tema_Optionala.Models
{
    internal class Manual
    {
        public int Id { get; set; }
        public int CylinderCapacity { get; set; }
        public int ManufactureYear { get; set; }
        public string ChassisNumber { get; set; }
        public Vehicle Vehicles { get; set; }
    }
}
