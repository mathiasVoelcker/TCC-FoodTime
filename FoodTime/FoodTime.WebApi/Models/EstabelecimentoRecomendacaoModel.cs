using FoodTime.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTime.WebApi.Models
{
    public class EstabelecimentoRecomendacaoModel
    {

        public EstabelecimentoRecomendacaoModel(Estabelecimento estabelecimento)
        {
            Id = estabelecimento.Id;
            Nome = estabelecimento.Nome;
            Telefone = estabelecimento.Telefone;
            IdEndereco = estabelecimento.Endereco.Id;
            HorarioAbertura = estabelecimento.HorarioAbertura;
            HorarioFechamento = estabelecimento.HorarioFechamento;
            PrecoMedio = estabelecimento.PrecoMedio;
            Categorias = estabelecimento.Categorias.Select(x => x.Descricao).ToList();
            Fotos = estabelecimento.Fotos.Select(x => x.Caminho).ToList();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int IdEndereco{ get; set; }
        public List<String> Categorias{ get; set; }
        public List<String> Fotos { get; set; }
        public DateTime HorarioAbertura { get; set; }
        public DateTime HorarioFechamento { get; set; }
        public decimal PrecoMedio { get; set; }

        public decimal Relevancia { get; set; }

        public void setRelevancia(decimal preferenciasCorrespondencias, decimal notaMedia, decimal distancia)
        {
            Relevancia = (preferenciasCorrespondencias + notaMedia + (100 * distancia)) / 102;
        }
    }
}