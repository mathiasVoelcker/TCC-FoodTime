using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTime.WebApi.Models
{
    public class AvaliacaoModel //model que recebe avaliacao de fronEnd
    {
        public AvaliacaoModel(int nota, decimal precoMedio, string comentario, string fotoAvaliacao, bool recomendado, DateTime dataAvaliacao, int idUsuario, int idEstabelecimento)
        {
            Nota = nota;
            PrecoMedio = precoMedio;
            Comentario = comentario;
            FotoAvaliacao = fotoAvaliacao;
            Recomendado = recomendado;
            DataAvaliacao = dataAvaliacao;
            IdUsuario = idUsuario;
            IdEstabelecimento = idEstabelecimento;
        }

        //public int Id { get; set; }
        public int Nota { get; set; }
        public decimal PrecoMedio { get; set; }
        public string Comentario { get; set; }
        public string FotoAvaliacao { get; set; }
        public bool Recomendado { get; private set; }
        public DateTime DataAvaliacao { get; private set; }
        public int IdUsuario { get; set; }
        public int IdEstabelecimento { get; set; }
    }
}