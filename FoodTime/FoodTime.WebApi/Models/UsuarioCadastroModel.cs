using FoodTime.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTime.WebApi.Models
{
    //model para retornar usuário para o front-end
    public class UsuarioCadastroModel
    {
        public UsuarioCadastroModel(string email, string senha, string nome, string sobrenome, string fotoPerfil, DateTime dataNascimento, bool admin, List<int> idsPreferencias)
        {
            Email = email;
            Senha = senha;
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
            FotoPerfil =fotoPerfil;
            Admin = admin;
            IdsPreferencias = new List<int>();
            IdsPreferencias = idsPreferencias;
        }

        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string FotoPerfil { get; set; }
        public bool Admin { get; set; }
        public List<int> IdsPreferencias { get; set; }
    }
}