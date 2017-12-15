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
        public List<int> IdCategorias { get; set; }
        public List<string> Fotos { get; set; }
        public decimal PrecoMedio { get; set; }
        public DateTime HorarioAbertura { get; set; }
        public DateTime HorarioFechamento { get; set; }
        public Endereco Endereco { get; set; }
        public List<int> IdPreferencias { get; set; }
        public bool Aprovado { get; set; }
    }
}
