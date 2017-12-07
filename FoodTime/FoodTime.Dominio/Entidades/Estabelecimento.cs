using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Dominio.Entidades
{
    public class Estabelecimento
    {

        protected Estabelecimento()
        {
        }

        protected Estabelecimento(string nome, string telefone, int idEndereco, EstabelecimentoCategoria categoria, DateTime horaAbertura, DateTime horaFechamento, decimal precoMedio, List<EstabelecimentoFotos> fotos, List<EstabelecimentoPreferencias> preferencias)
        {
            Nome = nome;
            Telefone = telefone;
            IdEndereço = idEndereco;
            Categoria = categoria;
            HorarioAbertura = horaAbertura;
            HorarioFechamento = horaFechamento;
            PrecoMedio = precoMedio;
            Fotos = fotos;
            Preferencias = preferencias;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public int IdEndereço { get; private set; }
        public EstabelecimentoCategoria Categoria { get; private set; }
        public List<EstabelecimentoFotos> Fotos { get; private set; }
        public List<EstabelecimentoPreferencias> Preferencias { get; private set; }
        public DateTime HorarioAbertura { get; private set; }
        public DateTime HorarioFechamento { get; private set; }
        public decimal PrecoMedio { get; private set; }

   


        public List<string> ValidarEntrada()
        {
            List<string> mensagens = new List<string>();

            if (string.IsNullOrEmpty(Nome))
                mensagens.Add("Nome não pode ser nulo.");

            if (string.IsNullOrEmpty(Telefone))
                mensagens.Add("Telefone não pode ser nulo.");

            if (IdEndereço==0)
                mensagens.Add("Deve conter um Endereço atrelado ao Estabelecimento");

            if (Categoria==null)
                mensagens.Add("Categoria não pode ser nulo.");

            if (HorarioAbertura == null)
                mensagens.Add("Horario de abertura não pode ser nulo.");

            if (HorarioFechamento == null)
                mensagens.Add("Horario de fechamento não pode ser nulo.");

            if (PrecoMedio==0)
                mensagens.Add("O Estabelecimento deve conter um preço médio");

            return mensagens;
        }

    }
}
