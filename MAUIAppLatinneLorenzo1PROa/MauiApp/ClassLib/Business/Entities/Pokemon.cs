using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Business.Entities
{
    public class Pokemon
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Image => $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{Id}.png";
    }
}
