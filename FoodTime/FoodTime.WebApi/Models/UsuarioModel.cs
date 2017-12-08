using FoodTime.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTime.WebApi.Models
{
    //model para retornar usuário para o front-end
    public class UsuarioModel
    {
        public UsuarioModel(Usuario usuario)
        {
            Id = usuario.Id;
            Email = usuario.Email;
            Nome = usuario.Nome;
            Sobrenome = usuario.Sobrenome;
            DataNascimento = usuario.DataNascimento;
            FotoPerfil = usuario.FotoPerfil;
            Admin = usuario.Admin;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string FotoPerfil { get; set; }
        public bool Admin { get; set; }
    }
}