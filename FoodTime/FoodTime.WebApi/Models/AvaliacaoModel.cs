using FoodTime.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTime.WebApi.Models
{
    public class AvaliacaoModel //model que recebe avaliacao de fronEnd
    {
        public AvaliacaoModel(Avaliacao avaliacao)
        {
            Nota = avaliacao.Nota;
            PrecoMedio = avaliacao.PrecoMedio;
            Comentario = avaliacao.Comentario;
            FotoAvaliacao = avaliacao.FotoAvaliacao;
            Recomendado = avaliacao.Recomendado;
            IdUsuario = avaliacao.Usuario.Id;
            IdEstabelecimento = avaliacao.Estabelecimento.Id;
        }

        public AvaliacaoModel()
        {

        }

        //public int Id { get; set; }

        public int Nota { get; set; }
        public decimal PrecoMedio { get; set; }
        public string Comentario { get; set; }
        public string FotoAvaliacao { get; set; }
        public bool Recomendado { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstabelecimento { get; set; }
    }
}