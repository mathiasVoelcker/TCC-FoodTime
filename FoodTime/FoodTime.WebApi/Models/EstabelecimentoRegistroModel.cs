using FoodTime.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTime.WebApi.Models
{
    public class EstabelecimentoRegistroModel
    {

        public string Nome { get; set; }
        public string Telefone { get; set; }
        public List<int> idCategorias { get; set; }
        public List<int> idFotos { get; set; }
        public decimal PrecoMedio { get; set; }
        public DateTime HorarioAbertura { get; set; }
        public DateTime HorarioFechamento { get; set; }
        public Endereco Endereco { get; set; }
        public bool Aprovado { get; set; }
    }
}
