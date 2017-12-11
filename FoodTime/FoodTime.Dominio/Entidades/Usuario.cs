using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Dominio.Entidades
{
    public class Usuario
    {
        public Usuario(string email, string senha, string nome, string sobrenome, string fotoPerfil, DateTime dataNascimento, bool admin, List<Preferencia> preferencias, List<Estabelecimento> estabelecimentos)
        {
            Email = email;
            Senha = senha;
            Nome = nome;
            Sobrenome = sobrenome;
            FotoPerfil = fotoPerfil;
            DataNascimento = dataNascimento;
            Admin = admin;
            Preferencias = preferencias;
            Senha = CriptografarSenha(senha);
            Estabelecimento = new List<Estabelecimento>();
        }

        protected Usuario()
        {
        }

        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Sobrenome { get; private set; }
        public string FotoPerfil { get; private set; }
        public bool Admin { get; private set; }
        public List<Preferencia> Preferencias { get; private set; }
        public List<Estabelecimento> Estabelecimento { get; private set; }

        public bool ValidarSenha(string senha)
        {
            return CriptografarSenha(senha) == Senha;
        }

        private string CriptografarSenha(string senha)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.Default.GetBytes(Email + senha);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("x2"));

            return sb.ToString();
        }

        public List<string> ValidarEntrada()
        {
            List<string> mensagens = new List<string>();

            if (string.IsNullOrWhiteSpace(Email))
                mensagens.Add("Email não pode ser nulo.");

            if (string.IsNullOrWhiteSpace(Senha))
                mensagens.Add("Senha não pode ser nula.");

            if (string.IsNullOrWhiteSpace(Nome))
                mensagens.Add("Nome não pode ser nulo.");

            if (string.IsNullOrWhiteSpace(Sobrenome))
                mensagens.Add("Sobrenome não pode ser nulo.");

            return mensagens;
        }

    }
}
