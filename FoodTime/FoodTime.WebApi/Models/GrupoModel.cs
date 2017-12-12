using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTime.WebApi.Models
{
    public class GrupoModel
    {
        public string Nome { get; set; }
        public string Foto { get; set; }
        public List<int> IdUsuarios { get; set; }
    }
}