using FoodTime.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTime.WebApi.Models
{
    public class EstabelecimentoMapaModel
    {
        public EstabelecimentoMapaModel(Estabelecimento estabelecimento)
        {
            Nome = estabelecimento.Nome;
            Telefone = estabelecimento.Telefone;
            Endereco = estabelecimento.Endereco;
            PrecoMedio = estabelecimento.PrecoMedio;
            Categorias = estabelecimento.Categorias.Select(x => x.Descricao).ToList();
            Fotos = estabelecimento.Fotos.Select(x => x.Caminho).ToList();
            Avaliacoes = new List<Avaliacao>();
        }

        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
        public List<String> Categorias { get; set; }
        public List<String> Fotos { get; set; }
        public decimal PrecoMedio { get; set; }

        public bool EstaAberto { get; set; }
        public decimal MediaAvaliacoes { get; set; }
        public int NumAvaliacoes { get; set; }
        public List<Avaliacao> Avaliacoes { get; set; }
    }
}