using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTime.WebApi.Models
{
    public class AvaliacaoModel //model que recebe avaliacao de fronEnd
    {
        //public int Id { get; set; }
        public int Nota { get; set; }
        public decimal PrecoMedio { get; set; }
        public string Comentario { get; set; }
        public string FotoAvaliacao { get; set; }
        public bool Recomendado { get; private set; }
        public DateTime DataAvaliacao { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstabelecimento { get; set; }
    }
}