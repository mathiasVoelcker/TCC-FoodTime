using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTime.WebApi.Models
{
    public class EstabelecimentoFiltroLocalModel
    {
        public string nome { get; set; }
        public decimal latitude{ get; set; }
        public decimal longitude { get; set; }
        public List<String> categorias { get; set; }
    }
}