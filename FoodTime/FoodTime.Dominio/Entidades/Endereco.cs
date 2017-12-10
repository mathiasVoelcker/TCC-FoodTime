using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Dominio.Entidades
{
    public class Endereco
    {
        public Endereco(string rua, string numero, string apto, string complemento, string bairro, string cidade, string estado, string cep, decimal latitude, decimal longitude)
        {
            Rua = rua;
            Numero = numero;
            Apto = apto;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
            Latitude = latitude;
            Longitude = longitude;
        }

        protected Endereco()
        {
        }

        public int Id { get; private set; }
        public string Rua { get; private set; }
        public string Numero { get; private set; }
        public string Apto { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string CEP { get; private set; }
        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }


        public List<string> ValidarEntrada()
        {
            List<string> mensagens = new List<string>();

            if (string.IsNullOrEmpty(Rua))
                mensagens.Add("Rua não pode ser nula.");

            if (Rua.Length>50)
                mensagens.Add("Tamanho máximo 50 caracteres.");

            if (string.IsNullOrEmpty(Numero))
                mensagens.Add("Numero não pode ser nulo.");

            if (Numero.Length > 20)
                mensagens.Add("Tamanho máximo 20 caracteres.");

            if (Apto.Length > 20)
                mensagens.Add("Tamanho máximo 20 caracteres.");

            if (Complemento.Length > 50)
                mensagens.Add("Tamanho máximo 50 caracteres.");

            if (string.IsNullOrEmpty(Bairro))
                mensagens.Add("Bairro não pode ser nulo.");

            if (Bairro.Length > 50)
                mensagens.Add("Tamanho máximo 50 caracteres.");

            if (string.IsNullOrEmpty(Cidade))
                mensagens.Add("Cidade não pode ser nula.");

            if (Cidade.Length > 50)
                mensagens.Add("Tamanho máximo 50 caracteres.");

            if (string.IsNullOrEmpty(Estado))
                mensagens.Add("Estado não pode ser nulo.");

            if (Estado.Length > 50)
                mensagens.Add("Tamanho máximo 50 caracteres.");

            if (string.IsNullOrWhiteSpace(CEP) || CEP.Contains(" "))
                mensagens.Add("CEP não pode ser nulo ou conter espaços.");

            if (CEP.Length > 8)
                mensagens.Add("Tamanho máximo 8 caracteres.");

            if (Latitude==0)
                mensagens.Add("Latitude não pode ser nula.");

            if (Longitude == 0)
                mensagens.Add("Longitude não pode ser nula.");


            return mensagens;
        }

        public bool Comparar(string endereco)
        {
            var enderecoString = Rua + " " + Numero + " " + Apto + " " + Complemento + " " + Bairro + " " + Cidade + " " + Estado + " " + CEP;
            enderecoString = enderecoString.ToUpper();
            endereco = endereco.ToUpper();
            return enderecoString.Contains(endereco);
        }
    }
}
