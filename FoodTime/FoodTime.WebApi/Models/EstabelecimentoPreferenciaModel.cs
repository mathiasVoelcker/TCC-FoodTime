using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTime.WebApi.Models
{
    public class EstabelecimentoPreferenciaModel
    {
        public int IdEstabelecimento { get; set; }
        public int IdPreferencia { get; set; }
        public bool Aprovado { get; set; }
    }
}