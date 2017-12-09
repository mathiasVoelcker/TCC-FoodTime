using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTime.WebApi.Models
{
    public class EstabelecimentoRecomendacao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int IdEndereco{ get; set; }
        public List<int> IdCategorias{ get; set; }
        public List<int> Fotos { get; set; }
        public DateTime HorarioAbertura { get; set; }
        public DateTime HorarioFechamento { get; set; }
        public decimal PrecoMedio { get; set; }

        public decimal NotaMedia { get; set; }
        public decimal Relevancia { get; set; }

    }
}