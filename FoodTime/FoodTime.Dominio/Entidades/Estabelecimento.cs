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

        public Estabelecimento(string nome, string telefone, Endereco endereco, List<Categoria> categorias, DateTime horaAbertura, DateTime horaFechamento, decimal precoMedio, List<Foto> fotos, bool aprovado)
        {
            Nome = nome;
            Telefone = telefone;
            Endereco = endereco;
            Categorias = categorias;
            HorarioAbertura = horaAbertura;
            HorarioFechamento = horaFechamento;
            PrecoMedio = precoMedio;
            Fotos = fotos;
            Aprovado = aprovado;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public Endereco Endereco { get; private set; }
        public List<Categoria> Categorias { get; private set; }
        public List<Foto> Fotos { get; private set; }
        public DateTime HorarioAbertura { get; private set; }
        public DateTime HorarioFechamento { get; private set; }
        public decimal PrecoMedio { get; private set; }
        public bool Aprovado { get; private set; }

        public bool EstaAberto(DateTime horarioAtual)
        {
            var diff = HorarioAbertura.TimeOfDay - horarioAtual.TimeOfDay;
            if (diff.Ticks > 0)
                return false;
            diff = HorarioFechamento.TimeOfDay - horarioAtual.TimeOfDay;
            if (diff.Ticks < 0)
                return false;
            return true;
        }

        public decimal DistanciaCoeficiente(decimal latitude, decimal longitude)
        {
            var x = Math.Pow((double)(latitude - Endereco.Latitude), 2.0);
            var y = Math.Pow((double)(longitude- Endereco.Longitude), 2.0);
            var distancia = (decimal)Math.Sqrt(x + y);
            return ((402.5m - distancia) / 402.5m);
        }

        public decimal DistanciaEstabelecimento(decimal latitude, decimal longitude)
        {
            var x = Math.Pow((double)(latitude - Endereco.Latitude), 2.0);
            var y = Math.Pow((double)(longitude - Endereco.Longitude), 2.0);
            return (decimal)Math.Sqrt(x + y);
        }

        public List<string> ValidarEntrada()
        {
            List<string> mensagens = new List<string>();

            if (string.IsNullOrEmpty(Nome))
                mensagens.Add("Nome não pode ser nulo.");

            if (Nome.Length>100)
                mensagens.Add("Tamanho máximo 100 caracteres.");

            if (string.IsNullOrEmpty(Telefone))
                mensagens.Add("Telefone não pode ser nulo.");

            if (Telefone.Length > 20)
                mensagens.Add("Tamanho máximo 20 caracteres.");

            if (Endereco==null)
                mensagens.Add("Deve conter um Endereço atrelado ao Estabelecimento.");

            if (Fotos==null)
                mensagens.Add("A Lista de Fotos não pode ser nula.");

            if (Categorias == null)
                mensagens.Add("A Lista de Categorias não pode ser nula.");

            if (HorarioAbertura == null)
                mensagens.Add("Horario de abertura não pode ser nulo.");

            if (HorarioFechamento == null)
                mensagens.Add("Horario de fechamento não pode ser nulo.");

            if (PrecoMedio==0)
                mensagens.Add("O Estabelecimento deve conter um preço médio.");

            return mensagens;
        }

        public bool CompareNome(string nomeComp)
        {
            var nomeEstab = Nome.ToUpper();
            return nomeEstab.Contains(nomeComp.ToUpper());
        }
    }
}
