using ClassLib.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppLorenzo.Models
{
    public class PokemonListResponse
    {
        public List<PokemonApiItem> Results { get; set; }
    }
}
