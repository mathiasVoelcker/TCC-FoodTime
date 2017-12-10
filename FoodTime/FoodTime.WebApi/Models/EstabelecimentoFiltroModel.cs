using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTime.WebApi.Models
{
    public class EstabelecimentoFiltroModel
    {
        public string endereco { get; set; }
        public string nome { get; set; }
        public List<String> categorias { get; set; }
    }
}